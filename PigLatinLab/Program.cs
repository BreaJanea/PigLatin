using System;
using System.Text.RegularExpressions;


namespace PigLatinLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to the Pig Latin Translator!!!");

            do
            {
                Console.Write("Enter a line to be translated: ");
                string pigLatinWord = Console.ReadLine();

                Console.WriteLine($"{pigLatinWord}");

               
            } while (UserContiue());
        }

        static string PigLatin(string input)
        {
            string pigLatinWord = null;

            if (Regex.IsMatch(input, @"^[a-zA-Z']+$"))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string c = input[i].ToString();

                    if ("aeiouAEIOU".Contains(c))
                    {
                        if (input.IndexOf(c) == 0)
                        {
                            pigLatinWord = input + "way";
                            break;
                        }

                        else
                        {
                            pigLatinWord = input.Substring(input.IndexOf(c)) + input.Substring(0, input.IndexOf(c)) + "ay";
                            break;
                        }

                    }
                    else
                    {
                        pigLatinWord = input;
                    }
                }
            }
            else
            {
                int specialCharIndex;
                string specialcharacterend = @"\|!#$%&/()=?»«@£§€{}.-;<>_,";
                foreach (var item in specialcharacterend)
                {
                    if (input.Contains(item) && (input.IndexOf(item) == (input.Length - 1)))
                    {
                        specialCharIndex = input.IndexOf(item);
                        specialcharacterend = input.Substring(0, specialCharIndex);

                        pigLatinWord = PigLatin(pigLatinWord) + input.Substring(specialCharIndex);
                    }

                    else if (input.Contains(item))
                    {
                        pigLatinWord = input;
                    }
                }

            }
            return pigLatinWord;
        }


        public static bool UserContiue()
        {
            char c;
            do
            {
                Console.Write("\nContinue? (y/n)?\n");
                c = Console.ReadKey().KeyChar;
                if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("\nSee ya!");
                    return false;
                }
            } while (c != 'y' && c != 'Y');
            return true;
        }

    }
}
