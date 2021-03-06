using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.ComputerSelling.Models;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public class MotherBoard : Component
    {
        private MotherboardModel model;

        public MotherBoard(MotherboardModel model)
        {
            this.model = model;
        }

        public override ComponentModel GetModel()
        {
            return model;
        }
    }
}