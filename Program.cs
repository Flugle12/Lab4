using System.Runtime.CompilerServices;
using System.Collections.Generic;


public class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>(4) { 1,2,3,4 };
        ReverseLists(ref list);
        PrintList(list);

        InsertAroundElements(ref list, 3);
        PrintList(list);
    
        HashSet<char> Clubs = new HashSet<char>() { 'a', 'b', 'c', 'f'};
        Dictionary<string, HashSet<char>> studentsd = new Dictionary<string, HashSet<char>>()
        {
            { "student A", new HashSet<char> {'a', 'b', 'c'}},
            { "student B", new HashSet<char> {'a', 'b',}},
            { "student C", new HashSet<char> {'a', 'c'}},
            { "student D", new HashSet<char> {'a', 'b'}},
            { "student E", new HashSet<char> {'a'}},
            { "student F", new HashSet<char> {'b', 'a'}}
        };

        Disco(Clubs, studentsd);
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
    static void InsertAroundElements(ref List<int> L, int element, int ElementForInsert = 0)
    {
        L.Insert(L.Find(p => p == element)-1, ElementForInsert);
        L.Insert(L.Find(p => p == element)-2, ElementForInsert);
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


private static void PrintList(List<int> list)
    {
        Console.WriteLine(string.Join(", ", list));
    }

}

