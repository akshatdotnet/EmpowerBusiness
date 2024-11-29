//Boxing is the process of converting from value type to reference type.

//Unboxing is the process of converting reference type to value type.
//Unboxing is explicit conversion process.

using System.Collections;

static void Main(string[] args)
{
    int num = 100;

    object obj = num;     //Boxing 

    int i = (int)obj;     //Unboxing

    ArrayList arrayList = new ArrayList();

    arrayList.Add(i);

    int k = (int)arrayList[0];

    Console.WriteLine(k);

    Console.ReadLine();
}