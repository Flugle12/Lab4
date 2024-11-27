using System.Runtime.CompilerServices;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Serialization;

public class Program
{
    static void Main(string[] args)
    {
        try { 
        Random intRand = new Random();

        Console.WriteLine("Введите длинну массива: ");
        int lenghL1;
        if(!int.TryParse(Console.ReadLine(), out lenghL1) || lenghL1 <= 0)
        {
            throw new ArgumentException("NaN");
        }

        List<int> list = new List<int>(lenghL1); //list for first 
        for(int i = 0; i < lenghL1; i ++)
        {
            list.Add(intRand.Next(1,101));
        }

        PrintList(list); // print List
        ReverseLists(ref list); // first task
        PrintList(list); // print List

        Console.WriteLine();

        LinkedList<int> list2 = new LinkedList<int>(); //create linkedList for second task
        for(int i = 0; i < 9; i++)
        {
            list2.AddLast(i);
        }

        Console.WriteLine("Введите число около которого вы хотите встаить элементы и число которое отите вставить");
        int e, inserter;
        if(!int.TryParse(Console.ReadLine(), out e) || !int.TryParse(Console.ReadLine(), out inserter) || e > list2.Count())
        {
            throw new ArgumentException("NaN");
        }

        PrintList(list2); // print Linked List
        InsertAroundElements(ref list2, e, inserter); //second task
        PrintList(list2); // print Linked List

        Console.WriteLine("Введите количество студентов:");
        int numberOfStudents;
        if (!int.TryParse(Console.ReadLine(), out numberOfStudents) || numberOfStudents <= 0)
        {
            throw new ArgumentException("Некорректное количество студентов.");
        }

        Dictionary<string, HashSet<char>> studentsd = new Dictionary<string, HashSet<char>>();

        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"Введите имя студента {i + 1} и посещенные клубы (например: 'student A a b c') (названия клубов a b c f):");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            string studentName = parts[0];
            HashSet<char> clubsVisited = new HashSet<char>(parts.Skip(1).Select(c => c[0]));

            if (studentsd.ContainsKey(studentName))
            {
                Console.WriteLine($"Студент {studentName} уже добавлен. Попробуйте снова.");
                i--;
                continue;
            }

            studentsd[studentName] = clubsVisited;
        }

        HashSet<char> Clubs = new HashSet<char>() { 'a', 'b', 'c', 'f' };
        Disco(Clubs, studentsd);
        string FileName = "C:\\Users\\User\\source\\repos\\Lab4\\bin\\Debug\\Text.txt";
        UniqueCharInText(FileName);

        StudentPassedExams();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        }
    //1
    static void ReverseLists(ref List<int> L)
    {
        List<int> reverseLiset = new List<int>(L.Count);
        for (int i = L.Count - 1; i >= 0; i--)
        {
            reverseLiset.Add(L[i]);
        }
        L = reverseLiset;
    }

    //2
    static void InsertAroundElements(ref LinkedList<int> L, int element, int ElementForInsert = 0)
    {
        var node = L.Find(element);
        if (node != null)
        {
            L.AddBefore(node, ElementForInsert);
            L.AddAfter(node, ElementForInsert);
        }
        else
        {
            Console.WriteLine("нет в массиве");
            return;
        }
    }

    //3
    static void Disco(HashSet<char> Clubs, Dictionary<string, HashSet<char>> students)
    {
        var AllVisitedClubs = new HashSet<char>(students.Values.First());

        foreach (var visited in students.Values)
        {
            AllVisitedClubs.IntersectWith(visited);
        }

        var SomeVisitedClubs = new HashSet<char>();

        foreach (var visits in students.Values)
        {
            SomeVisitedClubs.UnionWith(visits);
        }

        var NoOneVisitedClubs = new HashSet<char>(Clubs);
        NoOneVisitedClubs.ExceptWith(SomeVisitedClubs);

        Console.WriteLine("Клубы, в которых были все студенты: " + string.Join(", ", AllVisitedClubs));
        Console.WriteLine("Клубы, в которых были некоторые студенты: " + string.Join(", ", SomeVisitedClubs));
        Console.WriteLine("Клубы, в которых не было ни одного студента: " + string.Join(", ", NoOneVisitedClubs));
    }

    //4
    static void UniqueCharInText(string fileName)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = fileName,
            UseShellExecute = true
        });

        HashSet<char> uniqueChar = new HashSet<char>();
        string text;

        if (!File.Exists(fileName))
        {
            throw new ArgumentException("File not founded");
        }
        else
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                text = reader.ReadToEnd();
            }

            string[] word = text.Split(new char[] { ' ', '\n', '\r', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);



            for (int i = 1; i < word.Length; i += 2)
            {
                foreach (char ch in word[i])
                {
                    uniqueChar.Add(ch);
                }
            }
        }

        var sortedChar = uniqueChar.OrderBy(ch => ch);

        Console.WriteLine("Уникальные символы: ");
        foreach (char ch in sortedChar)
        {
            Console.Write(ch + " ");
        }
    }

    //5
    static void StudentPassedExams()
    {
        Console.WriteLine("\nВведите количетво судентов, а затем n записей о студентах:");
        Dictionary<string, List<int>> Students = new Dictionary<string, List<int>>();
        int n;

        if (!int.TryParse(Console.ReadLine(), out n))
        {
            throw new ArgumentException("NaN");
        }

        for (int i = 0; i < n; i++)
        {
            string inputText = Console.ReadLine();
            string[] part = inputText.Split(' ');

            string fullName = part[0] + part[1];

            List<int> studentScore = part.Skip(2).Select(int.Parse).ToList();

            Students[fullName] = studentScore;
        }

        List<string> admitedStudent = new List<string>();

        foreach (var student in Students)
        {
            string name = student.Key;
            List<int> score = student.Value;

            if (score[0] >= 30 && score[1] >= 30 && score[2] >= 30 && score.Sum() >= 140)
            {
                admitedStudent.Add(name);
            }
        }


        admitedStudent.Sort();
        foreach (var student in admitedStudent)
        {
            Console.WriteLine(student + " ");
        }
    }


    private static void PrintList(List<int> list)
    {
        Console.WriteLine(string.Join(", ", list));
    }

    private static void PrintList(LinkedList<int> list)
    {
        foreach (var item in list) Console.Write(item.ToString() + ", ");
        Console.WriteLine();
    }

}

