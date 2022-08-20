using System;

namespace jeu_du_pendu
{
    public class Pendu
    {
        private static string[] _PENDU_ASCII = { @"
                  +---+
                  |   |
                      |
                      |
                      |
                      |
                =========",

                @"
                  +---+
                  |   |
                  O   |
                      |
                      |
                      |
                =========",

                @"
                  +---+
                  |   |
                  O   |
                  |   |
                      |
                      |
                =========
                ",
                @"
                  +---+
                  |   |
                  O   |
                 /|   |
                      |
                      |
                =========
                ",
                @"
                  +---+
                  |   |
                  O   |
                 /|\  |
                      |
                      |
                =========
                ",
                @"
                  +---+
                  |   |
                  O   |
                 /|\  |
                 /    |
                      |
                =========
                ",
                @"
                  +---+
                  |   |
                  O   |
                 /|\  |
                 / \  |
                      |
                =========
                "
            };
        private string _mot;
        private List<char> _lettresTrouves = new List<char>();
        private int _nbEssai;

        public string Mot
        {
            get
            {
                return _mot;
            }
        }

        public bool Gagne
        {
            get
            {
                return _lettresTrouves.Count == _mot.Distinct().Count();
            }
        }

        public bool Perdu
        {
            get
            {
                return _nbEssai == _PENDU_ASCII.Length-1;
            }
        }

        public bool Termine
        {
            get
            {
                return this.Perdu || this.Gagne;
            }
        }

        public Pendu(string mot)
        {
            _mot = mot.ToLower();
        }

        public Pendu(List<string> mots)
        {
            Random r = new Random();
            int indexMot = r.Next(0, mots.Count());
            _mot = mots[indexMot].ToLower().RemoveDiacritics();
        }

        public string RecupererAscii()
        {
            return _PENDU_ASCII[_nbEssai];
        }

        public string RecupererLettresTrouves()
        {
            string lettres = "";

            foreach (var lettre in _mot)
            {
                if (_lettresTrouves.Contains(lettre))
                    lettres += lettre + " ";
                else
                    lettres += " _ ";
            }

            return lettres.ToUpper();
        }

        public void NouvelEssai(string lettre)
        {
            lettre = lettre.ToLower().RemoveDiacritics();
            if (_mot.Contains(lettre))
                _lettresTrouves.Add(lettre[0]);
            else
                _nbEssai++;
        }
    }
}

