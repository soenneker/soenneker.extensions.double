[![](https://img.shields.io/nuget/v/Soenneker.Extensions.Double.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.Double/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.double/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.double/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.Double.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.Double/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.double/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.double/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Double

Small conversion and absolute-tolerance comparison extensions for `double`.

## Installation

```bash
dotnet add package Soenneker.Extensions.Double
```

## Convert to `int`

```csharp
using Soenneker.Extensions.Double;

int lowerEven = 2.5d.ToInt(); // 2
int upperEven = 3.5d.ToInt(); // 4
```

`ToInt()` delegates to `Convert.ToInt32(double)`. It rounds to the nearest integer using midpoint-to-even rounding and throws `OverflowException` for NaN, infinity, or a rounded result outside the `Int32` range.

## Compare with an absolute tolerance

```csharp
bool close = 0.1d.NearlyEqual(0.10001d, epsilon: 0.0001d); // true
bool far = 1000d.NearlyEqual(1001d, epsilon: 0.5d);        // false
```

`NearlyEqual()` checks whether the absolute difference is less than or equal to `epsilon`. Matching positive infinities and matching negative infinities are equal. NaN never matches, and an infinity does not match a different value even when `epsilon` is infinite. A negative or NaN tolerance produces `false` unless the two inputs are already exactly equal.

This method does not scale tolerance with the magnitude of the values. For measurements spanning very different scales, choose an epsilon appropriate to the domain or use a relative-tolerance comparison instead.
