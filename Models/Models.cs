namespace WebFamilyKey2.Models
{
    public class User
    {
        public int Id { get; set; }       // chave primária
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int TenantId { get; set; }
    }
}
