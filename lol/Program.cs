using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lol
{
    class Program
    {
        static void Main(string[] args)
        {
            var vocab = new List<string>
            {
                "foo",
                "foobar",
                "bar",
                "foobarbar",
                "barfoo",
                "barfoobar"
            };
            var matches = new List<string>();
            var builder = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey();
                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;
                builder.Append(key.KeyChar);
                var foo = builder.ToString();
                matches = vocab.Where(w => w.StartsWith(builder.ToString())).ToList();
                var match = matches.FirstOrDefault();
                if (key.Key == ConsoleKey.Spacebar || match is null)//!word.StartsWith(foo)
                {
                    builder.Clear();
                    var cl = Console.CursorLeft;
                    var ct = Console.CursorTop;
                    Console.Write(string.Join("",Enumerable.Repeat(" ", 100)));
                    Console.SetCursorPosition(cl, ct);
                    continue;
                }


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(match.Substring(builder.ToString().Length) + $" ({matches.Count}) more matches");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(cursorLeft, cursorTop);
            }
        }
    }
}