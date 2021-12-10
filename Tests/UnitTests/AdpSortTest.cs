﻿using System;
using System.Collections.Generic;
using Implementations.Algorithms;
using Implementations.DataSets;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpSortTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpInsertionSort_Test<T>(T[] values)
    {
        
        var list = new List<T>(values);

        if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
        {
            Assert.Throws<InvalidOperationException>(() => AdpInsertionSort<T>.Sort(ref values));
            return;
        }

        list.Sort();
        
        AdpInsertionSort<T>.Sort(ref values);
        Assert.Equal(list.ToArray(), values);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpSelectionSort_Test<T>(T[] values)
    {
        
        var list = new List<T>(values);

        if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
        {
            Assert.Throws<InvalidOperationException>(() => AdpSelectionSort<T>.Sort(ref values));
            return;
        }

        list.Sort();
        
        AdpInsertionSort<T>.Sort(ref values);
        Assert.Equal(list.ToArray(), values);
    }
    
    
}