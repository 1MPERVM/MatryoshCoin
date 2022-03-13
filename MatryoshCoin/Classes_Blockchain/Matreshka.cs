using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatryoshCoin.Classes_Blockchain
{
    class Matreshka
    {
        public bool IsOpen = false;

        public string Phrase
        {
            get => _phrase;
        }

        private string _phrase
        {
            get => PhraseGenerate();
        }

        private string PhraseGenerate()
        {
            char[] letters = "M@TrE5KA".ToCharArray();

            Random rand = new Random();
            List<char> tempWord = new List<char>();

            for (int i = 0; tempWord.Count != letters.Length; i++)
            {

                int letter_num = rand.Next(0, letters.Length);

                if (tempWord.Contains(letters[letter_num]))
                {
                    i++;
                }
                else
                {
                    tempWord.Add(letters[letter_num]);
                }


            }
            var finalWord = new string(tempWord.ToArray());

            return finalWord;

        }


    }
}
