using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class FileStorageService
    {
        private readonly string _filePath = "diary_entries.json";

        public async Task SaveAsync(ObservableCollection<DiaryEntry> entries)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(entries, options);

            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<ObservableCollection<DiaryEntry>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new ObservableCollection<DiaryEntry>();

            string json = await File.ReadAllTextAsync(_filePath);

            var entries = JsonSerializer.Deserialize<ObservableCollection<DiaryEntry>>(json);

            return entries ?? new ObservableCollection<DiaryEntry>();
        }
    }
}