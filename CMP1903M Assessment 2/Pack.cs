using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    internal class Pack
    {
        readonly List<Card> pack;
        public Pack()
        {
            //Initialise the card pack here
            pack = new List<Card>();
            for (int s = 1; s < 5; s++)
            {
                for (int v = 1; v < 14; v++)
                {
                    pack.Add(new Card(v, s));
                }
            }
        }
        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = pack.Count - 1; i >= 0; i--)
            {
                int j = rng.Next(pack.Count - 1);
                Card currcard = pack[i];
                Card randomcard = pack[j];
                pack[i] = randomcard;
                pack[j] = currcard;

            }
        }
        public Card Deal()
        {
            //deals one card
            if (pack.Count > 0)
            {
                Card card = pack[0];
                pack.Remove(card);
                return card;
            }
            else
            {
                throw new PackEmptyException();
            }
        }
        public List<Card> Deal(int amount) //overload Deal()
        {
            //Deals the number of cards specified by 'amount'

            List<Card> output = new List<Card>(); //init output

            //calls deal 'amount' times and adds to output
            try
            {
                for (int i = 0; i < amount; i++)
                {
                    output.Add(Deal());
                }
            }
            catch (PackEmptyException)
            {
                //might want behaviour here
                throw;
            }

            return output;
        }
    }
}
