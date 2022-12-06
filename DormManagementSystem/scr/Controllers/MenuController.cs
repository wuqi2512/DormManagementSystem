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
            tableView.SetTableTexts(new string[,] { { "保存", }, { "测试数据", }, { "修改", }, { "增加", }, { "ID排序" }, { "ID查找", }, { "退出", }, });
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
                case 0:
                    Model.SaveData();
                    UIManager.Instance.InfoBlock.AddInfo("保存成功");
                    break;
                case 1:
                    Model.SaveTestData();
                    UIManager.Instance.InfoBlock.AddInfo("读取测试数据成功");
                    break;
                case 2:
                    UIManager.Instance.SwitchCurrentController(UIManager.Instance.DataTable);
                    break;
                case 3:
                    Model.AddEmptyStudent();
                    UIManager.Instance.SwitchCurrentController(UIManager.Instance.DataTable);
                    UIManager.Instance.InfoBlock.AddInfo("请修改新增的数据");
                    break;
                case 4: Model.BuddleSortByID(); break;
                case 5:
                    UIManager.Instance.InfoBlock.AddInfo("请输入关键字");
                    var position = UIManager.Instance.InfoBlock.GetPosition();
                    Console.SetCursorPosition(position.left, position.top);
                    Console.BackgroundColor = ConsoleColor.Red;
                    string input = Console.ReadLine();
                    Console.ResetColor();
                    var data = Model.StringMatchByID(input);
                    if (data.Length == 0)
                    {
                        UIManager.Instance.InfoBlock.AddInfo($"无匹配结果");
                    }
                    else
                    {
                        UIManager.Instance.SetMatchTable(Model.GetStudentData(data));
                        UIManager.Instance.InfoBlock.AddInfo($"查询:{input}");
                        UIManager.Instance.SwitchCurrentController(UIManager.Instance.MatchDataTable);
                    }
                    break;
                case 6: Environment.Exit(0); break;
            }
        }
    }
}
