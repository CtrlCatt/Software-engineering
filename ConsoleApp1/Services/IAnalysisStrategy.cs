using System.Collections.ObjectModel;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public interface IAnalysisStrategy
    {
        string Analyze(ObservableCollection<DiaryEntry> entries);
    }
}