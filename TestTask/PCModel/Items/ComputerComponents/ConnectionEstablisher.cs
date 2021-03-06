using System.Collections.Generic;
using TestTask.ComputerSelling.Items.Connections;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public class ConnectionEstablisher
    {
        private Dictionary<ConnectionInterface,Connection> connections;
        private Component belongs;
            
            
        public Connection TryToConnect  (Component target, ConnectionInterface connectionInterface)
        {
            ConnectionEstablisher targetEstablisher = target.Establisher;
            if (HasFreeConnectionInterface(connectionInterface) && targetEstablisher.HasFreeConnectionInterface(connectionInterface))
            {
                Connection connection = new Connection(connectionInterface, (this.belongs, target));
                targetEstablisher.AddConnection(connection,connectionInterface);
                AddConnection(connection,connectionInterface);
                return connection;
            }
            return null;
        }

        private void AddConnection(Connection connection,ConnectionInterface connectionInterface)
        {
            if (connection != null)
            {
                connections.Add(connectionInterface,connection);
            }
           
        }

        public bool HasConnectionInterface(ConnectionInterface connectionInterface)
        {
            return belongs.GetModel().ConnectionInterfacePool.FindConnectionInterface(connectionInterface) != null;
        }
        public bool HasFreeConnectionInterface(ConnectionInterface connectionInterface)
        {
            if (!HasConnectionInterface(connectionInterface))
                return false;
            bool interfaceIsFree = connections[connectionInterface] != null;
            return interfaceIsFree;
        }
    }
}