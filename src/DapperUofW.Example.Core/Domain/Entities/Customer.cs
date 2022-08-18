namespace DapperUofW.Example.Core.Domain.Entities
{
    public class Customer
    {
        private Customer()
        {
            Orders = new List<Order>();
        }

        public Guid Id { get; private init; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private init; }
        public IList<Order> Orders { get; private init; }

        public static Customer Create(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }

        public void ChangeName(string newFirstName, string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
            {
                throw new ArgumentNullException(nameof(newFirstName));
            }

            if (string.IsNullOrWhiteSpace(newLastName))
            {
                throw new ArgumentNullException(nameof(newLastName));
            }

            FirstName = newFirstName;
            LastName = newLastName;
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            Orders.Add(order);
        }
    }
}
