using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace aural_library.Logic
{
    public class FileHandler
    {
        private string auralFolderName = "aural";
        private string auralConfigFileName = "auralConfig.json";

        public string GetMyDocumentLocation()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public string GetAuralMyDocumentLocation()
        {
            return Path.Combine(GetMyDocumentLocation(), auralFolderName);
        }

        public string GetAuralConfigLocation()
        {
            return Path.Combine(GetAuralMyDocumentLocation(), auralConfigFileName);
        }
    }
}
