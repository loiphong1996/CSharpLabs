using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private ConsoleMenu mainMenu = new ConsoleMenu();
        private CDList cdList = new CDList();

        private void Run()
        {
            

            mainMenu.Checkbox = true;
            mainMenu.Title = "Menu";
            mainMenu.Border = true;
            mainMenu.AddOption("Add new CD."); //0
            mainMenu.AddOption("Update a CD."); //1
            mainMenu.AddOption("Delete a CD."); //2
            mainMenu.AddOption("Sort by Album."); //3
            mainMenu.AddOption("Sort by Singer."); //4
            mainMenu.AddOption("List all CD."); //5
            mainMenu.AddOption("Search CD by Album."); //6
            mainMenu.AddOption("Search CD by Singer"); //7
            mainMenu.AddOption("Search CD by Song."); //8
            mainMenu.AddOption("Exit"); //9

            
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                int inputValue = GetMenuInput(mainMenu);
                Console.Clear();
                mainMenu.Checkbox = false;
                ConsoleWrite(mainMenu.RenderLine(inputValue) + "\n", foreColor: ConsoleColor.Green);
                mainMenu.Checkbox = true;
                switch (inputValue)
                {
                    case 0:
                        AddCd();
                        break;
                    case 1:
                        UpdateCd();
                        break;
                    case 2:
                        DeleteCd();
                        break;
                    case 3:
                        AlbumSort();
                        break;
                    case 4:
                        SingerSort();
                        break;
                    case 5:
                        ShowAllCd();
                        break;
                    case 6:
                        SearchAlbum();
                        break;
                    case 7:
                        SearchSinger();
                        break;
                    case 8:
                        SearchSong();
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SearchSong()
        {
            string s = GetString("Enter CD's Song: ");
            List<CD> resultList = cdList.SearchBySong(s);

            Console.Write(resultList.ToString());

            WaitForKey();
        }

        private void SearchSinger()
        {
            string s = GetString("Enter CD's singer: ");
            List<CD> resultList = cdList.SearchBySinger(s);

            Console.Write(resultList.ToString());

            WaitForKey();
        }

        private void SearchAlbum()
        {
            string s = GetString("Enter CD's album: ");
            List<CD> resultList = cdList.SearchByAlbum(s);

            Console.Write(resultList.ToString());

            WaitForKey();
        }

        private void SingerSort()
        {
            cdList.SortBySinger(true);
            ShowAllCd();
        }

        private void AlbumSort()
        {
            cdList.SortByAlbum(true);
            ShowAllCd();

        }

        private void DeleteCd()
        {
            Console.WriteLine("Choose CD's ID to update");
            CD cd = ChooseCd(cdList);

            cdList.Remove(cd);

            WaitForKey();
        }

        private void UpdateCd()
        {
            Console.WriteLine("Choose CD's ID to update");
            CD cd = ChooseCd(cdList);

            string album = GetString("Enter CD's album: ");
            string singer = GetString("Enter CD's singer: ");
            int duration = GetInt32("Enter CD's duration: ");

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

            cd.Album = album;
            cd.Genre = genre;
            cd.Duration = duration;
            cd.SongList = songList;
            cd.Singer = singer;

            WaitForKey();
        }


        private void ShowAllCd()
        {
            Console.WriteLine(cdList.ToString());
            WaitForKey();
        }

        private void AddCd()
        {
            CD cd;
            Input(out cd);
            cdList.Add(cd);
            WaitForKey();
        }

        private CD ChooseCd(List<CD> cdList)
        {
            ConsoleMenu cdMenu = new ConsoleMenu();
            cdMenu.Border = false;
            cdMenu.Checkbox = true;

            foreach (CD cd in cdList)
            {
                cdMenu.AddOption(cd.Id.ToString());
            }

            int input = GetMenuInput(cdMenu);
            return cdList[input];
        }

        private int GetMenuInput(ConsoleMenu menu)
        {
            Console.CursorVisible = false;
            int originLeft = Console.CursorLeft;
            int originTop = Console.CursorTop;
            while (true)
            {
                Console.SetCursorPosition(originLeft, originTop);
                ConsoleWrite(menu.RenderAll());
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        menu.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        menu.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return menu.ChosenLine;
                }
            }
        }

        private void Input(out CD cd)
        {
            string id = "";
            bool valid = false;
            while (!valid)
            {
                id = GetString("Enter CD's ID: ");
                CD tmpCd = cdList.Find(id);
                if (tmpCd != null)
                {
                    ConsoleWrite("CD with id " + id + " already taken!\n", foreColor: ConsoleColor.Red);
                }
                else
                {
                    valid = true;
                }
            }


            string album = GetString("Enter CD's album: ");
            string singer = GetString("Enter CD's singer: ");
            int duration = GetInt32("Enter CD's duration: ");


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


        private string GetString(String message, Regex regex = null,ConsoleKey exitKey = ConsoleKey.Escape)
        {
            if (regex == null)
            {
                regex = new Regex(".+");
            }
            while (true)
            {
                Console.Write(message);
                string s = Console.ReadLine();
                if (regex.IsMatch(s))
                {
                    return s;
                }
                else
                {
                    ConsoleWrite("Invalid Input!\n", foreColor: ConsoleColor.Red);
                }
            }
        }

        private int GetInt32(string message)
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
                        ConsoleWrite("Input must be interger!\n", foreColor: ConsoleColor.Red);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        private void WaitForKey()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Successful!");
            ConsoleWrite("Press any key to continue", foreColor: ConsoleColor.Green);
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        private void GetGenre(out Genre genre)
        {
            ConsoleMenu genreMenu = new ConsoleMenu();
            genreMenu.Border = false;
            genreMenu.Checkbox = true;
            genreMenu.AddOption(Genre.Rock.ToString());
            genreMenu.AddOption(Genre.Rap.ToString());
            genreMenu.AddOption(Genre.Country.ToString());
            genreMenu.AddOption(Genre.Blue.ToString());
            genreMenu.AddOption(Genre.Jazz.ToString());
            genreMenu.AddOption(Genre.Dance.ToString());
            Console.Write("Choose a genre: \n");

            int input = GetMenuInput(genreMenu);
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