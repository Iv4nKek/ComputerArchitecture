using System;
using System.Collections.Generic;
using TestTask.ComputerSelling;
using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.ComputerSelling.Models.Atributes;
using TestTask.PCModel.Items.ComputerComponents;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConnectionInterface sata = new ConnectionInterface("Sata-1");
            ConnectionInterface pciExpress = new ConnectionInterface("PCI-Express");
            ConnectionInterfacePool pool = new ConnectionInterfacePool(new List<ConnectionInterface>(){sata,pciExpress});
            MotherboardModel yourMother = new MotherboardModel("Mega mother", pool,Socket.AM4,FormFactor.MiniATx);
            MotherBoard newBoard = new MotherBoard(yourMother);
            Computer computer = null;
            
            //Ломаем компьютер
            computer.Break();
            //Сдаём дворнику на металлолом
            computer = null;
            GC.Collect();


        }
    }
}