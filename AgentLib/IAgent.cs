using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentLib
{
    public interface IAgent
    {
        int Id { get; set; }
        string Noms { get; set; }
        string Adresse { get; set; }
        string Contact { get; set; }
        string Pseudo { get; set; }
        string PassWord { get; set; }
        string Niveau { get; set; }
        Sexe Sex { get; set; }
        int Nouveau();
        void Enregistrer(IAgent agent);
        void Supprimer(int id);
        List<IAgent> AllAgents();
        IAgent OneAgentDetail(int id);
    }
}
