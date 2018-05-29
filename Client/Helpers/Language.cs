using System;

namespace Nipema.Tyonohjaus.Client.Helpers
{
    public class LanguageHelper
    {
        //Helpers.Language.GetUISring("avain");
        public static string GetUIString(string key)
        {
            string uiString = "";
            try
            {
                var locExtension = new WPFLocalizeExtension.Extensions.LocTextExtension(key);
                locExtension.ResolveLocalizedValue(out uiString);
            }
            catch (Exception) { ; }

            return (!string.IsNullOrEmpty(uiString)) ? uiString : string.Format("Key: {0}", key);
        }
    }
}
