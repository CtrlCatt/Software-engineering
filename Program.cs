using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var diary = new Diary("Иван");

            var entry = new DiaryEntry(8, "Сегодня чувствовал себя спокойно и уверенно.");
            entry.AddEmotion(new Emotion(EmotionType.Спокойствие, 7, "Было ощущение внутренней устойчивости"));
            entry.AddEmotion(new Emotion(EmotionType.Интерес, 6, "Было интересно заниматься учебой"));

            entry.AddEvent(new EventRecord(
                "Учеба",
                "Работал над лабораторной по программной инженерии",
                DateTime.Now));

            entry.AddBodySensation(new BodySensation(
                BodyPart.Грудь,
                "Легкость в груди",
                4));

            diary.AddEntry(entry);

            Console.WriteLine($"Дневник пользователя: {diary.OwnerName}");
            Console.WriteLine($"Количество записей: {diary.Entries.Count}");

            foreach (var diaryEntry in diary.Entries)
            {
                Console.WriteLine($"\nЗапись от {diaryEntry.CreatedAt}");
                Console.WriteLine($"Настроение: {diaryEntry.MoodLevel}/10");
                Console.WriteLine($"Заметка: {diaryEntry.Notes}");

                Console.WriteLine("Эмоции:");
                foreach (var emotion in diaryEntry.Emotions)
                {
                    Console.WriteLine($"- {emotion.Type}, интенсивность: {emotion.Intensity}, комментарий: {emotion.Comment}");
                }

                Console.WriteLine("События:");
                foreach (var ev in diaryEntry.Events)
                {
                    Console.WriteLine($"- {ev.Title}: {ev.Description}");
                }

                Console.WriteLine("Телесные ощущения:");
                foreach (var sensation in diaryEntry.BodySensations)
                {
                    Console.WriteLine($"- {sensation.BodyPart}: {sensation.SensationDescription}, интенсивность: {sensation.Intensity}");
                }
            }
        }
    }
}