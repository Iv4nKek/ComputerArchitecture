using System.Collections.Generic;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;
using TestTask.PCModel.Items.ComputerComponents;

namespace TestTask.ComputerSelling.Items.Connections
{
    public interface IConnection
    {
        IConnectionInterface GetConnectionInterface();
        IEnumerable<IComponent> GetConnectedComponents();
    }
}