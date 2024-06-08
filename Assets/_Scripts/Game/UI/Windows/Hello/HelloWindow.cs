using _Scripts.UI.Windows;
using UnityEngine;

namespace _Scripts.Game.UI.Windows.Hello
{
    public class HelloWindow : MonoBehaviour, IWindow
    {
        public void Open()
        {
            Debug.Log("Open");
        }

        public void Close()
        {
        }
    }
}