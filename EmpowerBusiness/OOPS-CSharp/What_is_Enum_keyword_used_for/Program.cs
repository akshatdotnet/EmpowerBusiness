//Q. What is Enum keyword used for?
//An enum is a special "class" that represents a group of constants.


static void Main(string[] args)
{
    Level myLevel = Level.Medium;

    Console.WriteLine(myLevel);
}

enum Weekdays
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thrusday,
    Friday,
    Saturday
}

enum Level
{
    Low,
    Medium,
    High
}