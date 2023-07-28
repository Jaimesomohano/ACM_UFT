using Microsoft.Win32;
using System;

namespace APlus_UFT.Library.BaseLibrary
{
    class Registry
    {

        /// <summary>
        /// Registry Editor HKey local Machine
        /// </summary>
        public RegistryKey HKLM
        {
            get
            {
                RegistryKey KeyBase = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                return KeyBase;
            }
        }

        /// <summary>
        /// Registry Editor HKey Current User
        /// </summary>
        public RegistryKey HKCU
        {
            get
            {
                RegistryKey KeyBase = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                return KeyBase;
            }
        }

        public string ACMVersion
        {
            get
            {
                string[] values = null;
                values = HKLM.OpenSubKey(@"Software\AspenTech\AMSystem\CurVer\").GetSubKeyNames();
                foreach (string i in values)
                    if (i != null) return i;

                throw new Exception("No ACM version version found in the registry!");

            }
        }

        /// <summary>
        /// Get Aspen product version by product name. 
        /// e.g. Aspen Plus, Aspen Properties, Aspen Custom Modeler,Aspen Dynamics
        /// </summary>
        public string GetAspenProductVersion(string productName)
        {
            object value = null;
            value = HKLM.OpenSubKey($"Software\\AspenTech\\{productName}\\CurVer\\").GetValue("(Default)");

            if (value == null)
            {
                throw new Exception("No product found in the registry!");
            }
            string v = value.ToString();
            return value.ToString();
        }

        /// <summary>
        /// Get Aspen product version by product name. 
        /// e.g. Aspen Plus, Aspen Properties, Aspen Custom Modeler,Aspen Utilities
        /// </summary>
        public string GetValueData(string productName, string valueName)
        {
            var valueData = HKLM.OpenSubKey($"SOFTWARE\\AspenTech\\{productName}\\" + GetAspenProductVersion(productName) + @"\Dir").GetValue(valueName);
            if (valueData == null)
                throw new Exception("AspenTech has no key value:" + valueName + "for" + productName + "in the registry!");
            return valueData.ToString();
        }

    }
}
