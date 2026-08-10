// Chosen task:
// A program that asks the user for the time and gives different greetings based on the time entered.

// How to solve it:
// 1) Need a function that asks for the time and validates the user's input.
//    The tricky part is 0, which can be both an error and a valid clock time.
//    So we must tell a real 0 (midnight) apart from a 0 that comes from a failed parse.

// 2) Show the greetings based on time
//
// 3) Show the end text


int time = 0;   
GetValidTime();
ShowGreeting();
ShowGoodbye();

void GetValidTime()
{
    
    // Checks that the user typed a valid number, and keeps asking until they do.

    
    
    {
        bool isValidTime;
        do
        {
            Console.Clear();
            Console.Write("Write your time (0-23): ");
            isValidTime = int.TryParse(Console.ReadLine(), out time);

            // Number must be within 0-23 to be a real clock time
            if (!isValidTime || time < 0 || time > 23)
            {
                isValidTime = false;
                Console.WriteLine("Not a valid number");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        } while (!isValidTime);
    }
}

void ShowGreeting()
{
    if (time >= 0 && time <= 5) Console.WriteLine("Good night");
    else if (time >= 6 && time <= 11) Console.WriteLine("Good morning");
    else if (time >= 12 && time <= 17) Console.WriteLine("Good afternoon");
    else Console.WriteLine("Good evening");
}

void ShowGoodbye()
{
    Console.WriteLine("Surprise, there is nothing more for you to do now.");
    Console.WriteLine("The program ends here.");
}

