using System;
using __SARV.Framework.Common.Attributes;
using __SARV.Framework.Common.Component;
using __SARV.Framework.Common.Constant;
using __SARV.Framework.Kernal.Argument;
using Random = UnityEngine.Random;

namespace __SARV.Framework.Kernal.Property
{
    [SVTitle("Random")]
    [SVCategory(SVConstantCategory.Property.STRING)]
    [SVDescription("Random Text")]
    [Serializable]
    public class SVStringPropertyRandom : SVPropertyComponent<string>
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public override string ToString()
        {
            return "RandomString";
        }

        public override string GetValue(SVArgument argument)
        {
            return Generate(10);
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