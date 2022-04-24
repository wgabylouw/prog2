﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2_interface_graphique.Models
{
    internal class Users : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        //private int _usersId;
        public int UsersId { get; set; }
        //{
        //    get { return this._usersId; }

        //    set 
        //    {
        //        if (this._usersId != value)
        //        {
        //            this._usersId = value;
        //            this.OnPropertyChanged();
        //        }
        //    }
        //}
       

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
        //public bool Homme
        //{
        //    get
        //    {
        //        return string.Equals(Sex, "Homme");
        //    }
        //    set
        //    {
        //        if (value)
        //            Sex = "Homme";
        //        else
        //            Sex = "Femme";
        //    }
        //}
        //[NotMapped]
        //public bool Femme
        //{
        //    get
        //    {
        //        return string.Equals(Sex, "Femme");
        //    }
        //    set
        //    {
        //        if (value)
        //            Sex = "Femme";
        //        else
        //            Sex = "Homme";
        //    }
        //}
        //private string _sex;
        //public string Sex
        //{
        //    get { return this._sex; }

        //    set
        //    {
        //        if (this._sex != value)
        //        {
        //            this._sex = value;

        //            this.SetIsValid();
        //            this.OnPropertyChanged();
        //        }
        //    }
        //}

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


        /*Affichage d'un utilisateur dans la BD :*/
        public static Users ShowUser(int usersId)
        {
            TP2Context tp2Context = new TP2Context();
            Users users = tp2Context.Users.Find(usersId);
            return users;
            //Console.WriteLine($"{users.UsersId} - {users.Name}");
        }


        /*Affichage de plusieurs utilisateurs dans la BD :*/
        public static List<Users> ShowUsers()
        {
            TP2Context tp2Context = new TP2Context();
            List<Users> userss = tp2Context.Users.ToList();

            return userss;

            //foreach (Users users in userss)
            //{
            //    Console.WriteLine($"{users.UsersId} - {users.Name}");
            //}
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
    }
}
