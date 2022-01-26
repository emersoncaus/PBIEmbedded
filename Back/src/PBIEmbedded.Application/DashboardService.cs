using System;
using System.Threading.Tasks;
using AutoMapper;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;

namespace PBIEmbedded.Application
{
    public class DashboardService : IDashboardService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IDashboardPersist _dashboardPersist;
        private readonly IMapper _mapper;
        public DashboardService(IGeneralPersist generalPersist,
                                IDashboardPersist dashboardPersist,
                                IMapper mapper)
        {
            this._dashboardPersist = dashboardPersist;
            this._generalPersist = generalPersist;
            this._mapper = mapper;

        }
    public async Task<DashboardDto> AddDashboard(DashboardDto model)
    {
        try
        {
            var dash = _mapper.Map<Dashboard>(model);

            _generalPersist.Add<Dashboard>(dash);
            if (await _generalPersist.SaveChangesAsync())
            {
                var result = await _dashboardPersist.GetDashboardByIdAsync(dash.Id);
                return _mapper.Map<DashboardDto>(result);
            }
            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }

    public async Task<DashboardDto> UpdateDashboard(int dashboardId, DashboardDto model)
    {
        try
        {
            var dashboard = await _dashboardPersist.GetDashboardByIdAsync(dashboardId);
            if (dashboard == null) return null;

            model.Id = dashboard.Id;

            _mapper.Map(model, dashboard);

            _generalPersist.Update<Dashboard>(dashboard);
            if (await _generalPersist.SaveChangesAsync())
            {
                var result = await _dashboardPersist.GetDashboardByIdAsync(dashboard.Id);
                return _mapper.Map<DashboardDto>(result);
            }
            return null;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> DeleteDashboard(int dashboardId)
    {
        try
        {
            var dashboard = await _dashboardPersist.GetDashboardByIdAsync(dashboardId);
            if (dashboard == null) throw new Exception("object not found to be deleted");

            _generalPersist.Delete<Dashboard>(dashboard);
            return await _generalPersist.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<DashboardDto[]> GetAllDashboardsAsync()
    {
        try
        {
            var dashboards = await _dashboardPersist.GetAllDashboardsAsync();
            if (dashboards == null) return null;

            var result = _mapper.Map<DashboardDto[]>(dashboards);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<DashboardDto> GetDashboardByIdAsync(int dashboardId)
    {
        try
        {
            var dashboard = await _dashboardPersist.GetDashboardByIdAsync(dashboardId);
            if (dashboard == null) return null;

            var result = _mapper.Map<DashboardDto>(dashboard);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<DashboardDto[]> GetDashaboardsByServicePrincipalAsync(int servicePrincipalId)
    {
        try
        {
            var dashboards = await _dashboardPersist.GetDashaboardsByServicePrincipalAsync(servicePrincipalId);
            if (dashboards == null) return null;

            var result = _mapper.Map<DashboardDto[]>(dashboards);

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
}