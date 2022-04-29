using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TP2_interface_graphique.Models
{
    internal class Users : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int UsersId { get; set; }       

        private string _name;
        public string Name
        {
            get { return this._name; }

            set
            {
                if (this._name != value)
                {
                    this._name = value;

                    this.SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _firstName;
        public string FirstName
        {
            get { return this._firstName; }

            set
            {
                if (this._firstName != value)
                {
                    this._firstName = value;

                    this.SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _city;
        public string City
        {
            get { return this._city; }

            set
            {
                if (this._city != value)
                {
                    this._city = value;

                    this.SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _email;
        public string Email 
        {
            get { return this._email; }

            set
            {
                if (this._email != value)
                {
                    this._email = value;

                    this.SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }


        //Ajouter [NotMapped] au valeur qu'on ne veut pas dans la BD
        //[NotMapped]

        private ViewModels.OptionSex _sex;
        public ViewModels.OptionSex Sex
        {
            get { return this._sex; }

            set
            {
                this._sex = value;

                this.SetIsValid();
                this.OnPropertyChanged();
            }
        }

        private string _birthday;
        public string Birthday
        {
            get { return this._birthday; }

            set
            {
                if (this._birthday != value)
                {
                    this._birthday = value;

                    this.SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }

        public List<Predictions> Predictions { get; set; }


        public Users()
        {
            Predictions = new List<Predictions>();
        }


        private bool _isValid;
        [NotMapped]
        public bool IsValid
        {
            get { return this._isValid; }
        }
        private void SetIsValid()
        {
            this._isValid = !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.City)
                            && !string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Birthday);
        }
        public bool TestIsValid()
        {

            return (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.City)
                            && !string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Birthday));
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        /*Créer un nouvel un utilisateur dans la BD :*/
        public static void AddUser(Users users)
        {
            TP2Context tp2Context = new TP2Context();
            tp2Context.Users.Add(users);
            tp2Context.SaveChanges();

        }


        /*Aller chercher un utilisateur dans la BD :*/
        public static Users GetUser(int usersId)
        {
            TP2Context tp2Context = new TP2Context();
            Users users = tp2Context.Users.Find(usersId);
            return users;
        }


        /*Affichage de plusieurs utilisateurs dans la BD :*/
        public static List<Users> GetUsers()
        {
            TP2Context tp2Context = new TP2Context();
            List<Users> userss = tp2Context.Users.ToList();

            return userss;
        }


        /*Modifier les paramètres d'utilisateur dans la BD :*/
        public static void UpdateUser(Users _user) //int usersId, string _name, string _firstName, string _city, string _email, ViewModels.OptionSex _sex, string _birthday
        {
            TP2Context tp2Context = new TP2Context();
            Users User = tp2Context.Users.Find(_user.UsersId);
            
            User.Name = _user.Name;
            User.FirstName = _user.FirstName;
            User.City = _user.City;
            User.Email = _user.Email;
            User.Sex = _user.Sex;
            User.Birthday = _user.Birthday;

            tp2Context.SaveChanges();
        }

        //public static List<Models.Predictions> ShowPredictionOfUser(int UserId)
        //{
        //    TP2Context TP2Context = new TP2Context();
        //    List<Models.Predictions> predictions1 = new List<Models.Predictions>();
        //    Models.Users users = TP2Context.Users.Include(u => u.Predictions).Where(u => u.UsersId == UserId).First();

        //    foreach (Models.Predictions predictions in users.Predictions)
        //    {
        //        predictions1.Add(predictions);
        //    }
        //    return predictions1;
        //}
    }
}
