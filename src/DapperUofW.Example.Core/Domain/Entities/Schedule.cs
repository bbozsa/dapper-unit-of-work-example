namespace DapperUofW.Example.Core.Domain.Entities
{
    public class Schedule
    {
        private Schedule()
        {
            Appointments = new List<Appointment>();
        }

        public Guid Id { get; private init; }
        public Guid PhysicianId { get; private init; }
        public IList<Appointment> Appointments { get; private init; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public byte[]? ConcurrencyToken { get; private set; }

        public static Schedule Create(Guid physicianId)
        {
            if (physicianId == Guid.Empty)
            {
                throw new ArgumentException(nameof(physicianId));
            }

            var currentTime = DateTime.UtcNow;
            return new Schedule
            {
                Id = Guid.NewGuid(),
                PhysicianId = physicianId,
                CreatedDate = currentTime,
                LastModifiedDate = currentTime,
            };
        }
    }
}
