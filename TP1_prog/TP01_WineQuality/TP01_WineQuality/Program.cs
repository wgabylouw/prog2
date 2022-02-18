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
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };
            using (var reader = new StreamReader("C:\\Users\\gable\\source\\repos\\ecole\\TP1_prog\\train.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<entete>();
                var records = csv.GetRecords<colone>();
            }
        }
        public class colone
        {
            public float fixedAcidity { get; set; }
            public float volatileAcidity { get; set; }
            public float citricAcid { get; set; }
            public float residualSugar { get; set; }
            public float chlorides { get; set; }
            public float freeSulfurDioxide { get; set; }
            public float totalSulfurDioxide { get; set; }
            public float density { get; set; }
            public float pH { get; set; }
            public float sulphates { get; set; }
            public float alcohol { get; set; }
            public int quality { get; set; }
        }

        public sealed class entete : ClassMap<colone>
        {
            public entete()
            {
                AutoMap(CultureInfo.InvariantCulture);
                Map(m => m.fixedAcidity).Name("fixed acidity");
                Map(m => m.volatileAcidity).Name("volatile acidity");
                Map(m => m.citricAcid).Name("citric acid");
                Map(m => m.residualSugar).Name("residual sugar");
                Map(m => m.freeSulfurDioxide).Name("free sulfur dioxide");
                Map(m => m.totalSulfurDioxide).Name("total sulfur dioxide");

            }
        }
    }

}
