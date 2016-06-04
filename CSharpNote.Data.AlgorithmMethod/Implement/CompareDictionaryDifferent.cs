using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class CompareDictionaryDifferent : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var address1 = "C:\\Users\\WeiNang\\Desktop\\199";
            var address2 = "C:\\Users\\WeiNang\\Desktop\\28";

            var address1Files = GetFileDictionary(address1);
            var address2Files = GetFileDictionary(address2);

            var files = address1Files.Concat(address2Files)
                .GroupBy(item => item.FileName)
                .Where(g => g.Count() != 2)
                .Select(g => g.First())
                .GroupBy(item => item.DictionaryName)
                .ToDictionary(g => g.Key, g => g.Select(item => item.FileName).ToList())
                .ToList();

            var outputAddress = "C:\\Users\\WeiNang\\Desktop\\Different28And199.txt";
            File.WriteAllLines(outputAddress,
                files.SelectMany(file => file.Value
                    .Select(item => string.Format("{0}-{1}", file.Key, item)))
                    .ToArray());
        }

        private static List<FileItem> GetFileDictionary(string address)
        {
            return Directory.GetFiles(address)
                .Select(file =>
                {
                    var items = file.Split('\\');
                    var result = file.Split('\\').Skip(items.Count() - 2).ToList();
                    return new FileItem
                    {
                        DictionaryName = result.First(),
                        FileName = result.Skip(1).First()
                    };
                })
                .ToList();
        }

        public class FileItem
        {
            public string DictionaryName { get; set; }
            public string FileName { get; set; }
        }
    }
}