using System;
using System.IO;
using System.Threading;
using Admin;

namespace Quiz  
{   
    public class User
    {
        private string[] fileOutput = new[] {"false"};


        public User(){}

        public User(string userName, string password, string dateOfBirth) 
        {
            string newFolder = Path.Combine(@"", "BasicFiles");
            Directory.CreateDirectory(newFolder);
            File.AppendAllText(@"BasicFiles\users.txt", userName + "-" + password + "-" + dateOfBirth + "\n");
        }


        private void geographyQuiz()
        {
            string file = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\result.txt");
            try
            {
                fileOutput = File.ReadAllLines(file);
                if (fileOutput.Length != 0)
                {
                    Random rd = new Random();
                    int count = rd.Next(fileOutput.Length);
                    fileOutput = fileOutput[count].Split('-');
                    
                    string filePath = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileOutput[1] + ".txt");
                    
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    this.startQuiz(filePath, username);
                }
                else
                {
                    fileOutput = File.ReadAllLines(@"nono.txt");
                }


            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("No test created");
                Thread.Sleep(2000);
                Console.Clear();
                Login();
            }
        }
        private void mathematicsQuiz()
        {
            string file = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Mathematics\result.txt");
            try
            {
                fileOutput = File.ReadAllLines(file);
                if (fileOutput.Length != 0)
                {
                    Random rd = new Random();
                    int count = rd.Next(fileOutput.Length);
                    fileOutput = fileOutput[count].Split('-');

                    string filePath = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Mathematics\" + fileOutput[1] + ".txt");

                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    this.startQuiz(filePath, username);
                }
                else
                {
                    fileOutput = File.ReadAllLines(@"nono.txt");
                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("No test created");
                Thread.Sleep(2000);
                Console.Clear();
                Login();
            }
        }
        private void historyQuiz()
        {
            string file = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\History\result.txt");
            try
            {
                fileOutput = File.ReadAllLines(file);
                if (fileOutput.Length != 0)
                {
                    Random rd = new Random();
                    int count = rd.Next(fileOutput.Length);
                    fileOutput = fileOutput[count].Split('-');

                    string filePath = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\History\" + fileOutput[1] + ".txt");

                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    this.startQuiz(filePath, username);
                }
                else
                {
                    fileOutput = File.ReadAllLines(@"nono.txt");
                }

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("No test created");
                Thread.Sleep(2000);
                Console.Clear();
                Login();
            }
        }
        private void startQuiz(string filePath, string userName)
        {
            try
            {
                fileOutput = File.ReadAllLines(filePath);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("No test created");
                Thread.Sleep(2000);
                Console.Clear();
                Login();
            }
            Console.ForegroundColor = ConsoleColor.White;
            double score = 0;
            double requestScore = 0;
            int temp2 = 0;
            for (int i = 0; i < fileOutput.Length; i++)
            {
                if (temp2 == 3)
                {
                    requestScore++;
                    temp2 = 0;
                }
                else if (fileOutput[i] != "")
                {
                    temp2++;
                }
            }
            
            requestScore = 100 / requestScore;
            
            Console.Clear();
            string request;
            string variant;
            for (int i = 0; i < fileOutput.Length; i++)
            {
                if (i < fileOutput.Length)
                {
                    Console.WriteLine(fileOutput[i]);
                    i++;
                }
                else { break;}
                if (i < fileOutput.Length)
                {
                    Console.WriteLine(fileOutput[i]);
                    i++;
                }
                else { break; }
                if (i < fileOutput.Length)
                {
                    request = fileOutput[i];
                    i += 2;
                }
                else { break; }
                Console.Write("Select variant: ");
                variant = Console.ReadLine();
                if (variant == request)
                {
                    Console.Clear();
                    score += requestScore;
                    Console.WriteLine("Correct variant. Score: " + score);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("no correct variant. Score: " + score);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            Console.Clear();
            Console.WriteLine("Your total score: " + score);
            Console.Clear();
            
            string file = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\");
            string newFolder = Path.Combine(file, "Users");
            Directory.CreateDirectory(newFolder);
            file += @"Users\" + userName + ".txt";

            try
            {
                fileOutput = File.ReadAllLines(file);
                var temp = fileOutput;
                fileOutput = temp[fileOutput.Length - 1].Split('-');
                int temp1 = Convert.ToInt32(fileOutput[0]);
                fileOutput = new string[temp.Length + 1];
                fileOutput = temp;
                fileOutput[temp.Length] = $"{temp1}-{score}";
                File.WriteAllLines(file, fileOutput);
            }
            catch (Exception)
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.Write($"{1}-{score}");
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Exit?(y/n): ");
            request = Console.ReadLine();
            if (request == "y" || request == "Y" || request == "Yes" || request == "yes")
            {
                Console.Clear();
                Login();
            }
            else
            {
                Console.Clear();
            }
        }
        private void startNewQuiz()
        {
            Console.Write("Select a section(Geography/Mathematics/History or Exit): ");
            string select = Console.ReadLine();

            switch (select)
            {
                case "Geography":
                    geographyQuiz();
                    break;
                case "Mathematics":
                    mathematicsQuiz();
                    break;
                case "History":
                    historyQuiz();
                    break;
                case "Exit":
                    Login();
                    break;
            }
        }
        private void settings()
        {
            fileOutput = File.ReadAllLines(@"BasicFiles\users.txt");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tSettings");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1) Edit UserName");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2) Edit Password");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3) Edit Date of birth");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("0) Exit");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Select: "); string select = Console.ReadLine();

            if (select == "1")
            {
                Console.Clear();
                Console.WriteLine("Try entering the correct UserName, otherwise you will be redirected to the Lobby.");
                Console.Write("Enter previous Username: ");
                string userName = Console.ReadLine();

                Console.Write("Enter new UserName: ");
                string newUserName = Console.ReadLine();

                string[] file;
                Boolean temp = false;
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    file = fileOutput[i].Split('-');
                    if (file[0] == userName)
                    {
                        fileOutput[i] = new string($"{newUserName}-{file[1]}-{file[2]}");
                        File.WriteAllLines(@"BasicFiles\users.txt", fileOutput);
                        Console.Clear();
                        Console.WriteLine($"The UserName has been changed to {newUserName}.");
                        Thread.Sleep(3000);
                        break;
                    }
                }
                if (temp == false)
                {
                    Console.Clear();
                    this.settings();
                }
            }
            else if (select == "2")
            {
                Console.Clear();
                Console.WriteLine("Try entering the correct Password, otherwise you will be redirected to the Lobby.");
                Console.Write("Enter previous Password: ");
                string password = Console.ReadLine();

                Console.Write("Enter new Password: ");
                string newPassword = Console.ReadLine();

                string[] file;
                Boolean temp = false;
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    file = fileOutput[i].Split('-');
                    if (file[1] == password)
                    {
                        fileOutput[i] = new string($"{file[0]}-{newPassword}-{file[2]}");
                        File.WriteAllLines(@"BasicFiles\users.txt", fileOutput);
                        Console.Clear();
                        Console.WriteLine($"The Password has been changed to {newPassword}.");
                        Thread.Sleep(3000);
                        break;
                    }
                }
                if (temp == false)
                {
                    Console.Clear();
                    this.settings();
                }
            }
            else if (select == "3")
            {
                Console.Clear();
                Console.WriteLine("Try entering the correct Date of birth, otherwise you will be redirected to the Lobby.");
                Console.Write("Enter previous Date of birth: ");
                string dateOfBirth = Console.ReadLine();

                Console.Write("Enter new Date of birth: ");
                string newDateOfBirth = Console.ReadLine();

                string[] file;
                Boolean temp = false;
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    file = fileOutput[i].Split('-');
                    if (file[2] == dateOfBirth)
                    {
                        fileOutput[i] = new string($"{file[0]}-{file[1]}-{newDateOfBirth}");
                        File.WriteAllLines(@"BasicFiles\users.txt", fileOutput);
                        Console.Clear();
                        Console.WriteLine($"The Date of birth has been changed to {newDateOfBirth}.");
                        Thread.Sleep(3000);
                        break;
                    }
                }
                if (temp == false)
                {
                    Console.Clear();
                    this.settings();
                }
            }
            else if (select == "0")
            {
                Console.Clear();
                Login();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not choose correctly. :(");
                Thread.Sleep(2000);
                this.settings();
            }
        }
        private void testsScore()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();

            string[] fileOutput = new[] { "false" };
            string filePath = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Users\" + userName + ".txt");
            Boolean temp = false;

            try
            {
                fileOutput = File.ReadAllLines(filePath);
                temp = true;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have not passed any test");
            }

            if (temp == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    Console.WriteLine(fileOutput[i]);
                }

                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ReadKey();
            Console.Clear();

            Console.Write("Exit?(y/n)");
            string select1 = Console.ReadLine();

            if (select1 == "y" || select1 == "Y" || select1 == "yes" || select1 == "Yes")
            {
                Console.Clear();
                Login();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
        }


        public void Login() 
        { 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tLobby");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1) Start a new quiz");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2) View the results of her previous quizzes");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3) Change settings. Edit password and date of birth");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("4) Log out");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Select: ");
            string select = Console.ReadLine();


            switch (select)
            {
                case "1":
                    Console.Clear();
                    this.startNewQuiz();
                    break;
                case "2":
                    Console.Clear();
                    this.testsScore();
                    break;
                case "3":
                    Console.Clear();
                    this.settings();
                    break;
                case "4":
                    Console.Clear();
                    Program.Main();
                    break;
            }
        }
        public static string[] fileRead(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }  
} 