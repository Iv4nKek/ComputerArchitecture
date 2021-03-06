using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ConnectionInterfaces
{
    public class ConnectionPool
    {
        private List<IConnectionInterface> _connections;

        public List<IConnectionInterface> FindConnectionInterfaces(IConnectionInterfaceModel connectionInterfaceModel)
        {
            return _connections.FindAll(x=>x.GetModel()==connectionInterfaceModel);
        }
    }
}