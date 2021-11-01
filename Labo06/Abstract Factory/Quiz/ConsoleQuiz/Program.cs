using Quiz.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizFactoryProvider provider = new QuizFactoryProvider(vraagType());

            IQuizFactory factory = provider[vraagCategory(provider)];

            IQuiz quiz = new Quiz.Pattern.Quiz(factory);
            String antwoord = NextVraag(quiz); ;
            while (!antwoord.Equals("STOP"))
            {
                if (quiz.Check(antwoord))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct !");
                    if (quiz.Level != null)
                        Console.WriteLine("Level=" + quiz.Level.Beschrijving);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Verkeerd !!");
                }
                Console.ResetColor();
                Console.WriteLine("Huidige score: " + quiz.Score);
                Console.WriteLine("Next Level: " + (quiz.NextLevel.Grens - quiz.Score) + " punten");
                Console.WriteLine();
                antwoord = NextVraag(quiz);
            }
            // Console.ReadKey();
        }

        private static string NextVraag(IQuiz quiz)
        {
            Console.WriteLine(quiz.Vraag.Opgave);
            foreach (string antw in quiz.Vraag.Antwoorden)
            {
                Console.WriteLine(antw);
            }
            Console.Write("Jouw antwoord (STOP to exit): ");
            return Console.ReadLine();
        }

        private static ICategory vraagCategory(QuizFactoryProvider provider)
        {
            Console.WriteLine("Kies categorie:");
            foreach (ICategory cat in provider.Categories)
            {
                Console.WriteLine("\t" + cat.Id + ": " + cat.Description);
            }

            int catnr = 0;
            while (catnr < 1 || catnr > provider.Categories.Count)
            {
                Console.Out.Write("Create quiz for which category? [1-" + provider.Categories.Count + "]: ");
                string select = Console.In.ReadLine();
                try
                {
                    catnr = int.Parse(select);
                }
                catch
                {
                    Console.Out.WriteLine("Please enter a valid number!");
                }
            }
            return provider.Categories[catnr - 1];

        }

        private static string vraagType()
        {
            Console.Out.Write("Create quiz from " + String.Join(" or ", QuizFactoryProvider.inputTypes) + ": ");
            string inputType = Console.In.ReadLine().ToLower();
            while (!QuizFactoryProvider.inputTypes.Contains(inputType))
            {
                Console.Out.Write("Invalid option! Please answer with " + String.Join(" or ", QuizFactoryProvider.inputTypes) + ": ");
                inputType = Console.In.ReadLine().ToLower();
            }
            return inputType;
        }
    }
}
