using System;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class XorEncryption : AbstractExecuteModule
    {
        /// <summary>
        ///     Xor加密
        ///     解密再針對key做一次xor 操作
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var msg = "This is a message.";
            var key1 = '@';
            var sb1 = new StringBuilder();
            foreach (var c in msg)
            {
                sb1.Append((char) (c ^ key1));
            }
            Console.WriteLine(sb1.ToString());

            var key2 = "9s/*(W$37";
            var sb2 = new StringBuilder();
            for (var i = 0; i < msg.Length; i++)
            {
                sb2.Append((char) (msg[i] ^ key2[i%key2.Length]));
            }
            Console.WriteLine(sb2.ToString());
        }
    }
}