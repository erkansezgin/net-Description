namespace DescriptionLibrary.Tests
{
    using System;
    using System.ComponentModel;
    
    [Description("Class description.")]
    public class Class
    {
        [Description("Class event description.")]
        public event EventHandler Event;

        [Description("Class field description.")]
        public string Field;

        [Description("Class property description.")]
        public string Property { get; set; }

        [Description("Class constructor description.")]
        public Class() { }

        [Description("Another class constructor description.")]
        public Class(int i, string s) { }

        [method: Description("Class method description.")]
        [return: Description("Class method return description.")]
        public int Method<T>(
            [Description("Class generic parameter description.")]T _1,
            [Description("Class parameter description.")]string _2)
        {
            return 0;
        }
    }
}
