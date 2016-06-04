using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ValidationDavinciCode : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            CheckDavinciCode("B1D25:01,02,03,04", "B101", 1).ToConsole();
            CheckDavinciCode("B1D25:01,02,03,04", "B101A", 1).ToConsole();
            (CheckDavinciCode("B1D25:01,02,03,04", "B105", 5) == false).ToConsole();
            (CheckDavinciCode("B1D25:01,02,03,04", "B101", 4) == false).ToConsole();
            CheckDavinciCode("B1D25:01,02,03,04", "B101", 1).ToConsole();
            CheckDavinciCode("SA1D25:01,02,03,04", "SA101", 1).ToConsole();
            CheckDavinciCode("SA1D25:01,02,03,04", "SA101B", 1).ToConsole();
            (CheckDavinciCode("SA1D25:01,02,03,04", "B101", 10) == false).ToConsole();
            (CheckDavinciCode("SA1D25:", "B101", 1) == false).ToConsole();
            CheckDavinciCode("B1D25:01,02,03,04,05,06,07,08,09,10,11", "B111", 10).ToConsole();
            (CheckDavinciCode("B1D25:01,03,05,07,09,11", "B105", 2) == false).ToConsole();
            CheckDavinciCode("B1D25:01,03,05,07,09,11", "B105", 1).ToConsole();
        }

        public bool CheckDavinciCode(string davinciCode, string dieLayer, int bomUsage)
        {
            var davicciCodeParse = new DavinciCodeParse(davinciCode);
            var dieLayerParse = new DieLayerParse(dieLayer, bomUsage);

            return !davicciCodeParse.DieType.IsNullOrEmpty()
                   && !dieLayerParse.DieType.IsNullOrEmpty()
                   && davicciCodeParse.DieType == dieLayerParse.DieType
                   && dieLayerParse.Layers != null
                   && dieLayerParse.Layers.Any()
                   && davicciCodeParse.Layers != null
                   && davicciCodeParse.Layers.Any()
                   && dieLayerParse.Layers.All(layer => davicciCodeParse.Layers.Contains(layer));
        }

        /// <summary>
        ///     B1D25:01,02,03,04
        ///     B1 : DieType
        ///     D25 : Film
        ///     Layer : 01,02,03,04
        /// </summary>
        private class DavinciCodeParse
        {
            public DavinciCodeParse(string davinciCode)
            {
                DavinciCode = davinciCode;
            }

            private string DavinciCode { get; set; }

            public string DieType
            {
                get
                {
                    var result = DavinciCode.Split(':');
                    if (result.Count() != 2)
                        return string.Empty;

                    return new Regex(@"[A-Z]+[0-9]*").Matches(result[0])[0].ToString();
                }
            }

            public List<int> Layers
            {
                get
                {
                    var result = DavinciCode.Split(':');
                    if (result.Count() != 2)
                        return null;

                    var list = new List<int>();
                    foreach (var layer in result[1].Split(','))
                    {
                        int value;
                        if (!int.TryParse(layer, out value) && value <= 0)
                            return null;

                        list.Add(value);
                    }

                    return list;
                }
            }
        }

        /// <summary>
        ///     B105A
        ///     B1 : DieType
        ///     05 : 目前層別 透過BomUsage 反推測 Layer Ex: BomUsage = 4 Layer = 02,03,04,05
        ///     A : 棟別
        /// </summary>
        private class DieLayerParse
        {
            public DieLayerParse(string dieLayer, int bomUsage)
            {
                DieLayer = dieLayer;
                BomUsage = bomUsage;
            }

            private string DieLayer { get; set; }
            private int BomUsage { get; set; }

            public string DieType
            {
                get
                {
                    var result = new Regex(@"[A-Z]+[0-9]*").Matches(DieLayer)[0].ToString();
                    if (result.Length < 2)
                        return string.Empty;

                    return result.Substring(0, result.Length - 2);
                }
            }

            public int[] Layers
            {
                get
                {
                    var result = new Regex(@"[A-Z]+[0-9]*").Matches(DieLayer)[0].ToString();
                    if (result.Length < 2)
                        return null;

                    var layerString = result.Substring(result.Length - 2, 2);
                    int value;
                    if (!int.TryParse(layerString, out value)
                        || BomUsage > value)
                        return null;

                    return Enumerable.Range(value - BomUsage + 1, BomUsage).ToArray();
                }
            }
        }
    }
}