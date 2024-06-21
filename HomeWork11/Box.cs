namespace HomeWork11
{
    public class Box
    {
        public int Credits {  get; set; }
        public List<Basket> Basket { get; set; }
        public List<Collection> Collection { get; set; }
        
        public Box(int credits, List<Basket> baskets, List<Collection> collections) 
        {
            Credits = credits;
            Basket = baskets;
            Collection = collections;
        }
    }
}
