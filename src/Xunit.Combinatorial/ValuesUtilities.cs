// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the Ms-PL license. See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Xunit
{
    /// <summary>
    /// Utility methods for generating values for test parameters.
    /// </summary>
    internal static class ValuesUtilities
    {
        /// <summary>
        /// Gets a sequence of values that should be tested for the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter to get possible values for.</param>
        /// <returns>A sequence of values for the parameter.</returns>
        internal static IEnumerable<object?> GetValuesFor(ParameterInfo parameter)
        {
            Requires.NotNull(parameter, nameof(parameter));
            {
                CombinatorialValuesAttribute? attribute = parameter.GetCustomAttribute<CombinatorialValuesAttribute>();
                if (attribute is not null)
                {
                    return attribute.Values;
                }
            }

            {
                if (parameter.ParameterType.IsValueType)
                {
                    if (parameter.ParameterType == typeof(byte))
                    {
                        CombinatorialRangeAttribute<byte>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<byte>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(char))
                    {
                        CombinatorialRangeAttribute<char>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<char>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(decimal))
                    {
                        CombinatorialRangeAttribute<decimal>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<decimal>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(double))
                    {
                        CombinatorialRangeAttribute<double>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<double>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(Half))
                    {
                        CombinatorialRangeAttribute<Half>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<Half>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(Int128))
                    {
                        CombinatorialRangeAttribute<Int128>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<Int128>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(short))
                    {
                        CombinatorialRangeAttribute<short>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<short>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(int))
                    {
                        CombinatorialRangeAttribute<int>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<int>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(long))
                    {
                        CombinatorialRangeAttribute<long>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<long>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(nint))
                    {
                        CombinatorialRangeAttribute<nint>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<nint>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(sbyte))
                    {
                        CombinatorialRangeAttribute<sbyte>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<sbyte>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(float))
                    {
                        CombinatorialRangeAttribute<float>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<float>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(UInt128))
                    {
                        CombinatorialRangeAttribute<UInt128>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<UInt128>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(ushort))
                    {
                        CombinatorialRangeAttribute<ushort>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<ushort>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(uint))
                    {
                        CombinatorialRangeAttribute<uint>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<uint>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(ulong))
                    {
                        CombinatorialRangeAttribute<ulong>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<ulong>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                    else if (parameter.ParameterType == typeof(nuint))
                    {
                        CombinatorialRangeAttribute<nuint>? attribute = parameter.GetCustomAttribute<CombinatorialRangeAttribute<nuint>>();
                        if (attribute is not null)
                        {
                            return attribute.Values;
                        }
                    }
                }
            }

            {
                CombinatorialRandomDataAttribute? attribute = parameter.GetCustomAttribute<CombinatorialRandomDataAttribute>();
                if (attribute is not null)
                {
                    return attribute.Values;
                }
            }

            {
                CombinatorialMemberDataAttribute? attribute = parameter.GetCustomAttribute<CombinatorialMemberDataAttribute>();
                if (attribute is not null)
                {
                    return attribute.GetValues(parameter);
                }
            }

            return GetValuesFor(parameter.ParameterType);
        }

        /// <summary>
        /// Gets a sequence of values that should be tested for the specified type.
        /// </summary>
        /// <param name="dataType">The type to get possible values for.</param>
        /// <returns>A sequence of values for the <paramref name="dataType"/>.</returns>
        internal static IEnumerable<object?> GetValuesFor(Type dataType)
        {
            Requires.NotNull(dataType, nameof(dataType));

            if (dataType == typeof(bool))
            {
                yield return true;
                yield return false;
            }
            else if (dataType == typeof(int))
            {
                for (int i = int.MinValue; i < int.MaxValue; i++)
                {
                    yield return i;
                }

                yield return int.MaxValue;
            }
            else if (dataType.GetTypeInfo().IsEnum)
            {
                foreach (string name in Enum.GetNames(dataType))
                {
                    yield return Enum.Parse(dataType, name);
                }
            }
            else if (IsNullable(dataType, out Type? innerDataType))
            {
                yield return null;
                foreach (object? value in GetValuesFor(innerDataType))
                {
                    yield return value;
                }
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Determines whether <paramref name="dataType"/> is <see cref="Nullable{T}"/>
        /// and extracts the inner type, if any.
        /// </summary>
        /// <param name="dataType">
        /// The type to test whether it is <see cref="Nullable{T}"/>.
        /// </param>
        /// <param name="innerDataType">
        /// When this method returns, contains the inner type of the Nullable, if the
        /// type is Nullable is found; otherwise, null.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the type is a Nullable type; otherwise <see langword="false"/>.
        /// </returns>
        private static bool IsNullable(Type dataType, [NotNullWhen(true)] out Type? innerDataType)
        {
            innerDataType = null;

            TypeInfo? ti = dataType.GetTypeInfo();

            if (!ti.IsGenericType)
            {
                return false;
            }

            if (ti.GetGenericTypeDefinition() != typeof(Nullable<>))
            {
                return false;
            }

            innerDataType = ti.GenericTypeArguments[0];
            return true;
        }
    }
}
