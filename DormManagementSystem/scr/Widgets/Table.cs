using static DormManagementSystem.Common;

namespace DormManagementSystem.Widgets
{
    public class Table : View
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public int RowIndex { get; private set; }
        public int ColIndex { get; private set; }

        const int padLeft = 1;
        const int padRight = 5;

        private string[,] tableTexts;
        private int[] maxTextLengthPerCol;

        public Table(int left = 0, int top = 0)
        {
            Top = top;
            Left = left;
            RowIndex = -1;
            ColIndex = -1;
        }

        public void SetRowAndCol(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public void SetTableTexts(string[,] texts)
        {
            tableTexts = texts;
            maxTextLengthPerCol = new int[Col];
            for (int i = 0; i < Col; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (tableTexts[j, i].Length > maxTextLengthPerCol[i])
                    {
                        maxTextLengthPerCol[i] = tableTexts[j, i].Length;
                    }
                }
            }
        }


        public override void PrintOutline(ConsoleColor fgColor = ConsoleColor.White)
        {
            int height = Row + Row - 1 + 2;
            int width = 0;
            for (int i = 0; i < Col; i++)
            {
                width += maxTextLengthPerCol[i];
            }
            width += Col - 1 + 2 + (padLeft + padRight) * Col;

            string rowStr = WallStyle[0] + new string(WallStyle[1], width - 2) + WallStyle[0];
            string colStr = WallStyle[0] + new string(WallStyle[2], height - 2) + WallStyle[0];

            int lastLeft = Left;
            for (int i = 0; i < Col - 1; i++)
            {
                lastLeft += 1 + padLeft + maxTextLengthPerCol[i] + padRight;
                PrintCol(lastLeft, Top, colStr);
            }

            for (int i = 0; i < Row - 1; i++)
            {
                PrintRow(Left, Top + 2 + i * 2, rowStr);
            }

            PrintCol(Left, Top, colStr, ConsoleColor.Black, fgColor);
            PrintCol(lastLeft + 1 + padLeft + maxTextLengthPerCol[Col - 1] + padRight, Top, colStr, ConsoleColor.Black, fgColor);

            PrintRow(Left, Top, rowStr, ConsoleColor.Black, fgColor);
            PrintRow(Left, Top + Row * 2, rowStr, ConsoleColor.Black, fgColor);
        }
        public override void PrintText()
        {
            for (int i = 0; i < Row; i++)
            {
                int lastLeft = Left;
                for (int j = 0; j < Col; j++)
                {
                    lastLeft += 1 + padLeft;
                    if (i == RowIndex && j == ColIndex)
                    {
                        PrintRow(lastLeft, Top + 1 + i * 2, tableTexts[i, j], ConsoleColor.Black, ConsoleColor.Cyan);
                    }
                    else
                    {
                        PrintRow(lastLeft, Top + 1 + i * 2, tableTexts[i, j]);
                    }
                    lastLeft += maxTextLengthPerCol[j] + padRight;
                }
            }
        }
        public (int left, int top) GetIndexPosition()
        {
            int left = Left;
            for (int j = 0; j < Col; j++)
            {
                left += 1 + padLeft;
                if (j == ColIndex)
                {
                    break;
                }
                left += maxTextLengthPerCol[j] + padRight;
            }
            int top = Top + 1 + RowIndex * 2;
            return (left, top);
        }
        public override void ChangeIndex(Direction direct)
        {
            switch (direct)
            {
                case Direction.Up: RowIndex--; break;
                case Direction.Right: ColIndex++; break;
                case Direction.Down: RowIndex++; break;
                case Direction.Left: ColIndex--; break;
            }

            if (ColIndex == -1)
            {
                ColIndex = Col - 1;
            }
            else if (ColIndex == Col)
            {
                ColIndex = 0;
            }

            if (RowIndex == -1)
            {
                RowIndex = Row - 1;
            }
            else if (RowIndex == Row)
            {
                RowIndex = 0;
            }
        }
    }
}
