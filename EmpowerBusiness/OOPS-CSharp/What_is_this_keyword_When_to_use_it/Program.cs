//Q. What is “this” keyword in C#? When to use it?


Student std1 = new Student(001, "Jack");
std1.GetStudent();

class Student
{
    public int id;
    public string name;
    public Student(int id, string name)
    {
        this.id = id;
        this.name = name;

    }
    public void GetStudent()
    {
        Console.WriteLine(id + " : " + name);
    }
}