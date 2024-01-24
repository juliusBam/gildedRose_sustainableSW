using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class SulfurasTest
{
    
    private List<Item> _getSulfuras()
    {
        return new List<Item> { new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80} };
    }

    //Sulfuras values should not change with time
    [Test]
    public void TestConstantValuesSulfuras()
    {
        //given
        var items = this._getSulfuras();
        GildedRose gildedRose = new GildedRose(items);
        
        //then 40 days passed
        for (int days = 0; days < 40; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then
        Assert.AreEqual(80, items[0].Quality);
        Assert.AreEqual(20, items[0].SellIn);

    }
    
}