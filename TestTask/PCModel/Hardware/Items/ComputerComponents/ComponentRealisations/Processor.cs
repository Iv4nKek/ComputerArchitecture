using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ComputerComponentModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public class Processor : Component
    {
        private readonly ProcessorModel model;

        public Processor(ProcessorModel model)
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