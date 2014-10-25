using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace SymbolReader
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuleDefinition module = ModuleDefinition.ReadModule(@"C:\Users\Beeven\Documents\Visual Studio 2013\Projects\MarkdownPad2Cracker\MarkdownPad2.exe");

            TypeDefinition licenseEngine = module.Types.First(t => t.FullName == "MarkdownPad2.Licensing.LicenseEngine");
            MethodDefinition verifyLicense = licenseEngine.Methods.First(m => m.Name == "VerifyLicense");
            Console.WriteLine(verifyLicense.FullName);
            TypeDefinition license = module.Types.First(t => t.FullName == "MarkdownPad2.Licensing.License");


            var methodDateTimeParse = module.Import(typeof(System.DateTime).GetMethod("Parse", new Type[] { typeof(String) }));

            VariableDefinition loc_license = new VariableDefinition("lic", license);
            var processor = verifyLicense.Body.GetILProcessor();
            verifyLicense.Body.MaxStackSize = 7;
            verifyLicense.Body.Variables.Add(loc_license);
            var point = verifyLicense.Body.Instructions[0];


            processor.InsertBefore(point, processor.Create(OpCodes.Nop));
            processor.InsertBefore(point, processor.Create(OpCodes.Newobj, license.Methods.First(m => m.IsConstructor)));
            //processor.InsertBefore(point,processor.Create(OpCodes.Ldc_I4_6));
            processor.InsertBefore(point, processor.Create(OpCodes.Stloc_S, (byte)6));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldloc_S, (byte)6));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldstr, "beeven@hotmail.com"));
            processor.InsertBefore(point, processor.Create(OpCodes.Callvirt, license.Methods.First(m => m.Name == "set_Email")));
            processor.InsertBefore(point, processor.Create(OpCodes.Nop));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldloc_S, (byte)6));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldstr, "Beeven"));
            processor.InsertBefore(point, processor.Create(OpCodes.Callvirt, license.Methods.First(m => m.Name == "set_Name")));
            processor.InsertBefore(point, processor.Create(OpCodes.Nop));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldloc_S, (byte)6));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldstr, "2014-10-25"));
            processor.InsertBefore(point, processor.Create(OpCodes.Call, methodDateTimeParse));
            processor.InsertBefore(point, processor.Create(OpCodes.Callvirt, license.Methods.First(m => m.Name == "set_CreationDate")));
            processor.InsertBefore(point, processor.Create(OpCodes.Nop));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldloc_S, (byte)6));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldc_I4_1));
            processor.InsertBefore(point, processor.Create(OpCodes.Callvirt, license.Methods.First(m => m.Name == "set_LicenseTypeId")));
            processor.InsertBefore(point, processor.Create(OpCodes.Nop));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldarg_0));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldloc_S, (byte)6));
            processor.InsertBefore(point, processor.Create(OpCodes.Call, licenseEngine.Methods.First(m => m.Name == "set_License")));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldarg_0));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldc_I4_1));
            processor.InsertBefore(point, processor.Create(OpCodes.Call, licenseEngine.Methods.First(m => m.Name == "set_LicenseProcessed")));
            processor.InsertBefore(point, processor.Create(OpCodes.Ldc_I4_1));
            processor.InsertBefore(point, processor.Create(OpCodes.Ret));



            module.Write(@"C:\Users\Beeven\Documents\Visual Studio 2013\Projects\MarkdownPad2Cracker\MarkdownPad2.exe");

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
