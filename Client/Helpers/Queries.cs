using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Nipema.Tyonohjaus.Client.Helpers
{
    public static class Queries
    {
        public static System.Drawing.Point GetPoint()
        {
            var point = new System.Drawing.Point();
            //try
            //{
            //    using (var db = new MyDbContext())
            //    {
            //        string term1 = string.Format("StartingPoint{0}", (int)ot);
            //        string term2 = string.Format("EndingPoint{0}", (int)ot);

            //        var result_point = from s in db.Settings
            //                           where s.Description == term1
            //                           select s.Value;

            //        var result_point2 = from s in db.Settings
            //                            where s.Description == term2
            //                            select s.Value;

            //        if ( result_point.FirstOrDefault() != null)
            //        {
            //            point.X = int.Parse(result_point.First());
            //        }
            //        if ( result_point2.FirstOrDefault() != null)
            //        {
            //            point.Y = int.Parse(result_point2.First());
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    return point;
            //}
            return point;
        }
        public static string GetDefaultPressure()
        {
           /* string replaced = Helpers.Queries.GetSetting("DefaultPressure")?.Replace(".", ",");
            string ret = "";
            try
            {
               bool success = string.(replaced, out ret);
            }
            catch (Exception) { }*/
            return Helpers.Queries.GetSetting("Defaultpressure");
        }
        public static double GetDefaultOvenTime()
        {
            string replaced = Helpers.Queries.GetSetting("DefaultOvenTime")?.Replace(".", ",");
            double ret = 0;
            try
            {
                bool success = double.TryParse(replaced, out ret);
            }
            catch (Exception) { }
            
            return ret;
        }
        public static bool GetUsePressure()
        {
            if (GetSetting("UsePressure")?.ToLower() == "false") return false;
            else return true;
        }
        public static bool GetUseOvenTime()
        {
            if (GetSetting("UseOvenTime")?.ToLower() == "false") return false;
            else return true;
        }
        public static string GetProductColor(string nimikekoodi)
        {
            //using (var db = new MyDbContext())
            //{
            //    var result_ppvs = from v in db.Tyojono
            //                      where v.Nimikekoodi == nimikekoodi
            //                      select v;


            //    var res = result_ppvs.FirstOrDefault();
            //    if (res != null)
            //    {
            //        if (res.Vari == null) { return GetProductPropertyValue(nimikekoodi, 3); }
            //        else { return res.Vari; }
            //    }
            //    else return "";


            //}
            throw new NotImplementedException();
        }
        public static string GetProductPropertyValue(string nimikekoodi, int propertyId)
        {
            //using (var db = new MyDbContext())
            //{
            //    var result_ppvs = from v in db.ProductPropertyValues
            //                      where v.Nimikekoodi == nimikekoodi
            //                      && v.PropertyId == propertyId
            //                      select v;

            //    var res = result_ppvs.FirstOrDefault();

            //    if (res == null) return null;

            //    return res.PropertyValue;
            //}
            throw new NotImplementedException();

        }
        public static SolidColorBrush GetColorAsBrush(string nimikekoodi)
        {
            string x = GetProductPropertyValue(nimikekoodi, 3);
            try
            {

                return (SolidColorBrush)new BrushConverter().ConvertFromString(x);
            }
            catch (Exception) { return null; }
        }
        public static string GetSetting(string settingDescription)
        {
            //using (var db = new MyDbContext())
            //{
            //    var result_settings = from s in db.Settings
            //                          where s.Description == settingDescription
            //                          select s.Value;

            //    if (result_settings.FirstOrDefault() != null)
            //        return result_settings.FirstOrDefault();
            //    return "";
            //}
            return "";
        }
    }
}
