using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.ComputerSelling.Models;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    public interface IComponentModel 
    {
        ConnectionInterfacePool GetConnectionInterfacePool();
    }
}