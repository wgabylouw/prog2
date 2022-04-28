using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using KnnLibrary;
using CsvHelper;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP2_interface_graphique.ViewModels
{
    class FenetrePrincipaleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand MAJUserCommand { get; private set; }
        public ICommand OpenTrainCommand { get; private set; }
        public ICommand OpenTestCommand { get; private set; }
        public ICommand PredictionCommand { get; private set; }
        public ICommand RetourCommand { get; private set; }
        public Models.Users User { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public ObservableCollection<int> Ks { get; set; }

        public Models.Parameters Parameters { get; set; }
        public Models.Predictions Predictions { get; set; }

        public ObservableCollection<string> Algorithms { get; set; }
        public ObservableCollection<Models.Predictions> ListePredictionsUser { get; private set; }
        public ObservableCollection<Models.LigneMatriceConfusion> ListeMatriceConfusions { get; set; }
        public ObservableCollection<Wine> ListeWine { get; set; }
        public TP2Context TP2Context { get; set; }
        public KNN KNN { get; set; }
        private string _testPath;
        public string TestPath
        {
            get { return _testPath; }
            set
            {
                _testPath = value;
                OnPropertyChanged();
            }
        }
        private float _accuracy;
        public float Accuracy
        {
            get { return _accuracy; }
            set
            {
                _accuracy = value;
                OnPropertyChanged();
            }
        }



        public FenetrePrincipaleViewModel()
        {
            TP2Context = new TP2Context();
            ListeWine = new ObservableCollection<Wine>();
            KNN = new KNN();
            TestPath = "";
            Ks = new ObservableCollection<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Algorithms = new ObservableCollection<string>() { "selection", "shell" };
            ListeMatriceConfusions = new ObservableCollection<Models.LigneMatriceConfusion>();
            this.Cities = new ObservableCollection<string>()
            {
                "Québec",
                "Lévis",
                "Rimouski"
            };
            ListePredictionsUser = new ObservableCollection<Models.Predictions>();
            User = (Models.Users)Application.Current.Properties["test"];
            //User.Predictions = Models.Users.ShowPredictionOfUser(User.UsersId);
            Refresh();

            Parameters = new Models.Parameters();
            Parameters.K = 1;
            Predictions = new Models.Predictions();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //    txtEditor.Text = openFileDialog.FileName;

            OpenTrainCommand = new RelayCommand(
                o => true,
                o =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                        Parameters.TrainPath = openFileDialog.FileName;
                    foreach (Wine wine in KNN.ImportAllSamples(Parameters.TrainPath))
                        ListeWine.Add(wine);
                });

            OpenTestCommand = new RelayCommand(
                o => Parameters.IsValid,
                o =>
                {
                    KNN.Train(Parameters.TrainPath, Parameters.K,Parameters.Algorithm);
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        KNN.Evaluate(openFileDialog.FileName);
                        TestPath = openFileDialog.FileName;
                        AfficherMatriceConfusion();
                        Accuracy = KNN.Accuracy;
                    }
                });


            MAJUserCommand = new RelayCommand(
                o => User.TestIsValid(),
                o => {
                    Models.Users.UpdateUser(User);
                    MessageBox.Show($"Mise à jour du compte de {User.FirstName} {User.Name} réussit avec succès",
                                    "",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                });
            PredictionCommand = new RelayCommand(
                o => Parameters.IsValid && Predictions.IsValid,
                o => { CalculerQualite(); Refresh(); }
                ) ;
            RetourCommand = new RelayCommand(
                o => true,
                o => {
                    new MainWindow().Show();
                    fermer();
                }
                );


        }
        private void CalculerQualite()
        {
            Predictions.ParametersId = Models.Parameters.AddParameter(new Models.Parameters()
            {
                K = Parameters.K,
                TrainPath = Parameters.TrainPath,
                Algorithm = Parameters.Algorithm,
            });

            KNN knn = new KNN();
            Wine wine = new Wine()
            {
                Alcohol = Predictions.Alcohol,
                Sulphates = Predictions.Sulphates,
                CitricAcid = Predictions.CitricAcid,
                VolatileAcidity = Predictions.VolatileAcidity
            };
            knn.Train(Parameters.TrainPath,Parameters.K,Parameters.Algorithm);
            int result = knn.Predict(wine);
            Predictions.Quality = result;
            Predictions.UsersId = User.UsersId;

            Models.Predictions.AddPrediction(new Models.Predictions()
            {
                UsersId = Predictions.UsersId,
                ParametersId = Predictions.ParametersId,
                Sulphates = Predictions.Sulphates,
                CitricAcid = Predictions.CitricAcid,
                VolatileAcidity = Predictions.VolatileAcidity,
                Alcohol = Predictions.Alcohol,
                Quality = Predictions.Quality,
                DatePrediction = DateTime.Today
                

            });
            //Predictions.ParametersId = Parameters.ParametersId;




            if (result == 3)
                Predictions.ImagePath = "/Views/Image/third.png";
            else if (result == 6)
                Predictions.ImagePath = "/Views/Image/second.png";
            else if (result == 9)
                Predictions.ImagePath = "/Views/Image/first.png";
            else MessageBox.Show("Erreur !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            //MessageBox.Show(knn.Predict(wine).ToString());
        }
        private void Refresh()
        {
            ListePredictionsUser.Clear();
            foreach (Models.Predictions prediction in TP2Context.Predictions.Where(u => u.UsersId == User.UsersId).ToList())
                ListePredictionsUser.Add(prediction);
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AfficherMatriceConfusion()
        {
            ListeMatriceConfusions.Clear();
            
            ListeMatriceConfusions.Add(new Models.LigneMatriceConfusion(KNN.ConfusionMatrix, 3));
            ListeMatriceConfusions.Add(new Models.LigneMatriceConfusion(KNN.ConfusionMatrix, 6));
            ListeMatriceConfusions.Add(new Models.LigneMatriceConfusion(KNN.ConfusionMatrix, 9));
        }
        private void fermer()
        {
            var windows = Application.Current.Windows;
            for (var i = 0; i < windows.Count; i++)
                if (windows[i].DataContext == this)
                    windows[i].Close();
        }
    }
}
