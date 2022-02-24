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

            string filepath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..","samples", "sample_01.csv");
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "train.csv");
            //string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "samples", "sample_02.csv");
            Wine vin1 = knn.ImportOneSample(filepath1);
            knn.Train(filepath,10,2);
            Console.WriteLine(knn.Predict(vin1));


            //Wine vin2 = knn.ImportOneSample(filepath2);
            //Console.WriteLine(knn.EuclideanDistance(vin1, vin2));


            
        }
    }
}
