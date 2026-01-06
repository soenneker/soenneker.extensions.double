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

    /// <summary>
    /// Determines whether two double-precision floating-point numbers are nearly equal within a specified absolute
    /// tolerance.
    /// </summary>
    /// <remarks>This method returns false if either a or b is NaN. Use this method to compare floating-point
    /// values when exact equality is not required due to potential rounding errors.</remarks>
    /// <param name="a">The first double-precision floating-point value to compare.</param>
    /// <param name="b">The second double-precision floating-point value to compare.</param>
    /// <param name="epsilon">The maximum allowed absolute difference between the two values for them to be considered nearly equal. Must be
    /// greater than or equal to 0.</param>
    /// <returns>true if the absolute difference between a and b is less than or equal to epsilon; otherwise, false.</returns>
    [Pure]
    public static bool NearlyEqual(this double a, double b, double epsilon)
    {
        if (double.IsNaN(a) || double.IsNaN(b))
            return false;

        return Math.Abs(a - b) <= epsilon;
    }
}