using System.Threading.Tasks;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Application.Interfaces
{
    public interface IServicePrincipalService
    {
         Task<ServicePrincipalDto> AddServicePrincipal (ServicePrincipalDto model);
         Task<ServicePrincipalDto> UpdateServicePrincipal (int servicePrincipalId, ServicePrincipalDto model);
         Task<bool> DeleteServicePrincipal (int servicePrincipalId);
         Task<ServicePrincipalDto[]> GetAllServicePrincipalsAsync(bool includeUsers = false);
         Task<ServicePrincipalDto> GetServicePrincipalByIdAsync(int servicePrincipalId);
         Task<ServicePrincipalDto[]> GetAllServicePrincipalsByUser(string userEmail);
    }
}