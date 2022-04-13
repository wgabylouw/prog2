using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.Models
{
    internal class Predictions
    {
        public int PredictionsId { get; set; }

        public int Quality { get; set; }

        public float Alcohol { get; set; }

        public float Sulphates { get; set; }

        public float CitricAcid { get; set; }

        public float VolatileAcidity { get; set; }


        public int UsersId { get; set; }

        public Users Users { get; set; }


        public int ParametersId { get; set; }

        public Parameters Parameters { get; set; }
    }
}
