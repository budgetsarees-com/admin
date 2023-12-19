namespace Bs.BusinessCentral.Admin.Web.Services;

public interface IServiceBase<T>
{
    Task<T> GetAsync(int id);

    Task<List<T>> GetAsync();

    Task SaveAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(int id);
}
