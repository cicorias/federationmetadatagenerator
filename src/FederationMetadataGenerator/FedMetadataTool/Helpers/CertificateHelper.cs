using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace CedarLogic.Identity
{
    public class CertificateHelper
    {
        public static X509Certificate2 RetrieveCertificate(string subjectName)
        {
            X509Store store = null;
            X509Certificate2Collection certificates = null;
            X509Certificate2Collection certificates2 = null;
            try
            {
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.OpenExistingOnly);
                if (store.StoreHandle != IntPtr.Zero)
                {
                    certificates2 = store.Certificates;
                    certificates = certificates2.Find(X509FindType.FindBySubjectDistinguishedName, subjectName, true);
                    if (certificates.Count == 0)
                        throw new ArgumentException("Certificate not found: " + subjectName, "subjectName");

                    if (certificates.Count > 1)
                        throw new ArgumentException("More than one certificate found: " + subjectName, "subjectName");

                    if (certificates.Count == 1)
                    {
                            if (certificates[0].HasPrivateKey)
                            {
                                try
                                {
                                    var o = certificates[0].PrivateKey;
                                    return new X509Certificate2(certificates[0]);
                                }
                                catch (Exception ex)
                                {
                                    throw new ApplicationException("Can't read private key - ensure you have permissions", ex);
                                }
                            }
                            else
                                throw new ApplicationException("No private key on selected certificate " + subjectName);
                    }

                }
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        certificates[i].Reset();
                    }
                }

                if (certificates2 != null)
                {
                    for (int j = 0; j < certificates2.Count; j++)
                    {
                        certificates2[j].Reset();
                    }
                }

                if (store != null)
                {
                    store.Close();
                }
            }

            return null;
        }

        public static string[] GetCertificateNames()
        {
            List<string> certNames = new List<string>();
            X509Store store = null;
            try
            {
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.OpenExistingOnly);
                if (store.StoreHandle != IntPtr.Zero)
                {
                    foreach (var item in store.Certificates)
                    {
                        certNames.Add(item.Subject);
                        item.Reset();
                    }
                }

                return certNames.ToArray();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can't open cert store locally - make sure you have permissions", ex);
            }
            finally
            {
                if (store != null) store.Close();
            }

        }
    }
}
