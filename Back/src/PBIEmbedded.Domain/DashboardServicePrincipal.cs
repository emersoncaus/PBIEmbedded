namespace PBIEmbedded.Domain
{
    public class DashboardServicePrincipal
    {
        public int DashboardId { get; set; }
        public Dashboard Dashboard { get; set; }
        public int ServicePrincipalId { get; set; }
        public ServicePrincipal ServicePrincipal { get; set; }
    }
}