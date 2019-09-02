using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Classes
{
    class TriClasse : System.Collections.IComparer
    {
        public static TriClasse _instance=null;
       

        private static int sortOrderModifier = 1;
        public TriClasse(SortOrder sortOder)
        {
            if (sortOder == SortOrder.Descending)
            {
                sortOrderModifier = 1;
            }
            else if (sortOder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
        }
        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            int compareResult = System.String.Compare(DataGridViewRow1.Cells[1].Value.ToString(),
                DataGridViewRow2.Cells[1].Value.ToString());
            if (compareResult == 0)
            {
                compareResult = System.String.Compare(DataGridViewRow1.Cells[0].Value.ToString(),
                    DataGridViewRow2.Cells[0].Value.ToString());
            }
            return compareResult * sortOrderModifier;
        }
    }
}
