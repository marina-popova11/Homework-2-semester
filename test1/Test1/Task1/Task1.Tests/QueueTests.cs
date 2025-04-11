namespace Task1.Tests;

public class QueueTests
{
    private Queue queue = new();

    [SetUp]
    public void SetUp()
    {
        var queue = new Queue();
    }

    [Test]
    public void Test_IsEmpty()
    {
        var queue = new Queue();
        Assert.That(queue.IsEmpty, Is.True);
    }

    [Test]
    public void Test_Enqueue_SingleElement()
    {
        var queue = new Queue();
        queue.Enqueue(11, 1);
        Assert.That(queue.IsEmpty(), Is.False);
        Assert.That(queue.Dequeue(), Is.EqualTo(11));
    }

    [Test]
    public void Test_Enqueue_MoreElements()
    {
        var queue = new Queue();
        for (int i = 10; i > 0; --i)
        {
            queue.Enqueue(i, 10 - i + 1);
        }

        Assert.That(queue.IsEmpty(), Is.False);
        Assert.That(queue.Dequeue(), Is.EqualTo(1));
    }

    [Test]
    public void Test_Dequeue_ThrowException()
    {
        var queue = new Queue();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
}
