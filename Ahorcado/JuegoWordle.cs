using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;


namespace Wordle
{
    public class JuegoWordle
    {
        public string nombre, palabra;
        public int intentos = 0, dificultad = 0, voucher = 0;
        public int maxIntentos = 5;
        public bool juegoTerminado = false, partidaGanada = false;
        public Dictionary<string, int> puntajes = new Dictionary<string, int>() 
        { 
            ["Juan"] = 5,
            ["Carlos"] = 8,
            ["Facu"] = 9,
            ["Fede"] = 12,
            ["Pato"] = 6,
            ["Usuario6"] = 18,
            ["Usuario14"] = 17,
        };
        public List<string> palabrasIntentadas = new List<string>();
        public List<string> resultadoIntentos = new List<string>();
        readonly Stopwatch stopWatch = new Stopwatch();
        public string elapsedTime = "0";

        public string[] palabrasFacil = new string[] { "AUTO", "CASA", "PATO", "LORO" };
        public string[] palabrasMedio = new string[] { "BORDES", "CARROS", "CARCEL", "DISCOS" };
        public string[] palabrasDificil = new string[] { "CRUCEROS", "SIMBOLOS", "CREDITOS", "CERROJOS" };

        public JuegoWordle(string _nombre, int _maxIntentos, int _dificiultad)
        {
            nombre = _nombre;
            maxIntentos = _maxIntentos;
            dificultad = _dificiultad;
            intentos = 0;
            if (nombre == null || maxIntentos == 0 || dificultad == 0)
            {
                return;
            }
            if (puntajes.TryGetValue(nombre, out _))
            { }
            else
            {
                puntajes.Add(nombre, 0);
            }
            SetPalabra();
            stopWatch.Start();
        }

        private void SetPalabra()
        {
            Random random = new Random();

            if (dificultad <= 1)
            {
                int i = random.Next(0, palabrasFacil.Length);
                palabra = palabrasFacil[i];
            }
            if (dificultad == 2)
            {
                int i = random.Next(0, palabrasMedio.Length);
                palabra = palabrasMedio[i];
            }
            if (dificultad >= 3)
            {
                int i = random.Next(0, palabrasDificil.Length);
                palabra = palabrasDificil[i];
            }

        }

        public bool IntentarPalabra(string _palabra)
        {
            intentos++;
            _palabra = _palabra.ToUpper();
            palabrasIntentadas.Add(_palabra); // añado la palabra a la lista de intentos
            VerificarPalabra(_palabra);


            if(palabra == _palabra)
            {
                partidaGanada = true;
                TerminarJuego();
                return true;
            }

            if (intentos == maxIntentos)
            {
                TerminarJuego();
                return false;
            }

            return false;

            /* OLD LOGIC ----
             

            if (intentos <= maxIntentos)
            {
                if (palabra == _palabra)
                {
                    partidaGanada = true;
                    TerminarJuego();
                    return true;
                }
                else
                {
                    if (intentos == maxIntentos)
                    {
                        TerminarJuego();
                    }
                    return false;
                }
            }
            return false;
            */

        }
        private void TerminarJuego()
        {
            puntajes[nombre] = partidaGanada ? puntajes[nombre] + 1 : puntajes[nombre] - 1;
            if (partidaGanada)
            {
                Random random = new Random();
                voucher = random.Next(10, 75);
            }
            else
            {
                voucher = 0;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{1:00}min:{2:00}seg.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            juegoTerminado = true;
        }

        private void VerificarPalabra(string _palabra)
        {

            string palabraIntentada;

            //palabraIntentada = palabrasIntentadas[intentos - 1];
            palabraIntentada = _palabra;

            int[] frecuenciaPorLetra = new int[palabraIntentada.Length];
            char[] resultadoIntentado = new char[palabraIntentada.Length];


            for (int i = 0; i < frecuenciaPorLetra.Length; i++)
            {
                frecuenciaPorLetra[i] = palabra.Count(l => l == palabraIntentada[i]);
                
            }

            for (int k = 0; k < palabraIntentada.Length; k++)
            {
                if (palabraIntentada[k] == palabra[k])
                {
                    resultadoIntentado[k] = 'O';
                    for (int l = 0; l < palabraIntentada.Length; l++)
                    {
                        if (palabraIntentada[k] == palabraIntentada[l])
                        {
                            frecuenciaPorLetra[l] -= 1; // resto el numero de ocurrencias
                        }

                    }
                } else
                {
                    resultadoIntentado[k] = 'X';
                }
            }

            for (int i = 0; i < palabraIntentada.Length; i++)
            {
                if (frecuenciaPorLetra[i] == 0 && resultadoIntentado[i] != 'O')
                {
                    resultadoIntentado[i] = 'X';
                    continue;
                }
                else if (frecuenciaPorLetra[i] > 0 && resultadoIntentado[i] != 'O')
                {
                    if (palabraIntentada.Substring(0, i).Count(l => l == palabraIntentada[i]) <= frecuenciaPorLetra[i])
                    {
                        resultadoIntentado[i] = '-';
                        for (int l = 0; l < palabraIntentada.Length; l++)
                        {
                            if (palabraIntentada[i] == palabraIntentada[l])
                            {
                                frecuenciaPorLetra[l] -= 1; // resto el numero de ocurrencias
                            }

                        }

                    }
                }
               
            }
            
                //    for (int i = 0; i < palabraIntentada.Length; i++)
                //{
                //    if (palabraIntentada[i] == palabra[i])
                //    {
                //        resultadoIntentado[i] = 'O';
                //    }
                //    else
                //    {
                //        for (int j = 0; j < palabraIntentada.Length; j++)
                //        {
                //            if (palabraIntentada[i] == palabra[j])
                //            {
                //                resultadoIntentado[i] = '-';
                //                break;
                //            }
                //            else
                //            {
                //                resultadoIntentado[i] = 'X';
                //            }
                //        }
                //    }

                //}
                //Console.WriteLine(resultadoIntentado);
                string res = new string(resultadoIntentado);
            resultadoIntentos.Add(res);
        }

    }
}