using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1;

namespace CarManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            CDList cdList = new CDList();
            CD cd;
            while (true)
            {
                m.Show();
                if (m.Exit)
                    break;
                else
                {
                    switch (m.Selection)
                    {
                        case "1": cd = new CD();
                                cd.input();
                                cdList.Add(cd);
                                break;
                        case "2": cd = new CD();
                                cd.input();
                                cdList.Update(cd);
                                break;
                        case "3": cd = new Car();
                                cd.inputPlate();
                                cdList.Delete(cd.Plate);
                                break;
                        case "4": cd = new Car();
                                cd.inputPlate();
                                cdList.SearchbyPlate(cd.Plate);
                                break;
                        case "5":
                                cdList.ShowOrderbySpeed();
                                break;
                        default: break;
                    }
                }
            }
            Console.ReadLine();
        }
    }

    static class Extension
    {
        public static void input(this CD cd)
        {
            int id = GetInt32("Enter CD's id: ");
            string album = GetString("Enter CD's album: ");
            string singer = GetString("Enter CD's singer: ");
            int duration = GetInt32("Enter CD's duration: ");

            //song list
            List<string> songList = new List<string>();
            while (true)
            {
                string song = GetString("Enter a song in the CD: ");
                string ans = GetString("Do you want to continue inputting songs(Y/N): ");
                if (ans.Equals("N") || ans.Equals("n"))
                {
                    break;
                }


            }
            
            //genre
        }

        private static string GetString(String message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private static int GetInt32(String message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string str = Console.ReadLine();
                    int i = Int32.Parse(str);
                    return i;
                }
                catch (Exception ex)
                {
                    if (
                           ex is ArgumentNullException
                        || ex is FormatException
                        || ex is OverflowException
                    )
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        throw ex;
                    }
                    
                }
            }
            
        }
    }

    class Menu
    {
        string _Selection;

        public string Selection
        {
            get { return _Selection; }
        }
        bool _Exit;

        public bool Exit
        {
            get { return _Exit; }
        }

        public void Show()
        {
            Console.WriteLine("1. Add new CD");
            Console.WriteLine("2. Update a CD ");
            Console.WriteLine("3. Delete a CD ");
            Console.WriteLine("4. Sort by Album");
            Console.WriteLine("5. Sort by Singer");
            Console.WriteLine("6. List all CD");
            Console.WriteLine("7. Search CD by Album");
            Console.WriteLine("8. Search CD by Singer");
            Console.WriteLine("9. Search CD by song");
            _Selection = Console.ReadLine();
            if (
                _Selection != "1" 
                && _Selection != "2" 
                && _Selection != "3"
                && _Selection != "4" 
                && _Selection != "5"
                && _Selection != "6"
                && _Selection != "7"
                && _Selection != "8"
                && _Selection != "9"
                )
               _Exit = true;
            else _Exit = false;
        }
    }


}
