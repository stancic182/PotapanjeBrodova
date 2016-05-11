﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace UnitTests
{
    /// <summary>
    /// Summary description for TestMreže
    /// </summary>
    [TestClass]
    public class TestMreže
    {
        [TestMethod]
        public void Mreža_DajSlobodnaPoljaInicijalnoDajeSvaPoljaUMreži()
        {
            Mreža m = new Mreža(10, 10);
            Assert.AreEqual(100, m.DajSlobodnaPolja().Count());
            Assert.IsTrue(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaNakonEliminiranjaJednogPoljaVraćaOstatak()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(new Polje(1, 1));
            Assert.AreEqual(99, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaNakonEliminiranjaDvaPoljaVraćaOstatak()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(new Polje(1, 1));
            m.EliminirajPolje(new Polje(2, 2));
            Assert.AreEqual(98, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(2, 2)));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaNakonEliminiranjaDvaIstaPoljaVraćaOstatak()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(new Polje(1, 1));
            m.EliminirajPolje(new Polje(1, 1));
            Assert.AreEqual(99, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
        }

        [TestMethod]
        public void Mreža_DajPoljaZaBrodVraćaListuOd3HorizontalnaPolja()
        {
            Mreža m = new Mreža(10, 10);
            var polja = m.DajPoljaZaBrod(Orjentacija.Horizontalno, new Polje(3, 6), 3);
            Assert.AreEqual(3, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(3, 6)));
            Assert.IsTrue(polja.Contains(new Polje(3, 7)));
            Assert.IsTrue(polja.Contains(new Polje(3, 8)));
        }

        [TestMethod]
        public void Mreža_DajPoljaZaBrodVraćaListuOd2VertikalnaPolja()
        {
            Mreža m = new Mreža(10, 10);
            var polja = m.DajPoljaZaBrod(Orjentacija.Vertikalno, new Polje(3, 6), 2);
            Assert.AreEqual(2, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(3, 6)));
            Assert.IsTrue(polja.Contains(new Polje(4, 6)));
        }
        
        [TestMethod]
        public void Mreža_DajPoljaUZadanomSmjeruVraćaListuOd1PoljaGoreZaPolje1_6()
        {
            Mreža m = new Mreža(10, 10);
            var polja = m.DajPoljaUZadanomSmjeru(1, 6, Smjer.Gore);
            Assert.AreEqual(2, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(0, 6)));
        }

        [TestMethod]
        public void Mreža_DajPoljaUZadanomSmjeruVraćaListuOd3PoljaDesnoZaPolje1_6()
        {
            Mreža m = new Mreža(10, 10);
            var polja = m.DajPoljaUZadanomSmjeru(1, 6, Smjer.Desno);
            Assert.AreEqual(3, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(0, 6)));
        }

        [TestMethod]
        public void Mreža_DajPoljaUZadanomSmjeruVraćaListuOd8PoljaDoljeZaPolje1_6()
        {
            Mreža m = new Mreža(10, 10);
            var polja = m.DajPoljaUZadanomSmjeru(1, 6, Smjer.Dolje);
            Assert.AreEqual(8, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(1, 7)));
        }

        [TestMethod]
        public void Mreža_DajPoljaUZadanomSmjeruVraćaListuOd6PoljaLijevoZaPolje1_6()
        {
            Mreža m = new Mreža(10, 10);
            var polja = m.DajPoljaUZadanomSmjeru(1, 6, Smjer.Lijevo);
            Assert.AreEqual(6, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(1, 5)));
        }

        [TestMethod]
        public void Mreža_DajPoljaUZadanomSmjeruVraćaListuOd4PoljaIspodZaPolje1_6()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(6, 6);
            var polja = m.DajPoljaUZadanomSmjeru(1, 6, Smjer.Dolje);
            Assert.AreEqual(4, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(1, 5)));
        }

    }
}
