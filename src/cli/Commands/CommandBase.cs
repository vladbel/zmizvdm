using System;
using System.Collections.Generic;
using System.Reflection;

namespace cli
{
    public class CommandBase
    {
        public static Dictionary<string, string> GetCliOptions(Type commandType)
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = commandType.GetProperties();
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

        public static List<string> GetCliCommands(Type commandType)
        {
            List<string> cliCommands = new List<string>();


            object[] attrs = commandType.GetCustomAttributes(true);
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

        public static bool Match(Type commandType, Command parsedCommand)

        {
            var cliCommandAttributes = GetCliCommands(commandType);

            if (!cliCommandAttributes.Contains(parsedCommand.Name))
            {
                return false;
            }
; return true;
        }
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

}
