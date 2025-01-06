using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoldovanPaulaLab7.Models
{
    public class Warehouse
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string WarehouseName { get; set; }

        public string Adress { get; set; }

        public string WarehouseDetails
        {
            get
            {
                return WarehouseName + " " + Adress;
            } 
        } 

        [OneToMany]
        public List<CoffeeList> CoffeeLists { get; set; }
    }
}
