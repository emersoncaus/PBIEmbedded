using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBIEmbedded.Application.Dtos;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Domain;
using PBIEmbedded.Persistence.Contexts;

namespace PBIEmbedded.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicePrincipalController : ControllerBase
    {
    private readonly IServicePrincipalService _servicePrincipalService;
        public ServicePrincipalController(IServicePrincipalService servicePrincipalService)
        {
            this._servicePrincipalService = servicePrincipalService;


        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalService.GetAllServicePrincipalsAsync();
                 if(servicePrincipal == null) return NotFound("No service principal found");

                 return Ok(servicePrincipal);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to recover service principals. Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalService.GetServicePrincipalByIdAsync(id);
                 if(servicePrincipal == null) return NotFound("No service principal found");

                 return Ok(servicePrincipal);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to recover service principal. Error: {ex.Message}");
            }
        }

        [HttpGet("{user}/user")]
        public async Task<IActionResult> GetByUser(string userEmail)
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalService.GetAllServicePrincipalsByUser(userEmail);
                 if(servicePrincipal == null) return NotFound("No service principals found by user");

                 return Ok(servicePrincipal);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to recover service principals by user. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServicePrincipalDto model)
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalService.AddServicePrincipal(model);
                 if(servicePrincipal == null)
                 {
                     return BadRequest("Error adding a new service principal");
                 }

                 return Ok(servicePrincipal);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to add a new service principal. Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ServicePrincipalDto model)
        {
            try
            {
                 var servicePrincipal = await _servicePrincipalService.UpdateServicePrincipal(id, model);
                 if(servicePrincipal == null) return BadRequest("Error updating a service principal");

                 return Ok(servicePrincipal);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to update a service principal. Error: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 return await _servicePrincipalService.DeleteServicePrincipal(id) ?
                        Ok("Deleted") : 
                        BadRequest("Undeleted service principal");

            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Error trying to delete a service principal. Error: {ex.Message}");
            }
        }
    }
}
