
namespace DormManagementSystem
{
    public class MyArray<T>
    {
        public int Capacity { get; private set; }
        public int Count => index + 1;
        private T[] values;
        private int index;

        public T this[int key]
        {
            get
            {
                return values[key];
            }
            set
            {
                values[key] = value;
            }
        }

        public MyArray(int capacity = 10)
        {
            Capacity = capacity;
            values = new T[Capacity];
            index = -1;
        }

        public void Add(T value)
        {
            index++;
            if (index == Capacity)
            {
                ExtendCapacity();
            }
            values[index] = value;
        }

        public void RemoveAt(int s)
        {
            for (int i = 0; i < index; i++)
            {
                this[i] = this[i + 1];
            }
            index--;
        }

        public void ExtendCapacity(int amount = 10)
        {
            Capacity += amount;
            T[] array = new T[Capacity];
            for (int i = 0; i < values.Length; i++)
            {
                array[i] = values[i];
            }
            values = array;
        }

        public T[] GetArray()
        {
            T[] array = new T[index + 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = values[i];
            }
            return array;
        }
    }
}
