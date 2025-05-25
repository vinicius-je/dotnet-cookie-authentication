namespace CookieAuthSystem.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public ICollection<User> Users { get; private set; } = new List<User>();

        public Role() { }

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
