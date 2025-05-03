public class Student:IComparable
{
    private string fname;
    public string FirstName{
        get{return fname;}
        set {fname = value;}
    }
    private string lname;
    public string LastName{get{return lname;} set{lname = value;}}
    private int id;
    public int Id{
        get{return id;}
        set{id = value;}
    }
    public int StdId{get; set;}
    public double GPA{get; private set;}
    public string FullName => $"{FirstName} {LastName}";
    public Student(string fname, string lname, int Id, int StdId, double GPA)
    {
        this.fname = fname;
        this.lname = lname;
        this.Id = Id;
        this.StdId = StdId;
        this.GPA = GPA;
    }
    public override string ToString() => $"{FullName}\t{Id}\t{StdId}\t{GPA}";

    public int CompareTo(object obj)
    {
        Student other = obj as Student;
        if (other == null)
        {
            return 1;
        }
        return this.FirstName.CompareTo(other.FirstName);
    }
}