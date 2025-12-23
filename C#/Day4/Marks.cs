// An indexer can be read-only by removing the set accessor.

class Marks
{
    private int[] marks = { 80, 90, 85 };

    public int this[int index]
    {
        get { return marks[index]; }
    }

}