﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services 
{
    public class DatabaseService //: IDataStore<ItemModel>
    {

        

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });




        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
        public async Task<bool> CreateAsync(ItemModel item)
        {   
                Database.InsertAsync(item);
                return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel data)
        {
            //var oldData = datalist.Where((ItemModel arg) => arg.Id == data.Id).FirstOrDefault();
            //datalist.Remove(oldData);
            //datalist.Add(data);

            Database.UpdateAsync(data);

            return await Task.FromResult(true);
        }

        //public async Task<ItemModel> ReadAsync(string id)
        //{
        //    //return await Task.FromResult(datalist.FirstOrDefault(s => s.Id == id));
        //    return await Task.FromResult(Database.Table<ItemModel>().Where(i => i.Id == id).FirstOrDefaultAsync());

        //}

        //...
    }
}
