using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Xml.Linq;
using System.Net.Sockets;
using ConsoleDisplay.Common;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Core.Implements;
using ConsoleDisplay.Data.CSharpPracticeMethod.SubClass;

namespace ConsoleDisplay.Data.CSharpPracticeMethod
{
    [DisplayClassAttribue]
    public class CSharpPracticeMethodRepository : AbstractMethodRepository
    {
        
        [DisplayMethod]
        public void LamdaPratice()
        {
            Console.WriteLine("method like jquery");
            ((Action<double, double>)((x, y) =>
            {
                Console.WriteLine(2.0 * x * y - 1.5 * x);
            }))(2.0, 3.0);

            Console.WriteLine("anoymous object with lambda");
            var terminator = new
            {
                Typ = "T1000",
                Health = 100,
                Hit = (Func<double, double>)((x) =>
                {
                    return 100.0 * Math.Exp(-x);
                })
            };
        }

        [DisplayMethod]
        public void CountIntLength()
        {
            //數字長度
            int i = 165446546;
            Console.WriteLine("int i = 165446546 長度為{0}", Convert.ToString(i).Count());
        }

        [DisplayMethod]
        public void AndOperator()
        {
            //&運算
            Console.WriteLine("&運算 0x00001111 & 0x11110000 = 0x{0:x8}", 0x00001111 & 0x11110000);
        }

        [DisplayMethod]
        public void InverseNum()
        {
            //~ 可以取數值補數0x00000000 to 0xffffffff
            Console.WriteLine("取補數");
            int[] values = { 0, 0xfffff };
            foreach (int v in values)
            {
                Console.WriteLine("~0x{0:x8} = 0x{1:x8}", v, ~v);
            }
        }

        [DisplayMethod]
        public void DoublePuzzleSymbol()
        {
            //?? 如果左邊為空就設定右邊 如果左邊不為空就設定左邊
            string s = null ?? "test";
            Console.WriteLine("string s = null ?? test\ns = {0}", s);
        }

        [DisplayMethod]
        public void SplitChar()
        {
            string targetString = "Test#Hello#World#Test";
            string[] spliteStrings = targetString.Split("#".ToCharArray());
            for (int i = 0; i < spliteStrings.Count(); i++)
            {
                Console.WriteLine(spliteStrings.Count());
                Console.WriteLine(spliteStrings[i]);
            }
        }

        [DisplayMethod]
        public void ExportTxt()
        {
            string path = @"C:\Users\kewos\Desktop\export.txt";
            if (!System.IO.File.Exists(path))
                using (System.IO.File.Create(path)) { }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
            {
                for (int i = 1; i <= 100; i ++)
                    sw.WriteLine("<key name=\"Level {0}\" value=\"{1}\"/>", i, i);
            }
        }

        [DisplayMethod]
        public void DynamicCode()
        {
            string FooInterface = @"
            class Foo : FooLibrary.IPrint {
                public void Print() {
                    System.Console.WriteLine(""Hello from class Foo"");
                }
            }";

            CodeDomProvider cpd = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("運算元操作.dll");
            cp.GenerateExecutable = false;

            // Invoke compilation.
            CompilerResults cr = cpd.CompileAssemblyFromSource(cp, FooInterface);
            Assembly assembly = cr.CompiledAssembly;

            Type fType = assembly.GetTypes()[0];
            Type iType = fType.GetInterface("FooLibrary.IPrint");

            if (iType != null)
            {
                //FooLibrary.IPrint foo = (FooLibrary.IPrint)assembly.CreateInstance(fType.FullName);
                //foo.Print();
            }
        }

        private interface IPrint
        {
            void Print();
        }

        [DisplayMethod]
        public void PassAnonymousParameter()
        {
            HandleAnonymousParameter(
                new List<dynamic>()
                {
                    new
                    {
                        Name = "John",
                        Speak = (Action<string>)((name) =>
                        {
                            Console.WriteLine("MyName is {0}", name);
                        })
                    },
                    new
                    {
                        Name = "Nancy",
                        Speak = (Action<string>)((name) =>
                        {
                            Console.WriteLine("MyName is {0}", name);
                        })
                    },
                    new
                    {
                        Name = "Kent",
                        Speak = (Action<string>)((name) =>
                        {
                            Console.WriteLine("MyName is {0}", name);
                        })
                    },
                }
            );
        }

        private void HandleAnonymousParameter(dynamic anonymousList)
        {
            foreach (dynamic anonymousPerson in anonymousList)
            {
                anonymousPerson.Speak(anonymousPerson.Name);
            }
        }

        [DisplayMethod]
        public void LinqMutiFrom()
        {
            string[] strs = 
            {
                "asdf sdfsadfas asdfsadf d dsdf asss",
                "asdf qq s vb"
            };

            foreach (var word in (from str in strs
                                  from word in str.Split(' ')
                                  select word).Distinct())
            {
                Console.WriteLine(word);
            }

            foreach (var word in strs.SelectMany(str => str.Split(' ')))
            {
                Console.WriteLine(word);
            }
        }

        [DisplayMethod]
        [System.ComponentModel.Description("All 範例")]
        public void PracticeLinqAllMethod()
        { 
            List<dynamic> rules = new List<dynamic>()
            {
                new
                {
                    Test = (Func<dynamic, bool>)(e => e.Name == "aa"),
                    Message = "He isnt aa"
                },
                new
                {
                    Test = (Func<dynamic, bool>)(e => e.ID != 0),
                    Message = "Without Indentify"
                },
                new
                {
                    Test = (Func<dynamic, bool>)(e => e.Age > 18),
                    Message = "Age dont enought"
                },
            };

            var People = new
                {
                    Name = "aa",
                    ID = 485489,
                    Age = 25
                };

            bool conform = rules.All(rule => rule.Test(People));

            if (conform)
            {
                foreach (var failState in rules.Where(rule => rule.Test(People) == false))
                {
                    Console.WriteLine(failState.Message);
                }
                
            }
        }

