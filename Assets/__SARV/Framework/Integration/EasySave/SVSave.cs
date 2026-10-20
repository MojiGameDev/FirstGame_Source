namespace __SARV.Framework.Integration.EasySave
{
    public static class SVSave
    {
        public static void Save(string key, object value)
        {
            ES3.Save(key, value);
        }

        public static object Load(string key)
        {
            return ES3.Load(key);
        }

        public static T Load<T>(string key)
        {
            return ES3.Load<T>(key);
        }

        public static bool KeyExists(string key)
        {
            return ES3.KeyExists(key);
        }

        public static void DeleteKey(string key)
        {
            ES3.DeleteKey(key);
        }
    }
}