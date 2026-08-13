
/*
 Calculator - overloading assignment

 We only overload addition and multiplication for many numbers,
 because the order of the numbers doesn't change the result.

 Addition and multiplication are order-independent:
   2 + 3 + 4  is always 9   (whether grouped as (2+3)+4 or 2+(3+4))
   2 * 3 * 4  is always 24  (same result no matter the grouping)
 So a many-number version is always unambiguous.

 Subtraction and division depend on order:
   10 - 3 - 2   could be 5  ((10-3)-2)  or  9  (10-(3-2))
   100 / 5 / 2  could be 10 (100/5/2)   or  40 (100/(5/2))

 On a single line, C# reads left to right and handles this for us,
 so 10 - 3 - 2 returns 5 automatically. The problem only appears
 when you put the numbers in a params double[] and loop through them
 yourself: starting at 0, Subtract(10, 3, 2) becomes
 0 - 10 - 3 - 2 = -15 instead of 5, because the first number gets
 subtracted too. Addition avoids this, since starting at 0 is always
 safe (0 + 10 + 3 + 2 = 15).

 Therefore we overload only Sum and Multiply for many numbers, and
 keep Subtract and Divide as two-number methods, where there is no
 ambiguity (10 - 3 is always 7).

Conclusion :The assignment asks us to use overloading in a calculator, and the whole point of a calculator is to give the correct answer.
That's why we only overload addition and multiplication for many numbers.

 "Note: This program uses the European number format, where the decimal separator is a comma (e.g. 3,5 — not 3.5).
 Enter decimal numbers using a comma."
 
 */
using System.Timers;

Calculator calc = new Calculator();
bool running = true;
do
{
    Console.Clear();
    Introduksjon();

    running = UserInput(calc);// UserInput() returns false when the user chooses to quit.
                              // We store that result in 'running' so the do-while loop can end.


} while (running);

static void Introduksjon()
{
    Console.Clear();
    Console.WriteLine("Calculator");
    Console.WriteLine("What kind of calculation would you like to perform?");
    Console.WriteLine("Write that number for the calculation,");
    Console.WriteLine("(1) Addition of two numbers");
    Console.WriteLine("(2) Addition of several numbers");
    Console.WriteLine("(3) Multiplication of two numbers");
    Console.WriteLine("(4) Multiplication of several numbers");
    Console.WriteLine("(5) All calculation (+ - * /) ");
    Console.WriteLine("(6) Quit this program.");
}

