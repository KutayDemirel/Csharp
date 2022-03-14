using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Uygulama
{
    internal class Program
    {
        static string username;
        static int firstNumber;
        static int secondNumber;
        static int totalPoint = 0;
        static int highPoint = 0;
        static int wrong = 5;
        static int randomOpe;
        static int correctAnswer;
        static int userAnswer = 0;
        static string valueCheck;
        static bool exit = false;
        static string[,] pointCatch;
        static List<string> arrList = new List<string>();
        static Random random = new Random();

        static void Main(string[] args)
        {
            GameRun();
            Console.ReadKey();
        }

        static void GameRun()
        {
            Console.WriteLine("Welcome to the Math Exercise\nWhat is your username ?\n---------------------------------");
            username = Console.ReadLine();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("This is First Stage");
            Console.WriteLine("There will be only addition,subtraction");
            Console.WriteLine("---------------------------------------");
            while (totalPoint < 30 && wrong != 0 && !exit)
            {
                StageOne();
                ValidAnswer();
                if (exit)
                {
                    break;
                }
                AnswerCheck(5);
            }

            if (totalPoint == 30)
            {
                Console.WriteLine("================================================================");
                Console.WriteLine("Congratulations!!!");
                Console.WriteLine("Welcome to the Second Stage");
                Console.WriteLine("There will be only addition,subtraction,multiplication,division");
                Console.WriteLine("================================================================");
            }
            while (totalPoint < 80 && wrong != 0 && !exit)
            {
                StageTwo();
                ValidAnswer();
                if (exit)
                {
                    break;
                }
                AnswerCheck(10);
            }

            if (totalPoint == 80)
            {
                Console.WriteLine("================================================================");
                Console.WriteLine("Congratulations!!!");
                Console.WriteLine("Welcome to the Last Stage");
                Console.WriteLine("There will be only addition,subtraction,multiplication,division and modulo");
                Console.WriteLine("================================================================");
            }
            while (wrong != 0 && !exit)
            {
                StageThree();
                ValidAnswer();
                if (exit)
                {
                    break;
                }
                AnswerCheck(20);

            }

            if (wrong == 0)
            {
                Console.WriteLine("You have finished your life");
            }
            PrintPoint();
        }
        static void randomGenerator(int a)
        {
            firstNumber = random.Next(1, a);
            secondNumber = random.Next(1, a);
        }

        static void StageOne()
        {
            randomGenerator(100);
            randomOpe = random.Next(1, 100);
            if (randomOpe < 50)
            {
                Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber + secondNumber;

            }
            else
            {
                Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber - secondNumber;
            }
            //Console.WriteLine(correctAnswer);
        }

        static void StageTwo()
        {
            randomGenerator(1000);
            randomOpe = random.Next(0, 100);
            if (randomOpe <= 25)
            {
                Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber + secondNumber;

            }
            else if (randomOpe <= 50)
            {
                Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber - secondNumber;
            }
            else if (randomOpe <= 75)
            {
                Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber * secondNumber;
            }
            else
            {
                Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
                Console.WriteLine("! Write only Integer digit! \nWhat is your answer : ");
                correctAnswer = (int)(firstNumber / secondNumber);
            }
            //Console.WriteLine(correctAnswer);
        }

        static void StageThree()
        {
            randomGenerator(10000);
            randomOpe = random.Next(0, 100);
            if (randomOpe <= 20)
            {
                Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber + secondNumber;

            }
            else if (randomOpe <= 40)
            {
                Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber - secondNumber;
            }
            else if (randomOpe <= 60)
            {
                Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber * secondNumber;
            }
            else if (randomOpe <= 80)
            {
                Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
                Console.WriteLine("! Write only Integer digit! \nWhat is your answer : ");
                correctAnswer = (int)(firstNumber / secondNumber);
            }
            else
            {
                Console.WriteLine($"{firstNumber} mod {secondNumber} = ?");
                Console.WriteLine("What is your answer :");
                correctAnswer = firstNumber % secondNumber;
            }
            // Console.WriteLine(correctAnswer);
        }
        static void ValidAnswer()
        {
            valueCheck = Console.ReadLine().ToLower();
            if (valueCheck == "exit")
            {
                exit = true;
                Console.WriteLine("You have left too early");
                return;
            }
            while (!int.TryParse(valueCheck, out userAnswer))
            {
                Console.WriteLine("Wrong character choice try again");
                valueCheck = Console.ReadLine();
            }
        }
        static void AnswerCheck(int point)
        {
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("-------");
                Console.WriteLine("Correct");
                Console.WriteLine("-------");
                totalPoint += point;
            }
            else
            {
                Console.WriteLine("-------");
                Console.WriteLine("Wrong!!");
                Console.WriteLine("----------------------------");
                wrong--;
                Console.WriteLine("Your remaining attempts = " + wrong);
                Console.WriteLine("----------------------------");
            }
        }

        static void PrintPoint()
        {
            StreamWriter writer = new StreamWriter("Winner.txt", true);
            writer.WriteLine(username + " " + totalPoint);
            writer.Flush();
            writer.Close();

            Console.WriteLine("==========================");
            Console.WriteLine($"Your point : {totalPoint}");
            Console.WriteLine("==========================");

            // kullanıcının skor karşılaştırması
            PointsToList();
            pointCatch = ScoreCompare(arrList);
            //Şu ana kadar olan puanların yazdırılması
            WinnerList(pointCatch);

        }

        static void PointsToList()
        {
            StreamReader reader = new StreamReader("Winner.txt");


            string line = string.Empty;
            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    arrList.Add(line);

                }
            } while (line != null);
            reader.Close();
        }

        static string[,] ScoreCompare(List<string> arrList)
        {
            string[] arr;
            string[,] pointCatch = new string[arrList.Count, 2];

            for (int i = 0; i < arrList.Count; i++)
            {
                arr = arrList[i].Split(" ");
                pointCatch[i, 0] = arr[0];
                pointCatch[i, 1] = arr[1];
            }


            for (int i = 0; i < pointCatch.GetLength(0); i++)
            {

                if (pointCatch[i, 0] == username)
                {
                    if (int.Parse(pointCatch[i, 1]) > highPoint)
                    {
                        highPoint = int.Parse(pointCatch[i, 1]);
                    }
                }
            }
            if (highPoint == totalPoint)
            {
                Console.WriteLine("This is your highest score!!");
                Console.WriteLine("=============================");
            }
            else
            {
                Console.WriteLine("Your highest score :" + highPoint);
                Console.WriteLine("=================================");
            }

            return pointCatch;
        }


        static void WinnerList(string[,] pointCatch)
        {
            // Daha önceki sonuçların büyükten küçüğe sıralanması
            string temp1;
            string temp2;
            for (int i = 0; i < pointCatch.GetLength(0); i++)
            {
                for (int j = 0; j < pointCatch.GetLength(0) - 1; j++)
                {
                    if (int.Parse(pointCatch[j, 1]) < int.Parse(pointCatch[(j + 1), 1]))
                    {
                        temp1 = pointCatch[j, 0];
                        temp2 = pointCatch[j, 1];
                        pointCatch[j, 0] = pointCatch[(j + 1), 0];
                        pointCatch[j, 1] = pointCatch[(j + 1), 1];
                        pointCatch[(j + 1), 0] = temp1;
                        pointCatch[(j + 1), 1] = temp2;
                    }
                }
            }

            Console.WriteLine("----!!!Leader's List!!!----");
            for (int i = 0; i < 3; i++)
            {
                if (pointCatch.GetLength(0) >= i + 1) // daha önce 3 kez oynanmış mı kontrolü!
                {
                    if (int.Parse(pointCatch[i, 1]) == totalPoint && pointCatch[i, 0] == username)
                    {
                        Console.Write(i + 1 + ". Position " + pointCatch[i, 0] + " " + pointCatch[i, 1]);
                        Console.WriteLine("\t====> This is You !!");
                    }
                    else
                    {
                        Console.WriteLine(i + 1 + ". Position " + pointCatch[i, 0] + " " + pointCatch[i, 1]);
                    }
                }
            }
        }

    }
}
