using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;
        public event PropertyChangedEventHandler PropertyChanged;
        public SchedulerViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointments();
        }
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }
            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
        private void AddAppointments()
        {
            var dailyEvent = new Meeting()
            {
                EventName = "Daily scrum meeting",
                From = new DateTime(2020, 12, 13, 11, 0, 0),
                To = new DateTime(2020, 12, 13, 12, 0, 0),
                BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00BFFF")),
                ForegroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                Id = 1
            };
            this.Meetings.Add(dailyEvent);

            DateTime changedExceptionDate = new DateTime(2020, 12, 14);
            dailyEvent.RecurrenceExceptions = new ObservableCollection<DateTime>()
            {
              changedExceptionDate
            };

            var changedEvent = new Meeting()
            {
                EventName = "Scrum meeting - Changed Occurrence",
                From = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, 13, 0, 0),
                To = new DateTime(changedExceptionDate.Year, changedExceptionDate.Month, changedExceptionDate.Day, 14, 0, 0),
                BackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF1493")),
                ForegroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=10",
                Id = 2,
                RecurrenceId = 1
            };
            this.Meetings.Add(changedEvent);
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    

