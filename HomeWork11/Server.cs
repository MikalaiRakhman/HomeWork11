using HomeWork11.Rewards;

namespace HomeWork11
{
    public class Server
    {
        public Action<List<Chest>> ChestsCreated;

        public void Send()
        {
            if (ChestsCreated != null)
            {
                ChestsCreated(CreateListOfChests());
            }
        }

        private List<Chest> CreateListOfChests()
        {
            Random random = new Random();

            int x = random.Next(10);

            if (x >= 0 && x <= 2)
            {
                List<Chest> chests = new List<Chest>();

                int y = random.Next(2);

                if (y == 0)
                {
                    return null;
                }
                else
                {
                    return chests;
                }
            }
            else
            {
                List<Chest> chests = new List<Chest>();                

                for (int i = 0; i < 4; i++)
                {
                    chests.Add(CreateRandomChest());
                }                

                return chests;
            }
        }

        private Chest CreateRandomChest()
        {
            Chest chest = new Chest();

            chest.Rewards = GenerateRewardsForChest();

            return chest;
        }

        private List<IReward> GenerateRewardsForChest() 
        {
            var rewards = new List<IReward>();

            var credits = GenerateCreditsForChest();

            var collections = GenerateCollectionsForTheChest();

            var baskets = GenerateBasketsForTheChest();

            rewards = rewards.Concat(credits).Concat(collections).Concat(baskets).ToList();

            return rewards;
        }

        private List<IReward> GenerateCreditsForChest()
        {
            var rewards = new List<IReward>();

            Random random = new Random();

            int[] creditsMas = { 0, 10, 50, 100 };

            var count = creditsMas[random.Next(creditsMas.Length)];

            for (int i = 0; i < count; i++) 
            {
                rewards.Add(new Credits());
            }

            return rewards;
        }

        private List<IReward> GenerateCollectionsForTheChest()
        {
            var rewards = new List <IReward>();

            Random random = new Random();

            for (int i = 0; i < random.Next(6); i++)
            {
                rewards.Add(CreateRandomCollection());
            }

            return rewards;
        }

        private List<IReward> GenerateBasketsForTheChest() 
        {
            var rewards = new List<IReward>();

            Random random = new Random();

            for (int i = 0; i < random.Next(3); i++)
            {
                rewards.Add(CreateRandomBasket());
            }

            return rewards;
        }

        private Basket CreateRandomBasket()
        {
            var random = new Random();

            Basket basket = new Basket();

            int[] credits = { 10, 50 };

            var count = credits[random.Next(credits.Length)];

            for (int i = 0; i < count; i++)
            {
                basket.Rewards.Add(new Credits());
            }

            for (int i = 0; i < random.Next(1, 4); i++) 
            {
                basket.Rewards.Add(CreateRandomCollection());
            }

            return basket;
        }

        private Collection CreateRandomCollection() 
        {
            var random = new Random();

            Collection collection = new Collection();

            collection.Id = random.Next(1, 11);

            return collection;
        }
    }
}
