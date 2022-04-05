using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace TP01_WineQuality
{
    internal class KNN : IKNN
    {
        private List<Wine> data_train;
        private int K;
        private int Sort_Algorithm;




        /* Méthode KNN Train || Entrées : "Train List CSV", "k", "Choix Méthode Tri" || Sortie : Aucune || Rôle : Appel KNN Méthode ImportAllSamples */
        public void Train(string filename_train_samples_csv, int k = 1, int sort_algorithm = 1)
        {
            /* Train List Objet = KNN Méthode ImportAllSample("Train List CSV")*/
            data_train =  this.ImportAllSamples(filename_train_samples_csv);
            K = k;
            Sort_Algorithm = sort_algorithm;
        }


        /* Méthode KNN EuclideanDistance || Entrées : "Vin Objet", "une ligne de Train Object"  || Sortie : "1 distance Euclidienne Vin-Train" */
        public float EuclideanDistance(Wine first_sample, Wine second_sample)
        {
            float distance =0;

            for (int i = 0;i<first_sample.Features.Length;i++)
            {
                distance += (float)Math.Pow((first_sample.Features[i] - second_sample.Features[i]),2);
            }
            distance = (float)Math.Sqrt(distance);


            return distance;
        }

 
        /* Méthode KNN ImportAllSample || Entrée : "Train List CSV" || Sortie : "Train List Objet" || Rôle : Transfert "Train List CSV" en 
               "Train List Objet"*/
        public List<Wine> ImportAllSamples(string _filename_samples_csv)
        {
            List<Wine> data;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var reader = new StreamReader(_filename_samples_csv))
            using (var csv = new CsvReader(reader, config))
            {
                data = csv.GetRecords<Wine>().ToList();
            }

            return data;
        }

        
        /* Méthode KNN ImportOneSample || Entrée : "Vin CSV" || Sortie: "Vin Objet" || Rôle : Transfert "Vin CSV" en "Vin Objet"*/
        public Wine ImportOneSample(string filename_sample_csv)
        {
            Wine data = new Wine();

            /*Changer le délimiter CSV pour ";"*/
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            /*Lecture de fichier CSV*/
            using (var reader = new StreamReader(filename_sample_csv))
            using (var csv = new CsvReader(reader, config))
            {
                /*Lecture de l'entête CSV*/
                csv.Read();
                csv.ReadHeader();

                // Association de valeurs aux attributs de l'objet Vin.
                csv.Read();
                data.VolatileAcidity = csv.GetField<float>("volatile acidity");
                data.CitricAcid = csv.GetField<float>("citric acid");
                data.Sulphates = csv.GetField<float>("sulphates");
                data.Alcohol = csv.GetField<float>("alcohol");
                data.Label = csv.GetField<int>("quality");
            }

            return data;
        }

        // Méthode KNN Evaluate || Entrée : fichier_de_test CSV || Sortie : Float Précision de l'algorithme en % || Rôle : Donner la précision de l'algorithme.
        public float Evaluate(string filename_test_samples_csv)
        {
            
            List<Wine> ListeEvaluation = this.ImportAllSamples(filename_test_samples_csv);

            // Liste qui contiendra chacune des prédictions de l'algorithme.
            List<int> Prediction = new List<int>();

            // Tableau des valeurs possibles.
            int[] TableauLabel = new int[] { 3, 6, 9 };

            // Liste qui contiendra chacune des prédictions de l'expert.
            List<int> ListeExpert = new List<int>();
            float bon = 0;

            for (int i = 0; i < ListeEvaluation.Count; i++)
            {
                Prediction.Add(Predict(ListeEvaluation[i]));
                ListeExpert.Add(ListeEvaluation[i].Label);


                if (Prediction[i] == ListeExpert[i])
                {
                    bon++;
                }
            }

            // Appel de la méthode ConfusionMatrix
            ConfusionMatrix(Prediction, ListeExpert, TableauLabel);
            return (bon / Prediction.Count) * 100;
        }


        /*Méthode KNN ConfusionMatrix || Entrées : Liste des Qualités prédites, Liste des qualités données par l'expert, Tableau des qualités possibles 
          || Sortie : Aucune || Rôle : Calcul et affichage de la matrice de confusion */
        public void ConfusionMatrix(List<int> predicted_labels, List<int> expert_labels, int[] labels)
        {
            /* Construction de la matrice de confusion */
            int[,] Tableau = new int[labels.Length, labels.Length];

            for (int i = 0; i < expert_labels.Count; i++)
            {
                for (int j = 0; j < labels.Length; j++)
                   if (expert_labels[i] == labels[j])
                    {
                        if (predicted_labels[i] == 3)
                            Tableau[j, 0]++;
                        else if (predicted_labels[i] == 6)
                            Tableau[j, 1]++;
                        else 
                            Tableau[j, 2]++;    
                    }     
            }
            // Début de l'affichage de la matrice de confusion.
            Console.Write("Confusion Matrix : \n \n");
            foreach (var item in labels)
                Console.Write("      " + item);
            Console.WriteLine();
            foreach (var item in labels)
                Console.Write("________");


            // Boucle pour afficher correctement la matrice de confusion à la console.
            for (int i = 0;i < Tableau.GetLength(0); i++)
            {
                Console.WriteLine();
                Console.Write(labels[i]+"    |"+ Tableau[i,0]);
                for (int j = 1; j < Tableau.GetLength(0); j++)
                    Console.Write("     {0}", Tableau[i, j]);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

         
        /* Méthode KNN Predict || Entrée : "Vin Objet" || Sortie: "Résultat Qualité" || Rôle : Appel Méthodes KNN EuclideanDistance, KNN (SelectionSort 
           ou ShellSort) et KNN Vote et donne le résultat de la qualité du vin échantilloné*/
        public int Predict(Wine sample_to_predict)
        {
            /*"Distances Euclidiennes Vin-Train"*/
            List<float> listeDistance = new List<float>();

            /*"Qualités Vin-Train"*/
            List<int> listeLabels = new List<int>();
            for (int i=0;i<data_train.Count();i++)
            {
                /*"Distances Euclidiennes Vin-Train = KNN Méthode EuclideanDistance("Vin Objet", "Train List Objet")*/
                listeDistance.Add(EuclideanDistance(sample_to_predict, data_train[i]));
                listeLabels.Add(data_train[i].Label);
            }

            /* Choix et appel de KNN Méthode SelectionSort ou ShellSort("Distances Euclidiennes Vin-Train non triées", "Qualités non triées")*/
            if (Sort_Algorithm == 1)
                this.SelectionSort(listeDistance, listeLabels);
            else 
                this.ShellSort(listeDistance, listeLabels);
            
            /* Appel et retour de KNN Méthode Vote("Qualités triées")*/
            return this.Vote(listeLabels);
        }

         
        /* Méthode KNN Vote || Entrée : "Qualités triées" || Sortie: "Résultat Qualité" || Rôle : Prédire la qualité du vin échantilloné*/
        public int Vote(List<int> sorted_labels)
        {
            int compteur3=0,compteur6=0,compteur9 = 0;

            for (int i=0; i<K;i++)
            {
                if (sorted_labels[i] == 3)
                    compteur3++;
                else if (sorted_labels[i] == 6)
                    compteur6++;
                else compteur9++;
            }
            if (compteur3 > compteur6 && compteur3 > compteur9)
                return 3;
            else if (compteur9 > compteur3 && compteur9 > compteur6)
                return 9;
            else if (compteur6 > compteur3 && compteur6 > compteur9)
                return 6;
            else if (compteur3 == compteur6)
                return 3;
            else if (compteur3 == compteur9)
                return 9;
            else return 6;

        }

         
        /* Méthode KNN ShellSort || Entrées : "Distances Euclidiennes Vin-Train non triées", "Qualités non triées" || Sortie: "Aucune" 
           || Rôle : Trier "Distances Euclidiennes Vin-Train" */
        public void ShellSort(List<float> distances, List<int> labels)
        {
            // Les distances sont triées de la plus petite à la plus grande et les labels sont triés par rapport à la distance qui leur est associée.
            int compteur = distances.Count();
            int n = 0;
            float temp;
            int temp2;
            int j;
            while (n < compteur)
            {
                n = 3 * n + 1;
            }
            while (n != 0)
            {
                n = n / 3;
                for (int i = n; i < compteur; i++)
                {
                    temp = distances[i];
                    temp2 = labels[i];
                    j = i;
                    while (j > n - 1 && distances[j - n] > temp)
                    {
                        distances[j] = distances[j - n];
                        labels[j] = labels[j - n];
                        j = j - n;
                    }
                    distances[j] = temp;
                    labels[j] = temp2;
                }
            }
        }

         
        /* Méthode KNN SelectionSort || Entrées : "Distances Euclidiennes Vin-Train non triées", "Qualités non triées" || Sortie: "Aucune" 
           || Rôle : Trier "Distances Euclidiennes Vin-Train" */
        public void SelectionSort(List<float> distances, List<int> labels)
        {
            // Les distances sont triées de la plus petite à la plus grande et les labels sont triés par rapport à la distance qui leur est associée.
            float temp;
            int min;
            int compteur = distances.Count();
            for (int i = 0; i < compteur; i++)
            {
                min = i;
                for (int j = i + 1; j < compteur; j++)
                {
                    if (distances[j] < distances[min])
                        min = j;
                }
                if (min != i)
                {
                    temp = distances[min];
                    distances[min] = distances[i];
                    distances[i] = temp;
                    temp = labels[min];
                    labels[min] = labels[i];
                    labels[i] = (int)temp;
                }
            }
        }


        // Accesseur pour pouvoir utiliser la liste de vins du Train lors de l'affichage dans le Main.
        public List<Wine> Data_train { get
            { return data_train; } }
    }
}
