using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace MVCApp.Controllers
{
    public class TestController : Controller
    {
        public TestController()
        {
            Console.WriteLine("cted");
        }
        
        public DateTime GetTime()
        {
            return DateTime.Now;
        }

        public double GetTemperature()
        {
            Process p = new Process{ StartInfo = new ProcessStartInfo("vcgencmd", "measure_temp"){
                RedirectStandardOutput=true
            }};
            p.Start();
            p.WaitForExit();
            string s = p.StandardOutput.ReadToEnd();
            string[] split = s.Split('=');
            Console.WriteLine("Raw = " + s);
            if(split.Length > 1)
            {
                string value=split[1];
                Console.WriteLine("Val = "+value);
                if(value.Length > 3)
                {
                    string number = value.Substring(0, value.Length - 3);
                    Console.WriteLine("number = "+number);
                    double d;
                    if(double.TryParse(number, out d))
                    {
                        return d;
                    }
                }
            }
            return double.NaN;
        }
    }
}