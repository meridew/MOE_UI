using MOE_UI.Factories;

namespace MOE_UI.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IViewModelFactory _viewModelFactory;
        private CampaignViewModel _campaignViewModel;
        private RegionViewModel _regionViewModel;
        private EmailViewModel _emailViewModel;

        public ViewModelLocator()
        {
            _viewModelFactory = new ViewModelFactory();
        }

        public CampaignViewModel CampaignViewModel
        {
            get
            {
                if (_campaignViewModel == null)
                {
                    _campaignViewModel = _viewModelFactory.CreateCampaignViewModel();
                }
                return _campaignViewModel;
            }
        }

        public RegionViewModel RegionViewModel
        {
            get
            {
                if (_regionViewModel == null)
                {
                    _regionViewModel = _viewModelFactory.CreateRegionViewModel();
                }
                return _regionViewModel;
            }
        }

        public EmailViewModel EmailViewModel
        {
            get
            {
                if (_emailViewModel == null)
                {
                    _emailViewModel = _viewModelFactory.CreateEmailViewModel();
                }
                return _emailViewModel;
            }
        }
    }
}
