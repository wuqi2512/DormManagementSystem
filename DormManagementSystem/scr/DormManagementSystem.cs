using static DormManagementSystem.Common;

namespace DormManagementSystem
{
    public class DormManagementSystem
    {
        const string dataPath = "..\\..\\..\\SystemData.bin";
        MyArray<StudentInformation> studentArray;

        #region Save And Load Method
        public void LoadData()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(dataPath, FileMode.Open)))
            {
                int amount = reader.ReadInt32();
                studentArray = new MyArray<StudentInformation>(amount);
                for (int i = 0; i < amount; i++)
                {
                    studentArray.Add(new StudentInformation());
                    studentArray[i].LoadData(reader);
                }
            }
        }

        public void SaveData()
        {
            BuddleSortByID();
            using (BinaryWriter writer = new BinaryWriter(File.Open(dataPath, FileMode.Open)))
            {
                writer.Write(studentArray.Count);
                for (int i = 0; i < studentArray.Count; i++)
                {
                    studentArray[i].SaveData(writer);
                }
            }
        }

        public void InitializeData()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(dataPath, FileMode.Open)))
            {
                writer.Write(0);
            }
        }

        public void SaveTestData()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(dataPath, FileMode.Open)))
            {
                StudentInformation[] temp = new StudentInformation[]
                {
                    new StudentInformation(210521300, "李华", 100),
                    new StudentInformation(210521303, "小红", 113),
                    new StudentInformation(210521302, "张伟", 151),
                    new StudentInformation(210521304, "陈文", 131),
                    new StudentInformation(210521301, "李四", 145),
                };
                writer.Write(temp.Length);
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i].SaveData(writer);
                }
            }
            LoadData();
        }
        #endregion

        #region BuddleSort
        public void BuddleSortByID()
        {
            for (int i = 0; i < studentArray.Count - 1; i++)
            {
                for (int j = 0; j < studentArray.Count - 1 - i; j++)
                {
                    if (studentArray[j].StudentId > studentArray[j + 1].StudentId)
                    {
                        StudentInformation current = studentArray[j];
                        studentArray[j] = studentArray[j + 1];
                        studentArray[j + 1] = current;
                    }
                }
            }
        }
        public void BuddleSortByName()
        {
            for (int i = 0; i < studentArray.Count - 1; i++)
            {
                for (int j = 0; j < studentArray.Count - 1 - i; j++)
                {
                    if (studentArray[j].Name[0] > studentArray[j + 1].Name[0])
                    {
                        StudentInformation current = studentArray[j];
                        studentArray[j] = studentArray[j + 1];
                        studentArray[j + 1] = current;
                    }
                }
            }
        }
        public void BuddleSortByDormID()
        {
            for (int i = 0; i < studentArray.Count - 1; i++)
            {
                for (int j = 0; j < studentArray.Count - 1 - i; j++)
                {
                    if (studentArray[j].DormId > studentArray[j + 1].DormId)
                    {
                        StudentInformation current = studentArray[j];
                        studentArray[j] = studentArray[j + 1];
                        studentArray[j + 1] = current;
                    }
                }
            }
        }
        #endregion

        #region StringMatch
        public int[] StringMatchByID(string str)
        {
            MyArray<int> indexArray = new MyArray<int>();
            for (int i = 0; i < studentArray.Count; i++)
            {
                if (KMP(studentArray[i].StudentId.ToString(), str) != -1)
                {
                    indexArray.Add(i);
                }
            }

            return indexArray.GetArray();
        }
        public int[] StringMatchByName(string str)
        {
            MyArray<int> indexArray = new MyArray<int>();
            for (int i = 0; i < studentArray.Count; i++)
            {
                if (KMP(studentArray[i].Name, str) != -1)
                {
                    indexArray.Add(i);
                }
            }

            return indexArray.GetArray();
        }
        public int[] StringMatchByDormID(string str)
        {
            MyArray<int> indexArray = new MyArray<int>();
            for (int i = 0; i < studentArray.Count; i++)
            {
                if (KMP(studentArray[i].DormId.ToString(), str) != -1)
                {
                    indexArray.Add(i);
                }
            }

            return indexArray.GetArray();
        }
        #endregion

        public string[,] GetStudentData(int[] indexs)
        {
            string[,] result = new string[indexs.Length, 3];
            for (int i = 0; i < indexs.Length; i++)
            {
                result[i, 0] = studentArray[indexs[i]].StudentId.ToString();
                result[i, 1] = studentArray[indexs[i]].Name.ToString();
                result[i, 2] = studentArray[indexs[i]].DormId.ToString();
            }
            return result;
        }
        public string[,] GetAllStudentData()
        {
            string[,] result = new string[studentArray.Count, 3];
            for (int i = 0; i < studentArray.Count; i++)
            {
                result[i, 0] = studentArray[i].StudentId.ToString();
                result[i, 1] = studentArray[i].Name.ToString();
                result[i, 2] = studentArray[i].DormId.ToString();
            }
            return result;
        }
        public int GetDataAmount()
        {
            return studentArray.Count;
        }
        public void AddEmptyStudent()
        {
            studentArray.Add(new StudentInformation(-1, "-", -1));
        }
        public void DeleteStudent(int index)
        {
            studentArray.RemoveAt(index);
        }

        #region Modify Data Method
        public bool ModifyStudentID(int index, int studentId)
        {
            if (index < 0 || index >= studentArray.Count)
                return false;

            studentArray[index].StudentId = studentId;
            return true;
        }
        public bool ModifyName(int index, string name)
        {
            if (index < 0 || index >= studentArray.Count)
                return false;

            studentArray[index].Name = name;
            return true;
        }
        public bool ModifyDormID(int index, int dormId)
        {
            if (index < 0 || index >= studentArray.Count)
                return false;

            studentArray[index].DormId = dormId;
            return true;
        }
        #endregion
    }
}
