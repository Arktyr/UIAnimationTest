using System;
using System.Threading.Tasks;

namespace _Scripts.Extensions
{
    public static class AsyncOpertions
    {
        public static async Task GetAwaitBool(Func<bool> boolTask)
        {
            while (!boolTask()) 
                await Task.Yield();
        }
    }
}