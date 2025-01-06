using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MoldovanPaulaLab7.Models;

namespace MoldovanPaulaLab7.Data
{
    public class CoffeeListDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CoffeeListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CoffeeList>().Wait();
            _database.CreateTableAsync<Coffee>().Wait();
            _database.CreateTableAsync<ListCoffee>().Wait();
            _database.CreateTableAsync<Warehouse>().Wait();
        }
        public Task<int> SaveCoffeeAsync(Coffee coffee)
        {
            if (coffee.ID != 0)
            {
                return _database.UpdateAsync(coffee);
            }
            else
            {
                return _database.InsertAsync(coffee);
            }
        }


        public Task<int> DeleteCoffeeAsync(Coffee coffee)
        {
            return _database.DeleteAsync(coffee);
        }

        public Task<List<Coffee>> GetCoffeesAsync()
        {
            return _database.Table<Coffee>().ToListAsync();
        }
        public Task<List<CoffeeList>> GetCoffeeListsAsync()
                {
                    return _database.Table<CoffeeList>().ToListAsync();
                }

        public Task<CoffeeList> GetCoffeeListAsync(int id)
        {
            return _database.Table<CoffeeList>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCoffeeListAsync(CoffeeList clist)
        {
            if (clist.ID != 0)
            {
                return _database.UpdateAsync(clist);
            }
            else
            {
                return _database.InsertAsync(clist);
            }
        }

        public Task<int> DeleteCoffeeListAsync(CoffeeList clist)
        {
            return _database.DeleteAsync(clist);
        }

        public Task<int> SaveListCoffeeAsync(ListCoffee listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }

        public Task<List<Coffee>> GetListCoffeesAsync(int coffeelistid)
        {
            return _database.QueryAsync<Coffee>(
         "select C.ID, C.Description from Coffee C"
         + " inner join ListCoffee LC"
         + " on C.ID = LC.CoffeeID where LC.CoffeeListID = ?",
         coffeelistid);

        }

        public Task<List<Warehouse> GetWarehousesAsync()
        {
            return _database.Table<Warehouse>().ToListAsync();
        }


        public Task<int> SaveWarehouseAsync(Warehouse warehouse)
        {
            if (warehouse.ID != 0)
            {
                return _database.UpdateAsync(warehouse);
            }
            else
            {
                return _database.InsertAsync(warehouse);
            }
        }
    }
}
