using System.Threading.Tasks;

namespace AWork.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}