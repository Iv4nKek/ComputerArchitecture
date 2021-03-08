namespace TestTask.PCModel.Shop
{
    //Данный интерфейс требуется для того, чтобы абстрагироваться до уровня товаров и узнавать являются ли два товара одной моделью
    public interface ISellable
    {
        bool IsSameModel(ISellable anotherItem);
    }
}