using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Progress.Registration
{
    public class RegistrationService : IRegistrationService
    {
        public List<IProgressReader> ProgressReaders { get; } = new ();
        public List<IProgressWriter> ProgressWriters { get; } = new();

        public void RegisterWatchers(GameObject gameObject) => 
            RegisterComponents<IProgressReader>(gameObject, Register);

        public void UnregisterWatchers(GameObject gameObject) => 
            RegisterComponents<IProgressReader>(gameObject, Unregister);

        private void RegisterComponents<T>(GameObject gameObject, Action<T> registerAction) where T : class
        {
            foreach (T component in gameObject.GetComponentsInChildren<T>()) 
                registerAction(component);
        }

        private void Register<T>(T component) where T : IProgressReader
        {
            if (component is IProgressWriter progressWriter) 
                ProgressWriters.Add(progressWriter);
            ProgressReaders.Add(component);
        }

        private void Unregister<T>(T component) where T : IProgressReader
        {
            if (component is IProgressWriter progressWriter) 
                ProgressWriters.Remove(progressWriter);
            ProgressReaders.Remove(component);
        }

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
    
}