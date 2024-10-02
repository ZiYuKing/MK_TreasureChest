using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_Plugins.PulginEnums;

public static class ArrayUtil
{
    public static T Find<T>(this Span<T> data, Func<T, bool> value) where T : unmanaged
    {
        Span<T> span = data;
        for (int i = 0; i < span.Length; i++)
        {
            T val = span[i];
            if (value(val))
            {
                return val;
            }
        }

        return default(T);
    }

    public static bool WithinRange(int value, int min, int max)
    {
        if (min <= value)
        {
            return value < max;
        }

        return false;
    }

    public static IEnumerable<T[]> EnumerateSplit<T>(T[] bin, int size, int start = 0)
    {
        for (int i = start; i < bin.Length; i += size)
        {
            yield return bin.AsSpan(i, size).ToArray();
        }
    }

    public static int CopyTo<T>(this IEnumerable<T> list, IList<T> dest, Func<int, bool> skip, int start = 0)
    {
        int num = start;
        int num2 = 0;
        foreach (T item in list)
        {
            int num3 = FindNextValidIndex(dest, skip, num);
            if (num3 == -1)
            {
                break;
            }

            num2 += num3 - num;
            num = num3;
            dest[num++] = item;
        }

        return num - start - num2;
    }

    public static int FindNextValidIndex<T>(IList<T> dest, Func<int, bool> skip, int ctr)
    {
        while (true)
        {
            if ((uint)ctr >= dest.Count)
            {
                return -1;
            }

            if (dest[ctr] == null || !skip(ctr))
            {
                break;
            }

            ctr++;
        }

        return ctr;
    }
}