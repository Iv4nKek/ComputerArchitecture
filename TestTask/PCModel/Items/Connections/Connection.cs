using TestTask.PCModel.Items.ComputerComponents;
using TestTask.PCModel.Models.ConnectionInterfaceModel;
using System;

namespace TestTask.ComputerSelling.Items.Connections
{
    public class Connection
    {
        private ConnectionInterface connectionInterface;
        private (Component, Component) connectedComponents;

        public Connection(ConnectionInterface connectionInterface, (Component, Component) connectedComponents)
        {
            this.connectionInterface = connectionInterface;
            this.connectedComponents = connectedComponents;
        }
    }
}