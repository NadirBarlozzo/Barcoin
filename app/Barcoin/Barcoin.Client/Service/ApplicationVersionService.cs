using System.Diagnostics;
using System.Reflection;

namespace Barcoin.Client.Service
{
    public class ApplicationVersionService
    {
        private static FileVersionInfo fvi =
            FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

        public static string ProductVersion
        {
            get { return fvi.ProductVersion; }
        }

        public static string LegalCopyright
        {
            get { return fvi.LegalCopyright; }
        }

        public static string CompanyName
        {
            get { return fvi.CompanyName; }
        }

        public static string Comments
        {
            get { return fvi.Comments; }
        }

        public static string FileDescription
        {
            get { return fvi.FileDescription; }
        }
        public static string FileName
        {
            get { return fvi.FileName; }
        }

        public static string FileVersion
        {
            get { return fvi.FileVersion; }
        }

        public static string LegalTrademarks
        {
            get { return fvi.LegalTrademarks; }
        }

        public static string OriginalFilename
        {
            get { return fvi.OriginalFilename; }
        }

        public static string ProductName
        {
            get { return fvi.ProductName; }
        }
        public static string Language
        {
            get { return fvi.Language; }
        }

        public static int ProductMajorPart
        {
            get { return fvi.ProductMajorPart; }
        }

        public static int ProductMinorPart
        {
            get { return fvi.ProductMinorPart; }
        }

    }
}
