namespace CookieAuthSystem.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public ICollection<Role> Roles { get; private set; } = new HashSet<Role>();

        public User() { }

        public User(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public void AddRole(Role role)
        {
            Roles.Add(role);
        }

        public void RemoveRole(Role role)
        {
            Roles.Remove(role);
        }

        public bool IsPasswordMatch(string password)
        {
            return Password == password;
        }
    }
}
