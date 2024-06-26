namespace HomeWork11
{
    public class Basket
    {
        public int Credits { get; set; } // в корзине от 10 до 50 кредитов
        public List<Collection> Collections = new List<Collection>(); // в корзине от 1 до 3 коллекшинов
    }
}
