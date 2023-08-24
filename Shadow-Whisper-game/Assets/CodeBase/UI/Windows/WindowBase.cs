using CodeBase.Data;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.Progress.Service;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button closeButton;
        
        protected IProgressService ProgressService;
        protected OverallProgress Progress => ProgressService.OverallProgress;

        public void Construct(IProgressService progressService) => 
            ProgressService = progressService;

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Init();
            Subscribe();
        }

        private void OnDestroy() => 
            CleanUp();

        protected virtual void OnAwake() => 
            closeButton.onClick.AddListener(() => Destroy(gameObject));
        
        
        protected virtual void Init() {}
        protected virtual void Subscribe() {}
        protected virtual void CleanUp() {}
    }
}