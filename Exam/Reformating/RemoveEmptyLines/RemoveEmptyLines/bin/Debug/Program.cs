namespace ConsoleApplication1
{
    namespace Problem_2
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using Wintellect.PowerCollections;
        internal class Class2
        {
            private const string code = "+359";
            private static readonly IPhonebookRepository data = new REPNew(); // this works!
            private static readonly StringBuilder input = new StringBuilder();
            private static void Main()
            {
                while (true)
                {
                    var data = Console.ReadLine();
                    if (data == "End" || data == null)
                    {
                        // Error reading from console 
                        break;
                    }
                    var i = data.IndexOf('(');
                    if (i == -1)
                    {
                        Console.WriteLine("error!");
                        Environment.Exit(0);
                    }
                    var k = data.Substring(0, i);
                    if (!data.EndsWith(")"))
                    {
                        Main();
                    }
                    var s = data.Substring(i + 1, data.Length - i - 2);
                    var strings = s.Split(',');
                    for (var j = 0; j < strings.Length; j++)
                    {
                        strings[j] = strings[j].Trim();
                    }
                    if (k.StartsWith("AddPhone") && (strings.Length >= 2))
                    {
                        Cmd("Cmd3", strings);
                    }
                    else if ((k == "ChangeРhone") && (strings.Length == 2))
                    {
                        Cmd("Cmd2", strings);
                    }
                    else if ((k == "List") && (strings.Length == 2))
                    {
                        Cmd("Cmd1", strings);
                    }
                    else
                    {
                        throw new StackOverflowException();
                    }
                }
                Console.Write(input);
            }
            private static void Cmd(string cmd, string[] strings)
            {
                if (cmd == "Cmd1")
                {
                    // first command
                    var str0 = strings[0];
                    var str1 = strings.Skip(1).ToList();
                    for (var i = 0; i < str1.Count; i++)
                    {
                        str1[i] = conv(str1[i]);
                    }
                    var flag = data.AddPhone(str0, str1);
                    if (flag)
                    {
                        Print("Phone entry created.");
                    }
                    else
                    {
                        Print("Phone entry merged");
                    }
                }
                else if (cmd == "Cmd2")
                {
                    // second command
                    Print(string.Empty + data.ChangePhone(conv(strings[0]), conv(strings[1])) + " numbers changed");
                }
                else
                {
                    // third command
                    try
                    {
                        IEnumerable<Class1> entries = data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                        foreach (var entry in entries)
                        {
                            Print(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Print("Invalid range");
                    }
                }
            }
            private static string conv(string num)
            {
                var sb = new StringBuilder();
                for (var i = 0; i <= input.Length; i++)
                {
                    sb.Clear();
                    foreach (var ch in num)
                    {
                        if (char.IsDigit(ch) || (ch == '+'))
                        {
                            sb.Append(ch);
                        }
                    }
                    if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                    {
                        sb.Remove(0, 1);
                        sb[0] = '+';
                    }
                    while (sb.Length > 0 && sb[0] == '0')
                    {
                        sb.Remove(0, 1);
                    }
                    if (sb.Length > 0 && sb[0] != '+')
                    {
                        sb.Insert(0, code);
                    }
                    sb.Clear();
                    foreach (var ch in num)
                    {
                        if (char.IsDigit(ch) || (ch == '+'))
                        {
                            sb.Append(ch);
                        }
                    }
                    if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                    {
                        sb.Remove(0, 1);
                        sb[0] = '+';
                    }
                    while (sb.Length > 0 && sb[0] == '0')
                    {
                        sb.Remove(0, 1);
                    }
                    if (sb.Length > 0 && sb[0] != '+')
                    {
                        sb.Insert(0, code);
                    }
                    sb.Clear();
                    foreach (var ch in num)
                    {
                        if (char.IsDigit(ch) || (ch == '+'))
                        {
                            sb.Append(ch);
                        }
                    }
                    if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                    {
                        sb.Remove(0, 1);
                        sb[0] = '+';
                    }
                    while (sb.Length > 0 && sb[0] == '0')
                    {
                        sb.Remove(0, 1);
                    }
                    if (sb.Length > 0 && sb[0] != '+')
                    {
                        sb.Insert(0, code);
                    }
                }
                return sb.ToString();
            }
            private static void Print(string text)
            {
                input.AppendLine(text);
            }
        }
        internal class Class1 : IComparable<Class1>
        {
            private string name;
            private string name2;
            public SortedSet<string> Strings;
            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                    this.name2 = value.ToLowerInvariant();
                }
            }
            public int CompareTo(Class1 other)
            {
                return this.name2.CompareTo(other.name2);
            }
            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Clear();
                sb.Append('[');
                sb.Append(this.Name);
                var flag = true;
                foreach (var phone in this.Strings)
                {
                    if (flag)
                    {
                        sb.Append(": ");
                        flag = false;
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(phone);
                }
                sb.Append(']');
                return sb.ToString();
            }
        }
        internal class REPNew : IPhonebookRepository
        {
            public List<Class1> entries = new List<Class1>();
            public bool AddPhone(string name, IEnumerable<string> nums)
            {
                var old = from e in this.entries where e.Name.ToLowerInvariant() == name.ToLowerInvariant() select e;
                bool flag;
                if (old.Count() == 0)
                {
                    var obj = new Class1();
                    obj.Name = name;
                    obj.Strings = new SortedSet<string>();
                    foreach (var num in nums)
                    {
                        obj.Strings.Add(num);
                    }
                    this.entries.Add(obj);
                    flag = true;
                }
                else if (old.Count() == 1)
                {
                    var obj2 = old.First();
                    foreach (var num 
                        in nums)
                    {
                        obj2.Strings.Add(num);
                    }
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Duplicated name in the phonebook found: " + name);
                    return false;
                }
                return flag;
            }
            public int ChangePhone(string oldent, string newent)
            {
                var list = from e in this.entries where e.Strings.Contains(oldent) select e;
                var nums = 0;
                foreach (var entry 
                    in list)
                {
                    entry.Strings.Remove(oldent);
                    entry.Strings.Add(newent);
                    nums++;
                }
                return nums;
            }
            public Class1[] ListEntries(int start, int num)
            {
                if (start < 0 || start + num > this.entries.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid start index or count.");
                }
                this.entries.Sort();
                var ent = new Class1[num];
                for (var i = start; i <= start + num - 1; i++)
                {
                    var entry = this.entries[i];
                    ent[i - start] = entry;
                }
                return ent;
            }
        }
        internal class REP : IPhonebookRepository
        {
            private readonly Dictionary<string, Class1> dict = new Dictionary<string, Class1>();
            private readonly MultiDictionary<string, Class1> multidict = new MultiDictionary<string, Class1>(false);
            private readonly OrderedSet<Class1> sorted = new OrderedSet<Class1>();
            public bool AddPhone(string name, IEnumerable<string> nums)
            {
                var name2 = name.ToLowerInvariant();
                Class1 entry;
                var flag = !this.dict.TryGetValue(name2, out entry);
                if (flag)
                {
                    entry = new Class1();
                    entry.Name = name;
                    entry.Strings = new SortedSet<string>();
                    this.dict.Add(name2, entry);
                    this.sorted.Add(entry);
                }
                foreach (var num in nums)
                {
                    this.multidict.Add(num, entry);
                }
                entry.Strings.UnionWith(nums);
                return flag;
            }
            public int ChangePhone(string oldent, string newent)
            {
                var found = this.multidict[oldent].ToList();
                foreach (var entry in found)
                {
                    entry.Strings.Remove(oldent);
                    this.multidict.Remove(oldent, entry);
                    entry.Strings.Add(newent);
                    this.multidict.Add(newent, entry);
                }
                return found.Count;
            }
            public Class1[] ListEntries(int first, int num)
            {
                if (first < 0 || first + num > this.dict.Count)
                {
                    Console.WriteLine("Invalid start index or count.");
                    return null;
                }
                var list = new Class1[num];
                for (var i = first; i <= first + num - 1; i++)
                {
                    var entry = this.sorted[i];
                    list[i - first] = entry;
                }
                return list;
            }
        }
        internal interface IPhonebookRepository
        {
            bool AddPhone(string name, IEnumerable<string> phoneNumbers);
            int ChangePhone(string oldPhoneNumber, string newPhoneNumber);
            Class1[] ListEntries(int startIndex, int count);
        }
    }
}
