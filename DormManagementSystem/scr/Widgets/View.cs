

namespace DormManagementSystem.Widgets
{
    public abstract class View
    {
        public int Top { get; protected set; }
        public int Left { get; protected set; }

        protected char[] WallStyle = { '+', '-', '|', };

        public void SetPosition(int left, int top)
        {
            Top = top;
            Left = left;
        }

        public abstract void PrintOutline(ConsoleColor fgColor = ConsoleColor.White);
        public abstract void PrintText();
        public abstract void ChangeIndex(Direction direct);

        public static void PrintRow(int left, int top, string str, ConsoleColor bgColor = ConsoleColor.Black, ConsoleColor fgColor = ConsoleColor.White)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            Console.SetCursorPosition(left, top);
            Console.Write(str);
            Console.ResetColor();
        }
        public static void PrintCol(int left, int top, string str, ConsoleColor bgColor = ConsoleColor.Black, ConsoleColor fgColor = ConsoleColor.White)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            for (int i = 0; i < str.Length; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(str[i]);
            }
            Console.ResetColor();
        }
    }
}
