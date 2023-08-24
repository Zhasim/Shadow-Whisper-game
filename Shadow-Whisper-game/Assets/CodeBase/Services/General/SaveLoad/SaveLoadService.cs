using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.Progress.Registration;
using CodeBase.Infrastructure.Services.Progress.Service;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string OVERALL_PROGRESS = "OverallProgress";
        
        private readonly IProgressService _progressService;
        private readonly IRegistrationService _registrationService;
        private readonly ILogger _logger;

        public SaveLoadService(IProgressService progressService, 
            IRegistrationService registrationService,
            ILogger logger)
        {
            _progressService = progressService;
            _registrationService = registrationService;
            _logger = logger;
        }

        public void SaveProgress()
        {
            try
            {
                foreach (IProgressWriter progressWriter in _registrationService.ProgressWriters)
                    progressWriter.WriteProgress(_progressService.OverallProgress);
            
                PlayerPrefs.SetString(OVERALL_PROGRESS, _progressService.OverallProgress.ToJson());
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error saving progress: {exception.Message}");
            }
        }

        public OverallProgress LoadProgress()
        {
            try
            {
                string serializedProgress = PlayerPrefs.GetString(OVERALL_PROGRESS);
                if (string.IsNullOrEmpty(serializedProgress))
                    return null;
                
                return DeserializeProgress(serializedProgress);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error loading progress: {exception.Message}");
                return null;
            }
        }

        private OverallProgress DeserializeProgress(string serializedProgress)
        {
            try
            {
                return serializedProgress?.ToDeserialized<OverallProgress>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deserializing progress: {ex.Message}");
                return null;
            }
        }
    }
}