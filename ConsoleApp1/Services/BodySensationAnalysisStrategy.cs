using System.Collections.ObjectModel;
using System.Linq;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class BodySensationAnalysisStrategy : IAnalysisStrategy
    {
        public string Analyze(ObservableCollection<DiaryEntry> entries)
        {
            if (entries.Count == 0)
                return "Пока нет записей для анализа.";

            var mostFrequentBodyPart = entries
                .GroupBy(e => e.BodyPart)
                .OrderByDescending(g => g.Count())
                .First();

            double averageIntensity = entries.Average(e => e.BodySensationIntensity);

            return $"Анализ телесных ощущений:\n" +
                   $"Чаще всего отмечалась область: {mostFrequentBodyPart.Key}\n" +
                   $"Количество упоминаний: {mostFrequentBodyPart.Count()}\n" +
                   $"Средняя интенсивность ощущений: {averageIntensity:F1}/10\n\n" +
                   $"Это помогает отследить связь между эмоциональным состоянием и телесными реакциями.";
        }
    }
}