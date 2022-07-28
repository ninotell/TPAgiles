using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wordle;

namespace MVC.Controllers
{
    public class GameController : HomeController
    {
        public ActionResult Game()
        {
            return View(new WordleGame());
        }

        [HttpPost]
        public JsonResult IntentarPalabra(WordleGame model, string palabra)
        {
            model.PalabraIntentada = palabra;
            model.Win = Juego.IntentarPalabra(model.PalabraIntentada);
            model.ElapsedTime = Juego.elapsedTime;
            model.Puntajes = Juego.puntajes;
            model.Nombre = Juego.nombre;
            model.Voucher = Juego.voucher;
            model.ResultadosIntentos = Juego.resultadoIntentos;
            model.ErroresPosibles = Juego.maxIntentos;
            model.Dificultad = Juego.dificultad;
            model.Finish = Juego.juegoTerminado;
            model.ErroresCometidos = Juego.intentos;
            model.PalabrasIntentadas = Juego.palabrasIntentadas;
            model.Win = Juego.partidaGanada;
            model.Palabra = Juego.palabra;
            model.PalabraIntentada = "";
            return Json(model);
        }
    }
}
