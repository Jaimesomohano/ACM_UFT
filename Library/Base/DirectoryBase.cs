using System.IO;
using System.Linq;

namespace APlus_UFT.Library.BaseLibrary
{
    public static class DirectoryBase
    {
        private static Registry registry = new Registry();

        internal const string InputFolder = "Data\\Input";
        internal const string OutputFolder = "Data\\Output";

        public static string APlusDir
        {
            get
            {
                return System.IO.Path.Combine(registry.GetValueData("Aspen Plus", "mmxeq"), "AspenPlus.exe");
            }
        }
        public static string APropDir
        {
            get
            {
                return Path.Combine(registry.GetValueData("Aspen Properties", "mmxeq"), "AspenProperties.exe");
            }
        }
        public static string APlusExampleDir
        {
            get
            {
                return Path.Combine(registry.GetValueData("Aspen Plus", "mmtop"), "Examples");
            }
        }
        public static string APropExampleDir
        {
            get
            {
                return Path.Combine(registry.GetValueData("Aspen Properties", "mmtop"), "Examples");
            }
        }
        public static string AspenModelerDir
        {
            get
            {
                return System.IO.Path.Combine(registry.GetValueData("AMSystem", "Bin"), "AspenModeler.exe");
            }
        }
        public static string ProjectDir
        {
            get
            {

                string currentFolder = Directory.GetCurrentDirectory();
                if (currentFolder.Contains("APlus_UFT"))
                {
                    currentFolder = currentFolder.Substring(0, currentFolder.IndexOf("bin"));
                }
                if (currentFolder.Contains("TestResults"))
                {
                    currentFolder = Path.Combine(currentFolder.Substring(0, currentFolder.IndexOf("TestResults")), "APlus_UFT");
                }
                return currentFolder;
            }
        }
        public static string InputDir
        {
            get
            {
                string inputDir = Path.Combine(ProjectDir, InputFolder);

                return inputDir;
            }
        }
        public static string OutputDir
        {
            get
            {
                string outputDir = Path.Combine(ProjectDir, OutputFolder);

                return outputDir;
            }
        }
        public static string CommandLine
        {
            get
            {
                string commandLine = "C:\\Windows\\System32\\cmd.exe";
                return commandLine;
            }
        }
        public static string ResultsDir => Path.Combine(ProjectDir, "Results\\");
        public static string LogDir => Path.Combine(ProjectDir, "Log\\");
        public static string DebugLogDir => Path.Combine(ProjectDir, "DebugLog\\");
        public static string ReportDir => Path.Combine(ProjectDir, "Report\\");
        public static string GenerateInputFileDir(string caseName, string fileName)
        {
            string inputFileDir = Path.Combine(InputDir, caseName);
            if (!Directory.Exists(inputFileDir))
            {
                Directory.CreateDirectory(inputFileDir);
            }
            return Path.Combine(inputFileDir, fileName);
        }
        public static string GenerateOutputFileDir(string caseName, string fileName)
        {
            if (!Directory.Exists(OutputDir))
            {
                Directory.CreateDirectory(OutputDir);
            }
            string outPutFileDir = Path.Combine(OutputDir, caseName);
            if (!Directory.Exists(outPutFileDir))
            {
                Directory.CreateDirectory(outPutFileDir);
            }
            return Path.Combine(outPutFileDir, fileName);
        }
        public static string GenerateExampleFileDir(string product, string fileName)
        {
            string exampleFileDir = Path.Combine(product, fileName);

            return exampleFileDir;
        }
    }
}
