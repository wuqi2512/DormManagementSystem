using DormManagementSystem.Widgets;

namespace DormManagementSystem.Controllers
{
    public class MenuController : Controller
    {
        public override View View => tableView;


        public Table tableView;
        public DormManagementSystem Model { get; protected set; }

        public override void Initialize()
        {
            Model = new DormManagementSystem();
            Model.LoadData();

            tableView = new Table();
            tableView.SetRowAndCol(7, 1);
            tableView.SetTableTexts(new string[,] { { "保存", }, { "测试数据", }, { "修改", }, { "ID排序" }, { "姓名排序", }, { "寝室号排序" }, { "退出", }, });
        }

        public override void Update(ConsoleKey key)
        {
            base.Update(key);
            switch (key)
            {
                case ConsoleKey.Spacebar: ClickButton(); break;
            }

            View.PrintText();
            View.PrintOutline();
        }

        private void ClickButton()
        {
            switch (tableView.RowIndex)
            {
                case 0: Model.SaveData(); UIManager.Instance.InfoBlock.AddInfo("保存成功"); break;
                case 1: Model.SaveTextData(); UIManager.Instance.InfoBlock.AddInfo("读取测试数据成功"); break;
                case 2: UIManager.Instance.SwitchCurrentController(UIManager.Instance.DataTable); break;
                case 3: Model.BuddleSortByStudentID(); break;
                case 4: Model.BuddleSortByName(); break;
                case 5: Model.BuddleSortByDormID(); break;
                case 6: Environment.Exit(0); break;
            }
        }
    }
}
