using System.Collections;

namespace Implementations.DataStructures.Deprecated;

public class AdpDynamicArrayStepSize1<T> : IEnumerable<T>
{
    private T[] items;

    public AdpDynamicArrayStepSize1()
    {
        items = Array.Empty<T>();
    }

    public AdpDynamicArrayStepSize1(int capacity)
    {
        items = new T[capacity];
        var test = new List<int>();
    }

    public AdpDynamicArrayStepSize1(IEnumerable<T> collection)
    {
        items = collection.ToArray();
    }

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count()
    {
        return items.Length;
    }

    public void Add(T item)
    {
        var newItems = new T[items.Length + 1];
        for (var i = 0; i < items.Length; i++) newItems[i] = items[i];

        newItems[^1] = item;
        items = newItems;
    }

    public void Add(T[] collection)
    {
        var newItems = new T[items.Length + collection.Length];
        for (var i = 0; i < items.Length; i++) newItems[i] = items[i];

        for (var i = 0; i < collection.Length; i++) newItems[i + items.Length] = collection[i];

        items = newItems;
    }

    public T Pop()
    {
        var item = items[^1];
        var newItems = new T[items.Length - 1];
        for (var i = 0; i < newItems.Length; i++) newItems[i] = items[i];

        items = newItems;
        return item;
    }

    public void Clear()
    {
        items = Array.Empty<T>();
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(items, item);
    }

    public void Insert(int index, T item)
    {
        var newItems = new T[items.Length + 1];

        var j = 0;
        for (var i = 0; i < newItems.Length; i++)
        {
            if (i == index)
            {
                newItems[i] = item;
                continue;
            }

            newItems[i] = items[j];
            j++;
        }

        items = newItems;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index >= 0) return RemoveAt(index);

        return false;
    }

    public bool RemoveAt(int index)
    {
        var newItems = new T[items.Length - 1];

        var j = 0;
        for (var i = 0; i < items.Length; i++)
        {
            if (i == index) continue;

            newItems[j] = items[i];
            j++;
        }

        items = newItems;
        return true;
    }

    public T[] ToArray()
    {
        return items;
    }
}