// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE file in the project root for full license information.

using System.Numerics;

namespace Xunit
{
    /// <summary>
    /// Specifies which range of values for this parameter should be used for running the test method.
    /// </summary>
    /// <typeparam name="T">The number type of the parameter.</typeparam>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class CombinatorialRangeAttribute<T> : Attribute
        where T : INumber<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CombinatorialRangeAttribute{T}"/> class.
        /// </summary>
        /// <param name="from">The value at the beginning of the range.</param>
        /// <param name="count">
        /// The quantity of consecutive integer values to include.
        /// Cannot be less than 1, which would conceptually result in zero test cases.
        /// </param>
        public CombinatorialRangeAttribute(T from, T count)
        {
            if (count < T.One)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var values = new List<object>();
            for (T i = T.Zero; i < count; i++)
            {
                values.Add(from + i);
            }

            this.Values = values.ToArray();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinatorialRangeAttribute{T}"/> class.
        /// </summary>
        /// <param name="from">The value at the beginning of the range.</param>
        /// <param name="to">
        /// The value at the end of the range.
        /// Cannot be less than "from" parameter.
        /// When "to" and "from" are equal, CombinatorialValues is more appropriate.
        /// </param>
        /// <param name="step">
        /// The number of integers to step for each value in result.
        /// Cannot be less than one. Stepping zero or backwards is not useful.
        /// Stepping over "to" does not add another value to the range.
        /// </param>
        public CombinatorialRangeAttribute(T from, T to, T step)
        {
            if (step > T.Zero)
            {
                if (to < from)
                {
                    throw new ArgumentOutOfRangeException(nameof(to));
                }
            }
            else if (step < T.Zero)
            {
                if (to > from)
                {
                    throw new ArgumentOutOfRangeException(nameof(to));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(step));
            }

            var values = new List<object>();

            if (from < to)
            {
                for (T i = from; i <= to; i += step)
                {
                    values.Add(i);
                }
            }
            else
            {
                for (T i = from; i >= to; i += step)
                {
                    values.Add(i);
                }
            }

            this.Values = values.ToArray();
        }

        /// <summary>
        /// Gets the values that should be passed to this parameter on the test method.
        /// </summary>
        /// <value>An array of values.</value>
        public object[] Values { get; }
    }
}
