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
    }
}
