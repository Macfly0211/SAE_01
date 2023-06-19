using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_01.Model
{
   
    public class ApplicationData
    {


        public ObservableCollection<Personnel> LesPersonnel { get; set; }
        public ObservableCollection<Materiel> LesMateriel { get; set; }
        public ObservableCollection<CategorieMateriel> LesCategorieMateriel { get; set; }
        public ObservableCollection<EstAttribue> LesAttribution { get; set; }

        public ApplicationData()
        {
            reloadAppData();
        }

        //ReloadData = permet de mettre à jour les données
        public void reloadAppData()
        {
            Personnel p = new Personnel();
            LesPersonnel = p.FindAll();

            Materiel m = new Materiel();
            LesMateriel = m.FindAll();

            CategorieMateriel cm = new CategorieMateriel();
            LesCategorieMateriel = cm.FindAll();

            EstAttribue a = new EstAttribue();
            LesAttribution = a.FindAll();

            //Attribution a un materiel
            foreach (EstAttribue uneAttribution in LesAttribution.ToList())
            {
                uneAttribution.UnMateriel = LesMateriel.ToList().Find(m => m.Idmateriel == uneAttribution.fk_idMateriel);
            }
            //Attribution a un personnel
            foreach (EstAttribue uneAttribution in LesAttribution.ToList())
            {
                uneAttribution.UnPersonnel = LesPersonnel.ToList().Find(p => p.Idpersonnel == uneAttribution.fk_idPerso);
            }

            //Materiel a une Categorie
            foreach (Materiel unMateriel in LesMateriel.ToList())
            {
                unMateriel.UneCategorie = LesCategorieMateriel.ToList().Find(cm => cm.Idcategorie == unMateriel.fk_idcategorie);
            }
            
        }

        
    }
}
