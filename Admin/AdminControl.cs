using System;
using System.IO;
using System.Threading;

namespace Admin
{
    public static class AdminControl
    {
        private static void NewTestII(string filePath, string fileName, string select)
        {
            string[] questionVariant = new string[3];
            Console.Write("Enter Question: ");
            questionVariant[0] = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter Variants(A) 1,2  B) 3,4 ...): ");
            questionVariant[1] = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter correct variant: ");
            questionVariant[2] = Console.ReadLine();
            Console.Clear();

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < questionVariant.Length; i++)
                {
                    sw.WriteLine(questionVariant[i]);
                }
                sw.Write("\n\n");
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A new test file has been created");
            Thread.Sleep(2000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            string file = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\");
            if (select == "Geography" || select == "geography")
            {
                file += @"Geography\result.txt";
                string[] fileOut = new[] {"false"};

                try
                {
                    fileOut = File.ReadAllLines(file);
                    var temp = fileOut;
                    fileOut = temp[fileOut.Length - 1].Split('-');
                    int temp1 = Convert.ToInt32(fileOut[0]);
                    temp1++;
                    fileOut = new string[temp.Length + 1];
                    fileOut = temp;
                    fileOut[temp.Length] = $"{temp1}-{fileName}\n";
                    File.WriteAllLines(file, fileOut);
                }
                catch (Exception)
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    { 
                        sw.Write($"{1}-{fileName}\n");
                    }
                }
            }
            else if (select == "Mathematics" || select == "mathematics")
            {
                file += @"Mathematics\result.txt";
                string[] fileOut = new[] { "false" };

                try
                {
                    fileOut = File.ReadAllLines(file);
                    var temp = fileOut;
                    fileOut = temp[fileOut.Length - 1].Split('-');
                    int temp1 = Convert.ToInt32(fileOut[0]);
                    temp1++;
                    fileOut = new string[temp.Length + 1];
                    fileOut = temp;
                    fileOut[temp.Length] = $"{temp1}-{fileName}\n";
                    File.WriteAllLines(file, fileOut);
                }
                catch (Exception)
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        sw.Write($"{1}-{fileName}\n");
                    }
                }
            }
            else if (select == "History" || select == "History")
            {
                file += @"History\result.txt";
                string[] fileOut = new[] { "false" };

                try
                {
                    fileOut = File.ReadAllLines(file);
                    var temp = fileOut;
                    fileOut = temp[fileOut.Length - 1].Split('-');
                    int temp1 = Convert.ToInt32(fileOut[0]);
                    temp1++;
                    fileOut = new string[temp.Length + 1];
                    fileOut = temp;
                    fileOut[temp.Length] = $"{temp1}-{fileName}\n";
                    File.WriteAllLines(file, fileOut);
                }
                catch (Exception)
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        sw.Write($"{1}-{fileName}\n");
                    }
                }
            }
            Program.Main();
        }

        private static void TestAddQuesionII(string filePath, string fileName, string select)
        {
            string[] questionVariant = new string[3];
            Console.Write("Enter Question: ");
            questionVariant[0] = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter Variants(A) 1,2  B) 3,4 ...): ");
            questionVariant[1] = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter correct variant: ");
            questionVariant[2] = Console.ReadLine();
            Console.Clear();

            using (var file = File.AppendText(filePath))
            {
                for (int i = 0; i < questionVariant.Length; i++)
                {
                    file.WriteLine(questionVariant[i]);
                }
                file.Write("\n\n");
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Add Quesion");
            Thread.Sleep(2000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Program.Main();
        }

        private static void TestDeleteQuesionII(string filePath, string fileName, string select)
        {
            string[] questionVariant = new string[3];
            Console.Write("Enter Question: ");
            questionVariant[0] = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter Variants(A) 1,2  B) 3,4 ...): ");
            questionVariant[1] = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter correct variant: ");
            questionVariant[2] = Console.ReadLine();
            Console.Clear();

            var fileOutput = File.ReadAllLines(filePath);
            string[] deleteLines = new string[fileOutput.Length - 3];

            for (int i = 0, j = 0; i < fileOutput.Length - 3; i++)
            {
                if (fileOutput[i] != questionVariant[0] && fileOutput[i + 1] != questionVariant[1] && fileOutput[i + 2] != questionVariant[2] && fileOutput[i + 2] != "\n")
                {
                    deleteLines[j] = fileOutput[i];
                    j++;
                }
            }
            File.WriteAllLines(filePath, deleteLines);
            File.AppendAllText(filePath,"\n");
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Quesion deleted");
            Thread.Sleep(2000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Program.Main();
        }

        private static void DeleteTestII(string filePath, string fileName, string select)
        {
            File.Delete(filePath);
            string file = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop");
            if (select == "Geography" || select == "geography")
            {
                file += @"Geography\result.txt";
                string[] fileOut = new[] { "false" };

                try
                {
                    fileOut = File.ReadAllLines(file);
                    string[] temp = new[] {"false"};
                    string[] temp1 = new[] {"false"};

                    for (int i = 0, j = 0; i < fileOut.Length; i++)
                    {
                        temp = fileOut[i].Split('-');
                        if (temp[1] != fileName)
                        {
                            temp1[j] = fileOut[i];
                            j++;
                        }
                    }
                    File.WriteAllLines(file, temp1);
                }
                catch (Exception)
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        string s = $"{1}-{fileName}\n";
                        sw.Write(s);
                    }
                }
            }
            else if (select == "Mathematics" || select == "mathematics")
            {
                file += @"Mathematics\result.txt";
                string[] fileOut = new[] { "false" };

                try
                {
                    fileOut = File.ReadAllLines(file);
                    string[] temp = new[] { "false" };
                    string[] temp1 = new[] { "false" };

                    for (int i = 0, j = 0; i < fileOut.Length; i++)
                    {
                        temp = fileOut[i].Split('-');
                        if (temp[1] != fileName)
                        {
                            temp1[j] = fileOut[i];
                            j++;
                        }
                    }
                    File.WriteAllLines(file, temp1);
                }
                catch (Exception)
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        string s = $"{1}-{fileName}\n";
                        sw.Write(s);
                    }
                }
            }
            else if (select == "History" || select == "History")
            {
                file += @"History\result.txt";

                string[] fileOut = new[] { "false" };

                try
                {
                    fileOut = File.ReadAllLines(file);
                    string[] temp = new[] { "false" };
                    string[] temp1 = new[] { "false" };

                    for (int i = 0, j = 0; i < fileOut.Length; i++)
                    {
                        temp = fileOut[i].Split('-');
                        if (temp[1] != fileName)
                        {
                            temp1[j] = fileOut[i];
                            j++;
                        }
                    }
                    File.WriteAllLines(file, temp1);
                }
                catch (Exception)
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        string s = $"{1}-{fileName}\n";
                        sw.Write(s);
                    }
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test deleted");
            Thread.Sleep(2000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Program.Main();
        }

        public static void NewTest()
        {
            Console.Clear();
            Console.Write("Which division will write the test?(Geography,Mathematics,History or Exit): ");
            string select = Console.ReadLine();
            if (select == "Geography" || select == "geography")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Geography");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileName + ".txt";
                Console.Clear();

                NewTestII(filePath, fileName, select);
            }
            else if (select == "Mathematics" || select == "mathematics")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Mathematics");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Mathematics\" + fileName + ".txt";
                Console.Clear();

                NewTestII(filePath,fileName, select);
                
            }
            else if (select == "History" || select == "history")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "History");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\History\" + fileName + ".txt";
                Console.Clear();

                NewTestII(filePath, fileName, select);
            }
            else if (select == "Exit" || select == "exit" || select == "esc") { Program.Main(); }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not make the right choices are being asked to make the right choice.");
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                NewTest();
            }
        }

        public static void TestAddQuesion()
        {
            Console.Clear();
            Console.Write("Which division will write the test?(Geography,Mathematics,History or Exit): ");
            string select = Console.ReadLine();
            if (select == "Geography" || select == "geography")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Geography");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileName + ".txt";
                Console.Clear();

                TestAddQuesionII(filePath, fileName, select);
            }
            else if (select == "Mathematics" || select == "mathematics")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Mathematics");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Mathematics\" + fileName + ".txt";
                Console.Clear();

                TestAddQuesionII(filePath, fileName, select);

            }
            else if (select == "History" || select == "history")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "History");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\History\" + fileName + ".txt";
                Console.Clear();

                TestAddQuesionII(filePath, fileName, select);
            }
            else if (select == "Exit" || select == "exit" || select == "esc") { Program.Main(); }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not make the right choices are being asked to make the right choice.");
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                TestAddQuesion();
            }
        }

        public static void TestDeleteQuesion()
        {
            Console.Clear();
            Console.Write("Which division will write the test?(Geography,Mathematics,History or Exit): ");
            string select = Console.ReadLine();
            if (select == "Geography" || select == "geography")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Geography");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileName + ".txt";
                Console.Clear();

                TestDeleteQuesionII(filePath, fileName, select);
            }
            else if (select == "Mathematics" || select == "mathematics")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Mathematics");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Mathematics\" + fileName + ".txt";
                Console.Clear();

                TestDeleteQuesionII(filePath, fileName, select);

            }
            else if (select == "History" || select == "history")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "History");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\History\" + fileName + ".txt";
                Console.Clear();

                TestDeleteQuesionII(filePath, fileName, select);
            }
            else if (select == "Exit" || select == "exit" || select == "esc") { Program.Main(); }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not make the right choices are being asked to make the right choice.");
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                TestDeleteQuesion();
            }
        }

        public static void DeleteTest()
        {
            Console.Clear();
            Console.Write("Which division will write the test?(Geography,Mathematics,History or Exit): ");
            string select = Console.ReadLine();
            if (select == "Geography" || select == "geography")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Geography");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileName + ".txt";
                Console.Clear();

                DeleteTestII(filePath,fileName, select);
            }
            else if (select == "Mathematics" || select == "mathematics")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Geography");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileName + ".txt";
                Console.Clear();

                DeleteTestII(filePath, fileName, select);
            }
            else if (select == "History" || select == "history")
            {
                Console.Clear();

                Console.WriteLine("Please do not have the same names for the mini-tests, otherwise you will agree with the problem");
                Console.Write("Test Name: ");
                string fileName = Console.ReadLine();

                string newFolder = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop", "Geography");
                Directory.CreateDirectory(newFolder);

                string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Desktop\Geography\" + fileName + ".txt";
                Console.Clear();

                DeleteTestII(filePath, fileName, select);
            }
            else if (select == "Exit" || select == "exit" || select == "esc") { Program.Main(); }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You did not make the right choices are being asked to make the right choice.");
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                DeleteTest();
            }
        }
    }
}
