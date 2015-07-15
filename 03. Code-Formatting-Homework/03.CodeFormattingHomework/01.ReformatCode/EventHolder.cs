namespace _01.ReformatCode
{
    using System;

    using Wintellect.PowerCollections;

    internal class EventHolder
    {
        private readonly OrderedBag<Event> comparingDate = new OrderedBag<Event>();

        private readonly MultiDictionary<string, Event> comparingTitle = new MultiDictionary<string, Event>(true);

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this.comparingTitle.Add(title.ToLower(), newEvent);
            this.comparingDate.Add(newEvent);
            Messages.PrintEventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            var title = titleToDelete.ToLower();
            var removed = 0;
            foreach (var eventToRemove in this.comparingTitle[title])
            {
                removed++;
                this.comparingDate.Remove(eventToRemove);
            }

            this.comparingTitle.Remove(title);
            Messages.PrintEventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            var eventsToShow = this.comparingDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            var showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.PrintNoEventsFound();
            }
        }
    }
}