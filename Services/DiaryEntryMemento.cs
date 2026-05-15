using System;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class DiaryEntryMemento
    {
        public DateTime CreatedAt { get; }
        public int MoodLevel { get; }

        public string EventTitle { get; }
        public string EventDescription { get; }

        public EmotionType EmotionType { get; }
        public int EmotionIntensity { get; }
        public string EmotionComment { get; }

        public BodyPart BodyPart { get; }
        public string BodySensationDescription { get; }
        public int BodySensationIntensity { get; }

        public DiaryEntryMemento(DiaryEntry entry)
        {
            CreatedAt = entry.CreatedAt;
            MoodLevel = (int)entry.MoodLevel;

            EventTitle = entry.EventTitle;
            EventDescription = entry.EventDescription;

            EmotionType = entry.EmotionType;
            EmotionIntensity = (int)entry.EmotionIntensity;
            EmotionComment = entry.EmotionComment;

            BodyPart = entry.BodyPart;
            BodySensationDescription = entry.BodySensationDescription;
            BodySensationIntensity = (int)entry.BodySensationIntensity;
        }

        public DiaryEntry Restore()
        {
            return new DiaryEntry
            {
                CreatedAt = CreatedAt,
                MoodLevel = MoodLevel,

                EventTitle = EventTitle,
                EventDescription = EventDescription,

                EmotionType = EmotionType,
                EmotionIntensity = EmotionIntensity,
                EmotionComment = EmotionComment,

                BodyPart = BodyPart,
                BodySensationDescription = BodySensationDescription,
                BodySensationIntensity = BodySensationIntensity
            };
        }
    }
}