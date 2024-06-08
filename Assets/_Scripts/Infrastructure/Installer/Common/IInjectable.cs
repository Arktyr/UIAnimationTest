using UnityEngine;

namespace _Scripts.Infrastructure.Installer
{
    public abstract class IInjectable : MonoBehaviour
    {
        public abstract void Inject();
    }
}