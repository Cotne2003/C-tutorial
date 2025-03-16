using System.Resources;

namespace RegisterLoginJWT
{
    public static class HelperService
    {
        public static string GetFullMessage(this Exception ex)
        {
            if (ex == null)
                return string.Empty;

            var message = new List<string>();

            while (ex != null)
            {
                message.Add(ex.Message);
                ex = ex.InnerException;
            }

            return string.Join("=>", message);
        }

        public static string GetResourceValue(string sourceName)
        {
            ResourceManager resourceManager = new ResourceManager("RegisterLoginJWT.Resource", typeof(HelperService).Assembly);

            return resourceManager.GetString(sourceName);
        }

    }
}
