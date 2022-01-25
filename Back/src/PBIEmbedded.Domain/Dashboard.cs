using System.Collections.Generic;

namespace PBIEmbedded.Domain
{
    public class Dashboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Report_ID { get; set; }
        public string Area { get; set; }
        public IEnumerable<DashboardServicePrincipal> DashboardServicePrincipals { get; set; }
    }
}