using System;
using System.Collections.Generic;

namespace Tester
{
    public class MyStack<T>
    {
        private T[] array;
        public int Count { get; private set; }
        Comparer<T> comparer = Comparer<T>.Default;

        public MyStack(int capacity)
        {
            array = new T[capacity];
            this.Count = 0;
        }

        public void Push(T val)
        {
            if (Count < array.Length) array[Count++] = val;
            else throw new InvalidOperationException("The stack is out of capacity.");
        }

        public T Pop()
        {
            if (Count > 0) return array[--Count];
            else throw new InvalidOperationException("The stack is empty.");
        }

        public T Find(Func<T, bool> criteria)
        {
            if (criteria == null) { throw new ArgumentNullException("Criteria is null"); }
            foreach (T element in array)
            {
                if (criteria(element))
                {
                    return element;
                }
            }
            return default;
        }

        public T[] FindAll(Func<T, bool> criteria)
        {
            if (criteria == null) { throw new ArgumentNullException("Criteria is null"); }
            List<T> list = new List<T>();
            foreach(T element in array)
            {
                if (criteria(element))
                {
                    list.Add(element);
                }
            }
            T[] result = list.ToArray();
            if(result.Length == 0) { return null; }
            return result;
        }

        public int RemoveAll(Func<T, bool> criteria)
        {
            if (criteria == null) { throw new ArgumentNullException("Criteria is null"); }
            int count = 0;
            foreach (T element in array)
            {
                if (criteria(element))
                {
                    Pop();
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            if(array.Length == 0) { return default; }
            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                max = comparer.Compare(array[i], max) > 0 ? array[i] : max;
            }
            return max;
        }

        public T Min()
        {
            if (array.Length == 0) { return default; }
            T min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                min = comparer.Compare(array[i], min) < 0 ? array[i] : min;
            }
            return min;
        }
    }
}