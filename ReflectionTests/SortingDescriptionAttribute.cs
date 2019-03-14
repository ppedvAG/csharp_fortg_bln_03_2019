using System;

namespace ReflectionTests
{
    [System.AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    internal class SortingDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public SortingDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}