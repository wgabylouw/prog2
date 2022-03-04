using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP01_WineQuality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* à compléter */

            /*Objet knn (Class KNN)*/
            KNN knn = new KNN();

            /*"Vin CSV*/
            string filepath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..","samples", "sample_01.csv");

            /*Train List CSV*/
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "train.csv");

            //string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "samples", "sample_02.csv");




            /* 1. "Vin Objet" = KNN Méthode ImportOneSample("Vin CSV")*/
            Wine vin1 = knn.ImportOneSample(filepath1);


            /* 2. Appel KNN Méthode Train("Train List CSV", "K", "Choix Méthode Tri")*/
            knn.Train(filepath,10,2);


            /* 3. Appel KNN Méthode Predict("Vin Objet")*/
            Console.WriteLine(knn.Predict(vin1));


            //Wine vin2 = knn.ImportOneSample(filepath2);
            //Console.WriteLine(knn.EuclideanDistance(vin1, vin2)); 
        }
    }
}
