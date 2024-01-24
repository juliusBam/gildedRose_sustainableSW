using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class BackStagePassesTest
{
    
    private List<Item> _getBackstagePasses()
    {
        return new List<Item> { new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 40} };
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

        //when 15 days passed
        for (int days = 0; days < 15; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should have increased normally for 10 days and double for 1 day
        Assert.AreEqual(40, items[0].Quality);
        Assert.AreEqual(5, items[0].SellIn);

    }
    
    //the increase of quality of backstage passes should be normal
    //until the 10th day before the concert, afterwards it will be double until the fifth day before the concert
    //when it will triple
    [Test]
    public void TestTripleIncreaseOfQuality()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 16 days passed
        for (int days = 0; days < 16; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should have increased normally for 10 days and double for 5 days and then triple for 1 day
        Assert.AreEqual(43, items[0].Quality);
        Assert.AreEqual(4, items[0].SellIn);

    }
    
    //The quality of the passes should drop to 0 after the concert (meaning SellIn = -1)
    [Test]
    public void TestQualityDropAfterConcert()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 21 days passed --> meaning AFTER the concert
        for (int days = 0; days < 21; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should drop to 0
        Assert.AreEqual(0, items[0].Quality);
        Assert.AreEqual(-1, items[0].SellIn);

    }
    
    //The quality of the passes should not be allowed to be over 50
    [Test]
    public void TestQualityUpperLimit()
    {
        //given
        var items = this._getBackstagePasses();
        GildedRose gildedRose = new GildedRose(items);

        //when 19 days passed --> meaning the day before the concert --> quality should be at its highest
        for (int days = 0; days < 19; days++)
        {
            gildedRose.UpdateQuality();
        }
        
        //then quality should drop to 0
        Assert.AreEqual(50, items[0].Quality);
        Assert.AreEqual(1, items[0].SellIn);

    }
    
}