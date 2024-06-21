using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    public class Server
    {
        Random random = new Random();
        public List<Box> CreateListOfBoxes()
        {
            List<Box> boxes = new List<Box>();            
            return new List<Box>();
        }

        public Box CreateBox()
        {
            int[] creditsMas = {0, 10, 50,  100};
            int credits = creditsMas[random.Next(4)];
            Box box = new Box(credits, )
            return
        }
        public List<Basket> CreateBasketList() 
        {
            int countOfBasket = random.Next(3);

            return
        }
        public Basket CreateBasket()
        {
            int[] credits = { 10, 50 };

        }
    }
}
