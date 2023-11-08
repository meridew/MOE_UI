using MOE_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.Helpers
{
    public class FileHelper
    {
        static public void ExportCampaign(CampaignViewModel campaign)
        {
            foreach(var region in campaign.AddedRegions)
            {
                var json = region.ToJson();

                var fileName = $"{region.CampaignName}_{region.RegionName}.json";

                FileHelper.WriteFileContents($"C:\\Temp\\{fileName}" + ".json", json);
            }  
        }
        
        
        public static void WriteFileContents(string path, string contents)
        {
            System.IO.File.WriteAllText(path, contents);
        }
    }
}
