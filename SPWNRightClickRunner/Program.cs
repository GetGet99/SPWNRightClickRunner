// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;
using System;

try
{
    // create path to registry location
    string regPath = $@"spwn_auto_file\shell\Compile With SPWN";

    // add context menu to the registry
    using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(regPath))
    {
        key.SetValue(null, "Compile With SPWN");
    }

    // add command that is invoked to the registry
    using (RegistryKey key = Registry.ClassesRoot.CreateSubKey($@"{regPath}\command"))
    {
        key.SetValue(null, "cmd /k spwn build \"%1\"");
    }
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Please rerun the program as Admin");
}