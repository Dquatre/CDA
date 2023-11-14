namespace GestionFichier
{
    internal class Program
    {
        public class Personne
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public int Age { get; set; }

            public Personne(string nom, string prenom, int age)
            {
                Nom = nom;
                Prenom = prenom;
                Age = age;
            }
        }
        static void Main(string[] args)
        {
            //String chemin = @"c:\temp\";
            //String texte = "Coucou";
            //String cheminTab = @"c:\temp\";
            //String[] texteTab = { "Coucou","le","Coucou" };
            //String cheminList = @"c:\temp\";
            //List<String> texteList = new List<string>();

            //GestionFichier.CreerFichierTexte(chemin,"Text", texte);
            //GestionFichier.CreerFichierTexte(cheminTab, "TextTab", texteTab);
            //GestionFichier.CreerFichierTexte(cheminList, "TextList", texteList);
            //Console.WriteLine(GestionFichier.LireFichierTexte(@"c:\temp\TextTab.txt"));
            GestionFichier.EcrireFichierJson(@"c:\temp\Personne.json", new Personne("Didolla", "David", 25));

        }
    }
}