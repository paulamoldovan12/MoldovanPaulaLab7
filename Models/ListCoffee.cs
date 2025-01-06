using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MoldovanPaulaLab7.Models
{
    public class ListCoffee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(CoffeeList))]
        public int CoffeeListID { get; set; }

        public int CoffeeID { get; set; }
    }
}
