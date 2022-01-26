using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBIEmbedded.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        public IEnumerable<UserDto> Users { get; set; }
    }
}