        [DisplayMethod]
        public void StringJoinAndSplit()
        {
            string s = @"safdasd@fw#opfjkdsokjgpoijegrij$jjrgeoe$r";
            string[] ss = s.Split(new [] {'@','#','$'} );
            Console.WriteLine(string.Join("~~~~", ss));
        }

        [DisplayMethod]
        public void PracticeLinqJoinGeneration()
        { 
            var employees = new List<dynamic> {
				new { ID=1, Name="Scott", DepartmentID=1 },
				new { ID=2, Name="Poonam", DepartmentID=1 },
				new { ID=3, Name="Andy", DepartmentID=2}
			};

            var departments = new List<dynamic> {
				new { ID=1, Name="Engineering" },
				new { ID=2, Name="Sales" },
				new { ID=3, Name="Skunkworks" }
			};

            foreach (var data in from d in departments
                                 join e in employees on d.ID equals e.DepartmentID
                                     into eg
                                 from e in eg.DefaultIfEmpty()
                                 select new
                                 {
                                     DepartmentName = d.Name,
                                     Employee = (e == null) ? "" : e.Name
                                 }
            )
            {
                Console.WriteLine("Department:{0} Employee:{1}", data.DepartmentName, data.Employee);
            }

        }

        [DisplayMethod]
        public void LinqToXmlPratice()
        {
            XDocument doc = new XDocument(
                new XElement("Processes",
                    from p in System.Diagnostics.Process.GetProcesses()
		            orderby p.ProcessName ascending 
		            select new XElement("Process" , 
					    new XAttribute("Name" , p.ProcessName) ,
					    new XAttribute("PID" , p.Id)
                    )
                ));

            foreach (var p in from e in doc.Descendants("Process")
                              where e.Attribute("Name").Value == "chrome"
                              orderby (int)e.Attribute("PID") ascending
                              select (int)e.Attribute("PID"))
            {
                Console.WriteLine("PID:{0}", p);
            }
        }

        [DisplayMethod]
        public void LinqGroup()
        { 
            var employees = new List<dynamic> {
				new { ID=1, Name="Scott", DepartmentID=1 },
				new { ID=2, Name="Poonam", DepartmentID=1 },
				new { ID=3, Name="Andy", DepartmentID=2}
			};

            foreach (var data in from e in employees
                                 group e by e.DepartmentID into eg
                                 select new
                                 {
                                     DepartmentID = eg.Key,
                                     employees = eg
                                 })
            {
                Console.WriteLine(data.DepartmentID);
                foreach(var groupData in data.employees)
                {
                    Console.WriteLine("{0},{1},{2}",groupData.ID, groupData.Name, groupData.DepartmentID);
                }
            }
        }

        [DisplayMethod]
        public void ParallelForeach()
        {
            object obj = new object();
            object obj1 = new object();
            int count = 0;
            Parallel.For(1, 10 + 1, (num) =>
                {
                    lock (obj)
                    {
                        Parallel.For(1, num + 1, (num1) =>
                        {
                            lock (obj1)
                            {
                                count += num1;
                            }
                        });
                    }
                });
            Console.WriteLine(count);

            Parallel.ForEach(Enumerable.Range(0, 10000), (num, state) =>
                {
                    lock (obj)
                    {
                        if (num == 500) state.Break();
                        Console.WriteLine(num);
                    }
                });
        }

        [DisplayMethod]
        public void LinqSelectMany()
        {
            PetOwner[] petOwners = 
                    { new PetOwner { Name="Higa, Sidney", 
                          Pets = new List<string>{ "Scruffy", "Sam" } },
                      new PetOwner { Name="Ashkenazi, Ronen", 
                          Pets = new List<string>{ "Walker", "Sugar" } },
                      new PetOwner { Name="Price, Vernette", 
                          Pets = new List<string>{ "Scratches", "Diesel" } } };

            Console.WriteLine("Using SelectMany():");
   
            foreach (string pet in petOwners.SelectMany(petOwner => petOwner.Pets))
            {
                Console.WriteLine(pet);
            }

            Console.WriteLine("\nUsing Select():");

            foreach (List<String> petList in petOwners.Select(petOwner => petOwner.Pets))
            {
                foreach (string pet in petList)
                {
                    Console.WriteLine(pet);
                }
                Console.WriteLine();
            }

        }

        private class PetOwner
        {
            public string Name { get; set; }
            public List<String> Pets { get; set; }
        }

        [DisplayMethod]
        public void LinqAllVsAny()
        {
            string[] words = { "believe", "relief", "receipt", "field" };
            // if (state1 || state2 || state3 || state4)
            bool CheckByOr = "believe".Contains("pt") || "relief".Contains("pt") || "receipt".Contains("pt") || "field".Contains("pt");
            bool CheckByAny = words.Any(w => w.Contains("pt"));

            Console.WriteLine("CheckByOr and CheckByAny have same state : {0}", (CheckByOr == CheckByAny));

            // if (state1 && state2 && state3 && state4)
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };
            bool CheckByAll = numbers.All(n => n % 2 == 1);
            bool CheckByAnd = 
                (1 % 2 == 1 && 11 % 2 == 1 && 3 % 2 == 1 && 19 % 2 == 1 && 41 % 2 == 1 && 65 % 2 == 1 );

            Console.WriteLine("CheckByAll and CheckByAnd have same state : {0}", (CheckByAll == CheckByAnd));
        }

