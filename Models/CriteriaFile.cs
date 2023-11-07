using MOE_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MOE_UI.Models
{
    public class CriteriaFile : BaseViewModel
    {
        private readonly Dictionary<string, int> _commands = new()
        {
            { "REQUEST_DEVICE_INFO", 1 },
            { "OS_UPDATE_INSTALL_ACTION_DOWNLOAD_ONLY", 2 },
            { "OS_UPDATE_INSTALL_ACTION_INSTALL_DOWNLOADED", 3 }
        };

        string _campaign_name;
        public string Campaign_Name
        {
            get => _campaign_name;
            set => SetProperty(ref _campaign_name, value);
        }

        string _region_name;
        public string Region_Name
        {
            get => _region_name;
            set => SetProperty(ref _region_name, value);
        }

        string _schedule_start;
        public string Schedule_Start
        {
            get => _schedule_start;
            set => SetProperty(ref _schedule_start, value);
        }

        string _schedule_end;
        public string Schedule_End
        {
            get => _schedule_end; 
            set => SetProperty(ref _schedule_end, value);
        }

        private ObservableCollection<Stage> _stages;
        public ObservableCollection<Stage> Stages
        {
            get => _stages;
            set => SetProperty(ref _stages, value);
        }
        public CriteriaFile(string campaignName, string regionName, DateTime scheduleStart, DateTime scheduleEnd, ObservableCollection<Criterion> criteria)
        {
            Campaign_Name = campaignName;
            Region_Name = regionName;
            Schedule_Start = scheduleStart.ToString();
            Schedule_End = scheduleEnd.ToString();
            _stages = new ObservableCollection<Stage>();

            foreach (string command in _commands.Keys)
            {
                _stages.Add(new Stage(_commands[command], command, criteria));
            }
        }
    }
}
