using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ComputerComponentModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public class PowerSupply : Component
    {
        private readonly PowerSupplyModel model;

        public PowerSupply(PowerSupplyModel model) 
        {
            this.model = model;
            requireComponents = new List<Type>() {typeof(MotherBoard)};
        }

        public override ComponentModel GetModel()
        {
            return model;
        }
       
    }
}