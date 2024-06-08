using System.Collections.Generic;
using _Scripts.Infrastructure.Installer.Common;
using UnityEngine;

namespace _Scripts.Infrastructure.Installer
{
    public class AllServicesIntaller : MonoBehaviour
    {
        [SerializeField] private List<Common.Installer> _installers;
        [SerializeField] private List<IInjectable> _injectables;

        private void Awake()
        {
            foreach (var installer in _installers) 
                installer.Install();

            foreach (var injectable in _injectables) 
                injectable.Inject();
        }
    }
}