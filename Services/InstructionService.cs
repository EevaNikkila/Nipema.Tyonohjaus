using Nipema.Tyonohjaus.EF;
using Nipema.Tyonohjaus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nipema.Tyonohjaus.Services
{
    public class InstructionService
    {
        private readonly TyonohjausDbContext _context;

        public InstructionService(TyonohjausDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Hakee ohjeen Tuotteet ja ohjeet-näkymän alaosaan, mikäli tuotteella on ohje tehtynä
        /// </summary>
        /// <returns>Palauttaa Truen, jos ohje löytyi, Falsen, jos ei.</returns>
        public bool TryGetOhje()
        {
            //tätä kutsutaan kun Nimikekoodi asetetaan
            try
            {
                //using (var db = new MyDbContext())
                //{
                //    switch (this.Ohjetyyppi)
                //    {
                //        case (int)Ohjetyypit.Maalausohje:
                //            // Näyttää värin maalausohjeen yläreunassa
                //            Lisateksti = Helpers.Queries.GetProductPropertyValue(Nimikekoodi, 3);
                //            break;
                //        case (int)Ohjetyypit.Purkuohje:
                //            // Näyttää hyllypaikan purkuohjeen yläreunassa
                //            Lisateksti = Helpers.Queries.GetProductPropertyValue(Nimikekoodi, 5);
                //            break;
                //    }

                //    var result_ohje = from o in db.Ohjeet
                //                      where o.NimikekoodiRef == Nimikekoodi
                //                      select o;

                //    if (result_ohje.Count() == 0)
                //    {
                //        Ohjeteksti = "";
                //        OhjekuvaPolku = Helpers.FilePaths.GetOhjekuva(_ohjetyyppi, Nimikekoodi);
                //        Kuvaus = "";
                //        return false;
                //    }
                //    else
                //    {
                //        Ohjeteksti = result_ohje.First().GetOhjeteksti(this.Ohjetyyppi);
                //        OhjekuvaPolku = Helpers.FilePaths.GetOhjekuva(_ohjetyyppi, Nimikekoodi);
                //        Kuvaus = Helpers.Queries.GetProductPropertyValue(Nimikekoodi, 1);


                //    }

                //}
            }
            catch (Exception)
            {

            }
            return true;
        }
    }
}
