namespace vJoyInterfaceWrap {
    using System.IO;
    using System.Reflection;

    public static class DllMain {

        public static void ExtractvJoyInstallDll(string path) {
            string _interfacePath = string.Format("{0}\\vJoyInterface.dll", Path.GetDirectoryName(path));
            if (!File.Exists(_interfacePath))
                ExtractResource(new FileInfo(_interfacePath), Win32Wrapper.Is64BitOs() ? "vJoyInterface_x64.dll" : "vJoyInterface_x86.dll", false);

            string _installPath = string.Format("{0}\\vJoyInstall.dll", Path.GetDirectoryName(path));
            if (!File.Exists(_installPath))
                ExtractResource(new FileInfo(_installPath), Win32Wrapper.Is64BitOs() ? "vJoyInstall_x64.dll" : "vJoyInstall_x86.dll", false);
        }

        private static void ExtractResource(FileInfo fi, string resource, bool isFullName = true) {
            if(!isFullName)
                resource = string.Format("{0}.{1}", typeof(DllMain).Namespace, resource);
            var toexe = fi.OpenWrite();
            var fromexe = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            const int size = 4096;
            var bytes = new byte[size];
            int numBytes;
            while(fromexe != null && (numBytes = fromexe.Read(bytes, 0, size)) > 0)
                toexe.Write(bytes, 0, numBytes);
            toexe.Close();
            if(fromexe != null)
                fromexe.Close();
        }
    }
}