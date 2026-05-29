using System;
using System.Collections.ObjectModel;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Tests
{
    public static class ManualTests
    {
        public static void RunAll()
        {
            TestMoodAnalysis();
            TestEmotionAnalysis();
            TestBodyAnalysis();
            TestFactory();
            TestRestoreDeletedEntry();

            Console.WriteLine("Все тесты успешно пройдены.");
        }

        private static DiaryEntry Entry(
            int mood = 7,
            EmotionType emotion = EmotionType.Calmness,
            BodyPart bodyPart = BodyPart.Chest)
        {
            return new DiaryEntry
            {
                CreatedAt = DateTime.Now,
                MoodLevel = mood,
                EventTitle = "Test event",
                EventDescription = "Test description",
                EmotionType = emotion,
                EmotionIntensity = 5,
                EmotionComment = "Test emotion",
                BodyPart = bodyPart,
                BodySensationDescription = "Test body sensation",
                BodySensationIntensity = 5
            };
        }

        private static void Check(bool condition, string message)
        {
            if (!condition)
                throw new Exception("Тест не пройден: " + message);
        }

        private static void TestMoodAnalysis()
        {
            var entries = new ObservableCollection<DiaryEntry>
            {
                Entry(mood: 8),
                Entry(mood: 6),
                Entry(mood: 4)
            };

            var result = new MoodAnalysisStrategy().Analyze(entries);

            Check(result.Contains("6"), "анализ настроения должен посчитать среднее значение");
        }

        private static void TestEmotionAnalysis()
        {
            var entries = new ObservableCollection<DiaryEntry>
            {
                Entry(emotion: EmotionType.Anxiety),
                Entry(emotion: EmotionType.Anxiety),
                Entry(emotion: EmotionType.Joy)
            };

            var result = new EmotionAnalysisStrategy().Analyze(entries);

            Check(result.Contains("Anxiety"), "анализ эмоций должен найти самую частую эмоцию");
        }

        private static void TestBodyAnalysis()
        {
            var entries = new ObservableCollection<DiaryEntry>
            {
                Entry(bodyPart: BodyPart.Head),
                Entry(bodyPart: BodyPart.Head),
                Entry(bodyPart: BodyPart.Chest)
            };

            var result = new BodySensationAnalysisStrategy().Analyze(entries);

            Check(result.Contains("Head"), "анализ тела должен найти самую частую часть тела");
        }

        private static void TestFactory()
        {
            var strategy = new AnalysisStrategyFactory().CreateStrategy(AnalysisType.Mood);

            Check(strategy is MoodAnalysisStrategy, "фабрика должна создать стратегию анализа настроения");
        }

        private static void TestRestoreDeletedEntry()
        {
            var history = new DiaryEntryHistory();
            var entry = Entry(mood: 9, emotion: EmotionType.Joy, bodyPart: BodyPart.WholeBody);

            history.SaveDeletedEntry(entry);
            var restored = history.RestoreLastDeletedEntry();

            Check(restored != null, "удалённая запись должна восстановиться");
            Check(restored!.MoodLevel == 9, "восстановленная запись должна сохранить данные");
        }
    }
}