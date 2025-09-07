public class Student: IDisposable
{
    private string Name;
    private bool ismale;
    public void set_name(string newname){
        if (newname.Length <= 20){
        this.Name = newname;
        }
    }
    public string get_name(){
        string res;
        if (this.ismale){
            res = "Mr. " + this.Name;
        }
        else{
            res = "Ms. " + this.Name;
        }
        return res;
    }
    private string _lastname;
    public string Lastname{
        get{
            return _lastname;
        }
        set{
            this._lastname = value;
        }
    }
    public string fullname{
        get{
            return this.Name + " " + this.Lastname;
        }
    }
    public Student(string name)
    {
        this.Name = name;
        Register(name);
    }
    public void Register(string name)
    {
        Console.WriteLine("Registering " + name);
    }
    public void Dispose(){
        Console.WriteLine("Disposing " + Name);
    }
    ~Student(){
        Console.WriteLine("Finalizing");
    }
}