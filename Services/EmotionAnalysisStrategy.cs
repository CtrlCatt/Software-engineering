using System.Collections.ObjectModel;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class EmotionAnalysisStrategy : IAnalysisStrategy
    {
        public string Analyze(ObservableCollection<DiaryEntry> entries)
        {
            if (entries.Count == 0)
                return "Пока нет записей для анализа.";

            var mostFrequentEmotion = entries
                .GroupBy(e => e.EmotionType)
                .OrderByDescending(g => g.Count())
                .First();

            double averageIntensity = entries.Average(e => e.EmotionIntensity);

            return $"Анализ эмоций:\n" +
                   $"Самая частая эмоция: {mostFrequentEmotion.Key}\n" +
                   $"Количество появлений: {mostFrequentEmotion.Count()}\n" +
                   $"Средняя интенсивность эмоций: {averageIntensity:F1}/10\n\n" +
                   $"Это помогает увидеть, какое эмоциональное состояние чаще всего сопровождает пользователя.";
        }
    }
}