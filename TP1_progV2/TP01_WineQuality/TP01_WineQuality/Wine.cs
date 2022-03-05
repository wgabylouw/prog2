using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace TP01_WineQuality
{
    internal class Wine : IWine
    {
        /* à compléter */
        [CsvHelper.Configuration.Attributes.Name("volatile acidity")]
        public float VolatileAcidity { get; set; }
        [CsvHelper.Configuration.Attributes.Name("citric acid")]
        public float CitricAcid { get; set; }
        [CsvHelper.Configuration.Attributes.Name("sulphates")]
        public float Sulphates { get; set; }
        [CsvHelper.Configuration.Attributes.Name("alcohol")]
        public float Alcohol { get; set; }

        [CsvHelper.Configuration.Attributes.Name("quality")]
        public int Label { get; set; }


        public float[] Features { get
            { return new float[] { this.Alcohol, this.Sulphates,this.CitricAcid,this.VolatileAcidity }; }
        }


        /* 2.3 Méthod Wine PrintInfor || Entrée : aucune || Sortie : aucune || Rôle : Format d'affichage graphique "Train List Objet"*/
        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0:00.0} | {1:0.00} | {2:0.00} | {3:0.000} | {4:0}",
                this.Alcohol, this.Sulphates, this.CitricAcid, this.VolatileAcidity, this.Label));
        }
    }
}
