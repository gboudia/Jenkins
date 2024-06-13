using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpecFlowBDDCampus.Data
{
    public class Client
    {
        public string Email { get; set; }
        public string MotPasse { get; set; }
        public string ConfirmMotPasse { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string PaysNationnalité { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        //public ProfessionInstitution? institution { get; set; }

        //public class ProfessionInstitution
        //{
        public string Fonction { get; set; }
        public string NomOrganisme { get; set; }

        
    }//

    /*public class ProfessionInstitutionnel
    {
        public string Fonction { get; set; }
        public string NomOrganisme { get; set; }*/
    
}
