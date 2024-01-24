using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class BackStagePassesTest
{
    
    private List<Item> _getBackstagePasses()
    {
        return new List<Item> { new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 20} };
    }


    [Test]
    public void TestNormalIncreaseOfQuality()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 5 days passed
        for (int days = 0; days < 5; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should have increased normally
        Assert.AreEqual(25, items[0].Quality);
        Assert.AreEqual(15, items[0].SellIn);

    }
    
}