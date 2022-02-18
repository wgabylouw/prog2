using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_WineQuality
{
    internal interface IKNN
    {
        /* main methods */
        void Train(string filename_train_set_csv, int k = 1, int sort_algorithm = 1);
        float Evaluate(string filename_test_set_csv);
        int Predict(string filename_sample_csv);
        /* utils */
        float EuclideanDistance(IWine first_sample, IWine second_sample);
        int Vote(List<int> sorted_labels);
        void ConfusionMatrix(List<int> predicted_labels, List<int> expert_labels);
        List<int> ShellSort(List<float> distances, List<int> labels);
        List<int> SelectionSort(List<float> distances, List<int> labels);
    }
}