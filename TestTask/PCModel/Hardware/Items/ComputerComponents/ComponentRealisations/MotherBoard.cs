using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ComputerComponentModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public class MotherBoard : Component
    {
        private readonly MotherboardModel model;
        
        public MotherBoard(MotherboardModel model) 
        {
            this.model = model;
            requireComponents = new List<Type>() {typeof(Processor),typeof(HardDrive),typeof(PowerSupply)};
        }

        public override ComponentModel GetModel()
        {
            return model;
        }

        public ComputerSystem TryRun()
        {
            if (CanRun())
            {
                enabled = true;
                establisher.GetConnected().ForEach(x=>x.Enable());
                return establisher.GetComponent<HardDrive>().InstalledComputerSystem;
            }
            return null;
        }

        public void TurnOff()
        {
            enabled = false;
            establisher.GetConnected().ForEach(x=>x.Disable());
        }

       
    }
}