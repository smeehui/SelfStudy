namespace CRUDProductApp_API.Service
{
    public interface IGeneralService<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Remove(Guid guid);
        T? GetById(Guid id);
        List<T> GetAll();
    }
}
