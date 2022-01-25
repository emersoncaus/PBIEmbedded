using System.Collections.Generic;

namespace PBIEmbedded.Domain
{
    public class ServicePrincipal
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string SP_ID { get; set; }       
        public string SecretID { get; set; }
        public IEnumerable<DashboardServicePrincipal> DashboardServicePrincipals { get; set; }
        public IEnumerable<ServicePrincipalUser> ServicePrincipalsUser { get; set; }
        
    }
}