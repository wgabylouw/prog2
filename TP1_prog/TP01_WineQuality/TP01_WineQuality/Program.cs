using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;


namespace TP01_WineQuality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Csv csv = new Csv();
            List<Wine> vin1 = csv.ImportAllSamples("C:\\Users\\gable\\source\\repos\\Prog2_avec_fred\\prog2\\TP1_prog\\train.csv");
            foreach (var item in vin1)
            {
                Console.WriteLine(item.FixedAcidity);
            }
            Wine vin2 = csv.ImportOneSample("C:\\Users\\gable\\source\\repos\\Prog2_avec_fred\\prog2\\TP1_prog\\train.csv");
            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11}", 
                vin2.FixedAcidity, vin2.VolatileAcidity, vin2.CitricAcid, vin2.ResidualSugar, vin2.Chlorides,
                vin2.FreeSulfurDioxide,vin2.TotalSulfurDioxide,vin2.Density,vin2.PH,vin2.Sulphates,vin2.Alcohol,vin2.Quality);
        }


    }

}
