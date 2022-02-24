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
    internal class KNN : IKNN
    {
        private List<Wine> data_train;
        private int K;
        private int Sort_Algorithm;
        /* à compléter */
        public void Train(string filename_train_samples_csv, int k = 1, int sort_algorithm = 1)
        {
            data_train =  this.ImportAllSamples(filename_train_samples_csv);
            K = k;
            Sort_Algorithm = sort_algorithm;


            foreach (var item in data_train)
            {
                item.PrintInfo();
            }
        }
        public float EuclideanDistance(Wine first_sample, Wine second_sample)
        {
            float distance =0;

            for (int i = 0;i<first_sample.Features.Length;i++)
            {
                distance += (float)Math.Pow((first_sample.Features[i] - second_sample.Features[i]),2);
            }
            distance = (float)Math.Sqrt(distance);


            return distance;
        }
        public List<Wine> ImportAllSamples(string _filename_samples_csv)
        {
            List<Wine> data;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var reader = new StreamReader(_filename_samples_csv))
            using (var csv = new CsvReader(reader, config))
            {
                data = csv.GetRecords<Wine>().ToList();
            }

            return data;
        }
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
                csv.Read();
                csv.ReadHeader();

                csv.Read();
                data.VolatileAcidity = csv.GetField<float>("volatile acidity");
                data.CitricAcid = csv.GetField<float>("citric acid");
                data.Sulphates = csv.GetField<float>("sulphates");
                data.Alcohol = csv.GetField<float>("alcohol");
                data.Label = csv.GetField<int>("quality");
            }

            return data;
        }
        public int Predict(Wine sample_to_predict)
        {
            List<float> listeDistance = new List<float>();
            List<int> listeLabels = new List<int>();
            for (int i=0;i<data_train.Count();i++)
            {
                listeDistance.Add(EuclideanDistance(sample_to_predict, data_train[i]));
                listeLabels.Add(data_train[i].Label);
            }

            if (Sort_Algorithm == 1)
                this.SelectionSort(listeDistance, listeLabels);
            else 
                this.ShellSort(listeDistance, listeLabels);
             



            return this.Vote(listeLabels);
        }
        public int Vote(List<int> sorted_labels)
        {
            int compteur3=0,compteur6=0,compteur9 = 0;

            for (int i=0; i<K;i++)
            {
                if (sorted_labels[i] == 3)
                    compteur3++;
                else if (sorted_labels[i] == 6)
                    compteur6++;
                else compteur9++;
            }
            // a refaire pour les cas d'exeptions
            if (compteur3 > compteur6 && compteur3 > compteur9)
                return 3;
            else if (compteur9 > compteur3 && compteur9 > compteur6)
                return 9;
            else return 6;
        }
        public void ShellSort(List<float> distances, List<int> labels)
        {
            int compteur = distances.Count();
            int n = 0;
            float temp;
            int temp2;
            int j;
            while (n < compteur)
            {
                n = 3 * n + 1;
            }
            while (n != 0)
            {
                n = n / 3;
                for (int i = n; i < compteur; i++)
                {
                    temp = distances[i];
                    temp2 = labels[i];
                    j = i;
                    while (j > n - 1 && distances[j - n] > temp)
                    {
                        distances[j] = distances[j - n];
                        labels[j] = labels[j - n];
                        j = j - n;
                    }
                    distances[j] = temp;
                    labels[j] = temp2;
                }
            }
        }
        public void SelectionSort(List<float> distances, List<int> labels)
        {
            float temp;
            int min;
            int compteur = distances.Count();
            for (int i = 0; i < compteur; i++)
            {
                min = i;
                for (int j = i + 1; j < compteur; j++)
                {
                    if (distances[j] < distances[min])
                        min = j;
                }
                if (min != i)
                {
                    temp = distances[min];
                    distances[min] = distances[i];
                    distances[i] = temp;
                    temp = labels[min];
                    labels[min] = labels[i];
                    labels[i] = (int)temp;
                }
            }
        }



    }
}
