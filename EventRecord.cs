using System;

namespace ConsoleApp1
{
    public class EventRecord : DomainEntity, ITrackable
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime OccurredAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public EventRecord(string title, string description, DateTime occurredAt)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название события не может быть пустым.", nameof(title));

            Title = title;
            Description = description;
            OccurredAt = occurredAt;
            CreatedAt = DateTime.Now;
        }
    }
}