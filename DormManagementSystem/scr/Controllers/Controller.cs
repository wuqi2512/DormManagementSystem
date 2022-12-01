using DormManagementSystem.Widgets;

namespace DormManagementSystem.Controllers
{
    public abstract class Controller
    {
        public abstract View View { get; }

        public abstract void Initialize();
        public virtual void Update(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow: View.ChangeIndex(Direction.Up); break;
                case ConsoleKey.RightArrow: View.ChangeIndex(Direction.Right); break;
                case ConsoleKey.DownArrow: View.ChangeIndex(Direction.Down); break;
                case ConsoleKey.LeftArrow: View.ChangeIndex(Direction.Left); break;
            }
        }
    }
}
