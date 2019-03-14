using System;

namespace BookLibrary
{
    [System.AttributeUsage(AttributeTargets.Property,AllowMultiple = false, Inherited = true)]
    public class SortButtonTitleAttribute : Attribute
    {
        public string Label { get; set; }

        public SortButtonTitleAttribute(string label)
        {
            Label = label;
        }
    }
}