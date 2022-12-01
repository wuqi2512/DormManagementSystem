

namespace DormManagementSystem
{
    public class StudentInformation
    {
        public int StudentId;
        public string Name;
        public int DormId;

        public StudentInformation()
        {
            StudentId = 0;
            Name = string.Empty;
            DormId = 0;
        }
        public StudentInformation(int studentId, string name, int dormId)
        {
            StudentId = studentId;
            Name = name;
            DormId = dormId;
        }

        public void SaveData(BinaryWriter writer)
        {
            writer.Write(StudentId);
            writer.Write(Name);
            writer.Write(DormId);
        }

        public void LoadData(BinaryReader reader)
        {
            StudentId = reader.ReadInt32();
            Name = reader.ReadString();
            DormId = reader.ReadInt32();
        }

        public void PrintStudent()
        {
            Console.WriteLine($"StudentID:{StudentId}, Name:{Name}, DormID:{DormId}");
        }
    }
}
