using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.CustomLogger
{
    public class Logger : ILogger
    {
        public void LogInfo(string message) => 
            Debug.Log(message);

        public void LogError(string errorMessage) => 
            Debug.LogError($"[ERROR] {errorMessage}");

        public void LogException(Exception exception) => 
            Debug.LogException(exception);
    }
}