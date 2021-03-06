using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;
using TestTask.PCModel.Models.ConnectionInterfaceModel;
using IConnectionInterface = TestTask.ComputerSelling.Models.ConnectionInterfaceModel.IConnectionInterface;

namespace TestTask.ComputerSelling.ConnectionInterfaces
{
    public class ConnectionInterfacePool 
    {
        private List<ConnectionInterface> _connections;

        public ConnectionInterface FindConnectionInterface(ConnectionInterface connectionInterface)
        {
            if (_connections.Find(x => x == connectionInterface) !=null)
            {
                
            }
            return _connections.Find(x=>x==connectionInterface);
        }
        public ConnectionInterfacePool(List<ConnectionInterface> connections)
        {
            _connections = connections;
        }
    }
}