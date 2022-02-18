using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_WineQuality
{
    internal interface IWine
    {
        Wine ImportOneSample(string filename_sample_csv);
        List<Wine> ImportAllSamples(string filename_samples_csv);
        void PrintInfo();
    }
}
