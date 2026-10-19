using System;
using UnityEditor;

namespace __SARV.Framework.Common.Utils
{
    public static class SVGeneralUtils
    {
        public static string NewSaveKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}