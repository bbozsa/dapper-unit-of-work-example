namespace DapperUofW.Example.Core.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private init; }
        public Guid PhysicianId { get; private init; }
        public Guid PatientId { get; private init; }
        public string Description { get; private init; }
        public DateTime StartTime { get; private init; }
        public DateTime EndTime { get; private init; }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public byte[] ConcurrencyToken { get; private set; }

        public static Appointment Create(Guid physicianId, Guid patientId, string description, DateTime startTime, DateTime endTime)
        {
            if (physicianId == Guid.Empty)
            {
                throw new ArgumentException("Physician id cannot be empty.", nameof(physicianId));
            }

            if (patientId == Guid.Empty)
            {
                throw new ArgumentException("Patient id cannot be empty.", nameof(patientId));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (startTime >= endTime)
            {
                throw new ArgumentException("The appointment's start time must be before the appointment's end time.");
            }

            var currentTime = DateTime.UtcNow;
            return new Appointment
            {
                Id = Guid.NewGuid(),
                PhysicianId = physicianId,
                PatientId = patientId,
                Description = description,
                StartTime = startTime,
                EndTime = endTime,
                CreatedDate = currentTime,
                LastModifiedDate = currentTime,
            };
        }
    }
}
