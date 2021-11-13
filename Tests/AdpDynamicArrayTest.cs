using Algorithms;
using Xunit;

namespace Tests;
public class UnitTest1
{
    [Theory]
    [InlineData(1)]
    [InlineData(1.2)]
    [InlineData('c')]
    [InlineData("test")]
    public void Push_AddItem_WhenEmpty<T>(T value)
    {
        var sut = new AdpDynamicArray<T>();
        sut.Push(value);
        Assert.Equal(value, sut[0]);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(4, 5, 6, 7, 8)]
    public void Push_CheckFirstItemIsCorrect_WhenMultipleItemsArePushed(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();

        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values[0], sut[0]);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(4, 5, 6, 7, 8)]
    public void Push_CheckLastItemIsCorrect_WhenMultipleItemsArePushed(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();

        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values[^1], sut[sut.Count() - 1]);
    }


    [Theory]
    [InlineData(1, 2, 3)]
    public void Pop_CheckCountMinus1_WhenLastItemIsRemoved(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Pop();

        Assert.Equal(values.Length - 1, sut.Count());
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Pop_CheckLastItemIsReturned(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values[^1], sut.Pop());
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Clear_ShouldBeEmpty_WhenCleared(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        sut.Clear();
        Assert.Equal(0, sut.Count());
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Contains_ShouldReturnTrue_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        Assert.True(sut.Contains("hello"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Contains_ShouldReturnFalse_WhenItemIsNotInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        Assert.False(sut.Contains("hello2"));
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Insert_ShouldInsertItem_WhenItemIsInserted(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        sut.Insert(2, "hello2");
        Assert.Equal("hello2", sut[2]);
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Insert_ShouldNotAffectOtherItems_WhenItemIsInserted(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        sut.Insert(2, "hello2");
        Assert.True(sut.Contains(values[0]) && sut.Contains(values[^1]));
    }
    
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_ShouldReturnTrue_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        Assert.True(sut.Remove("hello"));
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_ShouldRemoveItem_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        sut.Remove("hello");
        Assert.False(sut.Contains("hello"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_CheckCountMinus1_WhenItemIsRemoved(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Remove("hello");
        Assert.Equal(values.Length - 1, sut.Count());
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_ShouldNotEffectOtherItems_WhenItemIsRemoved(params string[] values)
    {
            var sut = new AdpDynamicArray<string>();
            foreach (var value in values)
            {
                sut.Push(value);
            }

            sut.Remove(values[^2]);
            Assert.True(sut.Contains(values[0]) && sut.Contains(values[^1]));
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void RemoveAt_ShouldReturnTrue_WhenIndexIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        Assert.True(sut.RemoveAt(2));
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void RemoveAt_ShouldRemoveItem_WhenIndexIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        sut.RemoveAt(2);
        Assert.False(sut.Contains(values[2]));
    }
}