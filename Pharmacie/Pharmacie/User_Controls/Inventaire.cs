using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacie.Classes;
using ProduitLib;
using System.Threading;
//using iTextSharp.text
//using iTextSharp.text.pdf
//using Microsoft.Office.Interop.Excel;
using DGVPrinterHelper;

namespace Pharmacie.User_Controls
{
    public partial class Inventaire : UserControl
    {
        //int t1 = 13;
        int code_prod;
        int i;
        string dosage, forme;
        double pu, pt;
        DateTime expiration;
        public Inventaire()
        {
            InitializeComponent();
        }
        
        void Load_Product ()
        {
            dataGridView1.DataSource = DynamicClasses.GetInstance().Load_data("Affichage_Produit_Pv_Dexpir");
        }
        void clic_grid()
        {
            try
            {
                int i;
                i = dataGridView1.CurrentRow.Index;
                code_prod = Convert.ToInt32(dataGridView1["Numéro", i].Value.ToString());
                lab_designation.Text = dataGridView1["Produit", i].Value.ToString();
                expiration =Convert.ToDateTime(dataGridView1["D. Expiration", i].Value.ToString());
                dosage = dataGridView1["Dosage", i].Value.ToString();
                forme = dataGridView1["Forme", i].Value.ToString();
                lab_stock.Text = dataGridView1["Stock", i].Value.ToString();
                pu = Convert.ToDouble(dataGridView1["Pu", i].Value.ToString());
                pt = Convert.ToDouble(dataGridView1["PT", i].Value.ToString());
                // Get_Detail_Approv(new Detail_Approv());
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de faire l'inventaire pour ce produit !!!", "Message...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        struct DataParameter
        {
            public int progress;
            public int delay;
        }
        private DataParameter _inputparameter;
        //struct DataParameter
        //{
        //    public DataTable dt;
        //    public string filename { get; set; }
        //}
        //DataParameter _inputParameter;




        private void Inventaire_Load(object sender, EventArgs e)
        {
            Load_Product();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void Qte_physique_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Qte_physique.Text)){
                    Qte_physique.Text = "0";
                }
                else {
                    if (int.Parse(lab_stock.Text) < int.Parse(Qte_physique.Text))
                    {
                        lab_ecart.Text = (int.Parse(Qte_physique.Text) - int.Parse(lab_stock.Text)).ToString();
                    }
                    else { lab_ecart.Text = (int.Parse(lab_stock.Text) - int.Parse(Qte_physique.Text)).ToString(); }
                } 
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Qte_physique_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Report";
                printer.SubTitle = string.Format("Date :{0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = true;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Go down";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView2);

            }catch(Exception ex)
            {
                MessageBox.Show("Erreur " + ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            clic_grid();
        }
        void ExportExcel()
        {
            DataTable dt = new DataTable();
            while (dt.Columns.Count < dataGridView2.Columns.Count)
            {
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    dt.Columns.Add(col.HeaderText.ToString());
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                DataRow drow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    drow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(drow);
            }
            string ExcelPath = "Excel.xlsx";
            dt.ExportToExcel(ExcelPath);
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progress = ((DataParameter)e.Argument).progress;
            int delay = ((DataParameter)e.Argument).delay;
            int idex = 1;
            try
            {
                for (int i = 0; i < progress; i++)
                {
                    backgroundWorker.ReportProgress(idex++ * 100 / progress, string.Format("Progress data {0}", i));
                    Thread.Sleep(delay);
                }
                ExportExcel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //List<string> list = ((DataParameter)e.Argument).listeproduit;
            //string filename = ((DataParameter)e.Argument).filename;
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            //Worksheet ws = (Worksheet)excel.ActiveSheet;
            //excel.Visible = false;
            //int index = 1;
            //int process = list.Count();
            //ws.Cells[index, 1] = "ID";
            //ws.Cells[index, 2] = "Designation";
            //ws.Cells[index, 3] = "Dosage";
            //ws.Cells[index, 4] = "Forme";
            //ws.Cells[index, 5] = "Quantité";
            //ws.Cells[index, 6] = "Categorie";
            //ws.Cells[index, 7] = "Categorie";
            //ws.Cells[index, 8] = "Categorie";
            ////foreach (produit p in list)
            //{
            //    if (!backgroundWorker.CancellationPending)
            //    {
            //        backgroundWorker.ReportProgress(index++ * 100 / process);
            //        ws.Cells[index, 1] = p.idproduit.ToString();
            //        ws.Cells[index, 2] = p.designationprod;
            //        ws.Cells[index, 3] = p.dosage;
            //        ws.Cells[index, 4] = p.forme;
            //        ws.Cells[index, 5] = p.quatitestock;
            //        ws.Cells[index, 6] = p.designationprod;
            //        ws.Cells[index, 7] = p.designationprod;
            //        ws.Cells[index, 8] = p.designationprod;

            //    }
            //}
            //ws.SaveAs(filename, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            //excel.Quit();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labStatus.Text = string.Format("Processing...{0}", e.ProgressPercentage);
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Thread.Sleep(100);
                labStatus.Text = "Your data has been successfully exported";
            }
        }


        void ExportToPDF (DataTable dt)
        {
          //  Document
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //while (dt.Columns.Count < dataGridView2.Columns.Count)
            //{
            //    foreach (DataGridViewColumn col in dataGridView2.Columns)
            //    {
            //        dt.Columns.Add(col.HeaderText.ToString());
            //    }
            //}

            //foreach (DataGridViewRow  row in dataGridView2.Rows)
            //{
            //    DataRow drow = dt.NewRow();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        drow[cell.ColumnIndex] = cell.Value;
            //    }
            //    dt.Rows.Add(drow);
            //}
            //string ExcelPath = "Excel.xlsx";
            //dt.ExportToExcel(ExcelPath);

            _inputparameter.delay = 10;
            _inputparameter.progress = 1200;
            backgroundWorker.RunWorkerAsync(_inputparameter);



            //if (backgroundWorker.IsBusy)
            //    return;
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //       // _inputParameter.filename = sfd.FileName;
            //       // _inputParameter.listeproduit = dataGridView2.DataSource as List<string>;
            //        progressBar1.Minimum = 0;
            //        progressBar1.Value = 0;
            //        backgroundWorker.RunWorkerAsync(_inputparameter);
            //    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.Sort(new TriClasse(SortOrder.Ascending));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(i + 1, lab_designation.Text.Trim(), dosage, forme,lab_stock.Text.Trim(), Qte_physique.Text.Trim(),
                lab_ecart.Text.Trim(), pu, pt, expiration.ToShortDateString());
            i = i + 1;
        }
    }
}
