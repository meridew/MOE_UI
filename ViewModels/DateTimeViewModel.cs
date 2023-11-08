using System;
using System.Linq;

namespace MOE_UI.ViewModels
{
    public class DateTimeViewModel : BaseViewModel
    {
        public DateTime Today { get; set; } = DateTime.Today;
        
        public int[] Hours { get; } = Enumerable.Range(0, 24).ToArray();
        public int[] Minutes { get; } = Enumerable.Range(0, 60).ToArray();

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

        public DateTime SelectedStartDateTime
        {
            get => new(_selectedStartDate.Year, _selectedStartDate.Month, _selectedStartDate.Day, _selectedStartHour, _selectedStartMinute, 0);
        }

        public DateTime SelectedEndDateTime
        {
            get => new(_selectedEndDate.Year, _selectedEndDate.Month, _selectedEndDate.Day, _selectedEndHour, _selectedEndMinute, 0);
        }

        public override void ValidateProperty(string propertyName, object value)
        {
            base.ValidateProperty(propertyName, value);

            if (propertyName.StartsWith("SelectedStart") || propertyName.StartsWith("SelectedEnd"))
            {
                ValidateDateTimeRange();
            }
        }

        void ValidateDateTimeRange()
        {
            if(SelectedStartDateTime > SelectedEndDateTime)
            {
                AddDateTimeValidationErrors();
            }
            else
            {
                ClearDateTimeValidationErrors();
            }
        }

        void AddDateTimeValidationErrors()
        {
            AddError(nameof(SelectedStartDate), "Start date time must be before end date time.");
            AddError(nameof(SelectedStartHour), "Start date time must be before end time date.");
            AddError(nameof(SelectedStartMinute), "Start date time must be before end time date.");
            AddError(nameof(SelectedEndDate), "End date time must be after start date time.");
            AddError(nameof(SelectedEndHour), "End date time must be after start date time.");
            AddError(nameof(SelectedEndMinute), "End date time must be after start date time.");
        }

        void ClearDateTimeValidationErrors()
        {
            ClearError(nameof(SelectedStartDate));
            ClearError(nameof(SelectedStartHour));
            ClearError(nameof(SelectedStartMinute));
            ClearError(nameof(SelectedEndDate));
            ClearError(nameof(SelectedEndHour));
            ClearError(nameof(SelectedEndMinute));
        }
    }
}
