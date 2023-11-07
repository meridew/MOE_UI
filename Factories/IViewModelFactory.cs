using MOE_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.Factories
{
    public interface IViewModelFactory
    {
        CampaignViewModel CreateCampaignViewModel();
        RegionViewModel CreateRegionViewModel();
        DateTimeViewModel CreateDateTimeViewModel();
        CriteriaViewModel CreateCriteriaViewModel();
    }
}
