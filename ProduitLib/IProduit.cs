using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduitLib
{
    public interface IProduit
    {
        int Id { get; set; }
        string Designation { get; set; }
        string Dosage { get; set; }
        string Forme { get; set; }
        int QteStock { get; set; }
        int Ref_Categ { get; set; }
        string Categorie { get; set; }
        int Nouveau();
        void Enregistrer(IProduit prod);
        void Supprimer(int id);
        List<IProduit> AllProduits();
        IProduit OneProduit(int id);

    }
}
