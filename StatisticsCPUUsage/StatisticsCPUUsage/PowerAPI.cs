using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StatisticsCPUUsage {
    internal class PowerAPI {

        #region API

        /// <summary>
        /// Retrieves the active power scheme and returns a GUID that identifies the scheme.
        /// </summary>
        /// <param name="UserRootPowerKey">[in, optional] This parameter is reserved for future use and must be set to NULL</param>
        /// <param name="ActivePolicyGuid">[out] A pointer that receives a pointer to a GUID structure. Use the LocalFree function to free this memory.</param>
        /// <returns>Returns ERROR_SUCCESS (zero) if the call was successful, and a non-zero value if the call failed.</returns>
        [DllImportAttribute("powrprof.dll", EntryPoint = "PowerGetActiveScheme", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll")]
        public static extern uint PowerSetActiveScheme(IntPtr UserRootPowerKey, ref Guid SchemeGuid);

        [DllImport("powrprof.dll")]
        public static extern uint PowerReadACValueIndex(
            //第一个参数类型HKEY，不知道他是一个干啥用的指针，而且这个API里只能是NULL值，就简单声明为IntPtr类型，使用时传IntPtr.Zero就好了。
            IntPtr RootPowerKey,

            //GUID在C#里有这个Guid类型与之对应。至于一级指针，得看这个指针是干啥用的。
            //如果这个指针只是指向一个变量的话，就用ref修饰，实际传递的就是指针了。
            //如果这个指针指向的是一个数组的首地址，那就先得在C#里分配一段内存，然后把这个内存的地址传进去。参考前面转的博文。
            ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,

            //最后一个参数类型LPDWORD。LP指的是long pointer，好像现在的系统不分长短指针了，就简单把他理解为一个指针吧。那LPDWORD就是一个指向DWORD的指针。对应到C#里就是ref uint了。
            ref uint AcValueIndex
            );

        [DllImport("powrprof.dll")]
        public static extern uint PowerWriteACValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, uint AcValueIndex);

        [DllImport(@"User32", SetLastError = true, EntryPoint = "RegisterPowerSettingNotification", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, uint Flags);
        
        #endregion API

        #region Constant
        
        public const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        public const uint DEVICE_NOTIFY_SERVICE_HANDLE = 1;
        public const int WM_POWERBROADCAST = 536;

        public const string NO_SUBGROUP_GUID = "fea3413e-7e05-4911-9a71-700331f1c294";
        public const string GUID_DISK_SUBGROUP = "0012ee47-9041-4b5d-9b77-535fba8b1442";
        public const string GUID_SYSTEM_BUTTON_SUBGROUP = "4f971e89-eebd-4455-a8de-9e59040e7347";
        public const string GUID_PROCESSOR_SETTINGS_SUBGROUP = "54533251-82be-4824-96c1-47b60b740d00";
        public const string GUID_VIDEO_SUBGROUP = "7516b95f-f776-4464-8c53-06167f40cc99";
        public const string GUID_BATTERY_SUBGROUP = "e73a048d-bf27-4f12-9731-8b2076e8891f";
        public const string GUID_SLEEP_SUBGROUP = "238C9FA8-0AAD-41ED-83F4-97BE242C8F20";
        public const string GUID_PCIEXPRESS_SETTINGS_SUBGROUP = "501a4d13-42af-4429-9fd1-a8218c268e20";

        public const string PROCTHROTTLEMIN = "893dee8e-2bef-41e0-89c6-b55d0929964c";
        public const string PROCTHROTTLEMAX = "bc5038f7-23e0-4960-96da-33abaf5935ec";
        #endregion Constant

        #region API Help

        public static Guid PtrToStructure(IntPtr ptr) {
            return (Guid)Marshal.PtrToStructure(ptr, typeof (Guid));
        }

        #endregion API Help
    }

}