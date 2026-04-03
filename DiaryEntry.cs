using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class DiaryEntry : DomainEntity, ITrackable
    {
        private readonly List<Emotion> _emotions = new();
        private readonly List<EventRecord> _events = new();
        private readonly List<BodySensation> _bodySensations = new();

        public DateTime CreatedAt { get; private set; }
        public int MoodLevel { get; private set; }
        public string Notes { get; private set; }

        public IReadOnlyCollection<Emotion> Emotions => _emotions.AsReadOnly();
        public IReadOnlyCollection<EventRecord> Events => _events.AsReadOnly();
        public IReadOnlyCollection<BodySensation> BodySensations => _bodySensations.AsReadOnly();

        public DiaryEntry(int moodLevel, string notes)
        {
            if (moodLevel < 1 || moodLevel > 10)
                throw new ArgumentOutOfRangeException(nameof(moodLevel), "Уровень настроения должен быть от 1 до 10.");

            MoodLevel = moodLevel;
            Notes = notes;
            CreatedAt = DateTime.Now;
        }

        public void AddEmotion(Emotion emotion)
        {
            if (emotion == null)
                throw new ArgumentNullException(nameof(emotion));

            _emotions.Add(emotion);
        }

        public void AddEvent(EventRecord eventRecord)
        {
            if (eventRecord == null)
                throw new ArgumentNullException(nameof(eventRecord));

            _events.Add(eventRecord);
        }

        public void AddBodySensation(BodySensation sensation)
        {
            if (sensation == null)
                throw new ArgumentNullException(nameof(sensation));

            _bodySensations.Add(sensation);
        }
    }
}