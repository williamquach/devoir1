using System;

namespace ModelObjet
{
    public class Condition
    {
        const int nbJours = 30;
        // Permet de savoir si on a le droit d'être remboursé
        // On l'est à condition que le nombre de jours ne dépasse pas 30 !
        public static bool Valider(int unNbDeJours)
        {
            if (unNbDeJours <= 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Permet de renvoyer le montant MAX remboursé en fonction de la catégorie
        public static int CalculerMontantMax(string uneCategorie)
        {
            int montantMax = 0;
            if (uneCategorie == "Livre")
            {
                montantMax = 30;
            }
            else if (uneCategorie == "Jouet")
            {
                montantMax = 50;
            }
            else if (uneCategorie == "Informatique")
            {
                montantMax = 1000;
            }
            return montantMax;
            
        }
        // Permet de retourner le total remboursé en fonction de tous les critères
        public static double CalculerMontantRembourse(int unNbDeJours, string uneCategorie, bool estMembre, string unEtat, int unPrix)
        {
            double montantRembourse;
            if (Valider(unNbDeJours) == true) // - de 30 jours
            {
                double reductionMembre = CalculerReductionMembre(estMembre);
                double reductionEtat = CalculerReduction(unEtat);
                double montantMaxRembourse = CalculerMontantMax(uneCategorie);
                if (CalculerMontantMax(uneCategorie) < unPrix)
                {
                    unPrix = CalculerMontantMax(uneCategorie);
                }
                montantRembourse = unPrix - unPrix * Math.Round(reductionMembre / 100, 2) - unPrix * Math.Round(reductionEtat / 100, 2);
            }
            else // + de 30 jours
            {
                montantRembourse = 0;
            }

            return montantRembourse;

        }
        // Permet de renvoyer la réduction si on est membre ou pas
        public static double CalculerReductionMembre(bool estMembre)
        {
            double reductionMembre;
            if (estMembre)
            {
                reductionMembre = 0;
            }
            else
            {
                reductionMembre = 20;
            }
            return reductionMembre;
        }
        // Permet de renvoyer la réduction en fonction de l'état de l'achat
        public static double CalculerReduction(string unEtat)
        {
            double reductionEtat;
            if (unEtat == "Abimé" || unEtat == "Très abimé")
            {
                reductionEtat = 30;
            }
            else
            {
                reductionEtat = 10;
            }
            return reductionEtat;
        }
    }
}
