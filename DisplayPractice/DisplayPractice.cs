using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplayCommon;
using DisplayPractice.Pratice;
using System.Net.Sockets;


namespace DisplayPractice
{
    [DisplayClassAttribue]
    public class DisplayCSharpPractice : AbstractDisplayMethods
    {
        
        [DisplayMethod]
        [System.ComponentModel.Description("練習Lamda")]
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
        [System.ComponentModel.Description("數字長度")]
        public void CountIntLength()
        {
            //數字長度
            int i = 165446546;
            Console.WriteLine("int i = 165446546 長度為{0}", Convert.ToString(i).Count());
        }

        [DisplayMethod]
        [System.ComponentModel.Description("And運算")]
        public void AndOperator()
        {
            //&運算
            Console.WriteLine("&運算 0x00001111 & 0x11110000 = 0x{0:x8}", 0x00001111 & 0x11110000);
        }

        [DisplayMethod]
        [System.ComponentModel.Description("補數")]
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
        [System.ComponentModel.Description("??Operation")]
        public void DoublePuzzleSymbol()
        {
            //?? 如果左邊為空就設定右邊 如果左邊不為空就設定左邊
            string s = null ?? "test";
            Console.WriteLine("string s = null ?? test\ns = {0}", s);
        }

        [DisplayMethod]
        [System.ComponentModel.Description("分字串")]
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
        [System.ComponentModel.Description("匯出文字檔")]
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
        [System.ComponentModel.Description("動態Code")]
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

        interface IPrint
        {
            void Print();
        }

        [DisplayMethod]
        [System.ComponentModel.Description("匿名物件")]
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

        public void HandleAnonymousParameter(dynamic anonymousList)
        {
            foreach (dynamic anonymousPerson in anonymousList)
            {
                anonymousPerson.Speak(anonymousPerson.Name);
            }
        }

        [DisplayMethod]
        [System.ComponentModel.Description("SelectMany範例")]
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
        [System.ComponentModel.Description("字串切割join")]
        public void StringJoinAndSplit()
        {
            string s = @"safdasd@fw#opfjkdsokjgpoijegrij$jjrgeoe$r";
            string[] ss = s.Split(new [] {'@','#','$'} );
            Console.WriteLine(string.Join("~~~~", ss));
        }

        [DisplayMethod]
        [System.ComponentModel.Description("LinqJoin 範例")]
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
        [System.ComponentModel.Description("數字長度")]
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

        class PetOwner
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

        public List<int> Swap(List<int> items, int i, int j)
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


        class A
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
            Console.WriteLine(csv); // Output a,b,c,d

            var multipliers = new[] { 10, 20, 30, 40 };
            var multiplied = multipliers.Aggregate(5, (a, b) => 
            { 
                return a * b; 
            });
            Console.WriteLine(multiplied); //Output 1200000 ((((5*10)*20)*30)*40)
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

        public List<int> GetResult(List<int> total, int killStep, ref int leak)
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

        public void UseParams(params object[] items)
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

        public void PassParam(int a, string b, bool c)
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

        public async Task<string> AwaitTest()
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

        [DisplayMethod]
        public void TcpPingTest()
        {
            try
            {
                Int32 port = 8732;
                TcpClient client = new TcpClient("192.168.11.86", port);
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

        [DisplayMethod]
        public void RunTests()
        {
            //example from http://codeblog.jonskeet.uk/category/linq/
            int size = 10000000;
            Console.WriteLine("Always true");
            RunTests(size, x => false, true); 
            Console.WriteLine("Always true");
            RunTests(size, x => false && false && false, false); 
        }

        static void RunTests(int size, Func<string, bool> predicate, bool check)
        {
            for (int i = 1; i <= 10; i++)
            {
                RunTest(i, size, predicate, check);
            }
        }

        static void RunTest(int depth, int size, Func<string, bool> predicate, bool check)
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
    }
}
