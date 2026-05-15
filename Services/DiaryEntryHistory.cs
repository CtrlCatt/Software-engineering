using System.Collections.Generic;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class DiaryEntryHistory
    {
        private readonly Stack<DiaryEntryMemento> _deletedEntries = new();

        public void SaveDeletedEntry(DiaryEntry entry)
        {
            var memento = new DiaryEntryMemento(entry);
            _deletedEntries.Push(memento);
        }

        public DiaryEntry? RestoreLastDeletedEntry()
        {
            if (_deletedEntries.Count == 0)
                return null;

            var memento = _deletedEntries.Pop();
            return memento.Restore();
        }
    }
}