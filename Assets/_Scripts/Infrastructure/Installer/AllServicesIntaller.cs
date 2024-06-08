using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Infrastructure.Installer
{
    public class AllServicesIntaller : MonoBehaviour
    {
        [SerializeField] private List<Installer> _installers;
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