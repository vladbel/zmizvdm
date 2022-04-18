using System;
using System.Collections.Generic;
using System.Reflection;

namespace cli
{
    public class BuyCommand : BaseCommand
    {
        [Option("-n")]
        [Option("-name")]
        public string Name { get; set; }
    }

    public class SellCommand : BaseCommand
    {
        [Option("-n")]
        [Option("-N")]
        [Option("-name")]
        [Option("--name")]
        public string Name { get; set; }
    }

    public class BaseCommand
    {
        public static Dictionary<string, string> GetOptions( Type t)
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    OptionAttribute optionAttribute = attr as OptionAttribute;
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
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class OptionAttribute : Attribute
    {
        public OptionAttribute( string option)
        {
            Option = option;
        }
        public string Option { get; set; }
    }
}
