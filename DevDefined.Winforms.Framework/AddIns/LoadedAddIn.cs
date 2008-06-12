using System;
using System.Reflection;

namespace DevDefined.Winforms.Framework.AddIns
{
    public class LoadedAddIn
    {
        private readonly Assembly _assembly;
        private readonly string _description;
        private readonly string _fileName;
        private readonly string _name;

        public LoadedAddIn(string name, string description, Assembly assembly, string fileName)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (assembly == null) throw new ArgumentNullException("assembly");

            _name = name;
            _description = description;
            _assembly = assembly;
            _fileName = fileName;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public Assembly Assembly
        {
            get { return _assembly; }
        }

        public string Error { get; set; }

        public string FileName
        {
            get { return _fileName; }
        }
    }
}