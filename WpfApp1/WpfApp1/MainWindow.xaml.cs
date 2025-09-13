using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;

namespace PersonalCalendar
{
    public partial class MainWindow : Window
    {
        private List<CalendarEvent> events = new List<CalendarEvent>();
        private string dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.json");
        private DateTime currentWeekStart;
        private CalendarEvent selectedEvent;
        private const double MinutesPerRow = 60.0; // هر ردیف 60 دقیقه (1 ساعت)

        public MainWindow()
        {
            InitializeComponent();
            currentWeekStart = GetStartOfWeek(DateTime.Today);
            weekPicker.SelectedDate = currentWeekStart;
            InitializeCalendar();
            InitializeTimeLabels();
            LoadEvents();
            UpdateWeekTitle();
        }

        public class CalendarEvent
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan StartTime { get; set; }
            public int DurationMinutes { get; set; }
            public DateTime EndTime => Date.Add(StartTime).AddMinutes(DurationMinutes);
            public string Color { get; set; } = "#E6E6FA";
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Saturday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void InitializeCalendar()
        {
            var daysOfWeek = new[] { lblSat, lblSun, lblMon, lblTue, lblWed, lblThu, lblFri };
            for (int i = 0; i < 7; i++)
            {
                var day = currentWeekStart.AddDays(i);
                daysOfWeek[i].Content = $"{day:dd MMM}\n{GetPersianDayName(day.DayOfWeek)}";
            }
        }

        private void InitializeTimeLabels()
        {
            for (int i = 0; i < 24; i++) // 24 ردیف برای 24 ساعت
            {
                var timeLabel = new Label
                {
                    Content = $"{i:00}:00",
                    Style = (Style)FindResource("TimeLabelStyle")
                };
                Grid.SetRow(timeLabel, i);
                Grid.SetColumn(timeLabel, 0);
                mainGrid.Children.Add(timeLabel);
            }
        }

        private string GetPersianDayName(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "یکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه‌شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "";
            }
        }

