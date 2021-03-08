using System.Collections.Generic;
using System.Linq;
using TestTask.ComputerSelling;
using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.ComputerSelling.Models.Atributes;
using TestTask.PCModel;
using TestTask.PCModel.ComputerClass;
using TestTask.PCModel.Items;
using TestTask.PCModel.Items.ComputerComponents;
using TestTask.PCModel.Models.ConnectionInterfaceModel;
using TestTask.PCModel.Shop;

namespace TestTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //примеры работы с моделью.
            
            ConnectionInterface sata = new ConnectionInterface("Sata-1");
            ConnectionInterface pciExpress = new ConnectionInterface("PCI-Express");
            ConnectionInterface powerPin = new ConnectionInterface("PowerPin");
            ConnectionInterface socket = new ConnectionInterface("AM4");
            
            MotherboardModel motherboardModel = new MotherboardModel("B450",2, new List<ConnectionInterface>(){sata,pciExpress,powerPin,socket},Socket.AM4,FormFactor.MiniATx);
            HardDriveModel hddModel = new HardDriveModel("mega hdd", 4,new List<ConnectionInterface>() {sata, powerPin},7200);
            PowerSupplyModel powerSupplyModel = new PowerSupplyModel("PS-8000",55, new List<ConnectionInterface>() {powerPin, powerPin,powerPin},600);
            ProcessorModel processorModel = new ProcessorModel("3600x", 6,new List<ConnectionInterface>() {socket},6);
            
            MotherBoard mother = new MotherBoard(motherboardModel);
            MotherBoard anotherMother = new MotherBoard(motherboardModel);
            Processor processor = new Processor(processorModel);
            PowerSupply powerSupply = new PowerSupply(powerSupplyModel);
            HardDrive hardDrive = new HardDrive(hddModel);

            mother.Establisher.TryToConnect(processor, socket);
            mother.Establisher.TryToConnect(hardDrive, sata);
            mother.Establisher.TryToConnect(powerSupply, powerPin);
            hardDrive.Establisher.TryToConnect(powerSupply, powerPin);

            Hardware hardware = new Hardware(mother);
            ComputerSystem system = new ComputerSystem();
            hardDrive.InstallSystem(system);
            
            //Включение и перезагрузка. Включать можно только через Hardware. Выключать и рестарат через Hardware и ComputerSystem.(like IRL)
            Computer computer = new Computer(hardware);
            ComputerSystem loadedSystem = computer.Hardware.TryToTurnOn();
            loadedSystem.Restart();

            //Продажа компьютеров
            ShopCatalog catalog = new ShopCatalog();
            catalog.AddLot(new Lot(computer.Hardware,100,2));
            Lot wantToBuy = catalog.FindSuitable(x => x.Cost < 150 && x.Item is Hardware).First();
            Hardware boughtHardware = (Hardware)catalog.Buy(wantToBuy);
            Computer boughtComputer = new Computer(boughtHardware);
            
            //Замена материнской платы
            boughtComputer.Hardware.TryToReplaceComponent(mother, anotherMother);
            
            //Установка приложения в компьютерном классе
            Application trojan = new Application(new byte[228]);
            List<Computer> installedComputers = new List<Computer>() {boughtComputer};
            ComputerClass computerClass = new ComputerClass(installedComputers);
            computerClass.InstallApplicationOnEach(trojan);
            computerClass.Command(x=>x.System?.Execute(trojan.BinaryCode));

            // сбор металлолома
            MetalCollector collector = new MetalCollector();
            collector.Collect(boughtComputer);




        }
    }
}