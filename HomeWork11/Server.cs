namespace HomeWork11
{
    public class Server
    {
        private Random _random = new Random();
        public Action? BoxesCreated;

        public List<Box> CreateListOfBoxes()
        {
            int x = _random.Next(10);

            if (x >= 0 && x <= 2)
            {
                List<Box> boxes = new List<Box>();

                BoxesCreated?.Invoke();

                int y = _random.Next(2);

                if (y == 0)
                {
                    return null;
                }
                else
                {
                    return boxes;
                }
            }
            else
            {
                List<Box> boxes = new List<Box>();

                for (int i = 0; i < 4; i++)
                {
                    boxes.Add(CreateRandomBox());
                }

                BoxesCreated?.Invoke();

                return boxes;
            }
        }

        private Box CreateRandomBox()
        {
            Box box = new Box();

            int[] creditsMas = {0, 10, 50,  100};

            box.Credits = creditsMas[_random.Next(4)];

            for (int i = 0; i < _random.Next(6); i++) 
            {
                box.Collection.Add(CreateRandomCollection());
            }

            for (int i = 0; i < _random.Next(3); i++)
            {
                box.Basket.Add(CreateRandomBasket());
            }
            
            return box;
        }

        private Basket CreateRandomBasket()
        {
            Basket basket = new Basket();

            int[] credits = { 10, 50 };

            basket.Credits = credits[_random.Next(2)];

            for (int i = 0; i < _random.Next(1, 4); i++) 
            {
                basket.Collections.Add(CreateRandomCollection());
            }

            return basket;
        }

        private Collection CreateRandomCollection() 
        {
            Collection collection = new Collection();

            collection.Id = _random.Next(1, 11);

            return collection;
        }
    }
}
