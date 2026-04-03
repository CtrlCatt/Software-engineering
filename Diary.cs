using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Diary : DomainEntity
    {
        private readonly List<DiaryEntry> _entries = new();

        public string OwnerName { get; private set; }
        public IReadOnlyCollection<DiaryEntry> Entries => _entries.AsReadOnly();

        public Diary(string ownerName)
        {
            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("Имя владельца дневника не может быть пустым.", nameof(ownerName));

            OwnerName = ownerName;
        }

        public void AddEntry(DiaryEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            _entries.Add(entry);
        }

        public IEnumerable<DiaryEntry> GetEntriesByPeriod(DateTime startDate, DateTime endDate)
        {
            return _entries.Where(e => e.CreatedAt >= startDate && e.CreatedAt <= endDate);
        }
    }
}