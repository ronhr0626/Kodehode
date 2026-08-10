/*
FizzBuzz is a common programming challenge often used in 
interviews to test a developer's logical skills. 
The task is to print numbers from 1 to 100, 
but for multiples of three, print "Fizz" instead of the number, 
for multiples of five, print "Buzz", 
and for multiples of both three and five, print "FizzBuzz".
*/




for(int i=1;i<=100;i++)
{
    
    if (i%3==0)
    {
        Console.Write("Fizz");
    }
    if (i%5==0)
    {
        Console.Write("Fuzz");
    }
if (i % 3 != 0 && i % 5 != 0)
    {
        Console.Write(i);
    }
    Console.WriteLine();


}
//Console.WriteLine("press a key");
// Console.ReadLine();cls
