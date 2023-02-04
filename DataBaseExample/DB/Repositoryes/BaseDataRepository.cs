using DataBaseExample.DB.Interfases;
using DBCommon.Models;
using SQLite;

namespace DataBaseExample.DB.Repositoryes;

public class BaseDataRepository : IBaseRepository
{
    public BaseDataRepository()
    {
        _connection = new SQLiteAsyncConnection(Config.DBPath);
    }
    
    private readonly SQLiteAsyncConnection _connection;
    
    public async Task InitTableAsync<T>() where T : BaseDBModel, new()
    {
       await _connection.CreateTableAsync<T>();
    }

    public async Task<List<T>> TestQuery<T>(string query) where T : BaseDBModel, new()
    {
        return await _connection.QueryAsync<T>(query, "a%");
    }

    public async Task<List<T>> GetList<T>() where T : BaseDBModel, new()
    {
        var result =  await _connection.Table<T>().ToListAsync();
        if (result != null)
        {
            return result;
        }

        return default;
    }

    public async Task<T> Get<T>(int id) where T : BaseDBModel, new()
    {
       return await _connection.FindAsync<T>(id);
    }

    public async Task Add<T>(T item) where T : BaseDBModel, new()
    {
        await _connection.InsertAsync(item);
    }

    public async Task Update<T>(T item) where T : BaseDBModel, new()
    {
        await _connection.UpdateAsync(item);
    }

    public async Task Delete<T>(int id) where T : BaseDBModel, new()
    {
        var item = await _connection.FindAsync<T>(id);
        if (item != null)
        {
            await _connection.DeleteAsync(item);
        }
    }

    public async Task AddList<T>(List<T> items) where T : BaseDBModel, new()
    {
        foreach (var item in items)
        {
            await _connection.InsertOrReplaceAsync(item);
        }
    }
}