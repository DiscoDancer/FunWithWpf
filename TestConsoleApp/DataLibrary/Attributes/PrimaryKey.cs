using System;

namespace DataLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class PrimaryKey: Attribute
    {
    }
}
