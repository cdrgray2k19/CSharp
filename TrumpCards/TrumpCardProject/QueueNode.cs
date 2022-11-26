namespace TrumpCardProject;

public class QueueNode
{
    private Card data;
    private QueueNode next;

    public Card Data
    {
        get { return data; }
    }

    public QueueNode Next
    {
        get { return next; }
        set { next = value; }
    }

    public QueueNode(Card value)
    {
        this.data = value;
        this.next = null;
    }
}