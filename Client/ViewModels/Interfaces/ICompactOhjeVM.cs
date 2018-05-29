namespace Nipema.Tyonohjaus.Client.ViewModels
{
    public interface ICompactOhjeVM
    {
        string Kuvaus { get; set; }
        string Lisateksti { get; set; }
        string Nimikekoodi { get; set; }
        string OhjekuvaPolku { get; set; }
        string Ohjeteksti { get; set; }
        int Ohjetyyppi { get; set; }
    }
}