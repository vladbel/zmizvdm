using System;
using System.Collections.Generic;
using System.Text;

namespace cli
{
    public class Command
    {
        public Command(string command)
        {
            Arguments = new List<string>();
            Options = new Dictionary<string, Option>();
            Parse(command);
        }
        public string Name { get; private set; }

        public List<string> Arguments;
        public Dictionary<string, Option> Options { get; private set; }
        private void Parse(string command)
        {
            var parts = command.Trim().Split(" ");

            Option option = null;

            foreach (string part in parts)
            {
                if (Name == null)
                {
                    Name = part;
                }
                else if (part.StartsWith("-"))
                {
                    if (option != null)
                    {
                        Options.Add(option.Name, option);
                    }
                    option = new Option();
                    option.Name = part;
                }
                else if (option == null)
                {
                    Arguments.Add(part);
                }
                else if (option != null)
                {
                    option.Arguments.Add(part);
                }
            }

            if (option != null)
            {
                Options.Add(option.Name, option);
            }
        }
    }

    public class Option
    {

        public string Name;
        public List<string> Arguments;

        public Option()
        {
            Arguments = new List<string>();
        }
    }
}
