using JLogger;

//создаём экземпляр логгера без параметров
Logger logger = new Logger();

logger.AddNewRecord("TestRecord");

try
{
   throw new Exception("TestProblem");
}
catch(Exception ex) { logger.AddNewErrorRecord(ex.Message); }

//получаем все записи из журналов, выводим в консоль
Console.WriteLine("\n" + logger.GetErrorLog());
Console.WriteLine("\n" + logger.GetLog());

logger.ClearErrorLogs();
logger.ClearLogs();

//ещё пример использования
//создаём новый экзмемпляр, но уже с заданными именами файлов
Logger newLogger = new Logger(@"SecondLog.json", @"SecondErrorLog.json");

newLogger.AddNewRecord("SecondTestRecord1");
newLogger.AddNewRecord("SecondTestRecord2");
newLogger.AddNewRecord("SecondTestRecord3");

newLogger.AddNewErrorRecord("SecondTestProblem1");
newLogger.AddNewErrorRecord("SecondTestProblem2");
newLogger.AddNewErrorRecord("SecondTestProblem3");

//получаем заданное количество последних записей
Console.WriteLine("\n" + newLogger.GetErrorLog(2));
Console.WriteLine("\n" + newLogger.GetLog(2));

newLogger.ClearErrorLogs();
newLogger.ClearLogs();



