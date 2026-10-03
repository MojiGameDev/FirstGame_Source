using System;
using __SARV.Core.Attributes;
using __SARV.Core.Component;
using __SARV.Core.Constant;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace __SARV.Framework.Property
{
    [SVTitle("Random")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Random Text")]
    [Serializable]
    public class SVStringPropertyRandom : SVPropertyComponent<string>
    {
        public override string Value => Generate(10);

        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public override string ToString()
        {
            return "RandomText";
        }
        
        public static string Generate(int length)
        {
            var result = new char[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = CHARS[Random.Range(0, CHARS.Length)];
            }
            return new string(result);
        }
    }
}