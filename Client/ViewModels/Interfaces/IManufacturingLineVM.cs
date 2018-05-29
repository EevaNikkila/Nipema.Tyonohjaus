namespace Nipema.Tyonohjaus.Client.ViewModels
{
    public interface IManufacturingLineVM
    {
        ObservableCollectionEx<ManufacturingLineVM.LinjaItem> Items { get; }
        double PesupaineWidth { get; set; }
        double UunitusAikaWidth { get; set; }

        void GenerateItems();
        void ToggleHideableColumns();
    }
}