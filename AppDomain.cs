using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SamplesProjects
{
    public class Class1
    {
    }

    public class Class2
    {
    }

    [Serializable]
    public class ThirdParty
    {
        public ThirdParty()
        {
            Console.WriteLine("Third Party loaded");
            System.IO.File.Create(@"c:\x.txt");
        }

        ~ThirdParty()
        {
            Console.WriteLine("Third Party unloaded");
        }
    }

    class CAppDomain
    {
        public void MainFunc()
        {
            //AppDomain is a logical isolated container inside a process

            #region Define domain permissions
            var perm = new PermissionSet(PermissionState.None);
            perm.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            perm.AddPermission(new FileIOPermission(FileIOPermissionAccess.NoAccess, @"c:\"));
            #endregion

            #region Define domain setup
            var setup = new AppDomainSetup();
            setup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            #endregion

            //created new domain with limited permissions
            AppDomain securedDomain = AppDomain.CreateDomain("securedDomain", null, setup, perm);
            try
            {
                Type thirdParty = typeof(ThirdParty);
                //created the third party dll in the new domain
                securedDomain.CreateInstanceAndUnwrap(thirdParty.Assembly.FullName, thirdParty.FullName);
            }
            catch (Exception)
            {
                AppDomain.Unload(securedDomain);
            }

            //stay in current domain with full permissions
            Class1 obj1 = new Class1();
            Class2 obj2 = new Class2();
            Console.ReadLine();
        }
    }
}
