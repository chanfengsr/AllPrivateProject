using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StatisticsCPUUsage.Properties;

namespace StatisticsCPUUsage {
    public partial class Form1 : Form {
        private readonly StringBuilder _sbInfo = new StringBuilder();
        private PerformanceCounter[] _counters;
        private PerformanceCounter _totalCounter;
        private double _allCpuUsage = 0.00001;
        private readonly List<UsageInfo> _lstUsageInfo = new List<UsageInfo>();
        private Int64 _timeElapsed;
        private bool _normalSize = true;
        private int _dynAllocTime;
        private readonly bool _isAutoRun;
        private readonly string _historyRecordFileName;
        
        private Guid _activePolicyGuid;
        private Guid _processSetSubGroupGuid = new Guid(PowerAPI.GUID_PROCESSOR_SETTINGS_SUBGROUP);
        private Guid _processThrottleMinGuid = new Guid(PowerAPI.PROCTHROTTLEMIN);
        private Guid _processThrottleMaxGuid = new Guid(PowerAPI.PROCTHROTTLEMAX);
        private float _curProcessThrottleMax;//Percent

        public Form1(bool isAutoRun) {
            _isAutoRun = isAutoRun;
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.Text = this.Text + "  V" + Application.ProductVersion + "  ——by 巉沨散人";
            
            _historyRecordFileName = Application.StartupPath.TrimEnd('\\') + @"\StatisticsCPUUsage.rcd";
        }

        private void RefreshPerformance(bool refCurUsage) {
            foreach (UsageInfo usageInfo in _lstUsageInfo) {
                float curUsage = _counters[usageInfo.CpuId].NextValue();

                _allCpuUsage += curUsage * _curProcessThrottleMax;
                usageInfo.Usage += curUsage * _curProcessThrottleMax;

                if (refCurUsage)
                    usageInfo.CurrentUsage = curUsage * _curProcessThrottleMax;
            }
        }

        private string FmtFloat(double convValue) {
            string retSub = string.Format("{0:f}", convValue);
            
            return ( new string(' ', 6) + retSub ).Substring(retSub.Length , 6);
        }

        private void ShowCPUUsageInfo() {
            double cpuUsage;

            _sbInfo.Clear();
            foreach (UsageInfo usageInfo in _lstUsageInfo) {
                cpuUsage = 100.0 * usageInfo.Usage / _allCpuUsage;
                _sbInfo.AppendLine(string.Format("CPU-{0}:{1}%  CurUsage:{2}%"
                                                 , usageInfo.CpuId
                                                 , FmtFloat(cpuUsage)
                                                 , FmtFloat(usageInfo.CurrentUsage)));
            }

            _sbInfo.AppendLine();
            _sbInfo.AppendLine(string.Format("Total:{0}%  CurUsage:{1}%"
                                             , FmtFloat(100.0 * _allCpuUsage / ( _timeElapsed * 100 * Environment.ProcessorCount ))
                                             , FmtFloat(_totalCounter.NextValue() * _curProcessThrottleMax)));

            _sbInfo.AppendLine();
            _sbInfo.AppendLine(string.Format("Usage Order: {0}",
                                             _lstUsageInfo.OrderBy(info => info.Usage).Select(info => info.CpuId).Aggregate("", (current, cpuId) => current + cpuId + ",").TrimEnd(',')
                                   ));
            _sbInfo.AppendLine();
            _sbInfo.AppendLine(string.Format("Time Elapsed : {0} {1}:{2}:{3}"
                                             , _timeElapsed / 86400 //天
                                             , _timeElapsed % 86400 / 3600 //时
                                             , _timeElapsed % 3600 / 60 //分
                                             , _timeElapsed % 60)); //秒

            txtCPUUsageInfo.Text = _sbInfo.ToString();
        }

