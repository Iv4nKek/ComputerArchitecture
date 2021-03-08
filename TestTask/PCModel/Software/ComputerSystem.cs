
using TestTask.PCModel;
using TestTask.PCModel.Items.ComputerComponents;

namespace TestTask.PCModel.Items
{
    public class ComputerSystem
    {
        private Hardware current;
        private bool isTurnOn;
        
        public void InstallApplication(Application application)
        {
            
        }

        public void Execute(byte[] binaryCode)
        {
            
        }

        public void Startup(Hardware hardware)
        {
            if (hardware != null)
            {
                current = hardware;
                isTurnOn = true;
            }
        }

        public void TurnOff()
        {
            current?.TurnOff();
        }

        public void Restart()
        {
            current?.Restart();
        }
    }
}