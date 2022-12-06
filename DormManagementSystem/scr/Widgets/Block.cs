using static DormManagementSystem.Common;

namespace DormManagementSystem.Widgets
{
    public class Block : View
    {
        public int Row { get; protected set; }
        public int RowIndex { get; protected set; }
        public int TextIndex { get; protected set; }

        private string[] textArray;
        private int maxTextLength;

        public Block(int left = 0, int top = 0)
        {
            Left = left;
            Top = top;
            maxTextLength = 10;
            RowIndex = -1;
            TextIndex = -1;
            textArray = new string[0];
        }

        public void SetRow(int row)
        {
            Row = row;
        }
        public void SetTexts(string[] texts)
        {
            textArray = texts;
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].Length * 3 > maxTextLength)
                {
                    maxTextLength = texts[i].Length * 3;
                }
            }
        }

        public override void PrintOutline(ConsoleColor fgColor = ConsoleColor.White)
        {
            int height = Row + 2;
            int width = maxTextLength + 2;

            string rowStr = WallStyle[0] + new string(WallStyle[1], width - 2) + WallStyle[0];
            string colStr = WallStyle[0] + new string(WallStyle[2], height - 2) + WallStyle[0];

            PrintCol(Left, Top, colStr, ConsoleColor.Black, fgColor);
            PrintCol(Left + width - 1, Top, colStr, ConsoleColor.Black, fgColor);

            PrintRow(Left, Top, rowStr, ConsoleColor.Black, fgColor);
            PrintRow(Left, Top + height - 1, rowStr, ConsoleColor.Black, fgColor);
        }
        public override void PrintText()
        {
            if (RowIndex == -1 || TextIndex == -1)
            {
                RowIndex = Row - 1;
                TextIndex = textArray.Length - 1;
            }

            for (int i = 0; i < Row; i++)
            {
                int j = TextIndex - RowIndex + i;
                if (j < textArray.Length && j > -1)
                {
                    if (i == RowIndex)
                    {
                        PrintRow(Left + 1, Top + 1 + i, textArray[j], ConsoleColor.Cyan);
                    }
                    else
                    {
                        PrintRow(Left + 1, Top + 1 + i, textArray[j]);
                    }
                }
            }
        }

        public override void ChangeIndex(Direction direct)
        {
            switch (direct)
            {
                case Direction.Up:
                    if (TextIndex > 0)
                    {
                        if (RowIndex != 0)
                        {
                            RowIndex--;
                        }
                        TextIndex--;
                    }
                    break;
                case Direction.Down:
                    if (TextIndex < textArray.Length - 1)
                    {
                        if (RowIndex != Row - 1)
                        {
                            RowIndex++;
                        }
                        TextIndex++;
                    }
                    break;
            }
        }
        public (int left, int top) GetPosition()
        {
            int left = Left + 1 + maxTextLength;
            int top = Top + 1 + RowIndex;

            return (left, top);
        }
    }
}