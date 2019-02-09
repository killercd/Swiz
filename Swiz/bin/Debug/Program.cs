using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiz
{
    class Program
    {
        
        static void Main(string[] args)
        {
            StreamReader inputReader = new StreamReader(Console.OpenStandardInput());
            String line;
            while((line = inputReader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            
        }
     
    }
}
