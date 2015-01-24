using System;

namespace Fangtang
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class InjectAttribute : Attribute
    {
        public InjectAttribute() { }

        public InjectAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
