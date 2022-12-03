using System;
using System.Collections.Generic;

namespace PredictedRandom
{
    public class ArrayFactory<T> : PredictedArrayFactory<T>
    {
        private readonly (T, float)[] _keys;
        private readonly int _length;

        public ArrayFactory(int length, params (T,float)[] keys)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be positive and not 0 value.");

            float averagePercent = 0f;
            foreach (var pair in keys)
                averagePercent += pair.Item2;
            if (averagePercent < 99f || averagePercent > 100f)
                throw new ArgumentException("Sum of precents is not equal to 100");

            _length = length;
            _keys = keys.Clone() as (T,float)[];
        }

        public T[] Generate()
        {
            T[] result = new T[_length];
            List<T> requiredItems = new List<T>();

            foreach (var pair in _keys)
            {
                int itemsCount = (int) Math.Ceiling( _length * pair.Item2 / 100f);
                for (int count = 0; count < itemsCount; count++)
                    requiredItems.Add(pair.Item1);
            }
            result = requiredItems.GetRange(0, _length).ToArray();
            Shuffle(result);

            return result;
        }

        private void Shuffle(T[] anArray)
        {
            var rand = new Random();
            for(int i = 0; i < _length - 2; i++)
            {
                var lastUnswappedItemIndex = _length - 1  - i;
                var randomItem = rand.Next(0, lastUnswappedItemIndex );
                Swap(randomItem, lastUnswappedItemIndex, anArray);
            }
        }

        public void Swap(int index1, int index2, T[] anArray)
        {
            try
            {
                T temp = anArray[index1];
                anArray[index1] = anArray[index2];
                anArray[index2] = temp;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public interface PredictedArrayFactory<T>
    {
        public T[] Generate();
    }
}
