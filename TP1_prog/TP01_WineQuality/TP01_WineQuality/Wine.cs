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
    public class Wine : IWine
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
            //Console.WriteLine(
            //    $"fixed acidity : {this.FixedAcidity} | " +
            //    $"volatile acidity : {this.CitricAcid} | " +
            //    $"citric acid : {this.ResidualSugar} | " +
            //    $"chlorides : {this.Chlorides} | " +
            //    $"free sulfur dioxide : {this.FreeSulfurDioxide}" +
            //    $"total sulfur dioxide : {this.TotalSulfurDioxide} | " +
            //    $"density : {this.Density} | " +
            //    $"pH : {this.PH} | " +
            //    $"sulphates : {this.Sulphates} | " + 
            //    $"alcohol : {this.Alcohol} | " +
            //    $"quality : {this.Quality}"
            //);

            Console.WriteLine(string.Format("{0:00.0} | {1:0.000} | {2:0.00} | {3:00.00} | {4:0.00000000000000000} | {5:00.0} | {6:000.0} | {7:0.0000000000000000} | {8:0.00} | {9:0.00} | {10:00.0} | {11:0}",
                this.FixedAcidity, this.VolatileAcidity, this.CitricAcid, this.ResidualSugar, this.Chlorides,
                this.FreeSulfurDioxide, this.TotalSulfurDioxide, this.Density, this.PH, this.Sulphates, this.Alcohol, this.Quality));
            //Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11}",
            //    this.FixedAcidity, this.VolatileAcidity, this.CitricAcid, this.ResidualSugar, this.Chlorides,
            //    this.FreeSulfurDioxide, this.TotalSulfurDioxide, this.Density, this.PH, this.Sulphates, this.Alcohol, this.Quality);
        }
    }
    //class Csv : IWine
    //{
    //    public Wine ImportOneSample(string filename_sample_csv)
    //    {
    //        Wine data = new Wine();

    //        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    //        {
    //            Delimiter = ";",
    //        };

    //        using (var reader = new StreamReader(filename_sample_csv))
    //        using (var csv = new CsvReader(reader, config))
    //        {
    //            //data = csv.GetRecords<Wine>().ToList();
    //            csv.Read();

    //            data.FixedAcidity = csv.GetRecord<float>();
    //            data.VolatileAcidity = csv.GetField<float>("volatile acidity");
    //            data.CitricAcid = csv.GetField<float>("citric acid");
    //            data.ResidualSugar = csv.GetField<float>("residual sugar");
    //            data.Chlorides = csv.GetField<float>("chlorides");
    //            data.FreeSulfurDioxide = csv.GetField<float>("free sulfur dioxide");
    //            data.TotalSulfurDioxide = csv.GetField<float>("total sulfur dioxide");
    //            data.Density = csv.GetField<float>("density");
    //            data.PH = csv.GetField<float>("pH");
    //            data.Sulphates = csv.GetField<float>("sulphates");
    //            data.Alcohol = csv.GetField<float>("alcohol");
    //            data.Quality = csv.GetField<int>("quality");


    //        }

    //        return data;
    //    }
    //    public List<Wine> ImportAllSamples(string filename_samples_csv)
    //    {
    //        List<Wine> data;

    //        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    //        {
    //            Delimiter = ";",
    //        };

    //        using (var reader = new StreamReader(filename_samples_csv))
    //        using (var csv = new CsvReader(reader, config))
    //        {
    //            data = csv.GetRecords<Wine>().ToList();
    //        }

    //        return data;
    //    }
    //    public void PrintInfo()
    //    {

    //    }
    //}

}
