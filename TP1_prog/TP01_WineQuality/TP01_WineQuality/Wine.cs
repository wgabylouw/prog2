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
    class Wine
    {
        private float fixedAcidity;
        private float volatileAcidity;
        private float citricAcid;
        private float residualSugar;
        private float chlorides;
        private float freeSulfurDioxide;
        private float totalSulfurDioxide;
        private float density;
        private float pH;
        private float sulphates;
        private float alcohol;
        private int quality;



        public Wine ImportOneSample(string filename_sample_csv)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };
            using (var reader = new StreamReader(filename_sample_csv))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<entete>();
                var records = csv.GetRecords<Wine>();
            }



        //}
        public float FixedAcidity { get; set; }
        public float VolatileAcidity { get; set; }
        public float CitricAcid { get; set; }
        public float ResidualSugar { get; set; }
        public float Chlorides { get; set; }
        public float FreeSulfurDioxide { get; set; }
        public float TotalSulfurDioxide { get; set; }
        public float Density { get; set; }
        public float PH { get; set; }
        public float Sulphates { get; set; }
        public float Alcohol { get; set; }
        public int Quality { get; set; }
        
        public sealed class entete : ClassMap<Wine>
        {
            public entete()
            {
                AutoMap(CultureInfo.InvariantCulture);
                Map(m => m.fixedAcidity).Name("fixed acidity");
                Map(m => m.VolatileAcidity).Name("volatile acidity");
                Map(m => m.CitricAcid).Name("citric acid");
                Map(m => m.ResidualSugar).Name("residual sugar");
                Map(m => m.FreeSulfurDioxide).Name("free sulfur dioxide");
                Map(m => m.TotalSulfurDioxide).Name("total sulfur dioxide");

            }
        }
    }
}
