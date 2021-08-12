using System;

namespace NFTGenerator
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PriorityAttribute : Attribute
    {
        public int Value;
        public PriorityAttribute(int val)
        {
            Value = val;
        }
    }
}
