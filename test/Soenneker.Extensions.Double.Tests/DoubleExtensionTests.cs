
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Extensions.Double.Tests;

public class DoubleExtensionTests
{
    [Test]
    public void Default()
    {

    }

    [Test]
    public async ValueTask NearlyEqual_accepts_matching_infinities(CancellationToken cancellationToken)
    {
        await Assert.That(double.PositiveInfinity.NearlyEqual(double.PositiveInfinity, 0)).IsTrue();
        await Assert.That(double.NegativeInfinity.NearlyEqual(double.NegativeInfinity, 0)).IsTrue();
    }

    [Test]
    public async ValueTask NearlyEqual_rejects_nonmatching_infinities_even_with_infinite_tolerance(CancellationToken cancellationToken)
    {
        await Assert.That(double.PositiveInfinity.NearlyEqual(double.NegativeInfinity, double.PositiveInfinity)).IsFalse();
        await Assert.That(double.PositiveInfinity.NearlyEqual(1, double.PositiveInfinity)).IsFalse();
    }
}
