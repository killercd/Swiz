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
                string[] operators = operation.Split('/');
                
                if(operators != null && operators.Length < 3)
                {
                    Console.Error.WriteLine("Invalid operation pattern");
                    throw new Exception("Invalid Operation");
                }
                String oper = operators[0].Trim().ToLower();
                String pattern = operators[1].Trim().Replace("$$<slash>##", @"/");
                String trasformation = operators[2].Trim().Replace("$$<slash>##", @"/");
                String mode = operators.Length>3 ? operators[3].Trim() : string.Empty;

                switch (oper)
                {
                    case "s":
                        line = substitution(line, pattern, trasformation, mode);
                        break;
                    default:
                        break; 
                }


            }
            return line;
        }

        private static string substitution(string line,string pattern, string trasformation, string mode)
        {
            Regex rgx = new Regex(pattern);
            switch (mode)
            {
                case "g":
                    return rgx.Replace(line, trasformation);
                    
                default:
                    return rgx.Replace(line, trasformation, 1);

            }
            
        }
    }
}
