namespace HomeWork11
{
    public class Basket
    {
        public int Credits { get; set; } // в корзине от 10 до 50 кредитов
        public List<int> Collections { get; set; } // в корзине от 1 до 3 коллекшинов

        public Basket (int credits, List<int> collections)
        {
            Credits = credits;
            Collections = collections;
        }
    }
}
