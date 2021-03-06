using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.ComputerSelling.Models;

namespace TestTask.ComputerSelling.Items
{
    public interface IItem
    {
        ComponentModel GetModel();
    }
}