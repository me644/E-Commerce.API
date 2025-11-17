namespace Domain.Entites.IdentityModule
{
    public class Address
    {
        public int id {  get; set; }

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;


        public string City { get; set; } = string.Empty;
        public string Street { get;set; } = string.Empty;

        public User user { get; set; }


        public string UserId {  get; set; }=string.Empty;

    }
}