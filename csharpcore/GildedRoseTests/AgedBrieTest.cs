using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class AgedBrieTest
{

    private List<Item> _getAgedBrie()
    {
        return new List<Item> { new Item {Name = "Aged Brie", SellIn = 10, Quality = 20} };
    }
    
    //Aged Brie should increase in quality with time
    [Test]
    public void TestIncreaseOfQuality()
    {
        //given
        var items = this._getAgedBrie();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 5 days passed
        for (int days = 0; days < 5; days++)
        {
            
            gildedRose.UpdateQuality();
            
        }
        
        //then
        Assert.AreEqual(5, items[0].SellIn);
        Assert.AreEqual(25, items[0].Quality);

    }
    
    //Aged Brie should increase in quality with time but should
    //not go over 50 quality
    [Test]
    public void TestQualityUpperLimit()
    {
        //given
        var items = this._getAgedBrie();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 40 days passed
        for (int days = 0; days < 40; days++)
        {
            
            gildedRose.UpdateQuality();
            
        }
        
        //then
        Assert.AreEqual(-30, items[0].SellIn);
        Assert.AreEqual(50, items[0].Quality);

    }
    
    //Aged Brie quality increase should not be constant
    //after the "expiration date" it increases in quality twice as fast
    [Test]
    public void TestQualityIncreaseNotConstant()
    {
        //given
        var items = this._getAgedBrie();
        GildedRose gildedRose = new GildedRose(items);
        
        //when 15 days passed
        for (int days = 0; days < 15; days++)
        {
            
            gildedRose.UpdateQuality();
            
        }
        
        //then
        Assert.AreEqual(-5, items[0].SellIn);
        Assert.AreEqual(40, items[0].Quality);

    }
    
}