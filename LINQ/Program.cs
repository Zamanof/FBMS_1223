// LINQ - Language-Integrated Query
// LINQ to Object
// LINQ to DataSet
// LINQ to XML
// LINQ to Entities
// PLINQ - Parallel LINQ
// LINQ to SQL


#region LINQ

int[] arr = { 5, 9, 91, 12, 36, 31, 54, 84, 1, 123, 35, 78 };


// from select
//
//IEnumerable<int> query = from item in arr 
//                         select item;
//foreach (var item in query)
//{
//    Console.Write($"{item} ");
//}
//Console.WriteLine();
//arr[0] = 56;

//ShowArr(query);

// where orderby
//IEnumerable<int> evenQuery = from i in arr
//                             where i % 2 == 0
//                             orderby i descending
//                             select i;
//ShowArr(evenQuery);



// group by, into
//IEnumerable<IGrouping<int, int>> groupingQuery
//    = from i in arr 
//      group i by i % 10;


//foreach (IGrouping<int, int> key in groupingQuery)
//{
//    Console.Write($"Key {key.Key}\nValue:");
//    foreach(int item in key)
//    {
//        Console.Write($"\t{item}");
//    }
//    Console.WriteLine();
//}



//IEnumerable<IGrouping<int, int>> groupingQueryInto
//    = from i in arr
//      group i by i % 10 into result
//      where result.Count() > 1
//      select result;

//foreach (IGrouping<int, int> key in groupingQueryInto)
//{
//    Console.Write($"Key {key.Key}\nValue:");
//    foreach (int item in key)
//    {
//        Console.Write($"\t{item}");
//    }
//    Console.WriteLine();
//}



// let
//string[] azerbaijan =
//{
//    "El bilir ki, sən mənimsən,",
//    "Yurdum, yuvam, məskənimsən,",
//    "Anam doğma vətənimsən!",
//    "Ayrılarmı könül candan?",
//    "Azərbaycan, Azərbaycan!",
//    "Mən bir uşaq, sən bir ana,",
//    "Odur ki, bağlıyam sana,",
//    "Hanki səmtə, hanki yana",
//    "Hey uçsam da yuvam sənsən,",
//    "Elim, günüm, obam sənsən!"
//};

//IEnumerable<string> strings = from bend in azerbaijan
//                              let words = bend.Split(' ', ',', '?', '!')
//                              from word in words
//                              where word.Count() > 6
//                              select word;


//foreach (var item in strings)
//{
//    Console.Write($"{item} ");
//}
//Console.WriteLine();

//void ShowArr(IEnumerable<int> query)
//{
//    foreach (var item in query)
//    {
//        Console.Write($"{item} ");
//    }
//    Console.WriteLine();
//}
#endregion


List<Country> countries = new()
{
    new Country(){Name="Azerbaijan", Capital="Baku", Id= 1},
    new Country(){Name="USA", Capital="Washington", Id= 2},
    new Country(){Name="Ukraine", Capital="Kiev", Id= 3},
    new Country(){Name="Georgia", Capital="Tbilisi", Id= 4},
    new Country(){Name="Germany", Capital="Berlin", Id= 5},
    new Country(){Name="Japan", Capital="Tokio", Id= 6},
    new Country(){Name="China", Capital="Beijing", Id= 7},
    new Country(){Name="Italy", Capital="Rome", Id= 8},
    new Country(){Name="Spain", Capital="Madrid", Id= 9}
};

List<Employee> employees = new()
{
    new Employee(){Name="Nadir", Age=42, CountryId=1, Id=1},
    new Employee(){Name="Salam", Age=25, CountryId=1, Id=2},
    new Employee(){Name="Volodimir", Age=45, CountryId=3, Id=3},
    new Employee(){Name="Mark Salas", Age=36, CountryId=9, Id=4},
    new Employee(){Name="Leonardo Da Vinci", Age=532, CountryId=8, Id=5},
    new Employee(){Name="Anjelina Jolie", Age=44, CountryId=2, Id=6},
    new Employee(){Name="Keanu Reeves", Age=58, CountryId=2, Id=7},
    new Employee(){Name="Bruce Lee", Age=74, CountryId=7, Id=8},
    new Employee(){Name="Messi", Age=36, CountryId=9, Id=9},
    new Employee(){Name="Ronaldo", Age=38, CountryId=4, Id=10}
};

// boxing unboxing

#region join
//var query = from c in countries
//            join em in employees 
//            on c.Id equals em.CountryId into result
//            from r in result
//            select r;
//foreach (Employee e in query)
//{
//    Console.WriteLine($"{e} {countries.First(c=> c.Id == e.CountryId).Name}");
//}
#endregion

#region First, FirstOrDefault
//var emp = employees.First(x => x.Id == 1);
//Console.WriteLine(emp);

//var emp = employees.FirstOrDefault(x => x.Id == 2);
//if (emp is not null)
//{
//    Console.WriteLine(emp);
//}
#endregion

#region Single, SingleOrDefault
//var emp = employees.Single(x => x.Age == 36);
//Console.WriteLine(emp);

//var emp = employees.SingleOrDefault(x => x.Age == 12);
//Console.WriteLine(emp);
#endregion

#region Contains
//var ch = arr.Contains(5);
//Console.WriteLine(ch);
#endregion

#region Where
//var evenNumbers = arr.Where(x => x % 2 == 0);
//foreach (var item in evenNumbers)
//{
//    Console.WriteLine(item);
//}

//var emp = employees.Where(x => x.Age > 40);
//foreach (var item in emp)
//{
//    Console.WriteLine(item);
//}
#endregion

#region Max, Min, Average, Sum
//var resMax = employees.Max(x => x.Age);
//Console.WriteLine(resMax);

//var resMin = employees.Min(x => x.Age);
//Console.WriteLine(resMin);

//var resAvg = employees.Average(x => x.Age);
//Console.WriteLine(resAvg);

//var emp = employees.FirstOrDefault(x => x.Age == employees.Max(x => x.Age));
//Console.WriteLine(emp);

//var ageSum = employees.Sum(x => x.Age);
//Console.WriteLine(ageSum);
#endregion

#region OrderBy
//var empAsc = employees.OrderBy(x => x.Age);
//var empDesc = employees.OrderByDescending(x => x.Age);
//foreach (var item in empDesc)
//{
//    Console.WriteLine(item);
//}

//var ordEmployees = employees
//    .OrderByDescending(x => x.Age)
//    .ThenBy(x=> x.Name);

//foreach (var item in ordEmployees)
//{
//    Console.WriteLine(item);
//}
#endregion

#region Take, Skip. TakeWhile
//var emp = employees.Skip(3).Take(2);
//var emp = employees.TakeWhile(x => x.Age < 532);
//foreach(Employee e in emp)
//{
//    Console.WriteLine(e);
//}    
#endregion

#region All, Any
//var ch = employees.All(x => x.Age > 20);
//var ch = employees.Any(x => x.Age == 36);
//Console.WriteLine(ch);
#endregion


//employees.ForEach(x => Console.WriteLine(x));
//employees.ForEach(x => x.Age += 1);
//employees.ForEach(x => Console.WriteLine(x));
//Console.WriteLine(employees[0]);
class Country
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Capital { get; set; }

   

    public override string ToString()
    {
        return $"{Id}. Country name {Name} - Capital city: {Capital}";
    }
}

class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public int CountryId { get; set; }


    public override string ToString()
    {
        return $"{Id}. Name: {Name} - Age: {Age}";
    }
}