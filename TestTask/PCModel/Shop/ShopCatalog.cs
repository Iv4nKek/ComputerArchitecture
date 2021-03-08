using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.ComputerSelling;
using TestTask.PCModel.Items.ComputerComponents;

namespace TestTask.PCModel.Shop
{
    /*
     При создании магазина, мы абстрагируемся от того, что конкретно мы продаём, требуем лишь наследования от ISellable
     
    С одной стороны мы можем продавать компьютеры и компоненты к ким, 
    но с другой стороны для продажи компонентов было бы правильно использовать их модели, которых у самого компьютера нет :(
    При продаже лишь одних компонентов можно было бы использовать Generics(like ShopCatalog<Motherboard>) и не кастить товар из ISellable при покупке.
     */
    public class ShopCatalog
    {
        private List<Lot> lots = new List<Lot>();

        public void AddLot(Lot lot)
        {
            if (lot != null)
            {
                
                Lot same = lots.Find(x => x.Item.IsSameModel(lot.Item));
                if (same != null && same.Cost == lot.Cost)
                {
                    same.Amount += lot.Amount;
                }
                else
                {
                    lots.Add(lot);
                }
                
            }
        }

        public List<Lot> FindSuitable(Predicate<Lot> predicate, Func<Lot,Lot> sortPredicate) => lots.FindAll(predicate).OrderBy(sortPredicate).ToList();
        public List<Lot> FindSuitable(Predicate<Lot> predicate) => lots.FindAll(predicate).ToList();

        public ISellable Buy(Lot lot)
        {
            if (lot != null && lots.Contains(lot) && lot.Amount > 0)
            {
                lot.Amount--;
                if (lot.Amount == 0)
                {
                    lots.Remove(lot);
                }

                return lot.Item;
            }

            return null;
        }
    }
}