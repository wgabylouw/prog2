using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



// TP1 Frédérik Boutin et Gabriel Létourneau



namespace TP01_WineQuality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Si le programme n'a pas d'argument de spécifié lors de son exécution, on affiche l'aide et on arrête le programme.
            if (args.Length == 0)
            {
                AfficherAide();
                return;
            }
            /*Objet knn (Class KNN)*/
            KNN knn = new KNN();
            int k =1;
            bool afficherInfo = false;
            int sort_algorithm = 1;

            // Vérifie si le dernier argument est -i et affiche le(s) info(s).
            if (args[args.Length - 1] == "-i")
            {
                afficherInfo = true;
                args = args.Where(e => e != "-i").ToArray();
            }


            // Vérifie si le dernier argument est -h ou --help et affiche de l'aide au besoin + arrête le programme.
            if (args[args.Length - 1] == "-h" || args[args.Length-1] == "--help")
            {
                AfficherAide();
                return;
            }


            // Boucle for qui commence à la fin du Tableau "args" et qui décrémente par bond de 2 jusqu'à 0.
            for (int i=args.Length-2;i>=0;i-=2)
            {
                // Vérifie les arguments en commençant par la fin du tableau argument.
                switch (args[i])
                {
                    case "-e":
                        string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", args[i + 1]);
                        Console.WriteLine();
                        if (afficherInfo)
                        {
                            foreach (Wine item in knn.Data_train)
                            item.PrintInfo();
                        }
                        Console.WriteLine("Classification Accuracy -> {0} % \n",knn.Evaluate(filepath2));
                        break;


                    case "-p":
                        /*"Vin CSV*/
                        string filepath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "samples", args[i + 1]);
                        Wine vin1 = knn.ImportOneSample(filepath1);
                        Console.WriteLine();
                        if (afficherInfo)
                            vin1.PrintInfo();
                        Console.WriteLine("\n["+args[i+1] +"] Prediction by model -> "+knn.Predict(vin1) + " | by expert -> " + vin1.Label);
                        break;



                    case "-t":
                        /*Train List CSV*/
                        string filepath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", args[i+1]);
                        knn.Train(filepath3,k, sort_algorithm);
                        break;


                    case "-k":
                        k = Convert.ToInt32(args[i + 1]);
                        break;


                    case "-s":
                        sort_algorithm = Convert.ToInt32(args[i + 1]);
                        break;

                        //Si aucun cas ne correspond à l'élément du tableau "args", on affiche l'aide à l'utilisateur pour qu'il puisse utiliser l'application correctement.
                    default:
                        AfficherAide();
                        return;
                }
            }

            //Méthode supplémentaire qui permet d'afficher l'aide.
            void AfficherAide()
            {
                
                Console.Write("\nUtilisation [-e test_file.csv ou -p sample_file.csv] -t train_file.csv -k k_value -s sort_algorithm . \n \n" +
                        "-e (Evaluate) : spécifie qu'un fichier .csv contenant une liste de Vins à évaluer \n" +
                        "-p (Predict) : spécifie qu'un fichier .csv contenant un Vin à évaluer \n" +
                        "-t (Train) : spécifie la liste de Vins évaluée par un expert pour entrainer l'algorithme. \n" +
                        "-k : spécifie combien de \"proche(s) parent(s) à considérer\" la valeur de par défaut est 1 \n" +
                        "-s (sort algorithm) : spécifie quel alogirithme de tri est utilisé : 1 = tri Selection, 2 = tri Shell. la valeur par défaut est 1\n" +
                        "-i : spécifie d'afficher le(s) info(s) de(s) vin(s). \n" +
                        "-h ou --help : aficher l'aide.");
            }
        }
    }
}
