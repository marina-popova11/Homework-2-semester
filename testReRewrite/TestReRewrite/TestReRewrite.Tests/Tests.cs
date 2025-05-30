// <copyright file="Vector.cs" author="Popova Marina">
// under MIT License.
// </copyright>

namespace TestReRewrite.Tests;

/// <summary>
/// Tests.
/// </summary>
public class Tests
{
    [Test]
    public void Test_AddNullVector()
    {
        var vector = new Vector(10);
        vector[2] = 2.0;
        vector[7] = 3.0;
        vector[8] = 1.0;
        Assert.Throws<ArgumentNullException>(() => vector.Add(null!));
    }

    [Test]
    public void Test_AddTwoVectors()
    {
        var v1 = new Vector(10);
        v1[0] = 2.0;
        v1[3] = 4.0;

        var v2 = new Vector(10);
        v2[0] = 1.0;
        v2[3] = -1.0;
        v2[5] = 5.0;

        var v3 = v1.Add(v2);
        Assert.That(v3[0], Is.EqualTo(3.0));
        Assert.That(v3[3], Is.EqualTo(3.0));
        Assert.That(v3[5], Is.EqualTo(5.0));
    }

    [Test]
    public void Test_AddTwoVectors_ThrowsException()
    {
        var v1 = new Vector(10);
        v1[0] = 2.0;
        v1[3] = 4.0;

        var v2 = new Vector(7);
        v2[0] = 1.0;
        v2[3] = -1.0;
        v2[5] = 5.0;
        Assert.Throws<Exception>(() => v1.Add(v2));
    }

    [Test]
    public void Test_SubtractTwoVectors()
    {
        var v1 = new Vector(10);
        v1[0] = 5.0;
        v1[3] = 4.0;

        var v2 = new Vector(10);
        v2[0] = 2.0;
        v2[3] = 3.0;
        v2[5] = 10.0;

        var v3 = v1.Subtract(v2);
        Assert.That(v3[0], Is.EqualTo(3.0));
        Assert.That(v3[3], Is.EqualTo(1.0));
        Assert.That(v3[5], Is.EqualTo(-10.0));
    }

    [Test]
    public void Test_SubtractTwoVectors_ThrowsException()
    {
        var v1 = new Vector(10);
        v1[0] = 5.0;
        v1[3] = 4.0;

        var v2 = new Vector(6);
        v2[0] = 2.0;
        v2[3] = 3.0;
        v2[5] = 10.0;
        Assert.Throws<Exception>(() => v1.Subtract(v2));
    }

    [Test]
    public void Test_Product()
    {
        var v1 = new Vector(10);
        v1[0] = 2.0;
        v1[3] = 4.0;
        v1[5] = 6.0;

        var v2 = new Vector(10);
        v2[0] = 3.0;
        v2[3] = 5.0;
        v2[7] = 7.0;

        double v3 = v1.Product(v2);
        Assert.That(v3, Is.EqualTo((2 * 3) + (4 * 5)));
    }

    [Test]
    public void Test_DimLessThanOne()
    {
        Assert.Throws<InvalidDataException>(() => new Vector(-2));
    }

    [Test]
    public void Test_IsZero()
    {
        var vector = new Vector(19);
        Assert.That(vector.IsZero(), Is.True);
    }
}
