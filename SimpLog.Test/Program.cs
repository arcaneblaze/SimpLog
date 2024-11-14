﻿using SimpLog;

namespace SimpLog.Test;

class Program
{
    private static readonly SimpLog _logger = new SimpLog("LOGOGOGOG");
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        _logger.Log("Hello, World!", Types.Error);
    }
}