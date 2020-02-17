﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mine.Models;
namespace Mine.Services
{
    /// <summary>
    /// Interface for data intreactions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        Task<bool> CreateAsync(T Data);
        Task<bool> UpdateAsync(T Data);
        Task<bool> DeleteAsync(string id);
        Task<T> ReadAsync(string id);
        Task<List<ItemModel>> IndexAsync(bool forceRefresh = false);
    }
}