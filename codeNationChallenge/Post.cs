using System;
using System.Collections.Generic;
using System.Text;

namespace codeNationChallenge
{
    class Post
    {
        public int numero_casas { get; set; }
        public string Token { get; set; }
        public string decifrado => Decifrado();
        public string Cifrado { get ; set; }
        public string resumo_criptografico { get; set; }
        private string Decifrado()
        {
            string descript = "";
            foreach (char i in Cifrado)
            {
                for (int x = Alfabeto.Letra.Length - 1; x >= 0; x--)
                {
                    if (i == Alfabeto.Letra[x])
                    {
                        int _letra = x - numero_casas;
                        if (_letra < 0)
                        {
                            _letra += Alfabeto.Letra.Length;
                        }
                        descript += Alfabeto.Letra[_letra];
                        break;
                    } 
                    else if (x == 0)
                    {
                        descript += i;
                    }


                }           
            }
            return descript;
        }
    }
}
