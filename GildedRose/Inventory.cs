using System.Collections.Generic;
using System;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
         
        public void UpdateQuality()
        {
            
            foreach (var item in items)
            {
                if(item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality = Math.Clamp(item.Quality, 0, 80);
                }
                else
                {
                    item.SellIn--;
                    int decrement = (item.SellIn <= 0 ?2 : 1);
                    if (item.Name == "Aged Brie")
                    {
                        item.Quality += decrement;
                    }
                    else if(item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {

                        if (item.SellIn <= 10 && item.SellIn > 5)
                            item.Quality += 2;
                        else if (item.SellIn <= 5 && item.SellIn > 0)
                            item.Quality += 3;
                        else
                            item.Quality++;


                        if (item.SellIn <= 0)
                            item.Quality = 0;
                        
                    }
                    else if (item.Name == "Conjured Mana Cake")
                    {
                        item.Quality -= decrement*2;
                    }
                    else
                    {
                        item.Quality -= decrement;
                    }
                    item.Quality = Math.Clamp(item.Quality,0,50);


                }
            }
        }
    }
}
