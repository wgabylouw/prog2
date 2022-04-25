using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.Models
{
    internal class Predictions : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int PredictionsId { get; set; }

        public int Quality { get; set; }

        private float _alcohol = float.NaN;
        public float Alcohol
        {
            get { return this._alcohol; }
            set
            {
                if (this._alcohol != value)
                {
                    _alcohol = value;
                    _isValid = this.TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }

        private float _sulphates = float.NaN;
        public float Sulphates
        {
            get { return this._sulphates; }
            set
            {
                if (this._sulphates != value)
                {
                    _sulphates = value;
                    _isValid = this.TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }
        private float _citricAcid = float.NaN;
        public float CitricAcid
        {
            get { return this._citricAcid; }
            set
            {
                if (this._citricAcid != value)
                {
                    _citricAcid = value;
                    _isValid = this.TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }
        private float _volatileAcidity = float.NaN;
        public float VolatileAcidity
        {
            get { return this._volatileAcidity; }
            set
            {
                if (this._volatileAcidity != value)
                {
                    _volatileAcidity = value;
                    _isValid = this.TestIsValid();
                    this.OnPropertyChanged();
                }

            }
        }


        public int UsersId { get; set; }

        public Users Users { get; set; }


        public int ParametersId { get; set; }

        public Parameters Parameters { get; set; }

        private bool _isValid;
        public bool IsValid { get { return this._isValid; } }

        public bool TestIsValid()
        {
            return (!float.IsNaN(this.Alcohol) && !float.IsNaN(this.Sulphates) &&
                    !float.IsNaN(this.CitricAcid) && !float.IsNaN(this.VolatileAcidity));
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public static void AddPrediction(Predictions predict)
        {
            TP2Context tp2Context = new TP2Context();
            tp2Context.Predictions.Add(predict);
            tp2Context.SaveChanges();


        }
    }
}
