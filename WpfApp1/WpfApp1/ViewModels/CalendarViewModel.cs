using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;
using PersonalCalendar.Models;

namespace PersonalCalendar.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime _currentWeekStart;
        private ObservableCollection<CalendarEvent> _events;
        private string _weekTitle;
        private string _status;
        private bool _isAddEventPanelVisible;
        private string _newEventTitle;
        private DateTime? _newEventDate;
        private TimeSpan _newEventStartTime;
        private int _newEventDuration;
        private string _selectedEventId;

        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarViewModel()
        {
            _currentWeekStart = GetStartOfWeek(DateTime.Today);
            _events = new ObservableCollection<CalendarEvent>();
            LoadEvents();
            UpdateWeekTitle();

            // Initialize commands
            TodayCommand = new RelayCommand(ExecuteToday);
            PrevWeekCommand = new RelayCommand(ExecutePrevWeek);
            NextWeekCommand = new RelayCommand(ExecuteNextWeek);
            AddEventCommand = new RelayCommand(ExecuteAddEvent);
            SaveEventCommand = new RelayCommand(ExecuteSaveEvent);
            CancelEventCommand = new RelayCommand(ExecuteCancelEvent);
        }

        public DateTime CurrentWeekStart
        {
            get => _currentWeekStart;
            set
            {
                _currentWeekStart = value;
                OnPropertyChanged(nameof(CurrentWeekStart));
                UpdateWeekTitle();
            }
        }

        public ObservableCollection<CalendarEvent> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        public string WeekTitle
        {
            get => _weekTitle;
            set
            {
                _weekTitle = value;
                OnPropertyChanged(nameof(WeekTitle));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public bool IsAddEventPanelVisible
        {
            get => _isAddEventPanelVisible;
            set
            {
                _isAddEventPanelVisible = value;
                OnPropertyChanged(nameof(IsAddEventPanelVisible));
            }
        }

        public string NewEventTitle
        {
            get => _newEventTitle;
            set
            {
                _newEventTitle = value;
                OnPropertyChanged(nameof(NewEventTitle));
            }
        }

        public DateTime? NewEventDate
        {
            get => _newEventDate;
            set
            {
                _newEventDate = value;
                OnPropertyChanged(nameof(NewEventDate));
            }
        }

        public TimeSpan NewEventStartTime
        {
            get => _newEventStartTime;
            set
            {
                _newEventStartTime = value;
                OnPropertyChanged(nameof(NewEventStartTime));
            }
        }

        public int NewEventDuration
        {
            get => _newEventDuration;
            set
            {
                _newEventDuration = value;
                OnPropertyChanged(nameof(NewEventDuration));
            }
        }

        public string SelectedEventId
        {
            get => _selectedEventId;
            set
            {
                _selectedEventId = value;
                OnPropertyChanged(nameof(SelectedEventId));
            }
        }

        public ICommand TodayCommand { get; }
        public ICommand PrevWeekCommand { get; }
        public ICommand NextWeekCommand { get; }
        public ICommand AddEventCommand { get; }
        public ICommand SaveEventCommand { get; }
        public ICommand CancelEventCommand { get; }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Saturday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void LoadEvents()
        {
            string dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.json");
            if (File.Exists(dataFilePath))
            {
                try
                {
                    string json = File.ReadAllText(dataFilePath);
                    var loadedEvents = JsonConvert.DeserializeObject<ObservableCollection<CalendarEvent>>(json);
                    if (loadedEvents != null)
                    {
                        Events = loadedEvents;
                    }
                }
                catch (Exception ex)
                {
                    Status = $"خطا در بارگذاری رویدادها: {ex.Message}";
                }
            }
        }

        private void SaveEvents()
        {
            try
            {
                string dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.json");
                string json = JsonConvert.SerializeObject(Events, Formatting.Indented);
                File.WriteAllText(dataFilePath, json);
                Status = "رویدادها ذخیره شدند";
            }
            catch (Exception ex)
            {
                Status = $"خطا در ذخیره رویدادها: {ex.Message}";
            }
        }

        private void UpdateWeekTitle()
        {
            WeekTitle = $"{CurrentWeekStart:yyyy MMMM} - هفته {GetWeekOfYear(CurrentWeekStart)}";
        }

        private int GetWeekOfYear(DateTime date)
        {
            var dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            var calendar = dfi.Calendar;
            return calendar.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        private void ExecuteToday(object parameter)
        {
            CurrentWeekStart = GetStartOfWeek(DateTime.Today);
        }

        private void ExecutePrevWeek(object parameter)
        {
            CurrentWeekStart = CurrentWeekStart.AddDays(-7);
        }

        private void ExecuteNextWeek(object parameter)
        {
            CurrentWeekStart = CurrentWeekStart.AddDays(7);
        }

        private void ExecuteAddEvent(object parameter)
        {
            NewEventDate = CurrentWeekStart;
            NewEventStartTime = new TimeSpan(8, 0, 0);
            NewEventDuration = 60;
            NewEventTitle = string.Empty;
            IsAddEventPanelVisible = true;
        }

        private void ExecuteSaveEvent(object parameter)
        {
            if (string.IsNullOrWhiteSpace(NewEventTitle) || !NewEventDate.HasValue)
            {
                Status = "لطفاً عنوان و تاریخ رویداد را وارد کنید";
                return;
            }

            var newEvent = new CalendarEvent
            {
                Id = Guid.NewGuid().ToString(),
                Title = NewEventTitle,
                Date = NewEventDate.Value,
                StartTime = NewEventStartTime,
                DurationMinutes = NewEventDuration,
                Color = GetRandomColor()
            };

            Events.Add(newEvent);
            SaveEvents();
            IsAddEventPanelVisible = false;
        }

        private void ExecuteCancelEvent(object parameter)
        {
            IsAddEventPanelVisible = false;
        }

        private string GetRandomColor()
        {
            var colors = new[]
            {
                "#E6E6FA", "#ADD8E6", "#90EE90",
                "#FFB6C1", "#FFD700", "#98FB98",
                "#87CEFA"
            };
            return colors[new Random().Next(colors.Length)];
        }
    }
} 