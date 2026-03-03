using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public Email Email { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public int RoleId { get; private set; }

        private User() { } //Required for FE core //EF Core needs a parameterless constructor.

        private User(string name, Email email, string passwordHash, int roleId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }

        public static User Create(string name, Email email, string passwordHash, int roleId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            if (name.Length > 100)
                throw new ArgumentException("Name too long.");

            if (roleId <= 0)
                throw new ArgumentException("Invalid role.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash is required.");

            return new User(name, email, passwordHash, roleId);
        }
    }
}
