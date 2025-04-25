


using System.Collections;

namespace S13con;

class Program
{
//     public static void PrintPerson(Student s){
//         System.Console.WriteLine(s.FullName);
//     }
//     public static void PrintPerson(Teacher t){
//         System.Console.WriteLine(t.FullName);
//     }
    
    public static void PrintPersons(IPerson<int>[] ps){
        foreach (var p in ps){
            System.Console.WriteLine(p);
        }
    }

    static void Main(string[] args)
    {
        Student[] students = new Student[]{
            new Student(){
            FirstName = "ali",
            LastName = "ameri",
            GPA = 18.5
            },
            new Student(){
            FirstName = "mhadi",
            LastName = "saber",
            GPA = 17.5
            },
            new Student(){
            FirstName = "gholam",
            LastName = "siahi",
            GPA = 18
            },
            new Student(){
            FirstName = "milad",
            LastName = "jamali",
            GPA = 19.5
            }
        };
        Teacher t = new Teacher(){
            FirstName = "mohammad",
            LastName = "alavi"
        };
        // PrintPerson(s);
        PrintPersons(students);
        MySort(students, PersonComparers.personFirstNameComparer);
        System.Console.WriteLine("---------------");
        PrintPersons(students);
    }

    private static void MySort(IPerson<int>[] poeple, IComparer<IPerson<int>> cmp)
    {
        for (int i = 0; i < poeple.Length; i++){
            for (int j = 0; j < poeple.Length; j++){
                if (cmp.Compare(poeple[i], poeple[j]) > 0){
                    swap(poeple, i, j);
                }
            }
        }
    }

    private static void swap<T>(T[] poeple, int i, int j)
    {
        T tmp = poeple[i];
        poeple[i] = poeple[j];
        poeple[j] = tmp;
    }
    //TODO : bara ID va fullname ham comparer benevis.
    //TODO : be soorat class ke to studetns hast kamel con baraye hamash.
}
