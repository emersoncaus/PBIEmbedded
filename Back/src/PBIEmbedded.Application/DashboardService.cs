using System;
using System.Threading.Tasks;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Interface;

namespace PBIEmbedded.Application
{
    public class DashboardService : IDashboardService
    {
        private readonly IGeneralPersist _generalPersist;
        private readonly IDashboardPersist _dashboardPersist;
        public DashboardService(IGeneralPersist generalPersist, IDashboardPersist dashboardPersist)
        {
            this._dashboardPersist = dashboardPersist;
            this._generalPersist = generalPersist;

        }
        public async Task<Dashboard> AddDashboard(Dashboard model)
        {
            try
            {
                 _generalPersist.Add<Dashboard>(model);
                 if(await _generalPersist.SaveChangesAsync())
                 {
                    return await _dashboardPersist.GetDashboardByIdAsync(model.Id);
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            } 
            
        }

        public async Task<Dashboard> UpdateDashboard(int dashboardId, Dashboard model)
        {
            try
            {
                var dashboard = await _dashboardPersist.GetDashboardByIdAsync(dashboardId);
                if(dashboard == null) return null;

                model.Id = dashboard.Id;

                _generalPersist.Update<Dashboard>(model);
                 if(await _generalPersist.SaveChangesAsync())
                 {
                     return await _dashboardPersist.GetDashboardByIdAsync(model.Id);
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
                if(dashboard == null) throw new Exception("object not found to be deleted");

                _generalPersist.Delete<Dashboard>(dashboard);
                 return await _generalPersist.SaveChangesAsync();
                 
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Dashboard[]> GetAllDashboardsAsync()
        {
            try
            {
                 var dashboard = await _dashboardPersist.GetAllDashboardsAsync();
                 if(dashboard == null) return null;

                 return dashboard;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Dashboard> GetDashboardByIdAsync(int dashboardId)
        {
            try
            {
                 var dashboard = await _dashboardPersist.GetDashboardByIdAsync(dashboardId);
                 if(dashboard == null) return null;

                 return dashboard;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        // public async Task<Dashboard[]> GetDashboardsByAreaAsync(string area)
        // {
        //     try
        //     {
        //          var dashboard = await _dashboardPersist.GetDashboardsByAreaAsync(area);
        //          if(dashboard == null) return null;

        //          return dashboard;
        //     }
        //     catch (Exception ex)
        //     {
                
        //         throw new Exception(ex.Message);
        //     }
        // }

        public async Task<Dashboard[]> GetDashaboardsByServicePrincipalAsync(int servicePrincipalId)
        {
            try
            {
                 var dashboard = await _dashboardPersist.GetDashaboardsByServicePrincipalAsync(servicePrincipalId);
                 if(dashboard == null) return null;

                 return dashboard;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}