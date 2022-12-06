

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
    }
}
