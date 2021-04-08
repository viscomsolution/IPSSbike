using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TGMT
{
    public class TGMTregistry
    {
        static TGMTregistry m_instance;
        RegistryKey m_regKey;

        public bool Inited { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public TGMTregistry()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static TGMTregistry GetInstance()
        {
            if (m_instance == null)
                m_instance = new TGMTregistry();
            return m_instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init(string key)
        {
            m_regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + key, true);
            if (m_regKey == null)
            {
                Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey(key);
                m_regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\" + key, true);
            }
            Inited = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteKey(string value)
        {
            m_regKey.DeleteValue(value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveRegValue(string key, object value)
        {
            m_regKey.SetValue(key, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ReadRegValueString(string key, string defaultData ="")
        {
            Object data = m_regKey.GetValue(key);
            if (data == null)
                return defaultData;
            else
                return (string)data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ReadRegValueInt(string key, int defaultData = 0)
        {
            Object data = m_regKey.GetValue(key);
            if (data == null)
                return defaultData;
            else
                return (int)data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ReadRegValueBool(string key, bool defaultData = false)
        {
            return ReadRegValueString(key) == "True";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public float ReadRegValueFloat(string key, float defaultData = 0)
        {
            Object data = m_regKey.GetValue(key);
            if (data == null)
                return defaultData;
            else
                return float.Parse((string)data);
        }
    }
}
