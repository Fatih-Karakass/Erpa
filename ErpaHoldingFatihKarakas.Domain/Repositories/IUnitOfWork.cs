namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
