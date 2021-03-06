using System;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;

namespace TestTask.PCModel.Models.ConnectionInterfaceModel
{
    public class ConnectionInterface : IConnectionInterface
    {
        private String name;
        
        public string Name => name;
        public ConnectionInterface(string name)
        {
            this.name = name;
        }

        
    }
}