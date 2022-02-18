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
    }
    class Csv : IWine
    {
        public Wine ImportOneSample(string filename_sample_csv)
        {
            Wine data = new Wine();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var reader = new StreamReader(filename_sample_csv))
            using (var csv = new CsvReader(reader, config))
            {
                //data = csv.GetRecords<Wine>().ToList();
                csv.Read();

                data.FixedAcidity = csv.GetRecord<float>();
                data.VolatileAcidity = csv.GetField<float>("volatile acidity");
                data.CitricAcid = csv.GetField<float>("citric acid");
                data.ResidualSugar = csv.GetField<float>("residual sugar");
                data.Chlorides = csv.GetField<float>("chlorides");
                data.FreeSulfurDioxide = csv.GetField<float>("free sulfur dioxide");
                data.TotalSulfurDioxide = csv.GetField<float>("total sulfur dioxide");
                data.Density = csv.GetField<float>("density");
                data.PH = csv.GetField<float>("pH");
                data.Sulphates = csv.GetField<float>("sulphates");
                data.Alcohol = csv.GetField<float>("alcohol");
                data.Quality = csv.GetField<int>("quality");


            }

            return data;
        }
        public List<Wine> ImportAllSamples(string filename_samples_csv)
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
        public void PrintInfo()
        {

        }
    }

}
