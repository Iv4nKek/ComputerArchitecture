using System.Collections.Generic;
using TestTask.PCModel.Items.ComputerComponents;

namespace TestTask.ComputerSelling
{
    public class Computer
    {
        private List<Component> components;

        public void Break()
        {
            foreach (var component in components)
            {
                component.Break();
            }
        }

        private MotherBoard FindRoot()
        {
            return (MotherBoard)components.Find(x => x.GetType() == typeof(MotherBoard));
        }
        public void TurnOn()
        {
            
        }
    }
}