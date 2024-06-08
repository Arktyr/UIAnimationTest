using UnityEngine;

namespace _Scripts.Infrastructure.Installer.Common
{
    public abstract class IInjectable : MonoBehaviour
    {
        public abstract void Inject();
    }
}