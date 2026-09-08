using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoolArrayProj.Tests;

[TestClass]
public class BoolArrayTests
{
    [TestMethod]
    public void TestCreateArray()
    {
        // Arrange & Act
        var array = new BoolArray(100);
        
        // Assert
        Assert.IsNotNull(array);
    }
    
    [TestMethod]
    public void TestSetAndGet()
    {
        // Arrange
        var array = new BoolArray(100);
        
        // Act & Assert
        array[10] = true;
        Assert.IsTrue(array[10]);
        array[10] = false;
        Assert.IsFalse(array[10]);
    }
    
    [TestMethod]
    public void TestMultipleSets()
    {
        // Arrange
        var array = new BoolArray(100);
        for (int i = 0; i < 100; i += 2)
        {
            array[i] = true;
        }
        
        // Act & Assert
        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0)
            {
                Assert.IsTrue(array[i]);
            }
            else
            {
                Assert.IsFalse(array[i]);
            }
        }
    }
    
    [TestMethod]
    public void TestIndexOutOfRange()
    {
        // Arrange
        var array = new BoolArray(100);
        
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => { _ = array[100]; });
    }

    // Lab 4 Bonus:

    [TestMethod]
    public void TestCollectionInitializer()
    {
        // Arrange & Act
        var array = new BoolArray(3)
        {
            [0] = true,
            [1] = false,
            [2] = false
        };

        // var array = new BoolArray(3) { true, false, true }; requires an Add(bool) method in BoolArray

        // Assert
        Assert.IsTrue(array[0]);
        Assert.IsFalse(array[1]);
        Assert.IsFalse(array[2]);
        Assert.Throws<IndexOutOfRangeException>(() => array[4]);
    }
}