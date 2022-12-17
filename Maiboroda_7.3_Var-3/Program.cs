// Майборода А.А. - Вар 3 - Высокий
string[] names =
{
    "Баранова П. М.", "Зотов С. М.",
    "Николаев А. Э.", "Попов М. Н.",
    "Еремина С. М.", "Романов И. В.",
    "Белова Е. А.", "Волошина А. Р.",
    "Панова Е. Я.", "Корнеева С. С."
};

string[] courses = { "ISP", "A", "SA", "D" };

var random = new Random();

var students = new STUD[10];
for (var iteration = 0; iteration < 10; iteration++)
{
    var ses = new[] { random.Next(2, 6), random.Next(2, 6), random.Next(2, 6), random.Next(2, 6) };
    var student = new STUD(
        names[iteration], courses[random.Next(0, courses.Length)],
        random.Next(1, 5), random.Next(1, 3), ses);
    students[iteration] = student;
}

// Вывод студентов, упорядоченных по среднему баллу и сохранение положения в данном списке
students = students.OrderByDescending(student => student.Average).ToArray();
for (var iteration = 0; iteration < students.Length; iteration++)
{
    // students[iteration].Print(); Console.WriteLine();
    students[iteration].PositionByAverage = iteration + 1;
}

// Вывод студентов, упорядоченных по имени в алфавитном порядке
foreach (var student in students.OrderBy(student => student.Name))
{
    student.Print();
    Console.WriteLine();
}

struct STUD
{
    public string Name;
    public string Group;
    public int[] Ses;
    public int? PositionByAverage;
    public double Average;

    public STUD(string name, string group, int[] ses)
    {
        Name = name;
        Group = group;

        if (ses.Length != 4) throw new Exception("Length of Ses should be equal 4");
        Ses = ses;
        Average = ses.Average();

        PositionByAverage = null;
    }

    public STUD(string name, string faculty, int course, int groupNumber, int[] ses)
    {
        Name = name;
        Group = $"{faculty}-{course}/{groupNumber}";

        if (ses.Length != 4) throw new Exception("Length of Ses should be equal 4");
        Ses = ses;
        Average = ses.Average();

        PositionByAverage = null;
    }

    public void Print()
    {
        Console.WriteLine($"Имя студента: {Name}\nНазвание группы: {Group}");
        Console.Write("Успеваемость:");
        for (var estimateIndex = 0; estimateIndex < Ses.Length; estimateIndex++)
        {
            Console.Write($" {Ses[estimateIndex]}{(estimateIndex != Ses.Length - 1 ? "," : "\n")}");
        }
        Console.WriteLine($"Средний балл: {Average}");
        if (PositionByAverage != null)
            Console.WriteLine($"Положение в топе оценок: {PositionByAverage}");
    }
}