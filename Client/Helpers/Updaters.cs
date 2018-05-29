using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyonohjaus.Helpers
{
    public class Updates
    {
        public static event EventHandler RipustettuChanged;
        public static void UpdateRipustettu()
        {
            if (RipustettuChanged != null)
            {
                RipustettuChanged(null, new EventArgs());
            }
        }
        public static event EventHandler LanguageChanged;
        public static void UpdateLanguage()
        {
            if (LanguageChanged != null)
            {
                LanguageChanged(null, new EventArgs());
            }
        }
        public static event EventHandler TuoteChanged;
        public static void UpdateTuotteet()
        {
            if (TuoteChanged != null)
            {
                TuoteChanged(null, new EventArgs());
            }
        }
        public static event EventHandler TyojonoChanged;
        public static void UpdateTyojono()
        {
            if (TyojonoChanged != null)
            {
                var subscribers = TyojonoChanged.GetInvocationList();
                TyojonoChanged(null, new EventArgs());
            }
        }

        public static event EventHandler SettingsChanged;
        public static void UpdateSettings()
        {
            if (SettingsChanged != null)
            {
                SettingsChanged(null, new EventArgs());
            }
        }

        public static event EventHandler OhjeetChanged;
        public static void UpdateOhjeet()
        {
            if (OhjeetChanged != null)
            {
                OhjeetChanged(null, new EventArgs());
            }
        }
        public static event EventHandler ValmiitChanged;
        public static void UpdateValmiit()
        {
            if (ValmiitChanged != null)
            {
                ValmiitChanged(null, new EventArgs());
            }
        }
    }
}
