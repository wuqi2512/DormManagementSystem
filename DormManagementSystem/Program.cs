

namespace DormManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UIManager.Instance.Update();
            }
        }
    }
}