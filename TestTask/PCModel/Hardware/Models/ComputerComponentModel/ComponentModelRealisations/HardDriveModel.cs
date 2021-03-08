using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.PCModel.Items.ComputerComponents;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    public class HardDriveModel : ComponentModel
    {
        private int size;
        
        
        public HardDriveModel(string name,float mass, List<ConnectionInterface> connectionInterfacePool, int size) : base(name, connectionInterfacePool,mass)
        {
            this.size = size;
        }

        
    }
}