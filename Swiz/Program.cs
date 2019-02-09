using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Swiz
{
    class Program
    {
        
        static void Main(string[] args)
        {
            StreamReader inputReader = new StreamReader(Console.OpenStandardInput());
            String line;

            String operation = args.Length > 0 && !String.IsNullOrEmpty(args[0]) ? args[0] : string.Empty;

            while((line = inputReader.ReadLine()) != null)
            {
                
                Console.WriteLine(processLine(line, operation));
            }
            
        }

        private static string processLine(string line, string operation)
        {
            if (!string.IsNullOrEmpty(operation))
            {
                operation = operation.Replace(@"\/", "$$<slash>##");
                string[] operators = line.Split('/');
                
                if(operators != null && operators.Length != 3)
                {
                    Console.Error.WriteLine("Invalid operation pattern");
                    throw new Exception("Invalid Operation");
                }

            }
            return line;
        }
    }
}
