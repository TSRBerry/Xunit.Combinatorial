// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE file in the project root for full license information.

using Xunit;

public class CombinatorialRangeAttributeUIntTests
{
    [Theory]
    [InlineData(0u, 5u)]
    public void CountOfUnsignedIntegers_HappyPath_SetsAttributeWithRange(uint from, uint count)
    {
        object[] values = Sequence(from, from + count - 1, 1).Cast<object>().ToArray();

        var attribute = new CombinatorialRangeAttribute<uint>(from, count);
        Assert.Equal(values, attribute.Values);
    }

    [Theory]
    [InlineData(0u, 0u)]
    public void CountOfUnsignedIntegers_NegativeCount_ArgOutOfRange(uint from, uint count)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CombinatorialRangeAttribute<uint>(from, count));
    }

    [Theory]
    [InlineData(0u, 7u, 2u)]
    [InlineData(0u, 8u, 2u)]
    public void IntegerStep_HappyPath_SetsAttributeWithRange(uint from, uint to, uint step)
    {
        object[] expectedValues = Sequence(from, to, step).Cast<object>().ToArray();

        var attribute = new CombinatorialRangeAttribute<uint>(from, to, step);
        Assert.Equal(expectedValues, attribute.Values);
    }

    [Theory]
    [InlineData(4u, 2u, 1u)]
    [InlineData(1u, 5u, 0u)]
    public void IntegerStep_InvalidIntervalAndStep_ArgOutOfRange(uint from, uint to, uint step)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CombinatorialRangeAttribute<uint>(from, to, step));
    }

    private static IEnumerable<uint> Sequence(uint from, uint to, uint step)
    {
        uint value = from;
        while (value <= to)
        {
            yield return value;
            unchecked
            {
                value += step;
            }
        }
    }
}
