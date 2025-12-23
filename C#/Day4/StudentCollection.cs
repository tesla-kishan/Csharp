class StudentCollection
{
    private string[] students = new string[3];

    public string GetStudent(int index)
    {
        return students[index];
    }

    public void SetStudent(int index, string name)
    {
        students[index] = name;
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= students.Length)
                return "Invalid Index";
            return students[index];
        }
        set
        {
            if (index >= 0 && index < students.Length)
                students[index] = value;
        }
    }
}
