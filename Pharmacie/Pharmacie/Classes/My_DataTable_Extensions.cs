using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Classes
{
    public static class My_DataTable_Extensions
    {
       
        public static void ExportToExcel(this DataTable tbl, string excelFilePath = null)
        {
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("Eport to Excel : Null or empty input table !\n");
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = excelApp.ActiveSheet;
                for (var i =0; i < tbl.Rows.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        worksheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved");
                    } catch (Exception ex) {
                        throw new Exception("Export to Excel : Excel file could not be saved! Check filepath.\n" + ex.Message);
                    }
                }
                else {
                    excelApp.Visible = true;
                }
            }catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
