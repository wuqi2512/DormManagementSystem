using DormManagementSystem.Widgets;
using static DormManagementSystem.Common;

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

        public void SetData(string[,] texts)
        {
            tableView.SetRowAndCol((int)texts.GetLongLength(0), (int)texts.GetLongLength(1));
            tableView.SetTableTexts(texts);
        }

        public override void Update(ConsoleKey key)
        {
            base.Update(key);
            switch (key)
            {
                case ConsoleKey.Escape: UIManager.Instance.SwitchCurrentController(UIManager.Instance.Menu); break;
                case ConsoleKey.Backspace: ClickBackspace(); break;
                case ConsoleKey.Spacebar: ClickSpace(); break;
            }

            tableView.PrintText();
            tableView.PrintOutline();
        }

        private void ClickBackspace()
        {
            UIManager.Instance.Menu.Model.DeleteStudent(tableView.RowIndex);
            UIManager.Instance.InfoBlock.AddInfo("删除成功");
        }

        private void ClickSpace()
        {
            UIManager.Instance.InfoBlock.AddInfo("请输入修改后的值");
            var position = tableView.GetIndexPosition();
            int index = tableView.RowIndex;

            Console.SetCursorPosition(position.left, position.top);

            string input = Console.ReadLine();
            if (input == null)
            {
                UIManager.Instance.InfoBlock.AddInfo("输入为空,修改失败");
                return;
            }
            else if (tableView.ColIndex != 1 && StringToInt(input) == -1)
            {
                UIManager.Instance.InfoBlock.AddInfo("输入错误,修改失败");
                return;
            }
            
            switch (tableView.ColIndex)
            {
                case 0: UIManager.Instance.Menu.Model.ModifyStudentID(index, StringToInt(input)); break;
                case 1: UIManager.Instance.Menu.Model.ModifyName(index, input); break;
                case 2: UIManager.Instance.Menu.Model.ModifyDormID(index, StringToInt(input)); break;
            }

            UIManager.Instance.InfoBlock.AddInfo("修改成功");
        }
    }
}
