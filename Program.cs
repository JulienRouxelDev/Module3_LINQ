using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_LINK
{
   

    class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();

            // Liste prénoms auteurs commencant par G
            var auteurCommencantParG = ListeAuteurs.Where(a => a.Nom.Substring(0,1) == "G");

            Console.WriteLine("Liste prénoms auteurs commencant par G");
            foreach (var a in auteurCommencantParG)
            {
                Console.WriteLine(a.Prenom);
            }

            // Auteur ayant écrit le plus de livres
            var auteurs = ListeLivres.GroupBy(
                l => l.Auteur,
                (baseId, ids) => new
                {
                    Key = baseId,
                    Count = ids.Count()
                }) ;

            Console.WriteLine();
            Console.WriteLine("Auteur ayant écrit le plus de livres");
            
            foreach (var a in auteurs)
            {
                Console.WriteLine(a.Key.Nom);
                Console.WriteLine(a.Count);
            }


            //Nombre moyen de pages par auteurs
            //var pagesParAuteur = ListeLivres.GroupBy(
            //    l => l.Auteur,
            //    (basePage, pages) => new
            //    {
            //        Key = basePage,
            //        Min = pages.Min()
            //    });

            //Console.WriteLine();
            //Console.WriteLine("Nombre de pages myen par auteur");

            //foreach (var a in pagesParAuteur)
            //{
            //    Console.WriteLine(a.Key.Nom);
            //    Console.WriteLine(a.Min);
            //}

            //Auteur et liste de leurs livres

            Console.WriteLine();
            Console.WriteLine("Auteur et liste de leurs livres");
            foreach (var a in ListeAuteurs)
            {
                var livresAuteurs = ListeLivres.Where(l => l.Auteur == a);
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb = sb.Append(a.Nom).Append(" : ");
                foreach (var l in livresAuteurs)
                {
                    sb = sb.Append(l.Titre).Append("; ");
                }
                Console.WriteLine(sb);
            }



            // Titre de tous les livres triés 
            var livres = ListeLivres.OrderBy(l => l.Titre);

            Console.WriteLine();
            Console.WriteLine("Titres triés par ordre alpha");

            foreach (var l in livres)
            {
                Console.WriteLine(l.Titre);
            }

            // Livres dont le nb de pages est > à la moyenne 
            var listNbPages = ListeLivres.Select(l => l.NbPages);
            
            double nbPagesMoyen = listNbPages.Average();
            
            var livresSupMoyenne = ListeLivres.Where(l => l.NbPages>nbPagesMoyen);

            Console.WriteLine();
            Console.WriteLine("Livres dont le nb de pages est > à la moyenne");

            foreach (var l in livresSupMoyenne)
            {
                Console.WriteLine(l.Titre);
            }
            //Console.WriteLine(nbPagesMoyen);

            Console.ReadKey();
        }
        

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

         
    }
}
