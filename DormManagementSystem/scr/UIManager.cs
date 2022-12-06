using DormManagementSystem.Controllers;

namespace DormManagementSystem
{ 
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left,
    }

    public class UIManager
    {
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }

        private Controller currentController;

        public MenuController Menu { get; private set; }
        public DataTableController DataTable { get; private set; }
        public InfoBlockController InfoBlock { get; private set; }
        public DataTableController MatchDataTable { get; private set; }

        private UIManager()
        {
            Menu = new MenuController();
            Menu.Initialize();
            Menu.View.SetPosition(0, 0);
            Menu.View.PrintText();
            Menu.View.PrintOutline();

            DataTable = new DataTableController();
            DataTable.Initialize();
            DataTable.View.SetPosition(15, 8);
            DataTable.SetData(Menu.Model.GetAllStudentData());
            DataTable.View.PrintText();
            DataTable.View.PrintOutline();

            InfoBlock = new InfoBlockController();
            InfoBlock.Initialize();
            InfoBlock.View.SetPosition(15, 0);
            InfoBlock.AddInfo("欢迎进入寝室管理系统");

            MatchDataTable = new DataTableController();
            MatchDataTable.Initialize();
            MatchDataTable.View.SetPosition(55, 8);

            currentController = Menu;
        }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                currentController?.Update(Console.ReadKey().Key);

                Console.Clear();

                Menu.View.PrintText();
                Menu.View.PrintOutline();
                DataTable.SetData(Menu.Model.GetAllStudentData());
                DataTable.View.PrintText();
                DataTable.View.PrintOutline();
                InfoBlock.View.PrintText();
                InfoBlock.View.PrintOutline();

                currentController?.View.PrintOutline(ConsoleColor.Cyan);
                currentController?.View.PrintText();
            }
        }

        public void SwitchCurrentController(Controller controller)
        {
            currentController = controller;
            controller.View.PrintText();
            controller.View.PrintOutline();
        }

        public void SetMatchTable(string[,] texts)
        {
            MatchDataTable.SetData(texts);
            MatchDataTable.View.PrintText();
            MatchDataTable.View.PrintOutline();
        }
    }
}