        private void LoadHistoryRecord() {
            if (!File.Exists(_historyRecordFileName))
                return;

            string[] hisRecord = File.ReadAllText(_historyRecordFileName).Split(',');
            if (hisRecord.Length != _lstUsageInfo.Count + 1)
                return;

            try {
                Int64.TryParse(hisRecord[0], out _timeElapsed);
                double parseVal;
                for (int i = 0; i < _lstUsageInfo.Count; i++) {
                    if (double.TryParse(hisRecord[i + 1], out parseVal)) {
                        _lstUsageInfo[i].Usage = parseVal;
                        _allCpuUsage += parseVal;
                    }
                }
            }
            catch (Exception) {}
            finally {
                if (_allCpuUsage == 0)
                    _allCpuUsage = 1;
            }
        }

        private void SaveHistoryRecord(string fileName = "") {
            if (string.IsNullOrEmpty(fileName))
                fileName = _historyRecordFileName;

            StringBuilder sbRecord = new StringBuilder(_timeElapsed.ToString());
            foreach (UsageInfo usageInfo in _lstUsageInfo)
                sbRecord.Append("," + usageInfo.Usage);

            File.WriteAllText(fileName, sbRecord.ToString());
        }

        private void DynamicAllocationCPU(string processName, int useNum) {
            int[] cpuUseFlag = new int[Environment.ProcessorCount];
            string cpuUseFlags = "";
            
            IOrderedEnumerable<UsageInfo> orderInfo = _lstUsageInfo.OrderBy(info => info.Usage);
            foreach (UsageInfo usageInfo in orderInfo)
                if (useNum-- > 0)
                    cpuUseFlag[usageInfo.CpuId] = 1;

            foreach (int flag in cpuUseFlag)
                cpuUseFlags = flag + cpuUseFlags;

            if (cpuUseFlags != "")
                foreach (Process process in Process.GetProcessesByName(processName))
                    process.ProcessorAffinity = (IntPtr)Convert.ToInt16(cpuUseFlags,2);

        }

        private void LoadProcessThrottleSet() {
            uint cpuThrottle = 0;

            PowerAPI.PowerReadACValueIndex(
                IntPtr.Zero,
                ref _activePolicyGuid,
                ref _processSetSubGroupGuid,
                ref _processThrottleMinGuid,
                ref cpuThrottle);
            txtProcThrottleMin.Text = cpuThrottle.ToString();
            
            PowerAPI.PowerReadACValueIndex(
                IntPtr.Zero,
                ref _activePolicyGuid,
                ref _processSetSubGroupGuid,
                ref _processThrottleMaxGuid,
                ref cpuThrottle);
            txtProcThrottleMax.Text = cpuThrottle.ToString();
            _curProcessThrottleMax = (float)cpuThrottle / 100;
        }

        private void SetProcessThrottleMax(uint setValue) {
            PowerAPI.PowerWriteACValueIndex(
                IntPtr.Zero,
                ref _activePolicyGuid,
                ref _processSetSubGroupGuid,
                ref _processThrottleMaxGuid,
                setValue);

            PowerAPI.PowerSetActiveScheme(IntPtr.Zero, ref _activePolicyGuid);
        }

