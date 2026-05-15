using System.Collections.ObjectModel;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class MoodAnalysisStrategy : IAnalysisStrategy
    {
        public string Analyze(ObservableCollection<DiaryEntry> entries)
        {
            if (entries.Count == 0)
                return "Пока нет записей для анализа.";

            double averageMood = entries.Average(e => e.MoodLevel);
            int minMood = entries.Min(e => e.MoodLevel);
            int maxMood = entries.Max(e => e.MoodLevel);

            string conclusion;

            if (averageMood >= 7)
                conclusion = "Общее состояние можно оценить как достаточно устойчивое.";
            else if (averageMood >= 4)
                conclusion = "Состояние нестабильное: есть как ресурсные, так и напряжённые периоды.";
            else
                conclusion = "Средний уровень настроения низкий, стоит обратить внимание на повторяющиеся причины напряжения.";

            return $"Анализ настроения:\n" +
                   $"Средний уровень настроения: {averageMood:F1}/10\n" +
                   $"Минимальное значение: {minMood}/10\n" +
                   $"Максимальное значение: {maxMood}/10\n\n" +
                   conclusion;
        }
    }
}