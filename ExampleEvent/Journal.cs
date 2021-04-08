using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleEvent
{
    class Journal
    {

        private List<JournalEntry> journalEntries = new List<JournalEntry>();

        public void ChangedCountOfCollection(object source, StudentListHandlerEventArgs args)
        {
            journalEntries.Add(new JournalEntry(args.CollectionName, args.TypeOfChange, args.Student));
        }

        public void ChangedReference(object source, StudentListHandlerEventArgs args)
        {
            journalEntries.Add(new JournalEntry(args.CollectionName, args.TypeOfChange, args.Student));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if((journalEntries is null) || (journalEntries.Count is 0))
            {
                return $"Not changed in collection";
            }
            foreach(var journalEntry in journalEntries)
            {
                stringBuilder.Append($"{journalEntry}\n");
            }

            return stringBuilder.ToString();
        }


    }
}
