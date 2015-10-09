using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MakeCPUFullUse {
    public partial class Form1 : Form {
        private readonly PerformanceCounter _cpuCounter;
        private const string CPUUseInfo = "CPU:{0:F2}%, {1:F2}PB per sec.";
        private readonly List<Thread> _threadList = new List<Thread>();
        private long _calcCnt;
        private int[] _origPrsThdIds; //Original Process threads id collection.

        /// <summary>
        /// Show CPU Info in the title
        /// </summary>
        private readonly Action ShowInfo;

        public Form1() {
            InitializeComponent();

            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            ShowInfo = () => {
                this.Text = string.Format(CPUUseInfo, _cpuCounter.NextValue(), (float)( _calcCnt / 1048576.0 ));
            };
        }

        //Calculate 1024 times.
        private long BatchCalculate() {
            const long range = 1024;

            for (long i = 0; i < range; i++)
                Math.Sin(Math.PI);

            return range;
        }

        private void AutoAllocationCPU() {
            IEnumerable<ProcessThread> calcThreads = Process.GetCurrentProcess().Threads.Cast<ProcessThread>()
                                                            .Where(thd => !_origPrsThdIds.Any(origId => origId == thd.Id));

            double pow = 0;
            int count = 1;
            foreach (ProcessThread calcThread in calcThreads) {
                calcThread.ProcessorAffinity = (IntPtr)(Int16)( Math.Pow(2.0, pow++) );

                if (count < Environment.ProcessorCount) {
                    count++;
                }
                else {
                    pow = 0;
                    count = 1;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            ShowInfo();
            numThreadCount.Value = Environment.ProcessorCount;
            timer1.Enabled = true;

            //Init Original Process threads id collection.
            _origPrsThdIds = Process.GetCurrentProcess().Threads.Cast<ProcessThread>().Select(thd => thd.Id).ToArray();

            numThreadCount.Select(0, numThreadCount.Value.ToString().Length);
        }

        private void btnStart_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < numThreadCount.Value; i++) {
                Thread t = new Thread(() => {
                    while (true)
                        Interlocked.Add(ref _calcCnt, BatchCalculate());
                });

                t.Priority = ThreadPriority.BelowNormal;
                _threadList.Add(t);
            }

            btnStart.Enabled
                = numThreadCount.Enabled
                  = false;

            foreach (Thread t in _threadList)
                t.Start();

            AutoAllocationCPU();
        }

        private void btnStop_Click(object sender, EventArgs e) {
            foreach (Thread t in _threadList)
                t.Abort();
            _threadList.Clear();

            _calcCnt = 0;
            this.Cursor = Cursors.Default;
            btnStart.Enabled
                = numThreadCount.Enabled
                  = true;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            ShowInfo();
            _calcCnt = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            foreach (Thread t in _threadList)
                t.Abort();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            const int WM_KEYDOWN = 256;
            const int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN) {
                if (keyData == Keys.Escape) {
                    this.Close();
                    return false;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
