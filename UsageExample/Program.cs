using JLogger;

Logger logger = new Logger();

logger.AddNewRecord("TestRecord");

try
{
   throw new Exception("TestProblem");
}
catch(Exception ex) { logger.AddNewErrorRecord(ex.Message); }

Console.WriteLine(logger.GetErrorLog());
Console.WriteLine(logger.GetLog());
logger.ClearErrorLogs();
logger.ClearLogs();