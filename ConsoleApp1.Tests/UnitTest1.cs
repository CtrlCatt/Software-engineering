using System;
using System.Collections.ObjectModel;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class BusinessLogicTests
    {
        private DiaryEntry CreateEntry(
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

        [Fact]
        public void MoodAnalysisStrategy_ShouldCalculateAverageMood()
        {
            var entries = new ObservableCollection<DiaryEntry>
            {
                CreateEntry(mood: 8),
                CreateEntry(mood: 6),
                CreateEntry(mood: 4)
            };

            var strategy = new MoodAnalysisStrategy();

            string result = strategy.Analyze(entries);

            Assert.Contains("Анализ настроения", result);
            Assert.Contains("6", result);
        }

        [Fact]
        public void EmotionAnalysisStrategy_ShouldFindMostFrequentEmotion()
        {
            var entries = new ObservableCollection<DiaryEntry>
            {
                CreateEntry(emotion: EmotionType.Anxiety),
                CreateEntry(emotion: EmotionType.Anxiety),
                CreateEntry(emotion: EmotionType.Joy)
            };

            var strategy = new EmotionAnalysisStrategy();

            string result = strategy.Analyze(entries);

            Assert.Contains("Anxiety", result);
            Assert.Contains("2", result);
        }

        [Fact]
        public void BodySensationAnalysisStrategy_ShouldFindMostFrequentBodyPart()
        {
            var entries = new ObservableCollection<DiaryEntry>
            {
                CreateEntry(bodyPart: BodyPart.Head),
                CreateEntry(bodyPart: BodyPart.Head),
                CreateEntry(bodyPart: BodyPart.Chest)
            };

            var strategy = new BodySensationAnalysisStrategy();

            string result = strategy.Analyze(entries);

            Assert.Contains("Head", result);
            Assert.Contains("2", result);
        }

        [Fact]
        public void AnalysisStrategyFactory_ShouldCreateMoodStrategy()
        {
            var factory = new AnalysisStrategyFactory();

            var strategy = factory.CreateStrategy(AnalysisType.Mood);

            Assert.IsType<MoodAnalysisStrategy>(strategy);
        }

        [Fact]
        public void DiaryEntryHistory_ShouldRestoreDeletedEntry()
        {
            var history = new DiaryEntryHistory();
            var entry = CreateEntry(
                mood: 9,
                emotion: EmotionType.Joy,
                bodyPart: BodyPart.WholeBody);

            history.SaveDeletedEntry(entry);

            var restored = history.RestoreLastDeletedEntry();

            Assert.NotNull(restored);
            Assert.Equal(9, restored!.MoodLevel);
            Assert.Equal(EmotionType.Joy, restored.EmotionType);
            Assert.Equal(BodyPart.WholeBody, restored.BodyPart);
        }
    }
}