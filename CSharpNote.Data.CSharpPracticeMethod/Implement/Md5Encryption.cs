using System;
using System.Security.Cryptography;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class Md5Encryption : AbstractExecuteModule
    {
        private const string SALT = "S9@)#IK9FI09";

        [AopTarget]
        public override void Execute()
        {
            var source = "abcdefg";
            var md5 = MD5.Create();
            var encrypt = md5.ComputeHash(Encoding.Default.GetBytes(source + SALT));
            BitConverter.ToString(encrypt).ToConsole();
        }
    }
}