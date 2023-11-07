using MOE_UI.ViewModels;
using System;

namespace MOE_UI.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly DateTimeViewModel dateTimeViewModel;
        private readonly CriteriaViewModel criteriaViewModel;
        private readonly EmailViewModel emailViewModel;
        private readonly Lazy<RegionViewModel> lazyRegionViewModel; // Lazy<T> for lazy initialization

        public ViewModelFactory()
        {
            dateTimeViewModel = new DateTimeViewModel();
            criteriaViewModel = new CriteriaViewModel();
            emailViewModel = new EmailViewModel();
            lazyRegionViewModel = new Lazy<RegionViewModel>(() => new RegionViewModel(dateTimeViewModel, criteriaViewModel));
        }

        public CampaignViewModel CreateCampaignViewModel()
        {
            // Ensure we reuse the same RegionViewModel instance
            return new CampaignViewModel(lazyRegionViewModel.Value, emailViewModel);
        }

        public DateTimeViewModel CreateDateTimeViewModel()
        {
            return dateTimeViewModel;
        }

        public RegionViewModel CreateRegionViewModel()
        {
            // The Value property ensures that the instance is created only once.
            return lazyRegionViewModel.Value;
        }

        public CriteriaViewModel CreateCriteriaViewModel()
        {
            return criteriaViewModel;
        }

        public EmailViewModel CreateEmailViewModel()
        {
            return emailViewModel;
        }
    }

}
