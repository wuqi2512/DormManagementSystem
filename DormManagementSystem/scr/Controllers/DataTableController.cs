using DormManagementSystem.Widgets;

namespace DormManagementSystem.Controllers
{
    public class DataTableController : Controller
    {
        public override View View => tableView;

        private Table tableView;

        public override void Initialize()
        {
            tableView = new Table();
        }

        public void SetData(int row, int col, string[,] texts)
        {
            tableView.SetRowAndCol(row, col);
            tableView.SetTableTexts(texts);
        }

        public override void Update(ConsoleKey key)
        {
            base.Update(key);
            switch (key)
            {
                case ConsoleKey.Escape: UIManager.Instance.SwitchCurrentController(UIManager.Instance.Menu); break;
                case ConsoleKey.Spacebar: ClickButton(); break;
            }

            tableView.PrintText();
            tableView.PrintOutline();
        }

        private void ClickButton()
        {
            UIManager.Instance.InfoBlock.AddInfo("请输入修改后的值");
            var position = tableView.GetIndexPosition();
            int index = tableView.RowIndex;

            Console.SetCursorPosition(position.left, position.top);
            while (true)
            {

                string input = Console.ReadLine();
                switch (tableView.ColIndex)
                {
                    case 0: UIManager.Instance.Menu.Model.ModifyStudentID(index, Convert.ToInt32(input)); break;
                    case 1: UIManager.Instance.Menu.Model.ModifyName(index, input); break;
                    case 2: UIManager.Instance.Menu.Model.ModifyDormID(index, Convert.ToInt32(input)); break;
                }
                break;
            }

            UIManager.Instance.InfoBlock.AddInfo("修改成功");
            UIManager.Instance.SwitchCurrentController(UIManager.Instance.Menu);
        }
    }
}
