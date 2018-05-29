using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nipema.Tyonohjaus.Services
{
    class LoadedItemService
    {

        //public bool Save()
        //{
        //    this.RipustusAika = DateTime.Now;
        //    try
        //    {
        //        using (var db = new MyDbContext())
        //        {
        //            db.Ripustetut.Attach(this);
        //            db.Entry(this).State = System.Data.Entity.EntityState.Added;
        //            var ppv_result = from ppv in db.ProductPropertyValues
        //                             where ppv.Nimikekoodi == this.Nimikekoodi
        //                             select ppv;
        //            if (ppv_result.Count() == 0)
        //            {
        //                var ppd_nimikekoodi = from ppd in db.ProductPropertyDescriptions
        //                                      where ppd.Id == 1
        //                                      select ppd;
        //                if (ppd_nimikekoodi.Count() > 0)
        //                {
        //                    var newPpv = new ProductPropertyValue(this.Nimikekoodi, ppd_nimikekoodi.First(), this.Nimikekoodi);
        //                    db.ProductPropertyValues.Add(newPpv);
        //                }
        //            }
        //            return db.SaveChanges() > 0;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
