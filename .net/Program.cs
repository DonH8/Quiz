using System;
namespace Quiz
{
    public class Program
    {
        private Questions[] questions;
        static int totalTimeInSeconds = 10;
        private Options[] options;
        static int countCorrect = 0;
        public Program(Questions[] questions, Options[] options)
        {
            this.questions = questions;
            this.options = options;
        }
        public void Quizi()
        {
            int countf = 0;
            int countv = 0;
            bool[] isQuestionPrinted = new bool[questions.Length];
            Task timerTask = Task.Run(() => StartTimer());
            for (int i = 0; i < questions.Length; i++)
            {
                if (!isQuestionPrinted[i])
                {
                    Console.WriteLine(questions[i].getQuestion() + "\n" + options[i].writeOptions() + "\n" + questions[i].getHint()+"\n");
                    isQuestionPrinted[i] = true;
                }

                string answer = Console.ReadLine();
                if (answer != "A" && answer != "B" && answer != "C" && answer != "D" && answer != "fiftyfifty" && answer != "publiku" && answer != "exit")
                {
                    Console.WriteLine("\n" + "Input invalid mund te shenoni vetem :A , B, C, D, fiftyfifty, publiku, exit" + "\n");
                    isQuestionPrinted[i] = !isQuestionPrinted[i];
                    i--;
                }
                else if (answer == "exit")
                {
                    Environment.Exit(0);
                    Console.WriteLine("Numri i pergjigjjeve te sakta " + countCorrect);
                }
                else if (answer == "fiftyfifty" && countf == 0)
                {
                    fifty(questions[i], options[i]);
                    countf++;
                    i--;
                }
                else if (answer == "fiftyfifty" && countf > 0)
                {
                    Console.WriteLine("\n"+"Nuk e keni me opcionin 50/50"+"\n");
                    isQuestionPrinted[i] = !isQuestionPrinted[i];
                    i--;
                }
                else if (answer == "publiku" && countv == 0)
                {
                    Vote(questions[i], options[i]);
                    countv++;
                    i--;
                }
                else if (answer == "publiku" && countv > 0)
                {
                    Console.WriteLine("\n"+"Nuk e keni me opcionin e publikut" +"\n");
                    isQuestionPrinted[i] = !isQuestionPrinted[i];
                    i--;
                    
                }

                else if (string.Equals(answer, questions[i].getCorrectAnswer()))
                {
                    countCorrect++;
                    Console.WriteLine("\n" + "Pergjigjja e sakte" + "\n");
                }
                else { Console.WriteLine("\n" + "Pergjigjja jo e sakte" + "\n"); }

            }
            timerTask.Wait();
        }
        static async void StartTimer()
        {
            await Task.Delay(totalTimeInSeconds * 1000); // Convert seconds to milliseconds

            Console.WriteLine("\n"+"Koha juaj ka mbaruar."+"\n"+"Numri i pergjigjjeve te sakta: " + countCorrect);
            Thread.Sleep(2000);
            Environment.Exit(0);
        }

    public void fifty(Questions questions, Options options)
        {
            Random r = new Random();
            int rInt = r.Next(1, 4);
            if (questions.getCorrectAnswer() == "A")
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n"+"50/50 ka shfaqur:" +"\n"+ options.getOptionA() + " " + options.getOptionB()+"\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + options.getOptionC() + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + "     " + options.getOptionD() + "\n");
                }
            }
            else if (questions.getCorrectAnswer() == "B")
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + " " + options.getOptionB() + "\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + options.getOptionC() + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + "     " + options.getOptionD() + "\n");
                }
            }
            else if (questions.getCorrectAnswer() == "C")
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + options.getOptionC() + "\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + options.getOptionC() + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionC() + " " + options.getOptionD() + "\n");
                }
            }
            else
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionA() + "\n" + "     " + options.getOptionD() + "\n");

                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + "     " + options.getOptionB() + "\n" + "     " + options.getOptionD() + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "50/50 ka shfaqur:" + "\n" + options.getOptionC() + " " + options.getOptionD() + "\n");
                }

            }
        }
        public void Vote(Questions questions, Options options)

        {
            Random r = new Random();
            int correct = r.Next(50, 91);
            int wrong1 = r.Next(0, 100 - correct);
            int wrong2 = r.Next(0, 100 - correct - wrong1);
            int wrong3 = 100 - correct - wrong1 - wrong2;
            int rInt = r.Next(1, 4);
            if (questions.getCorrectAnswer() == "A")
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + correct + "%" + " B: " + wrong1 + "%" + "\n" + "C: " + wrong2 + "%" + " D: " + wrong3 + "%" + "\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + correct + "%" + " B: " + wrong3 + "%" + "\n" + "C: " + wrong1 + "%" + " D: " + wrong2 + "%" + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + correct + "%" + " B: " + wrong2 + "%" + "\n" + "C: " + wrong3 + "%" + " D: " + wrong1 + "%" + "\n");
                }
            }
            else if (questions.getCorrectAnswer() == "B")
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong1 + "%" + " B: " + correct + "%" + "\n" + "C: " + wrong2 + "%" + " D: " + wrong3 + "%" + "\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong3 + "%" + " B: " + correct + "%" + "\n" + "C: " + wrong1 + "%" + " D: " + wrong2 + "%" + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong2 + "%" + " B: " + correct + "%" + "\n" + "C: " + wrong3 + "%" + " D: " + wrong1 + "%" + "\n");
                }
            }
            else if (questions.getCorrectAnswer() == "C")
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong1 + "%" + " B: " + wrong2 + "%" + "\n" + "C: " + correct + "%" + " D: " + wrong3 + "%" + "\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong2 + "%" + " B: " + wrong3 + "%" + "\n" + "C: " + correct + "%" + " D: " + wrong1 + "%" + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong3 + "%" + " B: " + wrong1 + "%" + "\n" + "C: " + correct + "%" + " D: " + wrong2 + "%" + "\n");
                }
            }
            else
            {
                if (rInt == 1)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong2 + "%" + " B: " + wrong1 + "%" + "\n" + "C: " + wrong3 + "%" + " D: " + correct + "%" + "\n");
                }
                else if (rInt == 2)
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong1 + "%" + " B: " + wrong3 + "%" + "\n" + "C: " + wrong2 + "%" + " D: " + correct + "%" + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "Votat e publikut jane: " + "\n" + "A: " + wrong3 + "%" + " B: " + wrong2 + "%" + "\n" + "C: " + wrong1 + "%" + " D: " + correct + "%" + "\n");
                }

            }
        }
        public static void Main(string[] args)
        {
            Options[] optionsquizi1 = new Options[] { new Options("A:Don", "B:Don", "C:Don", "D:Don"), new Options("A:Don1", "B:Don1", "C:Don1", "D:Don1"), new Options("A:Don2", "B:Don2", "C:Don2", "D:Don2"), new Options("A:Don3", "B:Don3", "C:Don3", "D:Don3") };
            Questions[] questionquizi1 = new Questions[] { new Questions("Test 1", optionsquizi1[0], "E sakte nen C", "C"), new Questions("Test 2", optionsquizi1[1], "E sakte nen D", "D"), new Questions("Test 3", optionsquizi1[2], "E sakte nen B", "B"), new Questions("Test 4", optionsquizi1[3], "E sakte nen A", "A") };
            Program kuizi = new Program(questionquizi1, optionsquizi1);
            kuizi.Quizi();
        }
    }
}