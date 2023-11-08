using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MOE_UI.ViewModels
{
    public class CriteriaFileViewModel : BaseViewModel
    {
        private readonly Dictionary<string, int> commands = new()
        {
            { "REQUEST_DEVICE_INFO", 1 },
            { "OS_UPDATE_INSTALL_ACTION_DOWNLOAD_ONLY", 2 },
            { "OS_UPDATE_INSTALL_ACTION_INSTALL_DOWNLOADED", 3 }
        };

        string campaignName;
        public string CampaignName
        {
            get => campaignName;
            set => SetProperty(ref campaignName, value);
        }

        string regionName;
        public string RegionName
        {
            get => regionName;
            set => SetProperty(ref regionName, value);
        }

        DateTime scheduleStart;
        public DateTime ScheduleStart
        {
            get => scheduleStart;
            set => SetProperty(ref scheduleStart, value);
        }

        DateTime scheduleEnd;
        public DateTime ScheduleEnd
        {
            get => scheduleEnd;
            set => SetProperty(ref scheduleEnd, value);
        }

        DateTime scheduleStartUtc;
        public DateTime ScheduleStartUTC
        {
            get => scheduleStartUtc;
            set => SetProperty(ref scheduleStartUtc, value);
        }

        DateTime scheduleEndUtc;
        public DateTime ScheduleEndUTC
        {
            get => scheduleEndUtc;
            set => SetProperty(ref scheduleEndUtc, value);
        }

        string emailAddresses;
        public string EmailAddresses
        {
            get => emailAddresses;
            set
            {
                SetProperty(ref emailAddresses, value);
            }
        }

        int emailAddressCount;
        public int EmailAddressCount
        {
            get => emailAddressCount;
            set => SetProperty(ref emailAddressCount, value);
        }

        private ObservableCollection<StageViewModel> stages;
        public ObservableCollection<StageViewModel> Stages
        {
            get => stages;
            set => SetProperty(ref stages, value);
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }

        public CriteriaFileViewModel(string campaignName, string regionName, DateTime scheduleStart, DateTime scheduleEnd, DateTime scheduleStartUtc, DateTime scheduleEndUtc, string emailAddresses, int emailAddressCount, ObservableCollection<CriterionViewModel> criteria)
        {
            CampaignName = campaignName;
            RegionName = regionName;
            ScheduleStart = scheduleStart;
            ScheduleEnd = scheduleEnd;
            ScheduleStartUTC = scheduleStartUtc;
            ScheduleEndUTC = scheduleEndUtc;
            EmailAddresses = emailAddresses;
            EmailAddressCount = emailAddressCount;
            stages = new ObservableCollection<StageViewModel>();

            foreach (string command in commands.Keys)
            {
                stages.Add(new StageViewModel(commands[command], command, criteria));
            }
        }
    }
}
