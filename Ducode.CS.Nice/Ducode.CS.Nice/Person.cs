using System;
using System.Text;

namespace Ducode.CS.Nice
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendFormatLine("First name: {0}", FirstName);
            builder.AppendFormatLine("Last name: {0}", LastName);
            builder.AppendFormatLine("Address: {0}", Address);
            return builder.ToString();
        }
    }
}
