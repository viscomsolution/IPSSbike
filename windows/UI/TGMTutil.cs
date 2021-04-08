using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TGMT
{
    class TGMTutil
    {
        public static string CorrectPath(string path)
        {
            if(path[path.Length-1] != '\\')
            {
                path += '\\';
            }
            return path;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void OnlyInputNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            int lastDotIdx = version.LastIndexOf('.');
            return version.Substring(0, lastDotIdx);
        }
    }
}
