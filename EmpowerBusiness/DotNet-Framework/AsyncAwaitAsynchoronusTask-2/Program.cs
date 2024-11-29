
Task task1 = Task.Run(() => {
    Console.WriteLine(Method1());
});

Task task2 = Task.Run(() => {
    Console.WriteLine(Method2());
});

Task task3 = Task.Run(() => {
    Console.WriteLine(Method3());
});
Console.Read();



//Asynchronous Programming_Task
static int Method1()
{
    Thread.Sleep(500);
    return 10;
}
static int Method2()
{
    return 20;
}
static int Method3()
{
    return 30;
}