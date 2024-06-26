using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    public class Client
    {
        public List<Box> SortBoxes(List<Box> boxesFromServer)
        {
            var sortByCollectionCount = boxesFromServer.OrderByDescending(x => CountOfCreditsInTheBox(x)).ThenBy(x => CountOfCollectionsInTheBox(x)).ThenBy(x => x.Basket.Count);

            return sortByCollectionCount.ToList();
        }

        public string ShowInformationAboutBoxes(List<Box> sortedBoxes)
        {

            return $"*------------------------------------------------------------------\r\nСаммари:\r\n\r\n" +
                $"Сундук 1: {CountOfCreditsInTheBox(sortedBoxes[0])} кредитов, {CountOfCollectionsInTheBox(sortedBoxes[0])} коллекшенов ({CollectionIdNumbers(sortedBoxes[0])}), {sortedBoxes[0].Basket.Count} корзин\r\n" +
                $"Сундук 2: {CountOfCreditsInTheBox(sortedBoxes[1])} кредитов, {CountOfCollectionsInTheBox(sortedBoxes[1])} коллекшенов ({CollectionIdNumbers(sortedBoxes[1])}), {sortedBoxes[1].Basket.Count} корзины\r\n" +
                $"Сундук 3: {CountOfCreditsInTheBox(sortedBoxes[2])} кредитов, {CountOfCollectionsInTheBox(sortedBoxes[2])} коллекшенов ({CollectionIdNumbers(sortedBoxes[2])}), {sortedBoxes[2].Basket.Count} корзины\r\n" +
                $"Сундук 3: {CountOfCreditsInTheBox(sortedBoxes[3])} кредитов, {CountOfCollectionsInTheBox(sortedBoxes[3])} коллекшенов ({CollectionIdNumbers(sortedBoxes[3])}), {sortedBoxes[3].Basket.Count} корзина\r\n\r\n" +
                $"Всего:\r\n\t" +
                $"сундуков - {sortedBoxes.Count}\r\n\t" +
                $"корзин - {BasketCount(sortedBoxes)}\r\n\t" +
                $"коллекшенов - {CollectionCount(sortedBoxes)}\r\n\t" +
                $"кредитов - {CreditsCount(sortedBoxes)}\r\n\t\r\n" +
                $"Собранные коллешкшены: {CollectedCollectionsToString(CollectedCollectionsId(sortedBoxes))}\r\n" +
                $"Не собраные коллекшены: {NotCollectedCollectionIdToString(NotCollectedCollectionsId(CollectedCollectionsId(sortedBoxes)))}\r\n" +
                $"*------------------------------------------------------------------- ";
        }

        private int CountOfCreditsInTheBox(Box box)
        {
            int count = 0;

            count += box.Credits;

            for (int i = 0; i < box.Basket.Count; i++)
            {
                count += box.Basket[i].Credits;
            }

            return count;
        }

        private int CountOfCollectionsInTheBox(Box box)
        {
            int count = 0;

            count += box.Collection.Count;

            for (int i = 0; i < box.Basket.Count; i++)
            {
                count += box.Basket[i].Collections.Count;
            }

            return count;
        }

        private int BasketCount(List<Box> boxes)
        {
            int basketSum = 0;

            foreach (Box box in boxes)
            {
                basketSum += box.Basket.Count;
            }

            return basketSum;
        }

        private int CollectionCount(List<Box> boxes)
        {
            int count = 0;

            foreach (Box box in boxes)
            {
                count += box.Collection.Count;
                for (int i = 0; i < box.Basket.Count; i++)
                {
                    count += box.Basket[i].Collections.Count;
                }
            }

            return count;
        }

        private int CreditsCount(List<Box> boxes)
        {
            int count = 0;

            foreach (Box box in boxes)
            {
                count += CountOfCreditsInTheBox(box);
            }

            return count;
        }

        public string CollectionIdNumbers(Box box)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("id: ");

            for (int i = 0; i < box.Basket.Count; i++)
            {
                for (int j = 0; j < box.Basket[i].Collections.Count; j++)
                {
                    sb.Append($"{box.Basket[i].Collections[j].Id},");
                }
            }

            for (int i = 0; i < box.Collection.Count; i++)
            {
                if (i != box.Collection.Count - 1)
                {
                    sb.Append($"{box.Collection[i].Id},");
                }
                else
                {
                    sb.Append($"{box.Collection[i].Id}");
                }
            }

            return sb.ToString();
        }

        private List<int> NotCollectedCollectionsId(List<int> id) 
        {
            List<int> ints = new List<int>();

            for (int i = 1; i < 11; i++) 
            {
                if(!id.Contains(i))
                {
                    ints.Add(i); 
                }            
            }

            return ints;
        }

        private string NotCollectedCollectionIdToString(List<int> ints)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ints.Count; i++)
            {
                if (i != ints.Count - 1)
                {
                    sb.Append($"{ints[i]},");
                }
                else
                {
                    sb.Append($"{ints[i]}");
                }
            }

            return sb.ToString();
        }

        private List<int> CollectedCollectionsId(List<Box> boxes)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < boxes.Count; i++) 
            {
                for (int j = 0; j < boxes[i].Collection.Count; j++)
                {
                    if (!list.Contains(boxes[i].Collection[j].Id))
                    {
                        list.Add(boxes[i].Collection[j].Id);
                    }
                }

                for (int j = 0; j < boxes[i].Basket.Count; j++)
                {
                    for (int k = 0; k < boxes[i].Basket[j].Collections.Count; k++)
                    {
                        if (!list.Contains(boxes[i].Basket[j].Collections[k].Id))
                        {
                            list.Add(boxes[i].Basket[j].Collections[k].Id);
                        }
                    }
                }
            }

            list.Sort();

            return list;
        }
        
        private string CollectedCollectionsToString(List<int> ints)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < ints.Count; i++)
            {
                if (i != ints.Count - 1)
                {
                    sb.Append($"{ints[i]},");
                }
                else 
                {
                    sb.Append($"{ints[i]}");
                }
            }

            return sb.ToString();
        }
    }
}
