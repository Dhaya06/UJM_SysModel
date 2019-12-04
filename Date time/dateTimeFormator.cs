using System;

namespace SystemModeling_DateTimeFormator
{ 
    					
public class Program
    {
        public static void Main()
        {
            var nowDate=DateTime.Now;
            Console.WriteLine( nowDate.ToString("MM/dd/yyyy"));
            Console.WriteLine( nowDate.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine( nowDate.ToString("MM/dd/yyyy HH:mm"));
            Console.WriteLine( nowDate.ToString("MM/dd/yyyy hh:mm tt"));
            Console.WriteLine( nowDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss"));
            Console.WriteLine( nowDate.ToString("yyyy MMMM"));
            Console.WriteLine( nowDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            Console.WriteLine( nowDate.ToString("MM/dd/yyyy hh:mm tt"));
            Console.WriteLine( nowDate.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’") );
            Console.WriteLine( nowDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK") );

        }
        
    }
    
}

