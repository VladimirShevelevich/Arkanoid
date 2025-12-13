using UnityEngine;

namespace Arkanoid.Tools
{
    public static class CustomLogger
    {
        public static void DebugLog(string log)
        {
#if DEBUG
            Debug.Log(log);      
#endif
        }
    }
}