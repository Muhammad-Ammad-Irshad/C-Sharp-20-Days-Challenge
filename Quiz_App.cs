using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
    internal class Quiz_App
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            quiz.LoadQuestions();
            quiz.Start();
        }
    }
    class Question
    {
        public string Text { get; set; }
        public List<string> options { get; set; }
        public char Answer {  get; set; }
        public void Display()
        {
            Console.WriteLine(Text);
            foreach(string option in options)
            {
                Console.WriteLine(option);
            }
        }
        public bool IsCorrect(char userAnswer)
        {
            return char.ToUpper(userAnswer) == Answer;
        }
    }
    class Quiz
    {
        private List<Question> questions = new List<Question>();
        private int score = 0;
        public void LoadQuestions()
        {
            questions.Add(new Question
            {
                Text = "What is the Capital of France?",
                options = new List<string>() { "A. Berlin", "B. Madrid", "C. Paris", "D. Rome" },
                Answer = 'C'
            });
            questions.Add(new Question
            {
                Text = "Which Planet is known as the Red Planet?",
                options = new List<string> { "A. Earth", "B. Mars", "C. Jupiter", "D. Venus"},
                Answer = 'B'
            });
            questions.Add(new Question
            {
                Text = "Who wrote Hamlet?",
                options = new List<string> { "A. Charles Dickens", "B. Mark Twain", "C. William Shakespeare", "D. Leo Tolstoy" },
                Answer = 'C'
            });
            questions.Add(new Question
            {
                Text = "Which Programming language is used for android app development?",
                options = new List<string> { "A. Swift", "B. Kotlin", "C. Python", "D. Ruby" },
                Answer = 'B'
            });
            questions.Add(new Question
            {
                Text = "Who painted Mona Lisa?",
                options = new List<string> { "A. Vincent van gogh", "B. Pablo Picasso", "C. Leonardo da vinci", "D. Claude Monet" },
                Answer = 'C'
            });
            questions.Add(new Question
            {
                Text = "What is the largest animal on Earth?",
                options = new List<string> { "A. Elephant", "B. Whale Shark", "C. Blue Whale", "D. Giraffe" },
                Answer = 'C'
            });
            questions.Add(new Question
            {
                Text = "Which Country hosted the FIFA World Cup 2022?",
                options = new List<string> { "A. Russia", "B. Brazil", "C. America", "D. Qatar" },
                Answer = 'D'
            });
            questions.Add(new Question
            {
                Text = "Who is the Greatest Footballer of all time?",
                options = new List<string> { "A. Lionel Messi", "B. Neymar Jr", "C. Cristiano Ronaldo", "D. Benzema-aaaa-aaa" },
                Answer = 'C'
            });
            questions.Add(new Question
            {
                Text = "Who Won the Ballon'dor 2022?",
                options = new List<string> { "A. Lionel Messi", "B. Mbappe", "C. Benzemaa-aaa-aaaaaa", "D. Lewandowski" },
                Answer = 'C'
            });
            questions.Add(new Question
            {
                Text = "Who is the Ninja Turtle?",
                options = new List<string> { "A. Kylian Mbappe", "B. Erling Haaland", "C. Rodrigo", "D. Phil Foden" },
                Answer = 'A'
            });
            ShuffleQuestions();
        }
        private void ShuffleQuestions()
        {
            Random rnd = new Random();
            for (int i = 0; i < questions.Count; i++)
            {
                int j = rnd.Next(i, questions.Count);
                var temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }
        }
        public void Start()
        {
            foreach (var question in questions)
            {
                question.Display();
                Console.Write("Choose your answer(A/B/C/D): ");
                char userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (question.IsCorrect(userInput))
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! Correct Answer: {question.Answer}\n");
                }
            }
            ShowFinalScore();
        }
        private void ShowFinalScore()
        {
            Console.WriteLine($"\nQuiz Finished! Your Score: {score}/{questions.Count}");
            if(score == questions.Count)
            {
                Console.WriteLine("Excellent");
            }
            else if(score >= questions.Count)
            {
                Console.WriteLine("Good Job!");
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }
        }
    }
}
