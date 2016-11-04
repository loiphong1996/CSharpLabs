using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lab1;

namespace CarManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private ConsoleMenu menu = new ConsoleMenu();
        private CDList cdList = new CDList();

        private void Run()
        {
            menu.AddOption("Add new CD."); //0
            menu.AddOption("Update a CD."); //1
            menu.AddOption("Delete a CD."); //2
            menu.AddOption("Sort by Album."); //3
            menu.AddOption("Sort by Singer."); //4
            menu.AddOption("List all CD."); //5
            menu.AddOption("Search CD by Album."); //6
            menu.AddOption("Search CD by Singer"); //7
            menu.AddOption("Search CD by song."); //8
            menu.AddOption("Exit"); //9
            int inputValue = -1;
            while (inputValue != 2)
            {
                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine(menu.RenderAll());
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        menu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        inputValue = menu.ChosenLine;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menu.RenderLine(inputValue, false) + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        switch (inputValue)
                        {
                            case 0:
                                AddCD();
                                break;
                            case 5:
                                ShowAllCD();
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        private void ShowAllCD()
        {
            Console.WriteLine(cdList.ToString());
            ConsoleWrite("Press any key to continue",foreColor: ConsoleColor.Green);
            Console.ReadKey();
        }

        private void AddCD()
        {
            CD cd;
            input(out cd);
            cdList.Add(cd);
        }

        public void input(out CD cd)
        {
            int id = GetInt32("Enter CD's id: ");
            string album = GetString("Enter CD's album: ");
            string singer = GetString("Enter CD's singer: ");
            int duration = GetInt32("Enter CD's duration: ");

            //song list
            Regex ynRegex = new Regex("^y|Y|n|N$");
            Regex nRegex = new Regex("^(n|N)$");
            List<string> songList = new List<string>();
            while (true)
            {
                string song = GetString("Enter a song in the CD(N to exit): ");
                if (nRegex.IsMatch(song))
                {
                    break;
                }
                songList.Add(song);
            }
            Genre genre;
            GetGenre(out genre);

            cd = new CD(album, duration, genre, id, singer, songList);
        }

        private string GetString(String message, Regex regex = null)
        {
            while (true)
            {
                Console.Write(message);
                string s = Console.ReadLine();
                if (regex != null)
                {
                    if (regex.IsMatch(s))
                    {
                        return s;
                    }
                    else
                    {
                        ConsoleWrite("Invalid input!\n", foreColor: ConsoleColor.Red);
                    }
                }
                else
                {
                    return s;
                }
            }
        }

        private int GetInt32(String message)
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
                        ConsoleWrite("Invalid input!\n", foreColor: ConsoleColor.Red);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        private void GetGenre(out Genre genre)
        {
            ConsoleMenu genreMenu = new ConsoleMenu();
            genreMenu.AddOption("Rock");
            genreMenu.AddOption("Rap");
            genreMenu.AddOption("Country");
            genreMenu.AddOption("Blue");
            genreMenu.AddOption("Jazz");
            genreMenu.AddOption("Dance");
            Console.Write("Choose a genre: \n");

            int originLeft = Console.CursorLeft;
            int originTop = Console.CursorTop;

            bool valid = false;
            int input = 0;
            while (!valid)
            {
                Console.SetCursorPosition(originLeft,originTop);
                ConsoleWrite(genreMenu.RenderAll(border: false));
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        genreMenu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        genreMenu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        input = genreMenu.ChosenLine;
                        
                        valid = true;
                        break;
                }
            }
            genre = (Genre) input;
        }

        private void ConsoleWrite(
            string message,
            ConsoleColor foreColor = ConsoleColor.White,
            ConsoleColor backColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}