using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        //Fragor och svar
        #region
        //1. Stacken är något som körs sekventiellt och som "rensar" sig självt. Saker som är av typen value-type
        // ex int, bool kan ha sina faktiska värden placerade i en variabel medans en reference-type är en typ som ligger på
        //heapen och som istället refereras till via variabler. Heapen är inte sekventiellt på det sättet som stacken och
        //kräver Garbage Collection för att rensas.
        //
        //2. Exemepelvis variabel A är deklarered som typ int och innehåller värdet 5. Det innebär att A är lika med 5.
        //Om ett objekt istället instansieras och deklareras som tillhörande till variabel B är det istället så att
        //variabel B "äger" en referens som pekar till objektet som finns på heapen. Om jag deklarerar en ny variabel
        //C och sätter den lika till B så kommer ändringar på den ena reflekteras på den andra av just den anledningen
        //att de pekar till samma objekt.

        //3. Den första retunerar 3 för att den är deklarerad med värdet 3 och får aldrig ett nytt värde deklarerat.
        // Det skapas upp ett objekt x som får värdet 3 på "MyValue". Därefter skapas ett nytt objekt upp som sedan får en referens till det första objektet och värdet sätts om till 4.
        #endregion

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Reverse text with stack"
                    + "\n5. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ReverseText();
                        break;
                    case '5':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //Kapaciteten dubbleras varje gång nuvarande kapacitet överskrids.
            //Detta sker pga att det är så språket är designat. "Doubling strategy" med syfte att hantera
            //minne effektivt genom att dubblera istället för att vid varje enskild ökning behöva skapa ny plats i minnet.
            //Kapaciteten minskar inte när element tas bort.
            //Jag skulle säga att det är fördelaktigt att använda en egendefinierad array när man inte behöver en datatyp som dynamiskt kan ändra sin storlek.

            List<string> theList = new();
            
            while (true)
            {
                Console.WriteLine("Add to the list by typing +'TEXT' to add or -'TEXT' to remove. Press C to cancel.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Count is: {theList.Count}");
                        Console.WriteLine($"The capacity is: {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Count is: {theList.Count}");
                        Console.WriteLine($"The capacity is: {theList.Capacity}");
                        break;
                    default:
                        Console.WriteLine("You can only use + or -, press C to cancel");
                        break;
                    case 'C':
                        Main();
                        break;
                }
            }

        }
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> theQueue = new();

            while (true)
            {
                Console.WriteLine("Add to the Queue by typing +'TEXT' to enqueue or - to dequeue the first item. Press C to cancel.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"Enqued: {value}");
                        Console.WriteLine($"Count is: {theQueue.Count}");
                        break;
                    case '-':
                        if(theQueue.Count > 0)
                        {
                            Console.WriteLine($"Dequeing: {theQueue.Peek()}");
                            theQueue.Dequeue();
                            Console.WriteLine($"Count is: {theQueue.Count}");
                        } 
                        else
                        {
                            Console.WriteLine("Que is empty, nothing to deque.");
                        }
                        break;
                    default:
                        Console.WriteLine("You can only use + or -, press C to cancel");
                        break;
                    case 'C':
                        Main();
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            //Att använda en stack för att simulera ICA kön är inte så smart eftersom elementet som läggs till för är det som tas bort sist.
            
            Stack<string> theStack = new();

            while (true)
            {
                Console.WriteLine("Add to the Stack by typing +'TEXT' to add or - to remove the first item. Press C to cancel.");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        Console.WriteLine($"Pushed: {value} to the stack");
                        Console.WriteLine($"Count is: {theStack.Count}");
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            Console.WriteLine($"Popping: {theStack.Pop()} from the stack");
                            Console.WriteLine($"Count is: {theStack.Count}");
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty, nothing to pop.");
                        }
                        break;
                    default:
                        Console.WriteLine("You can only use + or -, press C to cancel");
                        break;
                    case 'C':
                        Main();
                        break;
                }
            }

        }
        static void ReverseText()
        {
            Stack<char> ReverseTextStack = new();
            Console.WriteLine("Write the text you want to reverse with the help of a stack");
            string input = Console.ReadLine();

            foreach (char ch in input)
            {
                ReverseTextStack.Push(ch);
            }

            foreach (char ch in input)
            {
                Console.Write(ReverseTextStack.Pop());
            }
            Console.WriteLine("");
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // Jag använder mig av en stack

            Console.WriteLine("Input a string and I'll determine whether it's well-formed or not");
            string input = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(') stack.Push(c);
                else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
                {
                    Console.WriteLine("The string is not well-formed.");
                    return;
                }
            }

            Console.WriteLine(stack.Count == 0 ? "The string is well-formed." : "The string is not well-formed.");
        }

    }
}

