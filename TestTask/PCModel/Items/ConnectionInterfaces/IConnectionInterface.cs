using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ConnectionInterfaces
{
    public interface IConnectionInterface
    {
        IConnectionInterfaceModel GetModel();
        IConnectionInterface Connect(IConnectionInterface connection);
    }
}