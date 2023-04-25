using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    public abstract class CardCollection : IEnumerable<Card>
    {
        protected abstract List<Card> Cards {get;}
        public abstract int Count {get;}
        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = Cards.Count - 1; i >= 0; i--)
            {
                int j = rng.Next(Cards.Count - 1);
                Card currcard = Cards[i];
                Card randomcard = Cards[j];
                Cards[i] = randomcard;
                Cards[j] = currcard;

            }
        }
        public Card this[int index]
        {
            get { return Cards[index]; }
            set { Cards[index] = value; }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)Cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Cards).GetEnumerator();
        }
    }
}
