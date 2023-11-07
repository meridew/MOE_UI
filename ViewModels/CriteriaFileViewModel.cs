using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MOE_UI.ViewModels
{
    public class CriteriaFileViewModel : BaseViewModel
    {
        private readonly Dictionary<string, int> commands = new()
        {
            { "REQUESTDEVICEINFO", 1 },
            { "OSUPDATEINSTALLACTIONDOWNLOADONLY", 2 },
            { "OSUPDATEINSTALLACTIONINSTALLDOWNLOADED", 3 }
        };

        string campaignname;
        public string CampaignName
        {
            get => campaignname;
            set => SetProperty(ref campaignname, value);
        }

        string regionname;
        public string RegionName
        {
            get => regionname;
            set => SetProperty(ref regionname, value);
        }

        DateTime schedulestart;
        public DateTime ScheduleStart
        {
            get => schedulestart;
            set => SetProperty(ref schedulestart, value);
        }

        DateTime scheduleend;
        public DateTime ScheduleEnd
        {
            get => scheduleend;
            set => SetProperty(ref scheduleend, value);
        }

        DateTime schedulestartutc;
        public DateTime ScheduleStartUTC
        {
            get => schedulestartutc;
            set => SetProperty(ref schedulestartutc, value);
        }

        DateTime scheduleendutc;
        public DateTime ScheduleEndUTC
        {
            get => scheduleendutc;
            set => SetProperty(ref scheduleendutc, value);
        }

        string emailaddresses;
        public string EmailAddresses
        {
            get => emailaddresses;
            set
            {
                SetProperty(ref emailaddresses, value);
            }
        }

        int emailaddresscount;
        public int EmailAddressCount
        {
            get => emailaddresscount;
            set => SetProperty(ref emailaddresscount, value);
        }


        private ObservableCollection<StageViewModel> stages;
        public ObservableCollection<StageViewModel> Stages
        {
            get => stages;
            set => SetProperty(ref stages, value);
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
