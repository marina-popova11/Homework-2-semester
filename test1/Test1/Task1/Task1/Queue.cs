namespace Task1;

/// <summary>
/// Class for queue.
/// </summary>
public class Queue
{
    private readonly int defaultSize = 8;
    private QueueItem?[] list;
    private int size;
    private int sequenceNumber = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Queue"/> class.
    /// </summary>
    public Queue()
    {
        this.list = new QueueItem[this.defaultSize];
        this.size = 0;
    }

    /// <summary>
    /// The function for check.
    /// </summary>
    /// <returns>True or false.</returns>
    public bool IsEmpty()
    {
        return this.size == 0;
    }

    /// <summary>
    /// The function for enqueue the value in queue.
    /// </summary>
    /// <param name="value">The value to enqueue.</param>
    /// <param name="priority">The priority.</param>
    public void Enqueue(int value, int priority)
    {
        if (this.list.Length == this.size)
        {
            var newList = new QueueItem[this.list.Length * 2];
            Array.Copy(this.list, newList, this.list.Length);
            this.list = newList;
        }

        var item = new QueueItem(value, priority, ++this.sequenceNumber);
        this.list[this.size] = item;
        this.Search(this.size);
        ++this.size;
    }

    /// <summary>
    /// The function for dequeue the value from queue.
    /// </summary>
    /// <returns>The value with the largest priority.</returns>
    /// <exception cref="InvalidOperationException">If the queue is Empty.</exception>
    public int Dequeue()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var result = this.list[0] ?? throw new InvalidOperationException();
        --this.size;
        this.list[0] = this.list[this.size];
        this.list[this.size] = null;

        if (this.size > 0)
        {
            this.SearchTwo(0);
        }

        return result.Value;
    }

    private void Search(int index)
    {
        while (index > 0)
        {
            int prevIndex = (index - 1) / 2;
            if (this.CompareItems(this.list[index], this.list[prevIndex]))
            {
                this.Swap(index, prevIndex);
                index = prevIndex;
            }
        }
    }

    private void SearchTwo(int index)
    {
        while (true)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;
            int largestIndex = index;

            if (leftChildIndex < this.size && this.CompareItems(this.list[leftChildIndex], this.list[largestIndex]))
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < this.size && this.CompareItems(this.list[rightChildIndex], this.list[largestIndex]))
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex == index)
            {
                break;
            }

            this.Swap(index, largestIndex);
            index = largestIndex;
        }
    }

    private bool CompareItems(QueueItem? first, QueueItem? second)
    {
        if (first == null || second == null)
        {
            throw new ArgumentNullException();
        }

        if (first.Priority != second.Priority)
        {
            return first.Priority > second.Priority;
        }

        return first.SequenceNumber < second.SequenceNumber;
    }

    private void Swap(int a, int b)
    {
        var tmp = this.list[a];
        this.list[a] = this.list[b];
        this.list[b] = tmp;
    }

    /// <summary>
    /// The class for queue`s item.
    /// </summary>
    public class QueueItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueItem"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="sequenceNumber">The sequenceNumber.</param>
        public QueueItem(int value, int priority, long sequenceNumber)
        {
            this.Value = value;
            this.Priority = priority;
            this.SequenceNumber = sequenceNumber;
        }

        /// <summary>
        /// Gets the value of element.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Gets the sequenceNumber.
        /// </summary>
        public long SequenceNumber { get; }

    }
}
