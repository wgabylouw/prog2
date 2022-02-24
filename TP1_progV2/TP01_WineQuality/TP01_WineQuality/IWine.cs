using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_WineQuality
{
    internal interface IWine
    {
        float[] Features { get; }
        int Label { get; }
        void PrintInfo();
    }
}
