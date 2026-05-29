using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ConsoleApp1.Services;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using System.Windows.Input;
using ConsoleApp1.Models;

namespace ConsoleApp1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private AnalysisType _selectedAnalysisType = AnalysisType.Mood;
        private string _analysisResult = "Выберите тип анализа и нажмите кнопку.";
        private readonly AnalysisStrategyFactory _analysisFactory = new();
        private readonly DiaryEntryHistory _entryHistory = new();
        private readonly FileStorageService _fileStorageService = new();
        private int _moodLevel = 5;
        private EmotionType _selectedEmotionType = EmotionType.Calmness;
        private int _emotionIntensity = 5;
        private string _emotionComment = string.Empty;
        private string _eventTitle = string.Empty;
        private string _eventDescription = string.Empty;
        private BodyPart _selectedBodyPart = BodyPart.Chest;
        private string _bodySensationDescription = string.Empty;
        private int _bodySensationIntensity = 5;
        private DiaryEntry? _selectedEntry;

        public ObservableCollection<DiaryEntry> Entries { get; } = new();

        public Array EmotionTypes => Enum.GetValues(typeof(EmotionType));
        public Array BodyParts => Enum.GetValues(typeof(BodyPart));

        public Array AnalysisTypes => Enum.GetValues(typeof(AnalysisType));

        public AnalysisType SelectedAnalysisType
        {
            get => _selectedAnalysisType;
            set
            {
                _selectedAnalysisType = value;
                OnPropertyChanged();
            }
        }

        public string AnalysisResult
        {
            get => _analysisResult;
            set
            {
                _analysisResult = value;
                OnPropertyChanged();
            }
        }
        public ICommand AnalyzeCommand { get; }

        public int MoodLevel
        {
            get => _moodLevel;
            set
            {
                _moodLevel = value;
                OnPropertyChanged();
            }
        }

        public EmotionType SelectedEmotionType
        {
            get => _selectedEmotionType;
            set
            {
                _selectedEmotionType = value;
                OnPropertyChanged();
            }
        }

        public int EmotionIntensity
        {
            get => _emotionIntensity;
            set
            {
                _emotionIntensity = value;
                OnPropertyChanged();
            }
        }

        public string EmotionComment
        {
            get => _emotionComment;
            set
            {
                _emotionComment = value;
                OnPropertyChanged();
            }
        }

        public string EventTitle
        {
            get => _eventTitle;
            set
            {
                _eventTitle = value;
                OnPropertyChanged();
            }
        }

        public string EventDescription
        {
            get => _eventDescription;
            set
            {
                _eventDescription = value;
                OnPropertyChanged();
            }
        }

        public BodyPart SelectedBodyPart
        {
            get => _selectedBodyPart;
            set
            {
                _selectedBodyPart = value;
                OnPropertyChanged();
            }
        }

        public string BodySensationDescription
        {
            get => _bodySensationDescription;
            set
            {
                _bodySensationDescription = value;
                OnPropertyChanged();
            }
        }

        public int BodySensationIntensity
        {
            get => _bodySensationIntensity;
            set
            {
                _bodySensationIntensity = value;
                OnPropertyChanged();
            }
        }

        public DiaryEntry? SelectedEntry
        {
            get => _selectedEntry;
            set
            {
                _selectedEntry = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddEntryCommand { get; }
        public ICommand DeleteEntryCommand { get; }
        public ICommand RestoreDeletedEntryCommand { get; }

        public MainViewModel()
        {
            AddEntryCommand = new RelayCommand(async _ => await AddEntryAsync());
            DeleteEntryCommand = new RelayCommand(async _ => await DeleteEntryAsync());
            AnalyzeCommand = new RelayCommand(_ => AnalyzeEntries());
            RestoreDeletedEntryCommand = new RelayCommand(async _ => await RestoreDeletedEntryAsync());

            _ = LoadEntriesAsync();
        }

        private void AnalyzeEntries()
        {
            var strategy = _analysisFactory.CreateStrategy(SelectedAnalysisType);
            AnalysisResult = strategy.Analyze(Entries);
        }

        private async Task AddEntryAsync()
        {
            if (string.IsNullOrWhiteSpace(EventTitle))
            {
                MessageBox.Show("Введите название события.");
                return;
            }

            var entry = new DiaryEntry
            {
                CreatedAt = DateTime.Now,
                MoodLevel = MoodLevel,
                EmotionType = SelectedEmotionType,
                EmotionIntensity = EmotionIntensity,
                EmotionComment = EmotionComment,
                EventTitle = EventTitle,
                EventDescription = EventDescription,
                BodyPart = SelectedBodyPart,
                BodySensationDescription = BodySensationDescription,
                BodySensationIntensity = BodySensationIntensity
            };

            Entries.Add(entry);
            ClearForm();

            await SaveEntriesAsync();
        }

        private async Task DeleteEntryAsync()
        {
            if (SelectedEntry == null)
            {
                MessageBox.Show("Сначала выберите запись для удаления.");
                return;
            }

            _entryHistory.SaveDeletedEntry(SelectedEntry);
            Entries.Remove(SelectedEntry);
            SelectedEntry = null;

            await SaveEntriesAsync();
        }
        private async Task RestoreDeletedEntryAsync()
        {
            var restoredEntry = _entryHistory.RestoreLastDeletedEntry();

            if (restoredEntry == null)
            {
                MessageBox.Show("Нет удалённой записи для восстановления.");
                return;
            }

            Entries.Add(restoredEntry);
            SelectedEntry = restoredEntry;

            await SaveEntriesAsync();
        }

        private async Task SaveEntriesAsync()
        {
            await _fileStorageService.SaveAsync(Entries);
        }
        private async Task LoadEntriesAsync()
        {
            var loadedEntries = await _fileStorageService.LoadAsync();

            Entries.Clear();

            foreach (var entry in loadedEntries)
            {
                Entries.Add(entry);
            }
        }

        private void ClearForm()
        {
            MoodLevel = 5;
            SelectedEmotionType = EmotionType.Calmness;
            EmotionIntensity = 5;
            EmotionComment = string.Empty;
            EventTitle = string.Empty;
            EventDescription = string.Empty;
            SelectedBodyPart = BodyPart.Chest;
            BodySensationDescription = string.Empty;
            BodySensationIntensity = 5;
        }

    }
}