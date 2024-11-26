using System.Runtime.CompilerServices;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;


public class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>(4) { 1,2,3,4 }; //list for first 
        ReverseLists(ref list); // first task
        PrintList(list); // print List

        LinkedList<int> list2 = new LinkedList<int>(); //create linkedList for second task
        for(int i = 0; i < 4; i++)
        {
            list2.AddLast(i);
        }


        InsertAroundElements(ref list2, 3, 90); //second task
        PrintList(list2); // print Linked List
    
        HashSet<char> Clubs = new HashSet<char>() { 'a', 'b', 'c', 'f'}; // clubs for fird task
        Dictionary<string, HashSet<char>> studentsd = new Dictionary<string, HashSet<char>>()
        {
            { "student A", new HashSet<char> {'a', 'b', 'c'}},
            { "student B", new HashSet<char> {'a', 'b',}},
            { "student C", new HashSet<char> {'a', 'c'}},
            { "student D", new HashSet<char> {'a', 'b'}},
            { "student E", new HashSet<char> {'a'}},
            { "student F", new HashSet<char> {'b', 'a'}}
        }; //dictionary for 4 task have a student and visited clubs

        Disco(Clubs, studentsd); // 3 task


        string FileName = "C:\\Users\\User\\source\\repos\\Lab4\\bin\\Debug\\Text.txt";
        UniqueCharInText(FileName);

        

    }

    //1

    /*
     * Составить программу, которая переворачивает список L, т.е. изменяет ссылки в этом списке так, 
     * чтобы его элементы оказались расположенными в обратном порядке.
     */
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
        if(node != null)
        {
            L.AddBefore(node, ElementForInsert);
            L.AddAfter(node, ElementForInsert);
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

