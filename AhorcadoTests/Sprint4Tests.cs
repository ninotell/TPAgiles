using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wordle;

namespace AhorcadoTests
{
    [TestClass]
    public class Sprint4Tests
    {
        // TEST DIFICULTAD FACIL
        // TEST DIFICULTAD FACIL
        // TEST DIFICULTAD FACIL

        [TestMethod]
        public void ValidarVoucherFacilResolucionRapida3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 1);
            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");

            Assert.AreEqual(juego.voucher,19);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionRapida6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 1);
            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");

            Assert.AreEqual(juego.voucher, 13);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionRapida10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 1);
            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");

            Assert.AreEqual(juego.voucher, 5);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionMedia3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 1);

            juego.palabra = "PERRO";
            
            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 12);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionMedia6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 1);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 9);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionMedia10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 1);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 5);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionLenta3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 1);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 7);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionLenta6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 1);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 4);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionLenta10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 1);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 0);
        }

        [TestMethod]
        public void ValidarVoucherFacilResolucionSuperLenta()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 1);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(50000000000); // 1hora 23 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 5);
        }

        // TEST DIFICULTAD MEDIA
        // TEST DIFICULTAD MEDIA
        // TEST DIFICULTAD MEDIA


        [TestMethod]
        public void ValidarVoucherMedioResolucionRapida3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 38);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionRapida6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 26);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionRapida10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 10);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionMedia3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 24);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionMedia6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 18);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionMedia10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 10);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionLenta3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 14);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionLenta6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 8);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionLenta10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 0);
        }

        [TestMethod]
        public void ValidarVoucherMedioResolucionSuperLenta()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 2);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(50000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 5);
        }

        // TEST DIFICULTAD DIFICIL
        // TEST DIFICULTAD DIFICIL
        // TEST DIFICULTAD DIFICIL


        [TestMethod]
        public void ValidarVoucherDificilResolucionRapida3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 57);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionRapida6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 39);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionRapida10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 15);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionMedia3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 36);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionMedia6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 27);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionMedia10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(1000000000); // 1 minuto 40 segundos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 15);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionLenta3Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 21);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionLenta6Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 6, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 12);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionLenta10Intentos()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 10, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(3000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 0);
        }

        [TestMethod]
        public void ValidarVoucherDificilResolucionSuperLenta()
        {

            JuegoWordle juego = new JuegoWordle("JUAN", 3, 3);

            juego.palabra = "PERRO";

            juego.IntentarPalabra("PERRO");
            juego.ts = new TimeSpan(50000000000); // 5 minutos
            juego.GenerarVoucher();


            Assert.AreEqual(juego.voucher, 5);
        }

    }
}