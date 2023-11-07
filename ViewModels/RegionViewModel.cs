using MOE_UI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MOE_UI.ViewModels
{
    public class RegionViewModel : BaseViewModel
    {
        string _selectedRegion;
        public string SelectedRegion
        {
            get => _selectedRegion;
            set => SetProperty(ref _selectedRegion, value);
        }

        public RegionViewModel(DateTimeViewModel dateTimeViewModel, CriteriaViewModel criteriaViewModel)
        {
            DateTimeViewModel = dateTimeViewModel;
            CriteriaViewModel = criteriaViewModel;

            ValidateProperty(nameof(SelectedRegion), SelectedRegion);
        }

        public DateTimeViewModel DateTimeViewModel { get; set; }
        public CriteriaViewModel CriteriaViewModel { get; set; }

        public string[] Regions { get; } = { "AMRS", "AMRS2", "AMRS3", "APAC", "EMEA" };

        public DateTime SelectedStartDateTimeUtc
        {
            get => TimeHelper.ConvertToUtc(SelectedRegion, DateTimeViewModel.SelectedStartDateTime);
        }

        public DateTime SelectedEndDateTimeUtc
        {
            get => TimeHelper.ConvertToUtc(SelectedRegion, DateTimeViewModel.SelectedEndDateTime);
        }

        public DateTime SelectedStartDateTime
        {
            get => DateTimeViewModel.SelectedStartDateTime;
        }
        public DateTime SelectedEndDateTime
        {
            get => DateTimeViewModel.SelectedEndDateTime;
        }

        public ObservableCollection<CriterionViewModel> SelectedCriteria
        {
            get => CriteriaViewModel.GetCriteria();
        }

        public override void ValidateProperty(string propertyName, object value)
        {
            base.ValidateProperty(propertyName, value);

            ClearError(propertyName);

            switch (propertyName)
            {
                case nameof(SelectedRegion):
                    if (string.IsNullOrEmpty(SelectedRegion))
                    {
                        AddError(propertyName, "Region is required.");
                    }
                    break;
            }
        }
    }
}
