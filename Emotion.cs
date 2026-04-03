using System;

namespace ConsoleApp1
{
    public class Emotion : DomainEntity
    {
        public EmotionType Type { get; private set; }
        public int Intensity { get; private set; }
        public string Comment { get; private set; }

        public Emotion(EmotionType type, int intensity, string comment)
        {
            if (intensity < 1 || intensity > 10)
                throw new ArgumentOutOfRangeException(nameof(intensity), "Интенсивность должна быть от 1 до 10.");

            Type = type;
            Intensity = intensity;
            Comment = comment;
        }
    }
}