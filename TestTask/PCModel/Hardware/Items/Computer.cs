using TestTask.PCModel;
using TestTask.PCModel.Items;
using TestTask.PCModel.Shop;

namespace TestTask.ComputerSelling
{
    /*
      Наивысший уровень абстрации для работы  с компьютером, где идет разделение на железо и софт 
      Выключение и перезапуск были внесены конкретно в hardware и в Software т.к. мы можем выключать комп через кнопку на системнике, или через ОС.
      Данный класс очень похож на паттерн фасад : он предоставляет доступ к своим большим подсистемам и выполняет простейшие задачи.
      Это делает его максимально простым и понятным для пользователя, не погружая его в взамодействие софта и железа.
     */
    public class Computer : IContainsMetal
    {
        private readonly Hardware hardware;
        private ComputerSystem system;
        

        public Hardware Hardware => hardware;
        public ComputerSystem System => system;

        public ComputerSystem TryToTurnOn()
        {
            system = hardware.TryToTurnOn();
            return system;
        }

        public Computer(Hardware hardware)
        {
            this.hardware = hardware;
        }

        public float GetMass()
        {
            return hardware.GetHardwareMass();
        }
    }
}