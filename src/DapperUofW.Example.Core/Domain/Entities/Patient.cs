namespace DapperUofW.Example.Core.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private init; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private init; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public byte[]? ConcurrencyToken { get; private set; }

        public static Patient Create(string firstName, string lastName, string email)
        {
            ArgumentException.ThrowIfNullOrEmpty(firstName);
            ArgumentException.ThrowIfNullOrEmpty(lastName);
            ArgumentException.ThrowIfNullOrEmpty(email);

            var currentTime = DateTime.UtcNow;
            return new Patient
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CreatedDate = currentTime,
                LastModifiedDate = currentTime
            };
        }
    }
}
