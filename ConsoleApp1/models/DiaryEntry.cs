using System;

namespace ConsoleApp1.Models
{
    public class DiaryEntry
    {
        public DateTime CreatedAt { get; set; }
        public int MoodLevel { get; set; }

        public EmotionType EmotionType { get; set; }
        public int EmotionIntensity { get; set; }
        public string EmotionComment { get; set; } = string.Empty;

        public string EventTitle { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;

        public BodyPart BodyPart { get; set; }
        public string BodySensationDescription { get; set; } = string.Empty;
        public int BodySensationIntensity { get; set; }

        public string ShortDescription =>
            $"{CreatedAt:dd.MM.yyyy HH:mm} | Настроение: {MoodLevel} | Эмоция: {EmotionType} | Событие: {EventTitle}";
    }
}