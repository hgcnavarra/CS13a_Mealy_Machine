using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("\nEnter input (/ * h only) or type 'exit': ");
            string input = Console.ReadLine();

            // Stop the program
            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Program ended.");
                break;
            }

            string state = "q0";
            int output = 0;

            Console.WriteLine("\nProcessing:");
            Console.WriteLine("Start State: q0\n");

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                // q0
                if (state == "q0")
                {
                    if (symbol == '/')
                    {
                        state = "q1";
                        output = 0;
                    }
                    else
                    {
                        state = "qtrap";
                        output = 0;
                    }
                }

                // q1
                else if (state == "q1")
                {
                    if (symbol == '*')
                    {
                        state = "q2";
                        output = 0;
                    }
                    else
                    {
                        state = "qtrap";
                        output = 0;
                    }
                }

                // q2
                else if (state == "q2")
                {
                    if (symbol == 'h')
                    {
                        state = "q5";
                        output = 0;
                    }
                    else if (symbol == '*')
                    {
                        state = "q3";
                        output = 0;
                    }
                    else if (symbol == '/')
                    {
                        state = "q2";
                        output = 0;
                    }
                    else
                    {
                        state = "qtrap";
                        output = 0;
                    }
                }

                // q3
                else if (state == "q3")
                {
                    if (symbol == 'h')
                    {
                        state = "q5";
                        output = 0;
                    }
                    else if (symbol == '*')
                    {
                        state = "q3";
                        output = 0;
                    }
                    else if (symbol == '/')
                    {
                        state = "q4";
                        output = 1;
                    }
                    else
                    {
                        state = "qtrap";
                        output = 0;
                    }
                }

                // q4
                else if (state == "q4")
                {
                    state = "qtrap";
                    output = 0;
                }

                // q5
                else if (state == "q5")
                {
                    if (symbol == 'h')
                    {
                        state = "q2";
                        output = 0;
                    }
                    else if (symbol == '*')
                    {
                        state = "q3";
                        output = 0;
                    }
                    else if (symbol == '/')
                    {
                        state = "q5";
                        output = 0;
                    }
                    else
                    {
                        state = "qtrap";
                        output = 0;
                    }
                }

                // qtrap
                else if (state == "qtrap")
                {
                    state = "qtrap";
                    output = 0;
                }

                Console.WriteLine(
                    $"Read '{symbol}' -> State: {state}, Output: {output}"
                );
            }

            Console.WriteLine("\nFinal State: " + state);

            if (state == "q4" && output == 1)
            {
                Console.WriteLine("Result: ACCEPTED");
            }
            else
            {
                Console.WriteLine("Result: REJECTED");
            }
        }
    }
}
