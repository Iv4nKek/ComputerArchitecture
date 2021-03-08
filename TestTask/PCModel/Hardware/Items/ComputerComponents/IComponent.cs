using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.ComputerSelling.Items;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public interface IComponent : IItem
    {
        ConnectionEstablisher Establisher { get; }
        void Enable();
        void Disable();
    }
}