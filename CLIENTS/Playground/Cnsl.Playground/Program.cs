using System;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace Cnsl.Playground
{
    class Program
    {
        private static string _domainName;

        private static string DomainName
        {
            get
            {
                if (string.IsNullOrEmpty(_domainName))
                {
                    var config = ConfigurationManager.AppSettings.Get("ADDomain");
                    if(string.IsNullOrEmpty(config))
                        throw new ConfigurationErrorsException("ADDomain was not provided in configuration");

                    _domainName = config;
                }

                return _domainName;
            }
        }

        static void Main(string[] args)
        {
            using (var ctx = new PrincipalContext(ContextType.Domain, DomainName))
            using (var search = new PrincipalSearcher(new UserPrincipal(ctx)))
                foreach (var entity in search.FindAll().Select(result => result.GetUnderlyingObject() as DirectoryEntry))
                {
                    Console.WriteLine("First Name: " + entity.Properties["givenName"]?.Value);
                    Console.WriteLine("Last Name: " + entity.Properties["sn"]?.Value);
                    Console.WriteLine("SAM: " + entity.Properties["samAccountName"]?.Value);
                    Console.WriteLine("Principal: " + entity.Properties["userPrincipalName"]?.Value);
                    Console.WriteLine();
                }

            Console.ReadLine();

        }
    }
}
