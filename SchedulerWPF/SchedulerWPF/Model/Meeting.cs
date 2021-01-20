using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class Meeting
    {
        public ObservableCollection<DateTime> RecurrenceExceptions { get; set; } = new ObservableCollection<DateTime>();
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public object Id { get; set; }
        public Brush BackgroundColor { get; set; }
        public Brush ForegroundColor { get; set; }
        public string RecurrenceRule { get; set; }
        public object RecurrenceId { get; set; }
    }
}








