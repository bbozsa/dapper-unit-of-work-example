namespace DapperUofW.Example.Core.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private init; }
        public string Description { get; private init; }
        public int TotalAmount { get; private init; }

        public static Order Create(string description, int totalAmount)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (totalAmount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalAmount));
            }

            return new Order
            {
                Id = Guid.NewGuid(),
                Description = description,
                TotalAmount = totalAmount
            };
        }
    }
}
