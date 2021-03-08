using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.ComputerSelling.Models.Atributes;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    public class MotherboardModel : ComponentModel
    {
        private Socket socket;
        private FormFactor formFactor;
        
        
        public MotherboardModel(string name,float mass, List<ConnectionInterface> connectionInterfacePool , Socket socket, FormFactor formFactor) : base(name, connectionInterfacePool,mass)
        {
            this.socket = socket;
            this.formFactor = formFactor;
        }
    }
}