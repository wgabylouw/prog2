using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.Models
{
    internal class Parameters : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int ParametersId { get; set; }

        private int _k;
        public int K
        {
            get { return this._k; }
            set
            {
                if (this._k != value)
                {
                    _k = value;
                    _isValid = TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }

        private string _algorithm;
        public string Algorithm
        {
            get { return this._algorithm; }
            set
            {
                if (this._algorithm != value)
                {
                    _algorithm = value;
                    _isValid = TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }

        private string _trainPath;
        public string TrainPath
        {
            get { return this._trainPath; }
            set
            {
                if (this._trainPath != value)
                {
                    _trainPath = value;
                    _isValid = TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }


        //public int PredictionsId { get; set; }

        public Predictions Predictions { get; set; }
        private bool _isValid;
        public bool IsValid { get { return this._isValid; } }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool TestIsValid()
        {
            return (!string.IsNullOrEmpty(this.TrainPath) && !string.IsNullOrEmpty(this.Algorithm));
        }
        public static int AddParameter(Parameters param)
        {
            TP2Context tp2Context = new TP2Context();
            tp2Context.Parameters.Add(param);
            tp2Context.SaveChanges();
            return param.ParametersId;
        }
    }
}
