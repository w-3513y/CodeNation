using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace codeNationChallenge
{
    class ResponseJson
    {
        public int numero_casas { get; set; m}
        public string token { get; set; }
        public string cifrado { get; set; }
        public string decifrado => Decifrado();
        public string resumo_criptografico => ResumeSHA1();
        private string Decifrado()
        {
            string descript = "";
            foreach (char i in cifrado)
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

        private string ResumeSHA1()
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(decifrado));
            return string.Concat(hash);
        }
        public override string ToString()
        {
            return "número de casas:      " + numero_casas + "\n" +
                   "token:                " + token + "\n" +
                   "cifrado:              " + cifrado + "\n" +
                   "decifrado:            " + decifrado + "\n" +
                   "resumo criptografico: " + resumo_criptografico;            
        }

    }
}