        private void VisibleMainForm() {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            _normalSize = true;
            this.taskIcon.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Icon = Resources.MainIco;
            taskIcon.Text = this.Text;

            _counters = new PerformanceCounter[Environment.ProcessorCount];

            for (int i = 0; i < _counters.Length; i++) {
                _counters[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                _lstUsageInfo.Add(new UsageInfo(i, 0));

                combCpuNum.Items.Add(i + 1);
            }
            _totalCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            combCpuNum.SelectedIndex = _counters.Length - 1;
            LoadHistoryRecord();
            timerRefresh.Enabled = true;

            #region 电源计划

            IntPtr activePolicyGuidPtr = IntPtr.Zero;
            PowerAPI.PowerGetActiveScheme(IntPtr.Zero, ref activePolicyGuidPtr);
            _activePolicyGuid = new Guid(PowerAPI.PtrToStructure(activePolicyGuidPtr).ToString());

            LoadProcessThrottleSet();

            PowerAPI.RegisterPowerSettingNotification(this.Handle, ref _processThrottleMaxGuid, PowerAPI.DEVICE_NOTIFY_WINDOW_HANDLE);

            #endregion 电源计划

            if (_isAutoRun)
                new System.Threading.Thread(
                    () => {
                        System.Threading.Thread.Sleep(50);
                        this.WindowState = FormWindowState.Minimized;
                    }
                    ).Start();
        }

        private void timerRefresh_Tick(object sender, EventArgs e) {
            _timeElapsed++;
            RefreshPerformance(_normalSize);

            if (_normalSize)
                ShowCPUUsageInfo();

            if (_timeElapsed % 300 == 0)
                SaveHistoryRecord();

            if (_timeElapsed % 3600 == 0)
                SaveHistoryRecord(_historyRecordFileName + "_bak");
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized && chkToSystemTray.Checked) {
                this.Hide();
                this.taskIcon.Visible = true;
                _normalSize = false;
            }
        }

        private void taskIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                VisibleMainForm();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            this.SaveHistoryRecord();
        }

        private void btnCopy2Clipboard_Click(object sender, EventArgs e) {
            try {
                Clipboard.SetText(txtCPUUsageInfo.Text);
            }
            catch (Exception) {}
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            const int WM_KEYDOWN = 256;
            const int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN) {
                switch (keyData) {
                    case Keys.Escape:
                        this.WindowState = FormWindowState.Minimized;
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkDynAllocate_CheckedChanged(object sender, EventArgs e) {
            grpDynAllocate.Enabled = chkDynAllocate.Checked;

            timerDynAlloc.Enabled = chkDynAllocate.Checked;
            _dynAllocTime = 0;
        }

        private void btnImmediateAlloc_Click(object sender, EventArgs e) {
            DynamicAllocationCPU(txtProcessName.Text.Trim(), (int)combCpuNum.SelectedItem);
            _dynAllocTime = 0;
        }

        private void timerDynAlloc_Tick(object sender, EventArgs e) {
            _dynAllocTime++;

            if (_dynAllocTime == 300) {
                DynamicAllocationCPU(txtProcessName.Text.Trim(), (int)combCpuNum.SelectedItem);
                _dynAllocTime = 0;
            }
        }

        private void rdoProcessState_CheckedChanged(object sender, EventArgs e) {
            uint setThrottle = uint.Parse(( (RadioButton)sender ).Text);
            SetProcessThrottleMax(setThrottle);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == PowerAPI.WM_POWERBROADCAST) {
                LoadProcessThrottleSet();
                return;
            }

            base.WndProc(ref m);
        }

        protected override void DefWndProc(ref Message m) {
            switch (m.Msg) {
                case GlobalDef.USER:
                    if (!_normalSize) {
                        VisibleMainForm();
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void btnTest_Click(object sender, EventArgs e) {
            double f = 59.26535897936;
            string r = FmtFloat(f);
            return;

            uint cpuThrottleMax = 5;
            uint ret = 0;
            
            ret = PowerAPI.PowerReadACValueIndex(
                IntPtr.Zero,
                ref _activePolicyGuid,
                ref _processSetSubGroupGuid,
                ref _processThrottleMaxGuid,
                ref cpuThrottleMax);

            cpuThrottleMax = 50;
             ret = PowerAPI.PowerWriteACValueIndex(
                IntPtr.Zero,
                ref _activePolicyGuid,
                ref _processSetSubGroupGuid,
                ref _processThrottleMaxGuid,
                 cpuThrottleMax);

            ret = PowerAPI.PowerSetActiveScheme(IntPtr.Zero, ref _activePolicyGuid);
            
            MessageBox.Show(cpuThrottleMax.ToString());
        }
    }
}