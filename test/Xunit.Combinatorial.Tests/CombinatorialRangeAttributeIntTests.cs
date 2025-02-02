// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE file in the project root for full license information.

using Xunit;

public class CombinatorialRangeAttributeIntTests
{
    [Theory]
    [InlineData(0, 5)]
    public void CountOfIntegers_HappyPath_SetsAttributeWithRange(int from, int count)
    {
        object[] values = Enumerable.Range(from, count).Cast<object>().ToArray();
        var attribute = new CombinatorialRangeAttribute<int>(from, count);
        Assert.Equal(values, attribute.Values);
    }

    [Theory]
    [InlineData(0, -2)]
    public void CountOfIntegers_NegativeCount_ArgOutOfRange(int from, int count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CombinatorialRangeAttribute<int>(from, count));
    }

    [Theory]
    [InlineData(0, 7, 2)]
    [InlineData(0, 8, 2)]
    [InlineData(7, 0, -2)]
    [InlineData(0, -8, -2)]
    public void IntegerStep_HappyPath_SetsAttributeWithRange(int from, int to, int step)
    {
        object[] expectedValues = Sequence(from, to, step).Cast<object>().ToArray();

        var attribute = new CombinatorialRangeAttribute<int>(from, to, step);
        Assert.Equal(expectedValues, attribute.Values);
    }

    [Theory]
    [InlineData(4, 2, 1)]
    [InlineData(1, 5, -1)]
    public void IntegerStep_InvalidIntervalAndStep_ArgOutOfRange(int from, int to, int step)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CombinatorialRangeAttribute<int>(from, to, step));
    }

    internal static IEnumerable<int> Sequence(int from, int to, int step)
        => step >= 0 ? SequenceIterator(from, to, step) : SequenceReverseIterator(from, to, step);

    private static IEnumerable<int> SequenceIterator(int from, int to, int step)
    {
        int value = from;
        while (value <= to)
        {
            yield return value;
            unchecked
            {
                value += step;
            }
        }
    }

    private static IEnumerable<int> SequenceReverseIterator(int from, int to, int step)
    {
        int value = from;
        while (value >= to)
        {
            yield return value;
            unchecked
            {
                value += step;
            }
        }
    }
}
