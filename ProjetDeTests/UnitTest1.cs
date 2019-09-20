using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelObjet;

namespace ProjetDeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void ValiderTest()
        {
            // Le nombre de jours d'achat est < à 30 jours
            Assert.AreEqual(true, Condition.Valider(25));
            // Le nombre de jours d'achat est > à 30 jours
            Assert.AreEqual(false, Condition.Valider(35));
        }

        [TestMethod()]
        public void CalculerMontantMaxTest()
        {
            // Pour la catégorie livre
            Assert.AreEqual(30, Condition.CalculerMontantMax("Livre"));


            // Pour la catégorie jouet
            Assert.AreEqual(50, Condition.CalculerMontantMax("Jouet"));


            // Pour la catégorie informatique
            Assert.AreEqual(1000, Condition.CalculerMontantMax("Informatique"));

        }

        [TestMethod()]
        public void CalculerMontantRembourseTest()
        {
            // Un livre achété 24 euros depuis 15 jours avec un état "Très abimé" en étant non membre
            Assert.AreEqual(12, Condition.CalculerMontantRembourse(15, "Livre", false, "Très abimé", 24));

            // Un livre achété 24 euros depuis 15 jours avec un état "Bon" en étant membre
            Assert.AreEqual(21.6, Condition.CalculerMontantRembourse(15, "Livre", true, "Bon", 24));

        }

        [TestMethod()]
        public void CalculerReductionMembreTest()
        {
            // Il est membre
            Assert.AreEqual(0, Condition.CalculerReductionMembre(true));


            // Il n'est pas membre
            Assert.AreEqual(20, Condition.CalculerReductionMembre(false));
        }

        [TestMethod()]
        public void CalculerReductionTest()
        {
            // Pour un état "bon"
            Assert.AreEqual(10, Condition.CalculerReduction("bon"));



            // Pour un état "abimé"
            Assert.AreEqual(30, Condition.CalculerReduction("Abimé"));

        }
    }
}
