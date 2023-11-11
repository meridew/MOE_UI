using MOE_UI.Commands;
using MOE_UI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MOE_UI.ViewModels
{
    public class CampaignViewModel : BaseViewModel
    { 
        public CampaignViewModel(RegionViewModel regionViewModel, EmailViewModel emailViewModel)
        {
            RegionViewModel = regionViewModel;
            EmailViewModel = emailViewModel;
            AddRegionIndicatorColor = "Transparent";
            UpdateRegionIndicatorColor = "Transparent";
            ValidateProperty(nameof(SelectedCampaignName), SelectedCampaignName);
            InitCommands();
        }

        public RegionViewModel RegionViewModel { get; set; }
        public EmailViewModel EmailViewModel { get; set; }

        string addRegionIncidactorColor;
        public string AddRegionIndicatorColor
        {
            get => addRegionIncidactorColor;
            set => SetProperty(ref addRegionIncidactorColor, value);
        }

        string updateRegionIndicatorColor;
        public string UpdateRegionIndicatorColor
        {
            get => updateRegionIndicatorColor;
            set => SetProperty(ref updateRegionIndicatorColor, value);
        }

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
                if (SelectedRegionRow != null)
                {
                    SelectedStageRow = value.Stages[0];
                }

                UpdateControlsOnSelectionChange(value, RegionViewModel);
            }
        }

        public RelayCommand AddRegionCommand { get; private set; }
        public RelayCommand UpdateRegionCommand { get; private set; }
        public RelayCommand RemoveRegionCommand { get; private set; }
        public RelayCommand ExportCampaignCommand { get; private set; }

        bool CanExportCampaign()
        {
            return AddedRegions.Count > 0;
        }

        void ExportCampaign()
        {
            FileHelper.ExportCampaignPrompt(this);
        }

        void RemoveRegion()
        {
            AddedRegions.Remove(SelectedRegionRow);

            if (AddedRegions.Count > 0)
            {
                SelectedRegionRow = AddedRegions[0];
            }
        }

        bool CanRemoveRegion()
        {
            return SelectedRegionRow != null;
        }

        void SetIndicatorColor(string property, bool enabled)
        {
            switch (property)
            {
                case nameof(AddRegionIndicatorColor):
                    AddRegionIndicatorColor = enabled ? "DarkGreen" : "Transparent";
                    break;
                case nameof(UpdateRegionIndicatorColor):
                    UpdateRegionIndicatorColor = enabled ? "LightGreen" : "Transparent";
                    break;
            }
        }

        public bool CanUpdateRegion()
        {
            // Check if there is a selected region.
            if (SelectedRegionRow == null)
            {
                SetIndicatorColor(nameof(UpdateRegionIndicatorColor), false);
                return false;
            }

            // Check if the region name is unique in AddedRegions, ignoring the selected region row.
            bool isRegionNameUniqueOrSameAsSelected = !AddedRegions.Any(region =>
                region != SelectedRegionRow &&
                region.RegionName.Equals(RegionViewModel.SelectedRegion, StringComparison.OrdinalIgnoreCase));

            // Check if any property of the SelectedRegionRow differs from the view model.
            bool isRegionChanged = SelectedRegionRow.RegionName != RegionViewModel.SelectedRegion ||
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

            // If the region name is unique (or the same as the selected one) and any other property has changed.
            if (isRegionNameUniqueOrSameAsSelected && isRegionChanged)
            {
                SetIndicatorColor(nameof(UpdateRegionIndicatorColor), true);
                return true;
            }

            // If none of the conditions are met, indicate no update is possible and return false.
            SetIndicatorColor(nameof(UpdateRegionIndicatorColor), false);
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
            if(IsDataComplete &&
                RegionViewModel.IsDataComplete &&
                RegionViewModel.DateTimeViewModel.IsDataComplete &&
                RegionViewModel.CriteriaViewModel.IsDataComplete &&
                !AddedRegions.Any(region => region.RegionName.Equals(RegionViewModel.SelectedRegion, StringComparison.OrdinalIgnoreCase)))
            {
                SetIndicatorColor(nameof(AddRegionIndicatorColor), true);
                
                return true;
            }

            SetIndicatorColor(nameof(AddRegionIndicatorColor), false);

            return false;
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
            RemoveRegionCommand = new RelayCommand(RemoveRegion, CanRemoveRegion);
            ExportCampaignCommand = new RelayCommand(ExportCampaign, CanExportCampaign);
        }

        void UpdateControlsOnSelectionChange(CriteriaFileViewModel value, RegionViewModel regionViewModel)
        {
            if(value != null)
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
                
                case nameof(RegionViewModel.SelectedRegion):
                    if (string.IsNullOrEmpty(RegionViewModel.SelectedRegion))
                    {
                        AddError(propertyName, "Region is required.");
                    }
                    else if (AddedRegions.Any(region => region.RegionName.Equals(RegionViewModel.SelectedRegion, StringComparison.OrdinalIgnoreCase)))
                    {
                        AddError(propertyName, "Region already added.");
                    }
                    break;
            }
        }
    }
}
