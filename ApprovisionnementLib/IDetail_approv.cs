using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovisionnementLib
{
    public interface IDetail_approv
    {
        int Id { get; set; }
        int Quantite { get; set; }
        decimal Pu { get; set; }
        DateTime DateFabric { get; set; }
        DateTime DateExpiration { get; set; }
        int RefProduit { get; set; }
        int RefApprov { get; set; }
        string Produit { get; set; }
        decimal Pt { get; set; }
        DateTime DateEntree { get; set; }
        int Nouveau();
        void Enregistrer(IDetail_approv approv);
        void Supprimer(int id);
        List<IDetail_approv> Approvisionnements();
        IDetail_approv OneProduiDetail(int id);
    }
}
