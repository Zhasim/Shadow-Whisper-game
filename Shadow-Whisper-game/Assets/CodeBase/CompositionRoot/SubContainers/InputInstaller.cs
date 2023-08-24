using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.CompositionRoot.SubContainers
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings() => 
            Container.Bind<IInputService>().FromMethod(BindInputService).AsSingle();

        private IInputService BindInputService()
        {
            if (Application.isEditor)
            {
                Debug.Log("INPUT STANDALONE");
                return new StandaloneInputService();
            }
            else
            {
                Debug.Log("INPUT MOBILE");
                return new MobileInputService();
            }
        }
    }
}