﻿using System.Configuration;
using System.Web.Configuration;
using SquishIt.Framework.Utilities;

namespace SquishIt.AspNet.Utilities
{
    public class MachineConfigReader : IMachineConfigReader
    {
        public bool IsNotRetailDeployment
        {
            get
            {
                //check retail setting in machine.config
                //Thanks Dave Ward! http://www.encosia.com
                System.Configuration.Configuration machineConfig = ConfigurationManager.OpenMachineConfiguration();
                var group = machineConfig.GetSectionGroup("system.web");
                if(group != null)
                {
                    var appSettingSection = (DeploymentSection)group.Sections["deployment"];
                    if(appSettingSection.Retail)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}