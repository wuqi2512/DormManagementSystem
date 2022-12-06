

namespace DormManagementSystem
{
    public static class Common
    {
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

        public static int StringToInt(string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] <= 57 && str[i] >= 48)
                {
                    result = result * 10 + str[i] - 48;
                }
                else
                {
                    return -1;
                }
            }
            return result;
        }

        public static int[] GetNext(string t)
        {
            int j = 0, k = -1;
            int[] nextVal = new int[t.Length];
            nextVal[0] = -1;

            while (j < t.Length - 1)
            {
                if (k == -1 || t[j] == t[k])
                {
                    j++;
                    k++;
                    if (t[j] != t[k])
                    {
                        nextVal[j] = k;
                    }
                    else
                    {
                        nextVal[j] = nextVal[k];
                    }
                }
                else
                {
                    k = nextVal[k];
                }
            }
            return nextVal;
        }
        public static int KMP(string s, string t)
        {
            int i = 0, j = 0, v;
            int[] nextVal = GetNext(t);

            while (i < s.Length && j < t.Length)
            {
                if (j == -1 || s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = nextVal[j];
                }
            }

            if (j >= t.Length)
                v = i - t.Length;
            else
                v = -1;

            return v;
        }
    }
}
