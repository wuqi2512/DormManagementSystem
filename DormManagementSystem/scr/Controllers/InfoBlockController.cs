using DormManagementSystem.Widgets;

namespace DormManagementSystem.Controllers
{
    public class InfoBlockController : Controller
    {
        public override View View => blockView;

        private Block blockView;

        private string[] infomations;
        private int index;

        public override void Initialize()
        {
            blockView = new Block();

            infomations = new string[0];
            index = -1;

            blockView.SetRow(5);
        }

        public void AddInfo(string info)
        {
            index++;
            if (index == infomations.Length)
            {
                string[] newArray = new string[infomations.Length + 1];
                for (int i = 0; i < infomations.Length; i++)
                {
                    newArray[i] = infomations[i];
                }
                infomations = newArray;
            }
            infomations[index] = info;

            blockView.SetTexts(infomations);
            blockView.ChangeIndex(Direction.Down);

            // TODO: temparory
            View.PrintText();
            View.PrintOutline();
        }
    }
}
