using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBIEmbedded.Application.Dtos
{
    public class ServicePrincipalDto
    {
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }    

        [Required]
        public string SP_ID { get; set; }   

        [Required]    
        public string SecretID { get; set; }

        public IEnumerable<ServicePrincipalDto> ServicePrincipals { get; set; }

        public IEnumerable<UserDto> Users { get; set; }
    }
}