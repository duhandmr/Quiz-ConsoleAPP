using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Quiz_APP
{

    class Question
    {
        public Question(string text, string[] choices, string answer)
        {
            this.Text = text;
            this.Choices = choices;
            this.Answer = answer;
        }

        public string Text { get; set; }
        public string[] Choices { get; set; }
        public string Answer { get; set; }

        public bool checkAnswer(string answer)
        {
            return this.Answer.ToLower() == answer.ToLower();
        }
    }

    class Quiz
    {
        public Quiz(Question[] questions)
        {
            this.Questions = questions;
            this.QuestionIndex = 0;
        }
        private Question[] Questions { get; set; }

        public int QuestionIndex { get; set; }

        public Question GetQuestion()
        {
            return this.Questions[this.QuestionIndex];
        }

        public void DisplayQuestion()
        {
            var question = this.GetQuestion();
            Console.WriteLine($"{this.QuestionIndex + 1}.Soru {question.Text}");

            foreach (var c in question.Choices)
            {
                Console.WriteLine($"-{c}");
            }
            Console.Write("Cevabınız: ");
            var result = Console.ReadLine();
            this.Guess(result);
        }

        public void Guess(string answer)
        {
            var question = this.GetQuestion();
            Console.WriteLine(question.checkAnswer(answer));
            this.QuestionIndex++;

            if (this.Questions.Length == this.QuestionIndex)
            {
                this.CalculateScore();
            }
            else
            {
                this.DisplayQuestion();
            }
        }

        public int CalculateScore()
        {
            int questionCount = this.Questions.Length;

            if (questionCount == 0)
            {
                Console.WriteLine("No questions available. Score: 0");
                return 0;
            }

            int questionScore = 100 / questionCount;
            int score = 0;

            foreach (var q in Questions)
            {
                if (q != null)
                {
                    score += questionScore;
                }
            }

            Console.WriteLine("Total Score: " + score);
            return score;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            var q1 = new Question("Türkiye'nin başkenti hangisidir ?", new string[] { "Ankara", "İstanbul", "İzmir", "Antalya" }, "Ankara");
            var q2 = new Question("Galatasaray kaç yılında kurulmuştur ?", new string[] { "1905", "1901", "1902", "1909" }, "190");
            var q3 = new Question("En iyi programlama dili hangisidir ?", new string[] { "C#", "Java", "C++", "JavaScript" }, "C#");
            var q4 = new Question("En popüler programlama dili hangisidir ?", new string[] { "C#", "Java", "C++", "JavaScript" }, "JavaScript");

            var questions = new Question[] { q1, q2, q3, q4 };
            var quiz = new Quiz(questions);

            quiz.DisplayQuestion();

            Console.ReadLine();

        }
    }
}
