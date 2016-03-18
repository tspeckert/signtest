using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PfxToSnk
{
    class Program
    {
        static void Main(String[] args)
        {
            String snkFile = args[0];
            String pfxFile = args[1];
            String password = args[2];
            Byte[] pfxBytes = File.ReadAllBytes(pfxFile);
            var certificate = new X509Certificate2(pfxBytes, password, X509KeyStorageFlags.Exportable);
            var privateKey = (RSACryptoServiceProvider)certificate.PrivateKey;
            Byte[] snkBytes = privateKey.ExportCspBlob(true);
            File.WriteAllBytes(snkFile, snkBytes);
        }
    }
}
