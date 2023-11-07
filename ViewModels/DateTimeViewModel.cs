using System;
using System.Linq;

namespace MOE_UI.ViewModels
{
    public class DateTimeViewModel : BaseViewModel
    {
        public int[] Hours { get; set; } = Enumerable.Range(0, 24).ToArray();
        public int[] Minutes { get; set; } = Enumerable.Range(0, 60).ToArray();

        DateTime _selectedStartDate = DateTime.Today;
        public DateTime SelectedStartDate
        {
            get => _selectedStartDate;
            set => SetProperty(ref _selectedStartDate, value);
        }

        DateTime _selectedEndDate = DateTime.Today;
        public DateTime SelectedEndDate
        {
            get => _selectedEndDate;
            set => SetProperty(ref _selectedEndDate, value);
        }

        int _selectedStartHour;
        public int SelectedStartHour
        {
            get => _selectedStartHour;
            set => SetProperty(ref _selectedStartHour, value);
        }

        int _selectedStartMinute;
        public int SelectedStartMinute
        {
            get => _selectedStartMinute;
            set => SetProperty(ref _selectedStartMinute, value);
        }

        int _selectedEndHour;
        public int SelectedEndHour
        {
            get => _selectedEndHour;
            set => SetProperty(ref _selectedEndHour, value);
        }

        int _selectedEndMinute;
        public int SelectedEndMinute
        {
            get => _selectedEndMinute;
            set => SetProperty(ref _selectedEndMinute, value);
        }

        public DateTime CalculatedSelectedStartDateTime
        {
            get => new(_selectedEndDate.Year, _selectedEndDate.Month, _selectedEndDate.Day, _selectedStartHour, _selectedStartMinute, 0);
        }

        public DateTime CalculatedSelectedEndDateTime
        {
            get => new(_selectedEndDate.Year, _selectedEndDate.Month, _selectedEndDate.Day, _selectedEndHour, _selectedEndMinute, 0);
        }

        public virtual void ValidateProperty(string propertyName, object value)
        {
            base.ValidateProperty(propertyName, value);
        }
    }
}
