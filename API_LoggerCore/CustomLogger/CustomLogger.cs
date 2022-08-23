using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_LoggerCore.CustomLogger
{
    public class CustomLogger
    {

        private string fileLocation = @"C:\Users\gc\source\repos\MarDelChat\MarDelChat\logger.txt";
        private string errorFileLocation = @"C:\Users\gc\source\repos\MarDelChat\MarDelChat\error.txt";

        public ILogger logger;
        public CustomLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public CustomLogger()
        { }
        public void Info (string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}",dateTime, message);
            if (logger == null)
                Console.WriteLine(message);
            else
                logger.LogInformation(message);
            using (var wr = File.AppendText(fileLocation))
            {
                wr.WriteLine(message);
            }
        }
        public void Error (string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}", dateTime, message);
            if (logger == null)
                Console.WriteLine("Error: " + message);
            else
                logger.LogError(message);

            using (var wr = File.AppendText(errorFileLocation))
            {
                wr.WriteLine(message);
            }
        }

    }
}
