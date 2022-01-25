using System.Collections.Generic;

namespace PBIEmbedded.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<ServicePrincipalUser> ServicePrincipalsUser { get; set; }
    }
}