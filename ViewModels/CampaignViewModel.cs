using MOE_UI.Commands;
using MOE_UI.Models;
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
        public CampaignViewModel(RegionViewModel regionViewModel)
        {
            RegionViewModel = regionViewModel;
            InitCommands();
        }

        public RegionViewModel RegionViewModel { get; set; }

        ObservableCollection<CriteriaFile> _regions = new();
        public ObservableCollection<CriteriaFile> Regions
        {
            get => _regions;
            set => SetProperty(ref _regions, value);
        }

        CriteriaFile _selectedRegionRow;
        public CriteriaFile SelectedRegionRow
        {
            get => _selectedRegionRow;
            set => SetProperty(ref _selectedRegionRow, value);
        }

        public ICommand AddRegionCommand { get; private set; }

        public bool CanAddRegion()
        {
            return IsDataComplete && RegionViewModel.IsDataComplete && RegionViewModel.DateTimeViewModel.IsDataComplete;
        }

        public void AddRegion()
        {
            CriteriaFile criteriaFile = new(SelectedCampaignName,
                                            RegionViewModel.SelectedRegion,
                                            RegionViewModel.CalculatedSelectedStartDateTimeUtc,
                                            RegionViewModel.CalculatedSelectedEndDateTimeUtc,
                                            RegionViewModel.SelectedCriteria);
            Regions.Add(criteriaFile);
        }

        public void InitCommands()
        {
            AddRegionCommand = new RelayCommand(AddRegion, CanAddRegion);
        }

        string _selectedCampaignName;
        public string SelectedCampaignName
        {
            get => _selectedCampaignName;
            set => SetProperty(ref _selectedCampaignName, value);
        }

        public virtual void ValidateProperty(string propertyName, object value)
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