        [DisplayMethod]
        public void CalculatePrimesWithParallelForeach()
        {
            int maxNumber = 500000;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            Parallel.ForEach(Enumerable.Range(2, maxNumber), (num) =>
                {
                    lock (this)
                    {
                        Boolean isPrime = num == 2 || Enumerable.Range(2, (int)Math.Sqrt(num)).All(testNum => num % testNum != 0);
                        if (isPrime) Console.WriteLine(num);
                    }
                });
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        [DisplayMethod]
        public void CalculatePrimesWithLinq()
        {
            int maxNumber = 500000;

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            foreach (var prime in from n in Enumerable.Range(2, maxNumber -1)
                                  where n == 2 || Enumerable.Range(2, (int)Math.Sqrt(n)).All(testNum => n % testNum != 0)
                                  select n)
            {
                Console.WriteLine(prime);
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        [DisplayMethod]
        public void CalculatePrimesWithParallelLinq()
        {
            int maxNumber = 10000;
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();
            foreach (var prime in 
                from n in Enumerable.Range(2, maxNumber - 1)
                .AsParallel()
                .AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                where n == 2 || Enumerable.Range(2, (int)Math.Sqrt(n)).All(testNum => n % testNum != 0)
                select n)
            {
                Console.WriteLine(prime);
            }
            stopwatch.Stop();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }

        [DisplayMethod]
        public void PLinqReSourceCompete()
        {
            int counter1 = 0;

            //使用Interlocked類別進行資料鎖定
            var query1 = (from num in Enumerable.Range(0, 10000).AsParallel()
                          where (System.Threading.Interlocked.Increment(ref counter1) > 10000)
                          select num).ToArray();

            Console.WriteLine("lock resource times:{0}", counter1);

            int counter2 = 0;
            var query2 = (from num in Enumerable.Range(0, 10000).AsParallel()
                          where (counter2 ++ > 10000)
                          select num).ToArray();

            Console.WriteLine("without locked resource times:{0}", counter2);
        }

        [DisplayMethod]
        public void StringToUnicode()
        {
            var number = 100;
            Console.WriteLine("二進制:{0}", Convert.ToString(number, 2));
            Console.WriteLine("八進制:{0}", Convert.ToString(number, 8));
            Console.WriteLine("二進制:{0}", Convert.ToString(number, 10));
            Console.WriteLine("十六進制:{0}", Convert.ToString(number, 16));

            Console.WriteLine("十六進制:{0}", number.ToString("X"));
            Console.WriteLine("長度4 十六進制:{0}", number.ToString("X4"));
        }

        [DisplayMethod]
        public void FisherYatesShuffle()
        {
            Random r = new Random();
            var items = Enumerable.Range(1, 52).ToList();
            for (int i = 0; i < items.Count() - 1; i ++)
            {
                Swap(items, i, r.Next((i + 1), items.Count()));
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private List<int> Swap(List<int> items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
            return items;
        }

        [DisplayMethod]
        public void LinqGroupBy()
        {
            List<dynamic> students = new List<dynamic> { 
                new { name = "Huadi", score = 90, id = "10001", phone = "0987654321", location = "A"},
                new { name = "Jason", score = 80, id = "10002", phone = "0987654324", location = "B"},
                new { name = "Tim", score = 85, id = "10003", phone = "0987654323", location = "D"},
                new { name = "Vicky", score = 47, id = "10004", phone = "0987654326", location = "C"},
                new { name = "Anny", score = 65, id = "10005", phone = "0987654322", location = "A"},
                new { name = "Eric", score = 43, id = "10006", phone = "0987654325", location = "A"} 
            };

            foreach (var groupStudent in
                from student in students
                where student.location.StartsWith("A")
                group student by student.score > 60 into g
                select 
                new 
                { 
                    location = g.Key,
                    students = g.ToList()
                }
            )
            {
                Console.WriteLine("Group - {0} :", groupStudent.location);
                foreach (var student in groupStudent.students)
                {
                    Console.WriteLine("Name = \"{0}\", Score = {1}", student.name, student.score);
                }
            }
        }

        private class A
        {
            public string name { get; set; }
            public int id { get; set; }
        }

        [DisplayMethod]
        public void TestLet()
        {
            List<A> As = new List<A>();

            foreach (var num in Enumerable.Range(0, 10))
            {
                As.Add(new A() { name = num.ToString(), id = num });
            }

            foreach (var item in 
                from a in As
                let hihi = a.name + "fffff"
                select new { hihi, name = a.name, id = a.id }
            )
            {
                Console.WriteLine("{0}{1}{2}",item.hihi, item.name, item.id);
            }
        }

        [DisplayMethod]
        public void LinqAggregate()
        {
            //get all element sum
            var sum = Enumerable.Range(1, 10).Aggregate((a, b) => a + b);
            Console.WriteLine(sum);

            var chars = new[] { "a", "b", "c", "d" };
            var csv = chars.Aggregate((a, b) => a + ',' + b);
            // Output a,b,c,d
            Console.WriteLine(csv);

            var multipliers = new[] { 10, 20, 30, 40 };
            var multiplied = multipliers.Aggregate(5, (a, b) => 
            { 
                return a * b; 
            });
            //Output 1200000 ((((5*10)*20)*30)*40)
            Console.WriteLine(multiplied);
        }

        [DisplayMethod]
        public void LastPosition()
        {
            int leak = 0;
            var killStep = 3;
            var total = Enumerable.Range(1, 42).ToList();
            while (total.Count > killStep)
            {
                total = GetResult(total, killStep, ref leak);
            }

            total.ForEach(num => Console.WriteLine(num));
        }

        private List<int> GetResult(List<int> total, int killStep, ref int leak)
        {
            var tmpLeak = leak;
            leak = killStep - ((total.Count + tmpLeak) % killStep);
            return total.Where(num => (total.FindIndex(index => index == num) + tmpLeak + 1) % killStep != 0).ToList();
        }

        [DisplayMethod]
        public void TestParams()
        {
            UseParams(1, "aaa", true, new object(), null);
        }

        private void UseParams(params object[] items)
        {
            foreach (var item in items)
            {
                if (item is int) Console.WriteLine("int");
                if (item == null) Console.WriteLine("null");
                if (item is object) Console.WriteLine("object");
                if (item is string) Console.WriteLine("string");
                if (item is bool) Console.WriteLine("bool");
            }
        }

        [DisplayMethod]
        public void PassParamWithParamName()
        {
            PassParam(a: 1, b: "2", c: true);
            PassParam(c: true, b: "2", a: 1);
        }

        private void PassParam(int a, string b, bool c)
        {
            Console.WriteLine("{0}{1}{2}", a, b, c);
        }

        [DisplayMethod]
        public void Stack()
        {

            // Construct a ConcurrentQueue.
            System.Collections.Concurrent.ConcurrentQueue<int> cq = new System.Collections.Concurrent.ConcurrentQueue<int>();
            
            // Populate the queue.
            for (int i = 0; i < 10000; i++) cq.Enqueue(i);

            // Peek at the first element.
            int result;
            if (!cq.TryPeek(out result))
            {
                Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
            }
            else if (result != 0)
            {
                Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
            }

            int outerSum = 0;
            // An action to consume the ConcurrentQueue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (cq.TryDequeue(out localValue)) localSum += localValue;
                System.Threading.Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);
        }

        [DisplayMethod]
        public void CompareFindAllWithWhere()
        {
            //find is better than where when collection is list 

            var numbers = Enumerable.Range(1, 1000000).ToList();

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var testFindAll = numbers.FindAll(number => (number % 2) == 0);
            sw.Stop();    

            var sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            var testWhere = numbers.Where(number => (number % 2) == 0).ToList();
            sw1.Stop();

            Console.WriteLine("where{0}, findall{1}", sw.ElapsedMilliseconds, sw1.ElapsedMilliseconds);
        }

        [DisplayMethod]
        public void YieldPratice()
        {
            ChatPipeLine pipe = new ChatPipeLine();
            pipe.Collect(true, true);
            pipe.Collect(true, true);
            pipe.Collect(true, true);
            pipe.Collect(true, true);
            pipe.ReleaseAll();
        }

        [DisplayMethod]
        public void ExplicitImplicitMethod()
        {
            //隱含轉換
            TypeConvert obj1 = "test1";
            Console.WriteLine(obj1.ToString());

            //明確轉換
            StringBuilder sb = new StringBuilder("test2");
            TypeConvert obj2 = (TypeConvert)sb;

            //隱含轉換
            if (obj2)
            {
                Console.WriteLine(obj2.ToString());
            }

            Console.Read();
        }

        [DisplayMethod]
        public void RealProxy()
        {
            var baby = LoggingProxy.Wrap(new Baby());
            Console.WriteLine("Name = {0}", baby.Name);

            try
            {
                baby.Sleep();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = {0}", e.Message);
            }
        }

        [DisplayMethod]
        public void AwaitPratice()
        {
            Console.WriteLine("start");
            var primeListAsync = PrintPrimeAsync(1000);
            Console.WriteLine("end");

            foreach (var prime in primeListAsync.Result)
            {
                Console.WriteLine(prime);
            }
        }

        private async Task<List<int>> PrintPrimeAsync(int maxNumber)
        {
            TaskCompletionSource<List<int>> tcs = new TaskCompletionSource<List<int>>();
            await Task.Run(() =>
            {
                var query = Enumerable.Range(2, maxNumber)
                            .Where( x =>
                                x == 2 ||
                                Enumerable.Range(2, (int)Math.Sqrt(x)).All(y => x % y != 0));
                tcs.SetResult(query.ToList());
            });

            return await tcs.Task;
        }

        [DisplayMethod]
        public void AwaitPratice2()
        {
            var awaitTask = AwaitTest();
            Console.WriteLine(awaitTask.Result);
        }

        private async Task<string> AwaitTest()
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
                tcs.SetResult("result");
            });

            return await tcs.Task;
        }

        [DisplayMethod]
        public void PingReply()
        {
            System.Net.NetworkInformation.Ping x = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply reply = x.Send(System.Net.IPAddress.Parse("127.0.0.1"));

            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                Console.WriteLine("Address is accessible");
        }

        /// <summary>
        /// 透過TcpClient傳入IpAddress Port建立連線
        /// </summary>
        [DisplayMethod]
        public void TcpPingTest()
        {
            try
            {
                Int32 port = 0;
                string ipAddress = "127.0.0.1";
                TcpClient client = new TcpClient(ipAddress, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("test");

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", "test");

                data = new Byte[256];

                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

        /// <summary>
        /// 效能測試 List And Array
        /// </summary>
        [DisplayMethod]
        public void PerformanceBetweenListAndArray()
        {
            List<int> list = new List<int>();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }
            sw.Stop();

            Console.Write("List:{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            sw.Reset();

            sw.Start();
            int[] array = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                array[i] = i;
            }
            sw.Stop();
            Console.Write("Array:{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            Console.ReadLine();
        }

        /// <summary>
        /// 效果測試For and Foreach
        /// </summary>
        [DisplayMethod]
        public void PerformanceBetweenForAndForeach()
        {
            List<int> Count = new List<int>();
            List<int> lst1 = new List<int>();
            List<int> lst2 = new List<int>();
            List<int> lst3 = new List<int>();

            for (int i = 0; i < 100000; i++) Count.Add(i);
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < Count.Count; i++) lst1.Add(i);
            sw.Stop();
            Console.Write("for:{0},{1}", sw.ElapsedTicks, Environment.NewLine);

            sw.Restart();
            foreach (int x in Enumerable.Range(0, 10000)) lst2.Add(x);
            sw.Stop();
            Console.Write("foreach:{0},{1}", sw.ElapsedTicks, Environment.NewLine);

            sw.Restart();
            Enumerable.Range(0, 10000).ToList().ForEach(x => lst3.Add(x));
            sw.Stop();
            Console.Write("foreach:{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            Console.ReadLine();
        }

        /// <summary>
        /// 效能測試 Struct and Class
        /// </summary>
        [DisplayMethod]
        public void PerformanceBetweenStructAndClass()
        {
            const int MAX = 10000;

            MyStructure[] objStruct = new MyStructure[MAX];
            MyClass[] objClass = new MyClass[MAX];

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < MAX; i++)
            {
                objStruct[i] = new MyStructure { FirstName = "test", LastName = "test" };
            }
            sw.Stop();
            Console.Write("struct :{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            sw.Restart();

            for (int i = 0; i < MAX; i++)
            {
                objClass[i] = new MyClass { FirstName = "test", LastName = "test" };
            }
            sw.Stop();
            Console.Write("class :{0},{1}", sw.ElapsedTicks, Environment.NewLine);

            Console.ReadLine();
        }

        private struct MyStructure
        {
            public string FirstName;
            public string LastName;
        }

        private class MyClass
        {
            public string FirstName;
            public string LastName;
        }

        [DisplayMethod("http://codeblog.jonskeet.uk/category/linq/")]
        public void RunTests()
        {
            int size = 10000000;
            Console.WriteLine("Always true");
            RunTests(size, x => false, true); 
            Console.WriteLine("Always true");
            RunTests(size, x => false && false && false, false); 
        }

        private void RunTests(int size, Func<string, bool> predicate, bool check)
        {
            for (int i = 1; i <= 10; i++)
            {
                RunTest(i, size, predicate, check);
            }
        }

        private void RunTest(int depth, int size, Func<string, bool> predicate, bool check)
        {
            IEnumerable<string> input = Enumerable.Repeat("value", size);

            for (int i = 0; i < depth; i++)
            {
                if (check)
                {
                    input = input.Where(predicate).Where(predicate).Where(predicate);
                }
                else
                {
                    input = input.Where(predicate);
                }
            }
            var sw =  System.Diagnostics.Stopwatch.StartNew();
            input.Count();
            sw.Stop();
            Console.WriteLine("Depth: {0} Size: {1} Time: {2}ms",
                              depth, size, sw.ElapsedMilliseconds);
        }

        [DisplayMethod]
        public void LinqZip()
        {
            var bands = new List<string> { "GnR", "PinkFloyd", "Rammstein", "Ozzy Osbourne", "The Verve", "Kasaabian" };
            var people = new List<string> { "John", "Peter", "Andrew", "Martin" };

            var result = people.Zip(bands, (p, b) => Tuple.Create(p, b)).ToList();
            result.ForEach(r => Console.WriteLine("{0} favor {1}", r.Item1, r.Item2));
        }

        #region BooleanOperate
        /// <summary>
        /// Flag操作
        /// </summary>
        [DisplayMethod]
        public void EnumFlagOperation()
        {
            Priority all = Priority.None;

            //使用or增加包函選項
            foreach (var p in Enum.GetValues(typeof(Priority)) as Priority[])
            {
                all |= p;
            }

            Console.WriteLine(all.ToString());
            Console.WriteLine(all.HasFlag(Priority.Medium));

            //使用xor去除選項
            foreach (var p in Enum.GetValues(typeof(Priority)) as Priority[])
            {
                all ^= p;
            }

            Console.WriteLine(all.ToString());
            Console.WriteLine(all.HasFlag(Priority.Medium));
        }

        [Flags]
        //可使用shift來當做value
        private enum PriorityShift
        {
            None = 0,
            VeryLow = 1 << 0,
            Low = 1 << 1,
            Medium = 1 << 2,
            High = 1 << 3,
            VeryHigh = 1 << 4
        }

        //使用16進位來當做value
        /// <summary>
        /// 使用16進位來當做value
        /// 0x0 = 0
        /// 0x1 = 1 
        /// 0x2 = 2
        /// 0x4 = 4
        /// 0x8 = 8
        /// 0x10 = 16
        /// 0x20 = 32
        /// 0x40 = 64
        /// 0x80 = 128
        /// 0x100 = 256
        /// 0x200 = 512
        /// 0x400 = 1024
        /// 0x800 = 2048
        /// </summary>
        [Flags]
        private enum PriorityHexadecimal
        {
            None = 0x0,
            VeryLow = 0x1,
            Low = 0x2,
            Medium = 0x4,
            High = 0x8,
            VeryHigh = 0x10
        }

        [Flags]
        private enum Priority
        {
            None = 0,
            VeryLow = 1,
            Low = 2,
            Medium = 4,
            High = 8,
            VeryHigh = 16,
            Default = None | VeryLow | Low | Medium
        }

        /// <summary>
        /// Xor加密
        /// 解密再針對key做一次xor 操作
        /// </summary>
        [DisplayMethod]
        public void XorEncryption()
        {
            string msg = "This is a message.";
            char key1 = '@';
            StringBuilder sb1 = new StringBuilder();
            foreach (char c in msg)
            {
                sb1.Append((char)(c ^ key1));
            }
            Console.WriteLine(sb1.ToString());

            string key2 = "9s/*(W$37";
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < msg.Length; i++)
            {
                sb2.Append((char)(msg[i] ^ key2[i % key2.Length]));
            }
            Console.WriteLine(sb2.ToString());
        }
        #endregion

        /// <summary>
        /// 動態產生汎形物件
        /// </summary>
        [DisplayMethod]
        public void DynamicalCreateGeneric()
        {
            var types = new List<Type> { typeof(int), typeof(string), typeof(double), typeof(char), typeof(bool) };
           
            var type = typeof(ObjectA<>);
            foreach (dynamic obj in 
                types.Select(t => Activator.CreateInstance(type.MakeGenericType(t)))
            )
            {
                obj.SpeakType();
            }
        }

        private class ObjectA<T>
        {
            public void SpeakType()
            {
                Console.WriteLine(typeof(T));
            }
        }

        /// <summary>
        /// 操作動態物件
        /// </summary>
        [DisplayMethod]
        public void OperateDynamicObject()
        {
            dynamic dObject =  new System.Dynamic.ExpandoObject();
            //add Property Changed Event
            ((System.ComponentModel.INotifyPropertyChanged)dObject).PropertyChanged +=
                new System.ComponentModel.PropertyChangedEventHandler(
                    (s, e) =>
                        Console.WriteLine("Property Changed{0}:", e.PropertyName));
            //增加Property
            dObject.Name = "DynamicObject";
            Console.WriteLine(dObject.Name);

            //透過dictionary 增加Property
            var dicObject =  dObject as IDictionary<string, object>;
            dicObject["hello"] = (Action<string>)((msg) => Console.WriteLine(msg));
            dObject.hello("hello world");

            //巡覽Property
            foreach (var property in dObject as IDictionary<string, object>)
            {
                Console.WriteLine("key:{0} value:{1}", property.Key, property.Value);
            }
        }

        [DisplayMethod]
        public void ProductXml()
        {
            var address = "";
            var xdoc = new System.Xml.XmlDocument();
            // 建立根節點物件並加入 XmlDocument 中 (第 0 層)
            var rootElement = xdoc.CreateElement("objective");
            xdoc.AppendChild(rootElement);
            var file = GetFile();
            var total = file.Count();
            for (int i = 1, j = 1; i <= total; i++, j++)
            {
                //針對跳號
                if (i > 65 && i < 77
                    || i > 116 && i < 120)
                {
                    j--;
                    total++;
                    continue;
                }
                var eleChild1 = xdoc.CreateElement("key");
                var attChild1 = xdoc.CreateAttribute("name");
                attChild1.Value = file[j - 1];
                var attChild2 = xdoc.CreateAttribute("value");
                attChild2.Value = i.ToString();
                eleChild1.Attributes.Append(attChild1);
                eleChild1.Attributes.Append(attChild2);
                rootElement.AppendChild(eleChild1);
                // 將建立的 XML 節點儲存為檔案
                xdoc.Save(address);
            }
        }

        private string[] GetFile()
        {
            //excel row data
            string file =@"";
            return file.Split(null).Where(s => s != "").ToArray();
        }

        /// <summary>
        /// type 取得方式
        /// 1.有instance 透過instance GetType()
        /// 2.已知type 透過typeof() 取得type
        /// 3.已知namespace 透過dll取得type
        /// </summary>
        [DisplayMethod]
        public void ReflectionExample()
        {
            Action<Caculator> action = (caculator) =>
            {
                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                caculator.Add(10, 10);
                stopwatch.Stop();
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            };

            var type = typeof(Caculator);

            var caculator1 = Activator.CreateInstance(type) as Caculator;
            action.Invoke(caculator1);

            dynamic caculator2 = Activator.CreateInstance(type);
            action.Invoke(caculator2);
        }

        private class Caculator
        {
            public int Add(int i, int j)
            {
                return i + j;
            }
        }

        [DisplayMethod]
        public void MoqTest1()
        {
            //var mock = new Moq.Mock<ICustom>();
            //mock.SetupGet(custom => custom.IsVip).Returns(true);
            //mock.SetupGet(custom => custom.Name).Returns("test");
            //mock.Setup(custom => custom.DoSomething()).Returns("look for ..");
            //var obj = mock.Object;
            //obj.IsVip.ToConsole();
            //obj.Name.ToConsole();
            //obj.DoSomething().ToConsole();
        }

        private interface ICustom
        {
            bool IsVip { get; set; }
            string Name { get; set; }
            string DoSomething();
        }

        [DisplayMethod]
        public void DeferExcute()
        {
            new DeferExcuteCaculator(10).Add(1).Add(1).Add(1).Sub(5).Sub(5).Invoke().ToConsole();
        }

        

        /// <summary>
        /// 1.Parameter
        /// 2.Body
        /// 3.LamdaExpression
        /// 4.Compile
        /// 5.Excute
        /// </summary>
        [DisplayMethod]
        public void ExpressionTree()
        {
            //參數
            ParameterExpression parameter1 = Expression.Parameter(typeof(int), "x");
            //主體
            BinaryExpression multiply = Expression.Multiply(parameter1, parameter1);
            //LamdaExpression
            Expression<Func<int, int>> square = Expression.Lambda<Func<int, int>>(
                multiply, parameter1);
            //Compile
            Func<int, int> lambda = square.Compile();
            //Excute
            Console.WriteLine(lambda(5));

            Expression<Func<int, int>> square1 = x => x * x;
            //透過square1取得Expression Body並相加
            BinaryExpression squareplus2 = Expression.Add(square1.Body,
                Expression.Constant(3));
            //LamdaExpression
            Expression<Func<int, int>> expr = Expression.Lambda<Func<int, int>>(squareplus2,
                square1.Parameters);
            //Compile
            Func<int, int> compile = expr.Compile();
            //Excute
            Console.WriteLine(compile(10));
        }

        [DisplayMethod]
        public void DynamicFeature()
        {
            new DairyItem().Apply();
        }

        private class AggregateRoot
        {
            public void Apply()
            {
                dynamic d = this;
                d.handle();
            }
        }

        private class DairyItem : AggregateRoot
        {
            public void handle()
            {
                "DairyItem handle something".ToConsole();
            }
        }

        private const string  SALT = "S9@)#IK9FI09";
        [DisplayMethod]
        public void MD5Encryption()
        {
            var source = "abcdefg";
            var md5 = System.Security.Cryptography.MD5.Create();
            var encrypt = md5.ComputeHash(Encoding.Default.GetBytes(source + SALT));
            BitConverter.ToString(encrypt).ToConsole();
        }


        /// <summary>
        /// HashTableDictionaryPerformanceCompare
        /// Conclusion:
        /// Hashtable has less performance than Dictionary because of Boxing and Unboxing.
        /// </summary>
        [DisplayMethod]
        public void HashTableDictionaryPerformanceCompare()
        {
            var hashTable = new System.Collections.Hashtable();
            var dictionary = new Dictionary<int, int>();
            var excuteTimes = Enumerable.Range(0, 1000000);
            excuteTimes.ForEach(n => 
            {
                hashTable.Add(n, n);
                dictionary.Add(n, n);
            });

            Action hashTableGetRemoveAction = () =>
            {
                excuteTimes.ForEach(n =>
                    {
                        if (hashTable.Contains(n))
                        {
                            int i = (int)hashTable[n];
                            hashTable.Remove(i);
                        }
                    });
            };
            hashTableGetRemoveAction.CaculateExcuteTime().ToConsole("hashTable:");

            Action dictionaryGetRemoveAction = () =>
            {
                excuteTimes.ForEach(n =>
                {
                    if (dictionary.ContainsKey(n))
                    {
                        int i = dictionary[n];
                        dictionary.Remove(i);
                    }
                });
            };
            dictionaryGetRemoveAction.CaculateExcuteTime().ToConsole("Dictionary:");
        }

        /// <summary>
        /// 1.Create an Assembly in an Application Domain.AssemblyBuilder will help you in that.
        /// 2.Create a Module inside the Assembly
        /// 3.Create a number of Type inside a Module
        /// 4.Add Properties, Methods, Events etc inside the Type.
        /// 5.Use ILGenerator to write inside the Properties, Methods etc.
        /// </summary>
        [DisplayMethod(@"http://www.codeproject.com/Articles/121568/Dynamic-Type-Using-Reflection-Emit")]
        public void Emit()
        {
            var asmbuilder = GetAssemblyBuilder("MyAssembly");
            var mbuilder = GetModule(asmbuilder);
            var tbuilder = GetType(mbuilder, "MyClass");
            Type[] tparams = { typeof(System.Int32), typeof(System.Int32) };
            var methodSum = GetMethod(tbuilder, "Sum", typeof(System.Single), tparams);

            //5.Use ILGenerator to write inside the Properties, Methods etc.
            var generator = methodSum.GetILGenerator();
            generator.DeclareLocal(typeof(System.Single));
            generator.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
            generator.Emit(System.Reflection.Emit.OpCodes.Ldarg_2);
            generator.Emit(System.Reflection.Emit.OpCodes.Add_Ovf);
            generator.Emit(System.Reflection.Emit.OpCodes.Conv_R4);
            generator.Emit(System.Reflection.Emit.OpCodes.Stloc_0);
            generator.Emit(System.Reflection.Emit.OpCodes.Ldloc_0);
            generator.Emit(System.Reflection.Emit.OpCodes.Ret);

            var type = tbuilder.CreateType();
            var a = type.GetMethod("Sum").Invoke(null, new object[] { 10, 10 });
        }
        #region emit
        /// <summary>
        /// 1.Create an Assembly in an Application Domain.AssemblyBuilder will help you in that.
        /// </summary>
        private System.Reflection.Emit.AssemblyBuilder GetAssemblyBuilder(string assembleName)
        {
            AssemblyName aname = new AssemblyName(assembleName);
            AppDomain currentDomain = AppDomain.CurrentDomain; // Thread.GetDomain();
            return currentDomain.DefineDynamicAssembly(aname, System.Reflection.Emit.AssemblyBuilderAccess.Run);
        }

        /// <summary>
        /// 2.Create a Module inside the Assembly
        /// </summary>
        private System.Reflection.Emit.ModuleBuilder GetModule(System.Reflection.Emit.AssemblyBuilder asmBuilder)
        {
            return asmBuilder.DefineDynamicModule("EmitMethods", "EmitMethods.dll");
        }

        /// <summary>
        /// 3.Create a number of Type inside a Module
        /// </summary>
        private System.Reflection.Emit.TypeBuilder GetType(System.Reflection.Emit.ModuleBuilder modBuilder, string className)
        {
            System.Reflection.Emit.TypeBuilder builder = modBuilder.DefineType(className, TypeAttributes.Public);
            return builder;
        }

        /// <summary>
        /// 4.Add Properties, Methods, Events etc inside the Type.
        /// </summary>
        /// <returns></returns>
        private System.Reflection.Emit.MethodBuilder GetMethod(System.Reflection.Emit.TypeBuilder typBuilder, string methodName,
                      Type returnType, params Type[] parameterTypes)
        {
            var builder = typBuilder.DefineMethod(methodName,
                              MethodAttributes.Public | MethodAttributes.HideBySig,
                                     CallingConventions.HasThis, returnType, parameterTypes);
            return builder;
        }
        #endregion emit 

        /// <summary>
        /// Conclusion
        /// FirstOrDefaule scan until fine first item
        /// SingleOrDefaultPerformance scan all item if result greater than 2 thow exception
        /// </summary>
        [DisplayMethod]
        public void SingleOrDefaultFirstOrDefaultPerformance()
        {
            var items = Enumerable.Range(1, 1000);
            Action FirstOrDefaultPerformance = () => items.Select(n => items.FirstOrDefault(m => n == m)).ToList();
            Action SingleOrDefaultPerformance = () => items.Select(n => items.SingleOrDefault(m => n == m)).ToList();

            FirstOrDefaultPerformance.CaculateExcuteTime().ToConsole("FirstOrDefaultPerformance:");
            SingleOrDefaultPerformance.CaculateExcuteTime().ToConsole("SingleOrDefaultPerformance:");

            Action SingleOrDefaultThrowException = () => items.Select(n => items.SingleOrDefault(m => n % 2 == 0)).ToList();
            SingleOrDefaultThrowException.ExcauteAndCatchException().ToConsole("ExceptionMessage:");

        }

        [DisplayMethod]
        public void ImplementCurry()
        {
            Func<int, int> SubtractOne = x => x - 1;
            SubtractOne.Curry()(1).ToConsole();

            Func<int, int, int> Mutiple = (x, y) => x * y;
            Mutiple.Curry()(8)(8).ToConsole();

            Func<int, int, int, int> SubtractFisrt = (x, y, z) => x - y - z;
            SubtractFisrt.Curry()(8)(5)(2).ToConsole();

            Func<int, int, int, int, int> Add = (w, x, y, z) => w + x + y + z;
            Add.Curry()(1)(2)(3)(4).ToConsole();
        }

        /// <summary>
        /// Conclusion
        /// 1.refenence type default value is null
        /// 2.value type default value is 0, struct is value type each item all default value
        /// 3.nullable return nullable<T>
        /// </summary>
        [DisplayMethod]
        public void DefaultValue()
        {
            //refenece type
            default(List<int>).ToConsole("List<int> default:");
            default(string).ToConsole("string default:");
            default(TestClass).ToConsole("TestClass default:");

            //value type
            default(int).ToConsole("int default:");
            default(DateTime).ToConsole("DateTime default:");
            default(TestEnum).ToConsole("TestEnum default:");

            //nullable type
            default(DateTime?).ToConsole("DateTime? default:");
            default(int?).ToConsole("int? default:");
        }

        private enum TestEnum
        { 
        }

        private class TestClass
        { 
        }

        public class LargeObjectHeapHandler
        {
            /// <summary>
            /// Static variable used to store our 'big' block. This ensures that the block is always up for garbage collection.
            /// </summary>
            public byte[] bigBlock;

            /// <summary>
            /// Allocates 90,000 byte blocks, optionally intersperced with larger blocks
            /// </summary>
            public void Fill(bool allocateBigBlocks, bool grow, bool alwaysGC)
            {
                // Number of bytes in a small block
                // 90000 bytes, just above the limit for the LOH
                const int blockSize = 90000;

                // Number of bytes in a larger block: 16Mb initially
                int largeBlockSize = 1 << 24;

                // Number of small blocks allocated
                int count = 0;

                try
                {
                    // We keep the 'small' blocks around
                    // (imagine an algorithm that allocates memory in chunks)
                    List<byte[]> smallBlocks = new List<byte[]>();

                    while(true)
                    {
                        // Write out some status information
                        if ((count % 1000) == 0)
                        {
                            Console.CursorLeft = 0;
                            Console.Write(new string(' ', 20));
                            Console.CursorLeft = 0;
                            Console.Write("{0}", count);
                            Console.CursorLeft = 0;
                        }

                        if (alwaysGC)
                        {
                            GC.Collect();
                        }
                        if (allocateBigBlocks)
                        {
                            bigBlock = new byte[largeBlockSize];
                        }
                        if (grow)
                        {
                            largeBlockSize++;
                        }
                        smallBlocks.Add(new byte[blockSize]);
                        count++;
                    }
                }
                catch (OutOfMemoryException)
                {
                    bigBlock = null;
                    GC.Collect();
                    Console.WriteLine("{1}Mb allocated", (count * blockSize) / (1024 * 1024));
                }
            }
        }

        /// <summary>
        /// 大於85000bytes的物件建立時分配於LOH(large object heap)
        /// LOH在建立的時候就屬於G2，只有在處理G2的回收時，才會處理LOH物件，並且不會壓縮空間
        /// 當配置一個大物件時會優先在LOH的底部進行配置 如果空間不足會向程式請求更多的空間 若其餘空間也不足時
        /// 才會考慮去使用之前被回收對象使用的空間
        /// 85k|16mb|85k
        /// 85k|16mb|85k|16mb+1|85k <- GC.Collect
        /// 85k|    |85k|      |85k <- allocation 16mb + 2 throw MemoryOutException
        /// 
        /// </summary>
        [DisplayMethod("https://www.simple-talk.com/dotnet/.net-framework/the-dangers-of-the-large-object-heap/")]
        public void TheDangersOfTheLargeObjectHeap()
        {
            var  handler = new LargeObjectHeapHandler();
            //handler.Fill(true, true, false);
            //handler.Fill(true, true, true);
            //handler.Fill(false, true, false);
            //handler.Fill(true, false, false);
        }
        
    }
}
