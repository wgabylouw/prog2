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
            if (args[args.Length - 1] == "-h" || args[args.Length-1] == "--help")
            {
                Console.Write("utilisation [-e test_file.csv ou -p sample_file.csv] -t train_file.csv -k k_value -s sort_algorithm \n \n" +
                    "-e (evaluate) : spécifie un fichier .csv constenant une liste de Vin à évaluer \n" +
                    "-p (predic) : spécifie un fichier .csv contenant un Vin à évaluer \n" +
                    "-t (train) : spécifie la liste de Vin faite par un expert pour entrainer l'algorithme. \n" +
                    "-k : spécifie combien de \"proche parent considéré\" valeur de base est 1 \n" +
                    "-s (sort algorithm) : spécifie quelle alogirithme de trie utiliser : 1 = trie selection, 2 = trie shell. valeur par defaut 1\n" +
                    "-h ou --help : aficher l'aide.");
                return;
            }
            for (int i=args.Length-2;i>=0;i-=2)
            {
                switch (args[i])
                {
                    case "-e":
                        string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", args[i + 1]);
                        foreach (Wine item in knn.Data_train)
                            item.PrintInfo();
                        knn.Evaluate(filepath2);
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
                    default:
                        Console.WriteLine("test");
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


            //Wine vin2 = knn.ImportOneSample(filepath2);
            //Console.WriteLine(knn.EuclideanDistance(vin1, vin2)); 
        }
    }
}
