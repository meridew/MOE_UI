using MOE_UI.ViewModels;
using System;

namespace MOE_UI.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly DateTimeViewModel _dateTimeViewModel;
        private readonly CriteriaViewModel _criteriaViewModel;
        private readonly Lazy<RegionViewModel> _lazyRegionViewModel; // Lazy<T> for lazy initialization

        public ViewModelFactory()
        {
            _dateTimeViewModel = new DateTimeViewModel();
            _criteriaViewModel = new CriteriaViewModel();
            _lazyRegionViewModel = new Lazy<RegionViewModel>(() => new RegionViewModel(_dateTimeViewModel, _criteriaViewModel));
        }

        public CampaignViewModel CreateCampaignViewModel()
        {
            // Ensure we reuse the same RegionViewModel instance
            return new CampaignViewModel(_lazyRegionViewModel.Value);
        }

        public DateTimeViewModel CreateDateTimeViewModel()
        {
            return _dateTimeViewModel;
        }

        public RegionViewModel CreateRegionViewModel()
        {
            // The Value property ensures that the instance is created only once.
            return _lazyRegionViewModel.Value;
        }

        public CriteriaViewModel CreateCriteriaViewModel()
        {
            return _criteriaViewModel;
        }
    }

}
