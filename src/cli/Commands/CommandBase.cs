using System;
using System.Collections.Generic;
using System.Reflection;

namespace cli
{
    public class CommandBase
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CliOptionAttribute : Attribute
    {
        public CliOptionAttribute( string option)
        {
            Option = option;
        }
        public string Option { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CliCommandAttribute : Attribute
    {
        public CliCommandAttribute(string option)
        {
            Option = option;
        }
        public string Option { get; set; }
    }

    public static class CliCommandExtention
    {
        public static Dictionary<string, string> GetCliOptions(this CommandBase command)
        {
            var t = command.GetType();
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    CliOptionAttribute optionAttribute = attr as CliOptionAttribute;
                    if (optionAttribute != null)
                    {
                        string propName = prop.Name;
                        string option = optionAttribute.Option;

                        _dict.Add(option, propName);
                    }
                }
            }

            return _dict;
        }

        public static List<string> GetCliCommands(this CommandBase command)
        {
            var t = command.GetType();
            List<string> cliCommands = new List<string>();


            object[] attrs = t.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                CliCommandAttribute optionAttribute = attr as CliCommandAttribute;
                if (optionAttribute != null)
                {
                    string option = optionAttribute.Option;

                    cliCommands.Add(option);
                }
            }
            return cliCommands;
        }

        public static bool Match ( this CommandBase command, Command parsedCommand)

        {
            var cliCommandAttributes = command.GetCliCommands();

            if (!cliCommandAttributes.Contains(parsedCommand.Name))
            {
                return false;
            }
;            return true;
        }
    }
}
