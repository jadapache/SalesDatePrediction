
namespace  SalesDatePrediction.Application.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        TRepository Repository<TRepository>() where TRepository : class;

        Task Commit();
    }
}
