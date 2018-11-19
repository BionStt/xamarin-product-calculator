using System;
using System.IO;
using System.Reflection;

namespace ProductCalculator.Services
{
    public class DataService
    {
        private string _assemblyName;
        public string AssemblyName
        {
            get
            {
                return _assemblyName ?? (_assemblyName = typeof(App).GetTypeInfo().Assembly.GetName().Name);
            }
        }

        private static DataService _instance;
        public static DataService Instance
        {
            get { return _instance ?? (_instance = new DataService()); }
        }

        private DataService() { }

        public Stream ReadTextFromResourceFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(
                string.Format("{0}.Data.{1}", AssemblyName, filename));
            return stream;
        }

        public string ReadTextFromStream(string filename)
        {
            var stream = ReadTextFromResourceFile(filename);
            var streamReader = new StreamReader(stream);
            var textContent = streamReader.ReadToEnd();
            return textContent;
        }
    }
}
