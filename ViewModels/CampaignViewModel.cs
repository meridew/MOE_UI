using MOE_UI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MOE_UI.ViewModels
{
    public class CampaignViewModel : BaseViewModel
    { 
        public CampaignViewModel(RegionViewModel regionViewModel, EmailViewModel emailViewModel)
        {
            RegionViewModel = regionViewModel;
            EmailViewModel = emailViewModel;
            ValidateProperty(nameof(SelectedCampaignName), SelectedCampaignName);
            InitCommands();
        }

        public RegionViewModel RegionViewModel { get; set; }
        public EmailViewModel EmailViewModel { get; set; }

        string selectedCampaignName;
        public string SelectedCampaignName
        {
            get => selectedCampaignName;
            set => SetProperty(ref selectedCampaignName, value);
        }

        ObservableCollection<CriteriaFileViewModel> addedRegions = new();
        public ObservableCollection<CriteriaFileViewModel> AddedRegions
        {
            get => addedRegions;
            set => SetProperty(ref addedRegions, value);
        }

        StageViewModel selectedStageRow;
        public StageViewModel SelectedStageRow
        {
            get => selectedStageRow;
            set
            {
                SetProperty(ref selectedStageRow, value);
            }
        }

        CriteriaFileViewModel selectedRegionRow;
        public CriteriaFileViewModel SelectedRegionRow
        {
            get => selectedRegionRow;
            set
            {
                SetProperty(ref selectedRegionRow, value);
                SelectedStageRow = value.Stages[0];
                UpdateControlsOnSelectionChange(value, RegionViewModel);
            }
        }

        public ICommand AddRegionCommand { get; private set; }
        public ICommand UpdateRegionCommand { get; private set; }

        public bool CanUpdateRegion()
        {
            if(SelectedRegionRow != null)
            {
                return !AddedRegions.Any(region => region.RegionName.Equals(RegionViewModel.SelectedRegion, StringComparison.OrdinalIgnoreCase)) &&
                SelectedRegionRow.RegionName != RegionViewModel.SelectedRegion ||
                SelectedRegionRow.ScheduleStart != RegionViewModel.SelectedStartDateTime ||
                SelectedRegionRow.ScheduleEnd != RegionViewModel.SelectedEndDateTime ||
                SelectedRegionRow.ScheduleStartUTC != RegionViewModel.SelectedStartDateTimeUtc ||
                SelectedRegionRow.ScheduleEndUTC != RegionViewModel.SelectedEndDateTimeUtc ||
                SelectedRegionRow.EmailAddresses != EmailViewModel.EmailAddresses ||
                SelectedRegionRow.EmailAddressCount != EmailViewModel.EmailAddressCount ||
                SelectedRegionRow.Stages[0].Criteria[1].Operand != RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsFamilyOperand ||
                SelectedRegionRow.Stages[0].Criteria[1].Value != RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsFamilyValue ||
                SelectedRegionRow.Stages[0].Criteria[0].Operand != RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsVersionOperand ||
                SelectedRegionRow.Stages[0].Criteria[0].Value != RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsVersionValue ||
                SelectedRegionRow.Stages[0].Criteria[2].Operand != RegionViewModel.CriteriaViewModel.SelectedTargetLastCommunicatedDaysOperand ||
                SelectedRegionRow.Stages[0].Criteria[2].Value != RegionViewModel.CriteriaViewModel.SelectedTargetLastCommunicatedDaysValue;
            }
            return false;
        }

        public void UpdateRegion()
        {
            SelectedRegionRow.CampaignName = SelectedCampaignName;
            SelectedRegionRow.RegionName = RegionViewModel.SelectedRegion;
            SelectedRegionRow.ScheduleStart = RegionViewModel.SelectedStartDateTime;
            SelectedRegionRow.ScheduleEnd = RegionViewModel.SelectedEndDateTime;
            SelectedRegionRow.ScheduleStartUTC = RegionViewModel.SelectedStartDateTimeUtc;
            SelectedRegionRow.ScheduleEndUTC = RegionViewModel.SelectedEndDateTimeUtc;
            SelectedRegionRow.EmailAddresses = EmailViewModel.EmailAddresses;
            SelectedRegionRow.EmailAddressCount = EmailViewModel.EmailAddressCount;
            SelectedRegionRow.Stages[0].Criteria[1].Operand = RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsFamilyOperand;
            SelectedRegionRow.Stages[0].Criteria[1].Value = RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsFamilyValue;
            SelectedRegionRow.Stages[0].Criteria[0].Operand = RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsVersionOperand;
            SelectedRegionRow.Stages[0].Criteria[0].Value = RegionViewModel.CriteriaViewModel.SelectedTargetDeviceOsVersionValue;
            SelectedRegionRow.Stages[0].Criteria[2].Operand = RegionViewModel.CriteriaViewModel.SelectedTargetLastCommunicatedDaysOperand;
            SelectedRegionRow.Stages[0].Criteria[2].Value = RegionViewModel.CriteriaViewModel.SelectedTargetLastCommunicatedDaysValue;
        }

        public bool CanAddRegion()
        {
            return IsDataComplete &&
                RegionViewModel.IsDataComplete &&
                RegionViewModel.DateTimeViewModel.IsDataComplete &&
                !AddedRegions.Any(region => region.RegionName.Equals(RegionViewModel.SelectedRegion, StringComparison.OrdinalIgnoreCase));
        }

        public void AddRegion()
        {
            CriteriaFileViewModel criteriaFile = new(SelectedCampaignName,
                                            RegionViewModel.SelectedRegion,
                                            RegionViewModel.SelectedStartDateTime,
                                            RegionViewModel.SelectedEndDateTime,
                                            RegionViewModel.SelectedStartDateTimeUtc,
                                            RegionViewModel.SelectedEndDateTimeUtc,
                                            EmailViewModel.EmailAddresses,
                                            EmailViewModel.EmailAddressCount,
                                            RegionViewModel.SelectedCriteria);
            AddedRegions.Add(criteriaFile);

            SelectedRegionRow = criteriaFile;
        }

        public void InitCommands()
        {
            AddRegionCommand = new RelayCommand(AddRegion, CanAddRegion);
            UpdateRegionCommand = new RelayCommand(UpdateRegion, CanUpdateRegion);
        }

        private void UpdateControlsOnSelectionChange(CriteriaFileViewModel value, RegionViewModel regionViewModel)
        {
            var dtvm = regionViewModel.DateTimeViewModel;
            var cvm = regionViewModel.CriteriaViewModel;
            
            SelectedCampaignName = value.CampaignName;
            regionViewModel.SelectedRegion = value.RegionName;
            dtvm.SelectedStartDate = value.ScheduleStart.Date;
            dtvm.SelectedEndDate = value.ScheduleEnd.Date;
            dtvm.SelectedStartHour = value.ScheduleStart.Hour;
            dtvm.SelectedEndHour = value.ScheduleEnd.Hour;
            dtvm.SelectedStartMinute = value.ScheduleStart.Minute;
            dtvm.SelectedEndMinute = value.ScheduleEnd.Minute;
            cvm.SelectedTargetDeviceOsFamilyOperand = value.Stages[0].Criteria[1].Operand;
            cvm.SelectedTargetDeviceOsFamilyValue = value.Stages[0].Criteria[1].Value;
            cvm.SelectedTargetDeviceOsVersionOperand = value.Stages[0].Criteria[0].Operand;
            cvm.SelectedTargetDeviceOsVersionValue = value.Stages[0].Criteria[0].Value;
            cvm.SelectedTargetLastCommunicatedDaysOperand = value.Stages[0].Criteria[2].Operand;
            cvm.SelectedTargetLastCommunicatedDaysValue = value.Stages[0].Criteria[2].Value;
            EmailViewModel.EmailAddresses = value.EmailAddresses;
        }

        public override void ValidateProperty(string propertyName, object value)
        {
            base.ValidateProperty(propertyName, value);

            ClearError(propertyName);

            switch (propertyName)
            {
                case nameof(SelectedCampaignName):
                    if (string.IsNullOrEmpty(SelectedCampaignName))
                    {
                        AddError(propertyName, "Campaign name is required.");
                    }
                    break;
            }
        }
    }
}
