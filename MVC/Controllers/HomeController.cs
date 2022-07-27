using MVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wordle;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
       
        public static JuegoWordle Juego { get; set; }

        // GET: Wordle
        public ActionResult Index()
        {
            return View(new WordleGame());
        }

        [HttpPost]
        public ActionResult Game(string nombre, int errors, int difficulty)
        {
            var textinfo = new CultureInfo("en-US", false).TextInfo;
            nombre = textinfo.ToTitleCase(nombre);

            System.Diagnostics.Debug.WriteLine(nombre);

            Juego = new JuegoWordle(nombre, errors, difficulty);

            WordleGame juego = new WordleGame
            {
                Nombre = Juego.nombre,
                ErroresPosibles = errors,
                Dificultad = Juego.dificultad,
                Palabra = Juego.palabra,
                ErroresCometidos = Juego.resultadoIntentos.Count,
                WordLength = ((Juego.dificultad * 2) + 2),
                Win = false,
                ResultadosIntentos = Juego.resultadoIntentos,
                PalabrasIntentadas = Juego.palabrasIntentadas,
                PalabraIntentada = ""
            };

            return View(juego);
        }
             
        
    }
}
