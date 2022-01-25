using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Application.Interfaces
{
    public interface IServicePrincipalService
    {
         Task<ServicePrincipal> AddServicePrincipal (ServicePrincipal model);
         Task<ServicePrincipal> UpdateServicePrincipal (int servicePrincipalId, ServicePrincipal model);
         Task<bool> DeleteServicePrincipal (int servicePrincipalId);
         Task<ServicePrincipal[]> GetAllServicePrincipalsAsync(bool includeUsers = false);
         Task<ServicePrincipal> GetServicePrincipalByIdAsync(int servicePrincipalId);
         Task<ServicePrincipal[]> GetAllServicePrincipalsByUser(string userEmail);
    }
}