using JLoger;

Logger logger = new Logger();

logger.AddNewRecord("TestRecord");
logger.AddNewErrorRecord("TestErrorRecord");

Console.WriteLine(logger.GetErrorLog());
Console.WriteLine(logger.GetLog());