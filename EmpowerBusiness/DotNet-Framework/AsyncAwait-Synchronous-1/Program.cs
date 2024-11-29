Console.WriteLine(Method1());
Console.WriteLine(Method2());
Console.WriteLine(Method3());
//Output 10 20 30


//Synchronous Programming
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
