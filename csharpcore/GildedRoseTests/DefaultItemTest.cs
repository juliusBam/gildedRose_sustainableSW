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
        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(20, items[0].Quality);

    }
    
    //Test sinking of quality and sellIn after expiration date
    //therefore quality degradation twice as fast
    [Test]
    public void TestAcceleratedDecay()
    {
        //given
        var items = this._getDefaultItems();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 20 days passed
        for (int days = 0; days < 20; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then
        Assert.AreEqual(-10, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);

    }
    
    //Test sinking of quality and sellIn after expiration date
    //therefore quality degradation twice as fast
    //but quality should stay at 0 --> no negative quality
    [Test]
    public void TestNoNegativeQuality()
    {
        //given
        var items = this._getDefaultItems();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 10 days passed
        for (int days = 0; days < 30; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then
        Assert.AreEqual(-20, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);

    }
    
}