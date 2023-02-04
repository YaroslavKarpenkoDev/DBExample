using DBCommon.Models;

namespace DataBaseExample.DB.Interfases;

public interface IBaseRepository
{
    public Task<List<T>> GetList<T>() where T : BaseDBModel, new();
    
    public Task<T> Get<T>(int id) where T : BaseDBModel, new();
    
    public Task Add<T>(T item) where T : BaseDBModel, new();
    
    public Task Update<T>(T item) where T : BaseDBModel, new();

    public Task Delete<T>(int id) where T : BaseDBModel, new();
    
    public Task AddList<T>(List<T> items) where T : BaseDBModel, new();
    
    public Task InitTableAsync<T>() where T : BaseDBModel, new();
    
    public Task<List<T>> TestQuery<T>(string query) where T : BaseDBModel, new();
}