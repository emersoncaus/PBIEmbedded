using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBIEmbedded.Application.Dtos
{
    public class DashboardDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Report_ID { get; set; }
        
        [Required]
        public string Area { get; set; }
        
        public IEnumerable<ServicePrincipalDto> ServicePrincipals { get; set; }
    }
}