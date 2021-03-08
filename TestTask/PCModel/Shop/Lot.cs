using TestTask.ComputerSelling;
using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.PCModel.Items.ComputerComponents;

namespace TestTask.PCModel.Shop
{
    // Обёртываеам ISellable объект в сущность товара
    public class Lot
    {
        private readonly ISellable item;
        private decimal cost;
        private int amount;

        public ISellable Item => item;
        

        public decimal Cost
        {
            get => cost;
            set =>cost = value>0? cost: value;
        }

        public int Amount
        {
            get => amount;
            set => amount = value>0? amount: value;
        }

        public Lot(ISellable item, decimal cost, int amount)
        {
            this.item = item;
            this.cost = cost;
            this.amount = amount;
        }
    }
}