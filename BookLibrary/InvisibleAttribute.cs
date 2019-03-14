using System;

namespace BookLibrary
{
   
    [System.AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited = true)]
    public class InvisibleAttribute : Attribute
    {
    }
}