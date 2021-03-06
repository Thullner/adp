namespace Implementations.Algorithms;

public class AdpSelectionSort<T> : BaseSort<T>
{
    public static void Sort(T[] array)
    {
        var length = array.Length;
        var comparer = Comparer<T>.Default;

        for (var i = 0; i < length - 1; i++)
        {
            var maxIndex = 0;
            for (var j = 1; j < length - i; j++)
            {
                try
                {
                    if (Compare(array[j], array[maxIndex]))
                    {
                        maxIndex = j;
                    }

                    Swap(array, maxIndex, length - i - 1);
                }
                catch (ArgumentException e)
                {
                    throw new InvalidOperationException("Can't compare types", e);
                }
            }
        }
    }
}