        private void WeekPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (weekPicker.SelectedDate.HasValue)
            {
                currentWeekStart = GetStartOfWeek(weekPicker.SelectedDate.Value);
                InitializeCalendar();
                RenderEvents();
                UpdateWeekTitle();
            }
        }

        private void LoadEvents()
        {
            if (File.Exists(dataFilePath))
            {
                try
                {
                    string json = File.ReadAllText(dataFilePath);
                    events = JsonConvert.DeserializeObject<List<CalendarEvent>>(json) ?? new List<CalendarEvent>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا در بارگذاری رویدادها: {ex.Message}");
                    events = new List<CalendarEvent>();
                }
            }
            RenderEvents();
        }

        private void SaveEvents()
        {
            try
            {
                string json = JsonConvert.SerializeObject(events, Formatting.Indented);
                File.WriteAllText(dataFilePath, json);
                UpdateStatus("رویدادها ذخیره شدند");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ذخیره رویدادها: {ex.Message}");
            }
        }

        private void RenderEvents()
        {
            // حذف رویدادهای قبلی
            var existingEvents = mainGrid.Children.OfType<Button>().ToList();
            foreach (var existingEvent in existingEvents)
            {
                mainGrid.Children.Remove(existingEvent);
            }

            // حذف Canvasهای قبلی
            var existingCanvases = mainGrid.Children.OfType<Canvas>().ToList();
            foreach (var canvas in existingCanvases)
            {
                mainGrid.Children.Remove(canvas);
            }

            var startOfWeek = currentWeekStart;
            var endOfWeek = startOfWeek.AddDays(7);

            var weekEvents = events
                .Where(e => e.Date >= startOfWeek && e.Date < endOfWeek)
                .OrderBy(e => e.Date)
                .ThenBy(e => e.StartTime)
                .ToList();

            // گروه‌بندی رویدادها بر اساس روز و زمان برای شناسایی تداخل‌ها
            var eventsByDay = new List<List<CalendarEvent>>[7]; // 7 روز هفته
            for (int i = 0; i < 7; i++)
            {
                eventsByDay[i] = new List<List<CalendarEvent>>();
                var dayEvents = weekEvents.Where(e => (int)(e.Date - startOfWeek).TotalDays == i).ToList();
                if (dayEvents.Any())
                {
                    var overlappingGroups = new List<List<CalendarEvent>>();
                    var currentGroup = new List<CalendarEvent> { dayEvents[0] };
                    for (int j = 1; j < dayEvents.Count; j++)
                    {
                        var lastEventInGroup = currentGroup.Last();
                        if (dayEvents[j].StartTime < lastEventInGroup.EndTime.TimeOfDay)
                        {
                            currentGroup.Add(dayEvents[j]);
                        }
                        else
                        {
                            overlappingGroups.Add(currentGroup);
                            currentGroup = new List<CalendarEvent> { dayEvents[j] };
                        }
                    }
                    overlappingGroups.Add(currentGroup);
                    eventsByDay[i] = overlappingGroups;
                }
            }

            // نمایش رویدادها
            for (int day = 0; day < 7; day++)
            {
                foreach (var group in eventsByDay[day])
                {
                    int groupSize = group.Count;
                    for (int i = 0; i < group.Count; i++)
                    {
                        AddEventToCalendar(group[i], day + 1, i, groupSize);
                    }
                }
            }

            UpdateStatus($"تعداد رویدادها: {weekEvents.Count}");
        }

        private void AddEventToCalendar(CalendarEvent calendarEvent, int column, int positionInGroup, int groupSize)
        {
            if (column < 1 || column > 7) return;

            // محاسبه موقعیت و اندازه رویداد بر اساس دقیقه
            int startMinutes = (int)calendarEvent.StartTime.TotalMinutes;
            int startHour = startMinutes / 60;
            int minutesWithinHour = startMinutes % 60;

            // محاسبه تعداد ردیف‌هایی که رویداد اشغال می‌کنه
            int endMinutes = startMinutes + calendarEvent.DurationMinutes;
            int endHour = endMinutes / 60;
            int rowSpan = endHour - startHour + (endMinutes % 60 > 0 ? 1 : 0);
            if (rowSpan < 1) rowSpan = 1;

            // ایجاد یک Canvas برای قرار دادن رویداد
            var canvas = new Canvas();
            Grid.SetColumn(canvas, column);
            Grid.SetRow(canvas, startHour);
            Grid.SetRowSpan(canvas, rowSpan);
            mainGrid.Children.Add(canvas);

            // تنظیم موقعیت و اندازه رویداد
            var eventButton = new Button
            {
                Tag = calendarEvent.Id,
                Style = (Style)FindResource("EventButton"),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(calendarEvent.Color)),
                ToolTip = $"{calendarEvent.Title}\nزمان: {calendarEvent.StartTime:hh\\:mm} تا {calendarEvent.EndTime:hh\\:mm}\nمدت: {calendarEvent.DurationMinutes} دقیقه"
            };

            // ایجاد Grid برای قرار دادن متن و دکمه‌ها
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            // متن رویداد
            var textBlock = new TextBlock
            {
                Text = $"{calendarEvent.StartTime:hh\\:mm} - {calendarEvent.Title}",
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(5, 2, 0, 0)
            };
            Grid.SetColumn(textBlock, 0);
            grid.Children.Add(textBlock);

            // دکمه ویرایش
            var editButton = new Button
            {
                Style = (Style)FindResource("EditButton"),
                Tag = calendarEvent
            };
            editButton.Click += (s, e) => EditEvent(calendarEvent);
            Grid.SetColumn(editButton, 1);
            grid.Children.Add(editButton);

            // دکمه حذف
            var deleteButton = new Button
            {
                Style = (Style)FindResource("DeleteButton"),
                Tag = calendarEvent
            };
            deleteButton.Click += (s, e) => DeleteEvent(calendarEvent);
            Grid.SetColumn(deleteButton, 2);
            grid.Children.Add(deleteButton);

            eventButton.Content = grid;

            // تنظیم عرض و موقعیت افقی برای مدیریت تداخل‌ها
            double canvasWidth = canvas.ActualWidth > 0 ? canvas.ActualWidth : 100; // عرض پیش‌فرض
            eventButton.Width = canvasWidth / groupSize;
            Canvas.SetLeft(eventButton, positionInGroup * (canvasWidth / groupSize));

            // تنظیم موقعیت عمودی و ارتفاع
            double pixelsPerMinute = 1.0; // مقدار اولیه
            Canvas.SetTop(eventButton, minutesWithinHour * pixelsPerMinute);
            eventButton.Height = Math.Max(calendarEvent.DurationMinutes * pixelsPerMinute, 20); // حداقل ارتفاع 20 پیکسل

            eventButton.Click += EventButton_Click;

            canvas.Children.Add(eventButton);

            // تنظیم PixelsPerMinute بر اساس ارتفاع واقعی ردیف
            canvas.SizeChanged += (s, e) =>
            {
                if (e.NewSize.Height > 0)
                {
                    // محاسبه pixelsPerMinute بر اساس ارتفاع کل Canvas و تعداد ردیف‌ها
                    double totalMinutes = rowSpan * MinutesPerRow;
                    pixelsPerMinute = e.NewSize.Height / totalMinutes;
                    Canvas.SetTop(eventButton, minutesWithinHour * pixelsPerMinute);
                    eventButton.Height = Math.Max(calendarEvent.DurationMinutes * pixelsPerMinute, 20); // حداقل ارتفاع 20 پیکسل
                    eventButton.Width = e.NewSize.Width / groupSize;
                    Canvas.SetLeft(eventButton, positionInGroup * (e.NewSize.Width / groupSize));
                }
            };
        }

        private void EditEvent(CalendarEvent calendarEvent)
        {
            selectedEvent = calendarEvent;
            txtEventTitle.Text = calendarEvent.Title;
            dpEventDate.SelectedDate = calendarEvent.Date;
            txtStartTime.Text = calendarEvent.StartTime.ToString(@"hh\:mm");
            txtDuration.Text = calendarEvent.DurationMinutes.ToString();
            addEventPanel.Visibility = Visibility.Visible;
        }

        private void DeleteEvent(CalendarEvent calendarEvent)
        {
            if (MessageBox.Show($"آیا از حذف رویداد '{calendarEvent.Title}' مطمئن هستید؟",
                "تایید حذف", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                events.RemoveAll(e => e.Id == calendarEvent.Id);
                RenderEvents();
                SaveEvents();
            }
        }

        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string eventId)
            {
                var selectedEvent = events.FirstOrDefault(ev => ev.Id == eventId);
                if (selectedEvent != null)
                {
                    MessageBox.Show($"رویداد: {selectedEvent.Title}\nتاریخ: {selectedEvent.Date:yyyy/MM/dd}\nزمان: {selectedEvent.StartTime:hh\\:mm} تا {selectedEvent.EndTime:hh\\:mm}",
                        "جزئیات رویداد", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void UpdateWeekTitle()
        {
            var endOfWeek = currentWeekStart.AddDays(6);
            lblWeekTitle.Content = $"{currentWeekStart:yyyy MMMM} - هفته {GetWeekOfYear(currentWeekStart)}";
        }

        private int GetWeekOfYear(DateTime date)
        {
            var dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            var calendar = dfi.Calendar;
            return calendar.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        private void UpdateStatus(string message = null)
        {
            lblStatus.Text = message ?? $"آخرین به‌روزرسانی: {DateTime.Now:HH:mm:ss}";
        }

        private void BtnToday_Click(object sender, RoutedEventArgs e)
        {
            currentWeekStart = GetStartOfWeek(DateTime.Today);
            weekPicker.SelectedDate = currentWeekStart;
            InitializeCalendar();
            RenderEvents();
            UpdateWeekTitle();
        }

        private void BtnPrevWeek_Click(object sender, RoutedEventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(-7);
            weekPicker.SelectedDate = currentWeekStart;
            InitializeCalendar();
            RenderEvents();
            UpdateWeekTitle();
        }

        private void BtnNextWeek_Click(object sender, RoutedEventArgs e)
        {
            currentWeekStart = currentWeekStart.AddDays(7);
            weekPicker.SelectedDate = currentWeekStart;
            InitializeCalendar();
            RenderEvents();
            UpdateWeekTitle();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            selectedEvent = null;
            txtEventTitle.Text = "";
            dpEventDate.SelectedDate = currentWeekStart;
            txtStartTime.Text = "08:00";
            txtDuration.Text = "60";
            addEventPanel.Visibility = Visibility.Visible;
        }

        private void BtnSaveEvent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventTitle.Text))
            {
                MessageBox.Show("لطفاً عنوان رویداد را وارد کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dpEventDate.SelectedDate == null)
            {
                MessageBox.Show("لطفاً تاریخ رویداد را انتخاب کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TimeSpan.TryParse(txtStartTime.Text, out TimeSpan startTime))
            {
                MessageBox.Show("زمان شروع باید به فرمت HH:mm باشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("مدت زمان باید عددی مثبت باشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selectedEvent != null)
            {
                selectedEvent.Title = txtEventTitle.Text;
                selectedEvent.Date = dpEventDate.SelectedDate.Value;
                selectedEvent.StartTime = startTime;
                selectedEvent.DurationMinutes = duration;
            }
            else
            {
                var newEvent = new CalendarEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = txtEventTitle.Text,
                    Date = dpEventDate.SelectedDate.Value,
                    StartTime = startTime,
                    DurationMinutes = duration,
                    Color = GetRandomColor()
                };
                events.Add(newEvent);
            }

            RenderEvents();
            addEventPanel.Visibility = Visibility.Collapsed;
            SaveEvents();
            selectedEvent = null;
        }

        private string GetRandomColor()
        {
            var colors = new[]
            {
                "#E6E6FA", "#ADD8E6", "#90EE90",
                "#FFB6C1", "#FFD700", "#98FB98",
                "#87CEFA", "#FFA07A", "#20B2AA",
                "#DDA0DD", "#F0E68C", "#7FFFD4"
            };
            return colors[new Random().Next(colors.Length)];
        }

        private void BtnCancelEvent_Click(object sender, RoutedEventArgs e)
        {
            addEventPanel.Visibility = Visibility.Collapsed;
            selectedEvent = null;
        }
    }
}