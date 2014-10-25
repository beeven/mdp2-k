using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkdownPad2.Licensing
{
    public class LicenseEngine
    {
        public License License; 
        private License Decrypt(string payLoad)
        {
            License result = new License(){
                Email = "beeven@Hotmail.com",
                Name = "Beeven",
                Product = "MarkdownPad2",
                CreationDate = DateTime.Parse("2014-10-25"),
                LicenseTypeId = 1
            };
            return result;
        }
    }
}
