using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1
{
    class ConsoleMenu
    {
        private List<string> optionsList;
        private bool border;
        private string title;
        private bool checkbox;
        private int longestOptionLength;
        private int chosenLine = 0;


        public ConsoleMenu(bool checkbox = true, bool border = false, string title = "")
        {
            optionsList = new List<string>();
            this.checkbox = checkbox;
            this.border = border;
            this.title = title;
        }

        public void AddOption(string option)
        {
            optionsList.Add(option);
            longestOptionLength = GetLongestOptionLength();
        }

        public void SetOptions(IEnumerable<string> enumerable)
        {
            foreach (var el in enumerable)
            {
                optionsList.Add(el);
            }
            longestOptionLength = GetLongestOptionLength();
        }

        public bool Border
        {
            get { return border; }
            set { border = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public bool Checkbox
        {
            get { return checkbox; }
            set { checkbox = value; }
        }

        public string RenderAll()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (border)
            {
                stringBuilder.Append('=', longestOptionLength/2 + 1);
                stringBuilder.Append(title);
                stringBuilder.Append('=', longestOptionLength/2 + 1);
                stringBuilder.Append('\n', 2);
            }

            for (int i = 0; i < optionsList.Count; i++)
            {
                stringBuilder.Append(RenderLine(i) + "\n");
            }

            if (border)
            {
                stringBuilder.Append('\n', 2);
                stringBuilder.Append('=', longestOptionLength + title.Length + 2);
            }


            return stringBuilder.ToString();
        }

        public string RenderLine(int index)
        {
            if (index != Clamp(index, 0, optionsList.Count))
                return null;

            StringBuilder stringBuilder = new StringBuilder();
            string s = optionsList[index];
            stringBuilder.Append(s);

            if (checkbox)
            {
                int spaceLeft = longestOptionLength - s.Length + 2;
                stringBuilder.Append(' ', spaceLeft);
                stringBuilder.Append("[");
                if (index == chosenLine)
                    stringBuilder.Append("X");
                else
                    stringBuilder.Append(" ");
                stringBuilder.Append("]");
            }

            return stringBuilder.ToString();
        }

        public void MoveUp()
        {
            chosenLine--;
            chosenLine = Clamp(chosenLine, 0, optionsList.Count - 1);
        }

        public void MoveDown()
        {
            chosenLine++;
            chosenLine = Clamp(chosenLine, 0, optionsList.Count - 1);
        }

        public int ChosenLine
        {
            get { return chosenLine; }
        }

        public int GetLongestOptionLength()
        {
            string longest = optionsList.OrderByDescending(s => s.Length).First();
            return longest.Length;
        }

        public T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            if (value.CompareTo(max) > 0)
                return max;
            return value;
        }

        public int GetMenuInput()
        {
            Console.CursorVisible = false;
            int originLeft = Console.CursorLeft;
            int originTop = Console.CursorTop;
            while (true)
            {
                Console.SetCursorPosition(originLeft, originTop);
                ConsoleWrite(this.RenderAll());
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        this.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        this.MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return this.ChosenLine;
                }
            }
        }

        public string GetString(String message, Regex regex = null, ConsoleKey exitKey = ConsoleKey.Escape)
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

        public int GetInt32(string message)
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

        public Enum GetEnum(Enum en)
        {
            ConsoleMenu enumMenu = new ConsoleMenu();
            string[] names = Enum.GetNames(typeof(Enum));
            enumMenu.SetOptions(names);
            int choice = enumMenu.GetMenuInput();
            return (Enum)choice;
        }

        public void WaitForKey()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Successful!");
            ConsoleWrite("Press any key to continue", foreColor: ConsoleColor.Green);
            Console.ReadKey();
            Console.CursorVisible = true;
        }


        public void ConsoleWrite(
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