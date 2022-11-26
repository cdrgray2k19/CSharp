namespace TrumpCardProject;


public class Queue
{
    private QueueNode first;
    private QueueNode last;
    private int length = 0;

    public Queue()
    {
        first = null;
        last = null;
    }

    public void add(Card node)
    {
        if (first == null)
        {
            first = new QueueNode(node);
            last = first;
        }
        else
        {
            QueueNode temp = new QueueNode(node);
            last.Next = temp;
            last = temp;
        }

        length += 1;
    }

    public QueueNode remove()
    {
        if (!isEmpty())
        {

            QueueNode temp = first;
            first = first.Next;

            length -= 1;
            return temp;
        }
        else
        {
            return null;
        }
    }

    public Boolean isEmpty()
    {
        return first == null;
    }

    public QueueNode peek()
    {
        if (!isEmpty())
        {
            return first;
        }
        else
        {
            return null;
        }
    }

    public int getLength()
    {
        return length;
    }
}