using System;
using System.Threading.Tasks;
using AutoMapper;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;

namespace PBIEmbedded.Application
{
    public class ServicePrincipalService : IServicePrincipalService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IServicePrincipalPersist _servicePrincipalPersist;
        private readonly IMapper _mapper;
        public ServicePrincipalService(IGeneralPersist generalPersist,
                                       IServicePrincipalPersist servicePrincipalPersist,
                                       IMapper mapper)
        {
            this._servicePrincipalPersist = servicePrincipalPersist;
            this._generalPersist = generalPersist;
            this._mapper = mapper;
        }
    public async Task<ServicePrincipalDto> AddServicePrincipal(ServicePrincipalDto model)
    {
        try
        {
            var sp = _mapper.Map<ServicePrincipal>(model);

            _generalPersist.Add<ServicePrincipal>(sp);
            if (await _generalPersist.SaveChangesAsync())
            {
                var result = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(sp.Id);
                return _mapper.Map<ServicePrincipalDto>(result);
            }
            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<ServicePrincipalDto> UpdateServicePrincipal(int servicePrincipalId, ServicePrincipalDto model)
    {
        try
        {
            var servicePrincipal = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(servicePrincipalId);
            if (servicePrincipal == null) return null;

            model.Id = servicePrincipal.Id;

            var sp = _mapper.Map<ServicePrincipal>(model);

            _generalPersist.Update<ServicePrincipal>(sp);

            if (await _generalPersist.SaveChangesAsync())
            {
                var result = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(servicePrincipal.Id);
                return _mapper.Map<ServicePrincipalDto>(result);
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
            if (servicePrincipal == null) throw new Exception("object not found to be deleted");

            _generalPersist.Delete<ServicePrincipal>(servicePrincipal);
            return await _generalPersist.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<ServicePrincipalDto[]> GetAllServicePrincipalsAsync(bool includeUsers = false)
    {
        try
        {
            var servicePrincipals = await _servicePrincipalPersist.GetAllServicePrincipalsAsync(includeUsers);
            if (servicePrincipals == null) return null;

            var result = _mapper.Map<ServicePrincipalDto[]>(servicePrincipals);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<ServicePrincipalDto[]> GetAllServicePrincipalsByUser(string userEmail)
    {
        try
        {
            var servicePrincipals = await _servicePrincipalPersist.GetAllServicePrincipalsByUser(userEmail);
            if (servicePrincipals == null) return null;

            var result = _mapper.Map<ServicePrincipalDto[]>(servicePrincipals);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<ServicePrincipalDto> GetServicePrincipalByIdAsync(int servicePrincipalId)
    {
        try
        {
            var servicePrincipals = await _servicePrincipalPersist.GetServicePrincipalByIdAsync(servicePrincipalId);
            if (servicePrincipals == null) return null;

            var result = _mapper.Map<ServicePrincipalDto>(servicePrincipals);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
}