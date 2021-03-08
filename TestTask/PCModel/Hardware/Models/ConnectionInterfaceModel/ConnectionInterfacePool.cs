using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;
using TestTask.PCModel.ComputerClass;
using TestTask.PCModel.Models.ConnectionInterfaceModel;
using IConnectionInterface = TestTask.ComputerSelling.Models.ConnectionInterfaceModel.IConnectionInterface;

namespace TestTask.ComputerSelling.ConnectionInterfaces
{
    /*
      Пул интерфейсов был создан для снятия с компонента ответственности за управление интерфейсами подключений 
     */
    public class ConnectionInterfacePool 
    {
        private List<ConnectionInterface> _connections;

        
        public ConnectionInterface FindConnectionInterface(ConnectionInterface connectionInterface)
        {
            return _connections.Find(x=>x==connectionInterface);
        }

        public ConnectionInterface FindSameInterface(ConnectionInterfacePool anotherPool)
        {
            foreach (var connectionInterface in _connections)
            {
                if (anotherPool.FindConnectionInterface(connectionInterface) != null)
                {
                    return connectionInterface;
                }
            }

            return null;
        }
        
        public List<ConnectionInterface> FindSameInterfaces(ConnectionInterfacePool anotherPool)
        {
            List<ConnectionInterface> connectionInterfaces = new List<ConnectionInterface>();
            foreach (var connectionInterface in _connections)
            {
                if (anotherPool.FindConnectionInterface(connectionInterface) != null)
                {
                    connectionInterfaces.Add(connectionInterface);
                }
            }
            return connectionInterfaces;
        }
        
        public ConnectionInterfacePool(List<ConnectionInterface> connections)
        {
            _connections = connections;
        }
    }
}