static bool UserInput(Calculator calc)
{
    string userInput = Console.ReadLine();
    bool isValid = int.TryParse(userInput, out int number);
    bool keepRunning = true;
    if (isValid == true)
    {
        switch (userInput)
        {
            case "1":
                {
                    Console.WriteLine("Addition of two numbers");
                    Console.Write("First number: ");
                    bool firstNumber = double.TryParse(Console.ReadLine(), out double inputA);
                    Console.Write("Second number: ");
                    bool secondNumber = double.TryParse(Console.ReadLine(), out double inputB);

                    if (firstNumber && secondNumber)
                        Console.WriteLine("Sum: " + calc.Sum(inputA, inputB));      // ← Variant 1
                    else
                        Console.WriteLine("Please enter valid numbers.");
                    break;
                }
            case "2":
                {
                    Console.WriteLine("Enter several numbers to add, separated by space:");
                    string line = Console.ReadLine();

                    // Split the line on spaces, ignoring empty parts (double spaces)
                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    List<double> numbers = new List<double>();
                    bool allValid = true;

                    foreach (string part in parts)
                    {
                        if (double.TryParse(part, out double value))
                            numbers.Add(value);
                        else
                        {
                            Console.WriteLine("Invalid number: " + part);
                            allValid = false;
                        }
                    }

                    if (allValid && numbers.Count > 0)
                        Console.WriteLine("Sum: " + calc.Sum(numbers.ToArray()));   // params overload
                    else
                        Console.WriteLine("Please enter valid numbers separated by space.");
                    break;
                }


            case "3":
                {
                    Console.WriteLine("Multiplication of two numbers");
                    Console.Write("First number: ");
                    bool firstNumber = double.TryParse(Console.ReadLine(), out double inputA);
                    Console.Write("Second number: ");
                    bool secondNumber = double.TryParse(Console.ReadLine(), out double inputB);

                    if (firstNumber && secondNumber)
                        Console.WriteLine("Product: " + calc.Multiplication(inputA, inputB));   // ← two-number overload
                    else
                        Console.WriteLine("Please enter valid numbers.");
                    break;
                }

            case "4":
                {
                   
                        Console.WriteLine("Enter several numbers to multiply, separated by space:");
                        string line = Console.ReadLine();

                        // Split the line on spaces, ignoring empty parts (double spaces)
                        string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        List<double> numbers = new List<double>();
                        bool allValid = true;

                        foreach (string part in parts)
                        {
                            if (double.TryParse(part, out double value))
                                numbers.Add(value);
                            else
                            {
                                Console.WriteLine("Invalid number: " + part);
                                allValid = false;
                            }
                        }

                        if (allValid && numbers.Count > 0)
                            Console.WriteLine("Product: " + calc.Multiplication(numbers.ToArray()));   // params overload
                        else
                            Console.WriteLine("Please enter valid numbers separated by space.");
                        break;
                   
                }
            case "5":
                {
                    Console.Write("Enter the first number: ");
                    double result;
                    while (!double.TryParse(Console.ReadLine(), out result))
                        Console.Write("Not a valid number. Try again: ");

                    while (true)
                    {
                        Console.Write("Operator (+ - * /) or '=' to finish: ");
                        string op = Console.ReadLine();

                        if (op == "=")
                            break;                          // user is done

                        if (op != "+" && op != "-" && op != "*" && op != "/")
                        {
                            Console.WriteLine("Invalid operator, try again.");
                            continue;
                        }

                        Console.Write("Next number: ");
                        if (!double.TryParse(Console.ReadLine(), out double next))
                        {
                            Console.WriteLine("Not a valid number, try again.");
                            continue;
                        }

                        // Perform the operation step by step
                        switch (op)
                        {
                            case "+": result += next; break;
                            case "-": result -= next; break;
                            case "*": result *= next; break;
                            case "/":
                                if (next == 0)
                                    Console.WriteLine("Cannot divide by zero. Ignored.");
                                else
                                    result /= next;
                                break;
                        }

                        Console.WriteLine("Result so far: " + result);   // running total each step
                    }

                    Console.WriteLine("Final result: " + result);
                    break;
                }
            case "6":
                Console.WriteLine("Exit...");
                keepRunning = false;
                break;
            default:
                Console.WriteLine("That was not a number. Enter a number from 1 to 6.");
                break;
        }
    }
    else
    {
        Console.WriteLine("That was not a number. Enter a number from 1 to 6.");   
    }
    Console.WriteLine("press a key first, then enter a new number");
    Console.ReadLine();


    return keepRunning;
}

public class Calculator
{
    // OVERLOAD: same method name "Sum", two different parameter lists.
    // Variant 1: used when adding exactly two numbers (menu option 1)

    public double Sum(double a, double b)
    {
        return a + b;
    }


    // / Variant 2: many numbers via params
    // — used when adding more than two numbers (menu option 5)

    public double Sum(params double[] nums)
    {
        return nums.Sum();
    }

    public double Subtract(double a, double b)   
    {
        return a - b;
    }
    public double Multiplication(double a, double b)   
    {
        return a * b;
    }
    public double Multiplication(params double[] nums)
    {
        double result = 1;//We start result at 1 because the loop multiplies every number into it, so it needs something to multiply the first number by.
                          //1 is the only value that doesn't change the answer (1 × 5 = 5).
        foreach (double n in nums)
            result *= n;
        return result;
    }

    public double Division(double a, double b)
    {
        return a / b;
    }



}