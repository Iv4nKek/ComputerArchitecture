using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    public class PowerSupplyModel : ComponentModel
    {
        private int power;
        
        
        public PowerSupplyModel(string name,float mass, List<ConnectionInterface> connectionInterfacePool, int power) : base(name, connectionInterfacePool,mass)
        {
            this.power = power;
        }
    }
}