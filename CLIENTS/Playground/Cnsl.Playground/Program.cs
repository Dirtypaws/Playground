using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using NDesk.Options;

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
            var showHelp = false;
            List<string> names = new List<string>();
            var p = new OptionSet
            {
                {"n|names=", "The name of someone to search - to search multiple separate with a '|'", x => names.AddRange(x.Split('|')) },
                {"h|help", "show this message and exit", x => showHelp = true}

            };

            if (showHelp)
            {
                p.WriteOptionDescriptions(Console.Out);
                return;
            }
            
            Find(names);

            Console.ReadLine();

        }
        private static void Find(IEnumerable<string> names)
        {
            using (var ctx = new PrincipalContext(ContextType.Domain, DomainName))
            using (var search = new PrincipalSearcher(new UserPrincipal(ctx)))
                foreach (
                    var entity in
                        search.FindAll()
                            .Where(x => !names.Any() || names.Contains(x.DisplayName))
                            .Select(result => result.GetUnderlyingObject() as DirectoryEntry))
                {
                    Console.WriteLine("First Name: " + entity.Properties["givenName"]?.Value);
                    Console.WriteLine("Last Name: " + entity.Properties["sn"]?.Value);
                    Console.WriteLine("SAM: " + entity.Properties["samAccountName"]?.Value);
                    Console.WriteLine("Principal: " + entity.Properties["userPrincipalName"]?.Value);
                    Console.WriteLine();
                }


        }
    }
}
