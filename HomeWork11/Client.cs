using System.Text;
using HomeWork11.Exceptions;
using HomeWork11.Exeptions;
using HomeWork11.Rewards;

namespace HomeWork11
{
    public class Client
    {
        public void Recive(List<Chest> chestsFromServer)
        {
            VerifyList(chestsFromServer);

            var sorted = SortBoxes(chestsFromServer);

            Console.WriteLine(ShowInformationAboutBoxes(sorted));
        }

        private void VerifyList(List<Chest> list)
        {
            if (list == null)
            {
                throw new NullListOfRewardsException();
            }
            else if (list.Count == 0)
            {
                throw new EmptyListOfRewardsException();
            }
        }

        private List<Chest> SortBoxes(List<Chest> chestsFromServer)
        {
            var sorted = chestsFromServer.
                OrderByDescending(CountInTheChest<Credits>).
                ThenByDescending(CountInTheChest<Collection>).
                ThenByDescending(x => x.Rewards.OfType<Basket>().Count());

            return sorted.ToList();
        }

        private string ShowInformationAboutBoxes(List<Chest> sortedChests)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"*------------------------------------------------------------------\r\nСаммари:\r\n\r\n");

            for ( int i = 0; i < sortedChests.Count; i++ )
            {
                sb.Append($"Сундук {i + 1}: {CountInTheChest<Credits>(sortedChests[i])} кредитов, {CountInTheChest<Collection>(sortedChests[i])} коллекшенов ({CollectionIdNumbers(sortedChests[i])}), {sortedChests[i].Rewards.OfType<Basket>().Count()} корзин\r\n");
            }

            sb.Append($"Всего:\r\n\t");
            sb.Append($"сундуков - {sortedChests.Count}\r\n\t");
            sb.Append($"корзин - {BasketCount(sortedChests)}\r\n\t");
            sb.Append($"коллекшенов - {CollectionCount(sortedChests)}\r\n\t");
            sb.Append($"кредитов - {CreditsCount(sortedChests)}\r\n\t\r\n");
            sb.Append($"Собранные коллешкшены: {CollectionIdToString(CollectedCollectionsId(sortedChests))}\r\n");
            sb.Append($"Не собраные коллекшены: {CollectionIdToString(NotCollectedCollectionsId(CollectedCollectionsId(sortedChests)))}\r\n");
            sb.Append($"*------------------------------------------------------------------- ");

            return sb.ToString();
        }

        private int CountInTheChest<T>(Chest chest)
        {
            int count = chest.Rewards.OfType<T>().Count();
            var basketsInTheBox = chest.Rewards.OfType<Basket>().ToList();
            count += basketsInTheBox.SelectMany(x => x.Rewards).ToList().OfType<T>().ToList().Count;

            return count;
        } 

        private int BasketCount(List<Chest> chests)
        {
            return chests.SelectMany(x => x.Rewards).ToList().OfType<Basket>().ToList().Count;
        }

        private int CollectionCount(List<Chest> boxes)
        {
            return boxes.Select(x => CountInTheChest<Collection>(x)).Sum(); 
        }

        private int CreditsCount(List<Chest> boxes)
        {
            return boxes.Select(x => CountInTheChest<Credits>(x)).Sum();
        }

        private string CollectionIdNumbers(Chest box)
        {
            StringBuilder sb = new StringBuilder();

            var collectionsFromBox = box.Rewards.OfType<Collection>().ToList();

            var baskets = box.Rewards.OfType<Basket>().ToList();

            var collectionsFromBaskets = baskets.SelectMany(x => x.Rewards.OfType<Collection>()).ToList();

            var allCollections = collectionsFromBox.Union(collectionsFromBaskets).ToList();

            var idFromAllColections = allCollections.Select(x => x.Id).ToList();            

            return sb.Append(String.Join(", ", idFromAllColections)).ToString();
        }

        private List<int> NotCollectedCollectionsId(List<int> id) 
        {
            List<int> ints = new List<int>();

            for (int i = 1; i < 11; i++)
            {
                if (!id.Contains(i))
                {
                    ints.Add(i);
                }
            }

            return ints;
        }

        private string CollectionIdToString(List<int> ints)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Join(", ", ints));

            return sb.ToString();
        }

        private List<int> CollectedCollectionsId(List<Chest> boxes)
        {
            var result = boxes.SelectMany(x => x.Rewards.OfType<Collection>()).ToList().Select(x => x.Id).ToList().Distinct().ToList();
            result.Sort();

            return result;
        }        
    }
}
