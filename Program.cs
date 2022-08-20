using System;

namespace jeu_du_pendu
{
    public class Program
    {
        public const string FILE_PATH = @"/Users/romaincs/Workspace/jeu_du_pendu/liste_mots.txt";

        public static void Main(string[] args)
        {
            string? recommencer = "o";
            while (recommencer == "o")
            {
                List<string> mots = RecupererListeMots(FILE_PATH);
                Pendu pendu = new(mots);

                while (true)
                {
                    Console.Clear();
                    string dessin = pendu.RecupererAscii();
                    Console.WriteLine(dessin + "\n\n");

                    if(pendu.Termine)
                    {
                        FinDeLaPartie(pendu);
                        break;
                    }

                    string lettresTrouves = pendu.RecupererLettresTrouves();
                    Console.WriteLine(lettresTrouves + "\n\n");

                    try
                    {
                        string lettre = SaisissezUneLettre();
                        pendu.NouvelEssai(lettre);
                    }
                    catch
                    {
                        Console.WriteLine("Vous devez saisir une lettre");
                    }
                }

                Console.Write("Nouvelle parties (o/n) ? ");
                recommencer = Console.ReadLine();

            }            
        }

        public static List<string> RecupererListeMots(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines.ToList<string>();
            
        }

        public static void FinDeLaPartie(Pendu pendu)
        {
            if (pendu.Gagne)
                Console.WriteLine("Bravo ! Vous avez gagné !");
            if (pendu.Perdu)
                Console.WriteLine("Désolé, vous avez perdu :-(");

            Console.WriteLine("Le mot a trouvé était: " + pendu.Mot);
        }

        public static string SaisissezUneLettre()
        {
            Console.Write("Saisissez une lettre: ");
            string? lettre = Console.ReadLine();
            if (string.IsNullOrEmpty(lettre) || lettre.Length != 1)
                throw new Exception();

            return lettre;
        }
    }
}