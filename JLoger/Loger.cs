using Newtonsoft.Json;
using System.Text;

namespace JLoger;

    public class Loger
    {

    //пути к файлам логов
    private string _logFileName;
    private string _errorLogFileName;

    //списки для хранения журналов
    private List<string> _logs;
    private List<string> _errorLogs;

    //конструкторы
    public Loger(string logFileName, string errorLogFileName)
    {
        _logFileName = logFileName;
        _errorLogFileName = errorLogFileName;
    }

    public Loger() : this(@"Log.json", @"ErrorLog.json") {}



    #region сериализаторы и десириализаторы
    // сериализация данных в формате JSON - реализация NewtonSoft
    public void SerializeData(List<string> logs, string fileName)
    {
        // Формирование строки JSON
        string jsonData = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);

        // Запись объекта в JSON-файл
        if (!File.Exists(fileName)) { using (File.Create(fileName)); Thread.Sleep(1000); }

        File.WriteAllText(fileName, jsonData, Encoding.UTF8);
    } // SerializeDataNs

    // десериализация данных из формата JSON - реализация NewtinSoft
    public List<string> DeserializeData(string fileName)
    {
        // прочитать в строку из текстового файла
        if (!File.Exists(fileName)) { using (File.Create(fileName)) ; Thread.Sleep(1000); }
        string jsonData = File.ReadAllText(fileName, Encoding.UTF8);

        // парсинг в коллекцию из JSON-строки
        // ! в конце строки означает подавление предупреждения компилятора 
        // о возможном NullReference
        return  JsonConvert.DeserializeObject<List<string>>(jsonData)!;
    } // DeserializeDataNs
    #endregion
}
