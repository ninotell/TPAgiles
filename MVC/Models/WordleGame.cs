using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class WordleGame
    {
        [DisplayName("Palabra")]
        public string Palabra { get; set; }

        [DisplayName("Errores Posibles")]
        public int ErroresPosibles { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Dificultad")]
        public int Dificultad { get; set; }

        [DisplayName("LongitudPalabra")]
        public int WordLength { get; set; }

        [DisplayName("Palabra Intentada")]
        public string PalabraIntentada { get; set; }

        [DisplayName("Win")]
        public bool Win { get; set; }

        [DisplayName("Juego Terminado")]
        public bool Finish { get; set; }

        [DisplayName("Errores Cometidos")]
        public int ErroresCometidos { get; set; }

        [DisplayName("Voucher")]
        public int Voucher { get; set; }

        [DisplayName("Tiempo")]
        public string ElapsedTime { get; set; }

        [DisplayName("Puntajes")]
        public Dictionary<string, int> Puntajes { get; set; }

        [DisplayName("Palabras Intentadas")]
        public List<string> PalabrasIntentadas { get; set; }

        [DisplayName("Resultados")]
        public List<string> ResultadosIntentos { get; set; }

    }
}
