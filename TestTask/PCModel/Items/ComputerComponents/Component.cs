using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.ComputerSelling.Items.Connections;
using TestTask.ComputerSelling.Models;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    public abstract class Component : IComponent
    {
        protected DateTime creationDate;
        protected DateTime warrantyTime;
        protected bool isBroken;
        protected bool isTurnOn;
        protected ConnectionEstablisher establisher;

        public ConnectionEstablisher Establisher => establisher;

        public abstract ComponentModel GetModel();

        public void Break()
        {
            //*логика удара компонента тяжелым предметом*
            isBroken = true;
        }

      
     
    }
}