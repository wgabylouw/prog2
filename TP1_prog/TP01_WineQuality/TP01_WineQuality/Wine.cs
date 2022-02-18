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
    public class Wine
    {
        [CsvHelper.Configuration.Attributes.Name("fixed acidity")]
        public float FixedAcidity { get; set; }
        [CsvHelper.Configuration.Attributes.Name("volatile acidity")]
        public float VolatileAcidity { get; set; }
        [CsvHelper.Configuration.Attributes.Name("citric acid")]
        public float CitricAcid { get; set; }
        [CsvHelper.Configuration.Attributes.Name("residual sugar")]
        public float ResidualSugar { get; set; }
        [CsvHelper.Configuration.Attributes.Name("chlorides")]
        public float Chlorides { get; set; }
        [CsvHelper.Configuration.Attributes.Name("free sulfur dioxide")]
        public float FreeSulfurDioxide { get; set; }
        [CsvHelper.Configuration.Attributes.Name("total sulfur dioxide")]
        public float TotalSulfurDioxide { get; set; }
        [CsvHelper.Configuration.Attributes.Name("density")]
        public float Density { get; set; }
        [CsvHelper.Configuration.Attributes.Name("pH")]
        public float PH { get; set; }
        [CsvHelper.Configuration.Attributes.Name("sulphates")]
        public float Sulphates { get; set; }
        [CsvHelper.Configuration.Attributes.Name("alcohol")]
        public float Alcohol { get; set; }
        [CsvHelper.Configuration.Attributes.Name("quality")]
        public int Quality { get; set; }


        //public static Wine ImportOneSample(string filename_sample_csv)
        //{
        //    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        //    {
        //        Delimiter = ";",
        //    };
        //    using (var reader = new StreamReader(filename_sample_csv))
        //    using (var csv = new CsvReader(reader, config))
        //    {
        //        csv.Read();
        //        csv.ReadHeader();

        //        csv.Context.RegisterClassMap<entete>();
        //        var records = csv.GetRecords<Wine>();

        //    }
        //}
        
        public sealed class entete : ClassMap<Wine>
        {
            public entete()
            {
                AutoMap(CultureInfo.InvariantCulture);
                Map(m => m.FixedAcidity).Name("fixed acidity");
                Map(m => m.VolatileAcidity).Name("volatile acidity");
                Map(m => m.CitricAcid).Name("citric acid");
                Map(m => m.ResidualSugar).Name("residual sugar");
                Map(m => m.FreeSulfurDioxide).Name("free sulfur dioxide");
                Map(m => m.TotalSulfurDioxide).Name("total sulfur dioxide");

            }
        }
    }
    class Csv
    {
        static public List<Wine> ImportAllSamples(string filename_samples_csv)
        {
            List<Wine> data;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var reader = new StreamReader(filename_samples_csv))
            using (var csv = new CsvReader(reader, config))
            {
                data = csv.GetRecords<Wine>().ToList();
            }

            return data;
        }
    }

}
