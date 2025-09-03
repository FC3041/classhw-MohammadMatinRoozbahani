using System.Globalization;

namespace S12Con;

class Program
{
    public static void swap<T>(T[] plist, int i, int j){
        T temp = plist[i];
        plist[i] = plist[j];
        plist[j] = temp;
    }
    public static void MySort<T>(T[] plist) where T : IHasHigher<T>{
        for (int i = 0; i < plist.Length; i++){
            for (int j = i+1; j < plist.Length; j++){
                if (plist[i].IsHigher(plist[j])){
                    swap(plist, i, j);
                }
            }
        }
    }
    static void Main(string[] args){
        Student[] students = new Student[3]{
            new Student("maryam" , "akbari" , 123),
            new Student("zoha","manedi",124),
            new Student("narges","mozafari",122)
        };
        for (int i = 0; i < students.Length; i++){
            students[i].PrintStudent();
        }
        System.Console.WriteLine("-----------------------");
        MySort(students);
        for (int i = 0; i < students.Length; i++){
            students[i].PrintStudent();
        }
    }
    static void Main2(string[] args){
        People p1 = new People ("zahra", "mahdavi", 1234);
        People p2 = new People ("ali", "hosseini", 1124);
        People p3 = new People ("hami", "jafari", 3224);

        List<People> people = new List<People>();
        people.Add(p1);
        people.Add(p2);
        people.Add(p3);

        people.Sort();
        for (int i = 0; i < people.Count(); i++){
            Console.WriteLine(people[i].fname);
        }
    }
    static void Main1(string[] args){
        IShape[] shapes = new IShape[]{
            new Rectangle(2,3),
            new Circle(8),
            new Rectangle(7,9),
            new Circle(5)
        };
        double Area_sum = 0;
        double Perimeter_sum = 0;
        for (int i = 0; i < shapes.Length; i++){
            Area_sum += shapes[i].Area();
            Perimeter_sum += shapes[i].Perimeter();
        }
        Console.WriteLine(Area_sum);
        Console.WriteLine(Perimeter_sum);
    }
    static void Main0(string[] args)
    {
        using (MyTimer time = new MyTimer("add 0 to 100")){
            int sum = 0;
            for (int i = 0; i < 100; i++){
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
