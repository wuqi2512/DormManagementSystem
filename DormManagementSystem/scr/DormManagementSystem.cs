

namespace DormManagementSystem
{
    public class DormManagementSystem
    {
        const string dataPath = "..\\..\\..\\SystemData.bin";
        StudentInformation[] studentArray;
        StudentInformation addStudent;

        public void AddStudent(StudentInformation student)
        {
            addStudent = student;
            SaveData();
            addStudent = null;
            LoadData();
        }

        public void LoadData()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(dataPath, FileMode.Open)))
            {
                int amount = reader.ReadInt32();
                studentArray = new StudentInformation[amount];
                for (int i = 0; i < amount; i++)
                {
                    studentArray[i] = new StudentInformation();
                    studentArray[i].LoadData(reader);
                }
            }
        }

        public void SaveData()
        {
            BuddleSortByStudentID();
            using (BinaryWriter writer = new BinaryWriter(File.Open(dataPath, FileMode.Open)))
            {
                if (addStudent != null)
                {
                    writer.Write(studentArray.Length + 1);
                    addStudent.SaveData(writer);
                }
                else
                {
                    writer.Write(studentArray.Length);
                }
                for (int i = 0; i < studentArray.Length; i++)
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

        public void SaveTextData()
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

        #region BuddleSort
        public void BuddleSortByStudentID()
        {
            for (int i = 0; i < studentArray.Length - 1; i++)
            {
                for (int j = 0; j < studentArray.Length - 1 - i; j++)
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
            for (int i = 0; i < studentArray.Length - 1; i++)
            {
                for (int j = 0; j < studentArray.Length - 1 - i; j++)
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
            for (int i = 0; i < studentArray.Length - 1; i++)
            {
                for (int j = 0; j < studentArray.Length - 1 - i; j++)
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

        public string[,] GetAllStudent()
        {
            string[,] result = new string[studentArray.Length, 3];
            for (int i = 0; i < studentArray.Length; i++)
            {
                result[i, 0] = studentArray[i].StudentId.ToString();
                result[i, 1] = studentArray[i].Name.ToString();
                result[i, 2] = studentArray[i].DormId.ToString();
            }
            return result;
        }
        public int GetDataAmount()
        {
            return studentArray.Length;
        }

        #region Modify Data Method
        public bool ModifyStudentID(int index, int studentId)
        {
            if (index < 0 || index >= studentArray.Length)
                return false;

            studentArray[index].StudentId = studentId;
            return true;
        }
        public bool ModifyName(int index, string name)
        {
            if (index < 0 || index >= studentArray.Length)
                return false;

            studentArray[index].Name = name;
            return true;
        }
        public bool ModifyDormID(int index, int dormId)
        {
            if (index < 0 || index >= studentArray.Length)
                return false;

            studentArray[index].DormId = dormId;
            return true;
        }
        #endregion
    }
}
