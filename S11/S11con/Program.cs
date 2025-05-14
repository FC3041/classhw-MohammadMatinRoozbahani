namespace S11con;

class Program
{
    static void Main(string[] args)
    {
        Student s = new Student(
            fname:"hami",
            lname:"jafari",
            Id: 32409594,
            StdId: 123456789,
            GPA: 19.5
        );

        List<Student> students = new List<Student>();
        students.Add(new Student(
            fname:"hami",
            lname:"jafari",
            Id: 325594,
            StdId: 123456789,
            GPA: 19.5
        ));
        students.Add(new Student(
            fname:"ashkan",
            lname:"mahdavi",
            Id: 324594,
            StdId: 3456789,
            GPA: 13.5
        ));
        students.Add(new Student(
            fname:"zari",
            lname:"moosavi",
            Id: 29594,
            StdId: 2234789,
            GPA: 15.5
        ));
        students.Add(new Student(
            fname:"ali",
            lname:"izadi",
            Id: 9594,
            StdId: 1236789,
            GPA: 18.5
        ));
        foreach (Student ss in students)
        {
            Console.WriteLine(ss);
        }
        students.Sort();
        Console.WriteLine("After sorting:");
        foreach (Student ss in students)
        {
            Console.WriteLine(ss);
        }

        while (true){
            Console.WriteLine("Enter a number: ");
            try{
                int num = int.Parse(Console.ReadLine());
            }
            catch (FormatException fe){
                Console.WriteLine(fe.Message);
                continue;
            }
        }
    }
}
