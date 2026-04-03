using System;

namespace ConsoleApp1
{
    public class BodySensation : DomainEntity
    {
        public BodyPart BodyPart { get; private set; }
        public string SensationDescription { get; private set; }
        public int Intensity { get; private set; }

        public BodySensation(BodyPart bodyPart, string sensationDescription, int intensity)
        {
            if (string.IsNullOrWhiteSpace(sensationDescription))
                throw new ArgumentException("Описание ощущения не может быть пустым.", nameof(sensationDescription));

            if (intensity < 1 || intensity > 10)
                throw new ArgumentOutOfRangeException(nameof(intensity), "Интенсивность должна быть от 1 до 10.");

            BodyPart = bodyPart;
            SensationDescription = sensationDescription;
            Intensity = intensity;
        }
    }
}