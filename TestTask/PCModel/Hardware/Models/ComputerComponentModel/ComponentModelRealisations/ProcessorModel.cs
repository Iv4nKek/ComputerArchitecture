using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    public class ProcessorModel : ComponentModel
    {
        private int cores;
        
        
        public ProcessorModel(string name,float mass, List<ConnectionInterface> connectionInterfacePool, int cores) : base(name, connectionInterfacePool,mass)
        {
            this.cores = cores;
        }
    }
}