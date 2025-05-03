public interface IPerson<_Type>:IComparable<IPerson<_Type>>{
    string FirstName {get;set;}
    string LastName {get;set;}
    string FullName {get;}
}
class PersonComparers{
    public static PersonFirstNameComparer personFirstNameComparer;
}
class PersonFirstNameComparer : IComparer<IPerson<int>> {
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        return x.FirstName.CompareTo(y.FirstName);
    }
}
class PersonLastNameComparer : IComparer<IPerson<int>> {
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        return x.LastName.CompareTo(y.LastName);
    }
}
class Student:IPerson<int>{
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string FullName {
        get{
            return FirstName + " " + LastName;
        }
    }
    public double GPA {get; set;}

    public int CompareTo(IPerson<int> other)
    {
        return this.FirstName.CompareTo(other.FirstName);
    }
    public override string ToString() => $"{this.FullName}\t{GPA}";
}
class Teacher:IPerson<string>{
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string FullName {
        get{
            return FirstName + " " + LastName;
        }
    }
    public double Rating {get; set;}

    public int CompareTo(IPerson<string> other)
    {
        throw new NotImplementedException();
    }
}