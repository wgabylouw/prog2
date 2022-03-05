using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_WineQuality
{
    internal interface IKNN
    {
        /* main methods */
        void Train(string filename_train_samples_csv, int k = 1, int sort_algorithm = 1);
        float Evaluate(string filename_test_samples_csv);
        int Predict(Wine sample_to_predict);
        ///* utils */
        float EuclideanDistance(Wine first_sample, Wine second_sample);
        int Vote(List<int> sorted_labels);
        void ConfusionMatrix(List<int> predicted_labels, List<int> expert_labels, int[] labels);
        void ShellSort(List<float> distances, List<int> labels);
        void SelectionSort(List<float> distances, List<int> labels);
        Wine ImportOneSample(string filename_sample_csv);
        List<Wine> ImportAllSamples(string filename_samples_csv);
    }
}
