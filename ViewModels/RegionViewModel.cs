using MOE_UI.Helpers;
using MOE_UI.Models;
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
        }

        public DateTimeViewModel DateTimeViewModel { get; set; }
        public CriteriaViewModel CriteriaViewModel { get; set; }

        public string[] Regions { get; } = { "AMRS", "AMRS2", "AMRS3", "APAC", "EMEA" };



        public DateTime CalculatedSelectedStartDateTimeUtc
        {
            get => TimeHelper.ConvertToUtc(SelectedRegion, DateTimeViewModel.CalculatedSelectedStartDateTime);
        }

        public DateTime CalculatedSelectedEndDateTimeUtc
        {
            get => TimeHelper.ConvertToUtc(SelectedRegion, DateTimeViewModel.CalculatedSelectedEndDateTime);
        }

        public ObservableCollection<Criterion> SelectedCriteria
        {
            get
            {
                var criteria = new ObservableCollection<Criterion>
                {
                    new Criterion(CriteriaViewModel.SelectedTargetDeviceOsField, CriteriaViewModel.SelectedTargetDeviceOsOperand, CriteriaViewModel.SelectedTargetDeviceOsValue),
                    new Criterion(CriteriaViewModel.SelectedTargetOsFamily, CriteriaViewModel.SelectedTargetOsFamilyOperand, CriteriaViewModel.SelectedTargetOsFamilyValue),
                    new Criterion(CriteriaViewModel.SelectedTargetLastCommunicatedDays, CriteriaViewModel.SelectedTargetLastCommunicatedDaysOperand, CriteriaViewModel.SelectedTargetLastCommunicatedDaysValue)
                };
                return criteria;
            }
        }

        public virtual void ValidateProperty(string propertyName, object value)
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
