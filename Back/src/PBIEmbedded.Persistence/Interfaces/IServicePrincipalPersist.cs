using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Persistence.Interface
{
    public interface IServicePrincipalPersist
    {
         Task<ServicePrincipal> GetServicePrincipalByIdAsync(int servicePrincipalId, bool includeUsers = false);
         Task<ServicePrincipal[]> GetAllServicePrincipalsAsync(bool includeUsers = false);
         Task<ServicePrincipal[]> GetAllServicePrincipalsByUser(string userEmail);
         
    }
}