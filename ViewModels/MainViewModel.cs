using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ConsoleApp1.Models;

namespace ConsoleApp1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private int _moodLevel = 5;
        private EmotionType _selectedEmotionType = EmotionType.Спокойствие;
        private int _emotionIntensity = 5;
        private string _emotionComment = string.Empty;
        private string _eventTitle = string.Empty;
        private string _eventDescription = string.Empty;
        private BodyPart _selectedBodyPart = BodyPart.Грудь;
        private string _bodySensationDescription = string.Empty;
        private int _bodySensationIntensity = 5;
        private DiaryEntry? _selectedEntry;

        public ObservableCollection<DiaryEntry> Entries { get; } = new();

        public Array EmotionTypes => Enum.GetValues(typeof(EmotionType));
        public Array BodyParts => Enum.GetValues(typeof(BodyPart));

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

        public MainViewModel()
        {
            AddEntryCommand = new RelayCommand(_ => AddEntry());
            DeleteEntryCommand = new RelayCommand(_ => DeleteEntry(), _ => SelectedEntry != null);
        }

        private void AddEntry()
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
        }

        private void DeleteEntry()
        {
            if (SelectedEntry != null)
            {
                Entries.Remove(SelectedEntry);
            }
        }

        private void ClearForm()
        {
            MoodLevel = 5;
            SelectedEmotionType = EmotionType.Спокойствие;
            EmotionIntensity = 5;
            EmotionComment = string.Empty;
            EventTitle = string.Empty;
            EventDescription = string.Empty;
            SelectedBodyPart = BodyPart.Грудь;
            BodySensationDescription = string.Empty;
            BodySensationIntensity = 5;
        }
    }
}