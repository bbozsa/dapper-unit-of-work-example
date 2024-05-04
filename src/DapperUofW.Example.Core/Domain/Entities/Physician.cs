namespace DapperUofW.Example.Core.Domain.Entities
{
    public class Physician
    {
        public Guid Id { get; private init; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private init; }
        public int EmployeeNumber { get; private init; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public byte[]? ConcurrencyToken { get; private set; }

        public static Physician Create(string firstName, string lastName, string email, int employeeNumber)
        {
            ArgumentException.ThrowIfNullOrEmpty(firstName);
            ArgumentException.ThrowIfNullOrEmpty(lastName);
            ArgumentException.ThrowIfNullOrEmpty(email);

            if (employeeNumber < 1)
            {
                throw new ArgumentException("Invalid employee number.", nameof(employeeNumber));
            }

            var currentTime = DateTime.UtcNow;
            return new Physician
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                EmployeeNumber = employeeNumber,
                CreatedDate = currentTime,
                LastModifiedDate = currentTime
            };
        }
    }
}
