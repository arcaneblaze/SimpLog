using System.ComponentModel;

namespace SimpLog;

public enum Types
{
    Error,
    Info,
    Warning,
    Debug
}

public class SimpLog
{
    private Dictionary<Types, ConsoleColor> colors = new Dictionary<Types, ConsoleColor>() {
        {Types.Debug, ConsoleColor.White},
        {Types.Info, ConsoleColor.Blue},
        {Types.Warning, ConsoleColor.DarkYellow},
        {Types.Error, ConsoleColor.Red},
    };
    
    [Description("Only path, without file")]
    private string _logPath;
    public SimpLog(string logPath = "Logs")
    {
        _logPath = logPath;
    }
    private string _dateTimeNow;
    private void FileWriter(Types logType, string logText) {
        if(!Directory.Exists(_logPath)) Directory.CreateDirectory(_logPath);
        if (!File.Exists("log.simplog")) File.Create("log.simplog");
        using (StreamWriter streamWriter = new StreamWriter($"{_logPath}/log.simplog", true))
        {
            streamWriter.WriteLine("{0} - {1} => {2}", _dateTimeNow, logType.ToString(), logText);
        }
    }
    
    public void Log(string _message, Types _type)
    {
        _dateTimeNow = DateTime.Now.ToString("yyyy.MM.dd HH:mm");

        FileWriter(_type, _message);
            
        ConsoleColor color = colors[_type];
        Console.ForegroundColor = color;
        Console.WriteLine("{0} - {1} => {2}", _dateTimeNow, _type.ToString(), _message);
        Console.ResetColor();
    }
}