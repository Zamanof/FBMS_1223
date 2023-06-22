using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace AppDomain_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(AppDomain.CurrentDomain);
            //Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

            PermissionSet permission =
                new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            permission.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read,
                @"c://"));
            //ThirdPartySuperLibrary badProgramm = new ThirdPartySuperLibrary();
            //badProgramm.Babbat();
            var appSetup = new AppDomainSetup() {ApplicationBase = Environment.CurrentDirectory };
            var domain = AppDomain.CreateDomain("Secure domain", null, appSetup, permission);
            var type = typeof(ThirdPartySuperLibrary);
            //Console.WriteLine(type.Assembly.FullName);
            //Console.WriteLine(parameters[0].Name);

            domain.CreateInstance(type.Assembly.FullName, type.FullName);
            //var some = type.GetMethod("Babbat");
            //var parameters = some.GetParameters();
            //foreach (var parameter in parameters)
            //{
            //    Console.WriteLine(parameter.ParameterType.FullName);
            //}

            AppDomain.Unload(domain);

        }
    }

    public class ThirdPartySuperLibrary
    {
        public ThirdPartySuperLibrary()
        {
            Console.WriteLine("I am Xatker. I am Anonymous. Oqurlayacam datalarini!");
        }
        public void Babbat(int A, float b)
        {
            Console.WriteLine("Dehshet, Felaket, Qismet, Hormet");
        }
        ~ThirdPartySuperLibrary()
        {
            Console.WriteLine("Ha. HA. hA. Oqurladim datalarini!");
        }
    }
}
