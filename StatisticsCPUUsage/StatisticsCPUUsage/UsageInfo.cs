
namespace StatisticsCPUUsage {
    public class UsageInfo {
        private readonly int _cpuId;
        private double _usage;
        private float _curUsage;

        public UsageInfo(int cpuId, double usage) {
            _cpuId = cpuId;
            _usage = usage;
        }

        public int CpuId {
            get {
                return _cpuId;
            }
        }

        public double Usage {
            get {
                return _usage;
            }
            set {
                _usage = value;
            }
        }

        public float CurrentUsage {
            get {
                return _curUsage;
            }
            set {
                _curUsage = value;
            }
        }
    }
}
