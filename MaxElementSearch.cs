using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public static class MaxElementSearch
    {
        interface IFloatWrapper
        {
            float Value { get; }
        }

        class FloatWrapper : IFloatWrapper
        {
            public float Value { get; }
            public FloatWrapper(float value)
            {
                Value = value;
            }
        }

        public static T GetMax<T>(this IEnumerable<T> coll, Func<T,float> getParam) where T : class
        {
            T resultMaxVal = null;
            float max = float.MinValue;
            foreach (T item in coll)
            {
                float f = getParam(item);
                if (f > max)
                {
                    resultMaxVal = item;
                    max = f;
                }
            }
            return resultMaxVal;
        }
        
        
        private static float GetParam<T>(T param) where T : class => param switch
        {
            IFloatWrapper wrapper => wrapper.Value,
            float fl => fl,
            _ => throw new ArgumentException("Невозможно преобразовать тип")
        };

        public static void Run()
        {
            List<IFloatWrapper> list = new() { new FloatWrapper(0.5f), new FloatWrapper(7.86f), new FloatWrapper(-3.5f) };
            float resultMaxVal = list.GetMax<IFloatWrapper>(GetParam).Value;
            Console.WriteLine("Значение максимального элемента=" + resultMaxVal);
        }
    }
}
