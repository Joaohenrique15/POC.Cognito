using System.Threading.Tasks;

namespace POC.Cognito.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}