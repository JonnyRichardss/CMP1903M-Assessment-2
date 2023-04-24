﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_2
{
    internal class Pack : CardCollection
    {
        public override List<Card> Cards { get;}
        public Pack()
        {
            //Initialise the card Cards here
            Cards = new List<Card>();
            for (int s = 1; s < 5; s++)
            {
                for (int v = 1; v < 14; v++)
                {
                    Cards.Add(new Card(v, s));
                }
            }
        }
        public Pack(bool shuffled) : this()
        {
            if (shuffled)
            {
                this.Shuffle();
            }
        }
        public Card Deal()
        {
            //deals one card
            if (Cards.Count > 0)
            {
                Card card = Cards[0];
                Cards.Remove(card);
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
