using System;
using System.Collections.Generic;
using TestTask.ComputerSelling;
using TestTask.PCModel.Items;
using TestTask.PCModel.Items.ComputerComponents;

namespace TestTask.PCModel.ComputerClass
{
    /*
     Т.к. компьютеры класса, как правило, не различаются, и действия касаются их всех,
     то тут я решил сделать что-то напоминающие паттерн Команда и отдавать команды, котырые будут исполняся на всех компьютерах
    */
    public class ComputerClass
    {
        private List<Computer> installedComputers;

        public void Command(Action<Computer> command)
        {
            installedComputers.ForEach(command);
        }
        public void InstallApplicationOnEach(Application application)
        {
            Command(x=>x.Hardware.TryToTurnOn()?.InstallApplication(application));
            
        }
        
        public ComputerClass(List<Computer> installedComputers)
        {
            this.installedComputers = installedComputers;
        }
    }
}