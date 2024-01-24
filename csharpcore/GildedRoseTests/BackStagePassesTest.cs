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
    
    //the increase of quality of backstage passes should be normal
    //until the 10th day before the concert
    [Test]
    public void TestLimitNormalIncreaseOfQuality()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 10 days passed
        for (int days = 0; days < 10; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should have increased normally
        Assert.AreEqual(30, items[0].Quality);
        Assert.AreEqual(10, items[0].SellIn);

    }
    
    //the increase of quality of backstage passes should be normal
    //until the 10th day before the concert and the day after should be double
    [Test]
    public void TestDoubleIncreaseOfQuality()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 11 days passed
        for (int days = 0; days < 11; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should have increased normally for 10 days and double for 1 day
        Assert.AreEqual(32, items[0].Quality);
        Assert.AreEqual(9, items[0].SellIn);

    }
    
    //the increase of quality of backstage passes should be normal
    //until the 10th day before the concert, afterwards it will be double until the fifth day before the concert
    [Test]
    public void TestLimitDoubleIncreaseOfQuality()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 11 days passed
        for (int days = 0; days < 15; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should have increased normally for 10 days and double for 1 day
        Assert.AreEqual(40, items[0].Quality);
        Assert.AreEqual(5, items[0].SellIn);

    }
    
}