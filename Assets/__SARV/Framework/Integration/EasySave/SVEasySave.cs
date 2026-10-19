namespace __SARV.Framework.Integration.EasySave
{
    public static class SVEasySave
    {
        public static void Save(string key, object value)
        {
            ES3.Save(key, value);
        }
    }
}