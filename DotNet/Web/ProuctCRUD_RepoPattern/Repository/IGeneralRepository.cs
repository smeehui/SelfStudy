namespace ProductCRUD_RepoPattern.Repository
{
    public interface IGeneralRepository<T>
    {
        T Add(T dto);
        T Update(Guid id,T dto);
        void Remove(Guid guid);
        T? GetById(Guid id);
        List<T> GetAll();
    }
}
