namespace AppAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}