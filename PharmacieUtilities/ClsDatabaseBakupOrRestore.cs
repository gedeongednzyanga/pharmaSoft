using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacieUtilities
{
    public class ClsDatabaseBakupOrRestore
    {
        private static string backupPath = "";
        public String getBackupPath(RadioButton rb, TextBox txt)
        {
            if (rb.Checked == true)
            {
                backupPath = ClsConstantes.Table.cheminBackup;
                try
                {
                    if (Directory.Exists(backupPath))
                    {
                        return backupPath;
                    }
                    DirectoryInfo di = Directory.CreateDirectory(backupPath);
                    backupPath = di.FullName;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                backupPath = txt.Text;
            }
            return backupPath;
        }
    }
}
