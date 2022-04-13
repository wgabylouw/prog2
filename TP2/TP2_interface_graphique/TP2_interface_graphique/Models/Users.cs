using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.Models
{
    internal class Users
    {
        public int UsersId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Sex { get; set; }

        public string Birthday { get; set; }

        public List<Predictions> Predictions { get; set; }


        public Users()
        {
            Predictions = new List<Predictions>();
        }

    }
}
