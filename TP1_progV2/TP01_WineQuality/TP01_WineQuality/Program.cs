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
            KNN knn = new KNN();
            int k = 1;
            int sort_algorithm = 1;
            for (int i=args.Length-1;i>=0;i--)
            {
                //Console.WriteLine(args[i]);
                switch (args[i])
                {
                    case "-e":
                        string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", args[i + 1]);
                        knn.Evaluate(filepath2);
                        foreach (var item in knn.Data_train)
                            item.PrintInfo();
                        break;
                    case "-p":
                        string filepath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "samples", args[i + 1]);
                        Wine vin1 = knn.ImportOneSample(filepath1);
                        Console.WriteLine("["+args[i+1] +"] Prediction by model -> "+knn.Predict(vin1) + " | by expert -> " + vin1.Label);
                        break;
                    case "-t":
                        string filepath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", args[i+1]);
                        knn.Train(filepath3, k, sort_algorithm);
                        break;
                    case "-k":
                        k = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-s":
                        sort_algorithm = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-h":

                        break;
                    default:
                        break;
                }
            }

            /*Objet knn (Class KNN)*/

            /*"Vin CSV*/
            //string filepath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..","samples", "sample_01.csv");

            //string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "test.csv");

            /*Train List CSV*/
            //string filepath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "train.csv");

            //string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "samples", "sample_02.csv");




            /* 1. "Vin Objet" = KNN Méthode ImportOneSample("Vin CSV")*/
            //Wine vin1 = knn.ImportOneSample(filepath1);


            /* 2. Appel KNN Méthode Train("Train List CSV", "K", "Choix Méthode Tri")*/
            //knn.Train(filepath3,10,2);


            /* 3. Appel KNN Méthode Predict("Vin Objet")*/
            //Console.WriteLine(knn.Predict(vin1));


            //Console.WriteLine(knn.Evaluate(filepath2));
            Console.ReadLine();


            //Wine vin2 = knn.ImportOneSample(filepath2);
            //Console.WriteLine(knn.EuclideanDistance(vin1, vin2)); 
        }
    }
}
