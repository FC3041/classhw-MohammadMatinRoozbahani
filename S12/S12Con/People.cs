public class People : IComparable{
    public string fname;
    public string lname;
    public int NID;
    public People(string fn, string ln, int id){
        fname = fn;
        lname = ln;
        NID = id;
    }
    public void PrintPeople(){
        Console.WriteLine($"{this.fname},{this.lname},{this.NID}");
    }
    public int CompareTo(object obj){
        People temp = obj as People;
        if (temp == null){
            return 1;
        }
        return this.NID.CompareTo(temp.NID);
    }
}