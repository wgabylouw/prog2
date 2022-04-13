using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.Models
{
    internal class Parameters
    {
        public int ParametersId { get; set; }

        public int K { get; set; }

        public bool Algorithm { get; set; }

        public string TrainPath { get; set; }


        //public int PredictionsId { get; set; }

        public Predictions Predictions { get; set; }

    }
}
