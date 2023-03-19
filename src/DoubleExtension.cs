using System;
using System.Diagnostics.Contracts;

namespace Soenneker.Extensions.Double;

public static class DoubleExtension
{
    /// <summary>
    /// Shorthand for Convert.ToInt32()
    /// </summary>
    [Pure]
    public static int ToInt(this double value)
    {
        return Convert.ToInt32(value);
    }
}