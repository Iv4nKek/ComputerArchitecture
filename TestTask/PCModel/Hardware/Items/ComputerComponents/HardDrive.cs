using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ComputerComponentModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public class HardDrive : Component
    {
        private readonly HardDriveModel model;
        private ComputerSystem installedComputerSystem;

        public HardDrive(HardDriveModel model)
        {
            this.model = model;
            requireComponents = new List<Type>() {typeof(MotherBoard)};
        }


        public ComputerSystem InstalledComputerSystem => installedComputerSystem;

        public void InstallSystem(ComputerSystem computerSystem)
        {
            installedComputerSystem = computerSystem;
        }

        public override ComponentModel GetModel()
        {
            return model;
        }

      
    }
}