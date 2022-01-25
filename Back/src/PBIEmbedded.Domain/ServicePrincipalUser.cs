namespace PBIEmbedded.Domain
{
    public class ServicePrincipalUser
    {
        public int ServicePrincipalId { get; set; }
        public ServicePrincipal ServicePrincipal { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}