using System;
using System.Threading.Tasks;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;

namespace PBIEmbedded.Application
{
    public class ServicePrincipalService : IServicePrincipalService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IServicePrincipalPersist _servicePrincipalPersist;
        public ServicePrincipalService(IGeneralPersist generalPersist, IServicePrincipalPersist servicePrincipalPersist)
        {
            this._servicePrincipalPersist = servicePrincipalPersist;
            this._generalPersist = generalPersist;
        }
        public async Task<ServicePrincipal> AddServicePrincipal(ServicePrincipal model)
        {
            try
            {
                 _generalPersist.Add<ServicePrincipal>(model);
                 if(await _generalPersist.SaveChangesAsync())
                 {
                    return await _servicePrincipalPersist.GetServicePrincipalByIdAsync(model.Id);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicePrincipal> UpdateServicePrincipal(int servicePrincipalId, ServicePrincipal model)
        {
            try
            {
                var servicePrincipal = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(servicePrincipalId);
                if(servicePrincipal == null) return null;

                model.Id = servicePrincipal.Id;

                _generalPersist.Update<ServicePrincipal>(model);
                 if(await _generalPersist.SaveChangesAsync())
                 {
                     return await _servicePrincipalPersist.GetServicePrincipalByIdAsync(model.Id);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteServicePrincipal(int servicePrincipalId)
        {
            try
            {
                var servicePrincipal = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(servicePrincipalId);
                if(servicePrincipal == null) throw new Exception("object not found to be deleted");

                _generalPersist.Delete<ServicePrincipal>(servicePrincipal);
                 return await _generalPersist.SaveChangesAsync();
                 
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicePrincipal[]> GetAllServicePrincipalsAsync(bool includeUsers = false)
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalPersist.GetAllServicePrincipalsAsync(includeUsers);
                 if(servicePrincipal == null) return null;

                 return servicePrincipal;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicePrincipal[]> GetAllServicePrincipalsByUser(string userEmail)
        {
             try
            {
                 var servicePrincipal = await _servicePrincipalPersist.GetAllServicePrincipalsByUser(userEmail);
                 if(servicePrincipal == null) return null;

                 return servicePrincipal;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicePrincipal> GetServicePrincipalByIdAsync(int servicePrincipalId)
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(servicePrincipalId);
                 if(servicePrincipal == null) return null;

                 return servicePrincipal;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}