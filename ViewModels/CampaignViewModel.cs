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

        ObservableCollection<CriteriaFileViewModel> regions = new();
        public ObservableCollection<CriteriaFileViewModel> Regions
        {
            get => regions;
            set => SetProperty(ref regions, value);
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
                var name = nameof(SelectedCampaignName);
                Console.WriteLine(name);
                SetProperty(ref selectedRegionRow, value);
                UpdateControlsOnSelectionChange(value, RegionViewModel);
            }
        }

        public ICommand AddRegionCommand { get; private set; }

        public bool CanAddRegion()
        {
            return IsDataComplete && RegionViewModel.IsDataComplete && RegionViewModel.DateTimeViewModel.IsDataComplete;
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
            Regions.Add(criteriaFile);

            SelectedRegionRow = criteriaFile;
        }

        public void InitCommands()
        {
            AddRegionCommand = new RelayCommand(AddRegion, CanAddRegion);
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
            cvm.SelectedTargetOsFamilyOperand = value.Stages[0].Criteria[1].Operand;
            cvm.SelectedTargetOsFamilyValue = value.Stages[0].Criteria[1].Value;
            cvm.SelectedTargetDeviceOsOperand = value.Stages[0].Criteria[0].Operand;
            cvm.SelectedTargetDeviceOsValue = value.Stages[0].Criteria[0].Value;
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
