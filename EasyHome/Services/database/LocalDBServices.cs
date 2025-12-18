using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyHome.Models;
using EasyHome.Services.database.Config;

namespace EasyHome.Services.database
{
    public class LocalDBServices
    {

        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await database.CreateTableAsync<Products>();
        }

        public async Task<List<Products>> GetItemsAsync()
        {
            await Init();
            return await database.Table<Products>().ToListAsync();
        }

        public async Task<Products> GetItemAsync(int id)
        {
            await Init();
            return await database.Table<Products>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Products item)
        {
            await Init();
            if (item.ID != 0)
                return await database.UpdateAsync(item);
            else
                return await database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Products item)
        {
            await Init();
            return await database.DeleteAsync(item);
        }
    }
}