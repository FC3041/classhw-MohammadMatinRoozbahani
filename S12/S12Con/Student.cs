public interface IHasHigher<T>{
    bool IsHigher(T std);
}
public class Student:IHasHigher<Student>{
    public string fname;
    public string lname;
    public int NID;
    public Student(string fn, string ln, int id){
        fname = fn;
        lname = ln;
        NID = id;
    }
    public void PrintStudent(){
        Console.WriteLine($"{this.fname},{this.lname},{this.NID}");
    }
    public bool IsHigher(Student std){
        return this.NID > std.NID;
    }
    // public int CompareTo(object obj){
    //     Student temp = obj as Student;
    //     if (temp == null){
    //         return 1;
    //     }
    //     return this.NID.CompareTo(temp.NID);
    // }
}

public class Teacher:IHasHigher<Teacher>{
    public string fname;
    public string lname;
    public int NID;
    public Teacher(string fn, string ln, int id){
        fname = fn;
        lname = ln;
        NID = id;
    }
    public void PrintTeacher(){
        Console.WriteLine($"{this.fname},{this.lname},{this.NID}");
    }
    public bool IsHigher(Teacher std){
        return this.NID > std.NID;
    }
    // public int CompareTo(object obj){
    //     Student temp = obj as Student;
    //     if (temp == null){
    //         return 1;
    //     }
    //     return this.NID.CompareTo(temp.NID);
    // }
}