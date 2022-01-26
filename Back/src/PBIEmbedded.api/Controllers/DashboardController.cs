using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Application.Interfaces;

namespace PBIEmbedded.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            this._dashboardService = dashboardService;


        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var dashboards = await _dashboardService.GetAllDashboardsAsync();
                 if(dashboards == null) return NoContent();

                
                 return Ok(dashboards);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to recover dashboards. Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var dashboard = await _dashboardService.GetDashboardByIdAsync(id);
                 if(dashboard == null) return NoContent();

                 return Ok(dashboard);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to recover dashboard. Error: {ex.Message}");
            }
        }

        // [HttpGet("{area}/area")]
        // public async Task<IActionResult> GetByArea(string area)
        // {
        //     try
        //     {
        //          var dashboards = await _dashboardService.GetDashboardsByAreaAsync(area);
        //          if(dashboards == null) return NotFound("No dashboard found by area");

        //          return Ok(dashboards);
        //     }
        //     catch (Exception ex)
        //     {
                
        //         return this.StatusCode(StatusCodes.Status500InternalServerError,
        //         $"Error trying to recover dashboards by area. Error: {ex.Message}");
        //     }
        // }

        [HttpGet("{servicePrincipalId}/servicePrincipalId")]
        public async Task<IActionResult> GetByServicePrincipal(int servicePrincipalId)
        {
            try
            {
                 var dashboards = await _dashboardService.GetDashaboardsByServicePrincipalAsync(servicePrincipalId);
                 if(dashboards == null) return NoContent();

                 return Ok(dashboards);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to recover dashboards by service principal. Error: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(DashboardDto model)
        {
            try
            {
                 var dashboards = await _dashboardService.AddDashboard(model);
                 if(dashboards == null)
                 {
                     return BadRequest("Error adding a new dashboard");
                 }

                 return Ok(dashboards);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to add a new dashboard. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DashboardDto model)
        {
            try
            {
                 var dashboard = await _dashboardService.UpdateDashboard(id, model);
                 if(dashboard == null) return BadRequest("Error updating a dashboard");

                 return Ok(dashboard);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to update a dashboard. Error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 return await _dashboardService.DeleteDashboard(id) ?
                        Ok("Deleted") : 
                        BadRequest("Undeleted dashboard");

            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to delete a dashboard. Error: {ex.Message}");
            }
        }

    }
}