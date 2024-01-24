using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class DefaultItemTest
{

    private List<Item> _getDefaultItems()
    {
        return new List<Item> { new Item {Name = "Vanilla", SellIn = 10, Quality = 30} };
    }

    
    //Test sinking of quality and sellIn under default conditions
    [Test]
    public void TestDefaultBehaviour()
    {
        //given
        var items = this._getDefaultItems();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 10 days passed
        for (int days = 0; days < 10; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then
        Assert.AreEqual(items[0].SellIn, 0);
        Assert.AreEqual(items[0].Quality, 20);

    }
    
    //Test sinking of quality and sellIn after expiration date
    //therefore quality degradation twice as fast
    [Test]
    public void TestAcceleratedDecay()
    {
        //given
        var items = this._getDefaultItems();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 10 days passed
        for (int days = 0; days < 20; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then
        Assert.AreEqual(items[0].SellIn, -10);
        Assert.AreEqual(items[0].Quality, 0);

    }
    
}