using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.Models
{
    public class LigneMatriceConfusion
    {
        public int Label { get; set; }
        public int L3 { get; set; }
        public int L6 { get; set; }
        public int L9 { get; set; }

        public LigneMatriceConfusion(Dictionary<int, int[]> matriceInitial, int label)
        {
            Label = label;
            L3 = matriceInitial[label][0];
            L6 = matriceInitial[label][1];
            L9 = matriceInitial[label][2];
        }
    }
}
