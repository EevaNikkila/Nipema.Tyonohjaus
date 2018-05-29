using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Nipema.Tyonohjaus.Client.Helpers;
using Nipema.Tyonohjaus.Client.ViewModels;

namespace Nipema.Tyonohjaus.Client.Views.Partial
{
    public class SortAdorner : Adorner
    {
        private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

        private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
        {
            this.Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform
                    (
                            AdornedElement.RenderSize.Width - 15,
                            (AdornedElement.RenderSize.Height - 5) / 2
                    );
            drawingContext.PushTransform(transform);

            Geometry geometry = ascGeometry;
            if (this.Direction == ListSortDirection.Descending)
                geometry = descGeometry;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }
    }
    /// <summary>
    /// Interaction logic for LinjaView.xaml
    /// </summary>
    public partial class ManufacturingLine : ListView
    {
        public ManufacturingLine()
        {

        }
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private readonly IManufacturingLineVM _viewmodel;
        public class LinjaViewColumnHeader : GridViewColumnHeader
        {
            public string TranslationKey;

            public LinjaViewColumnHeader(string translationKey)
            {
                TranslationKey = translationKey;
                this.Content = LanguageHelper.GetUIString(TranslationKey);
                //Helpers.Updates.LanguageChanged += Updates_LanguageChanged;

            }

            private void Updates_LanguageChanged(object sender, EventArgs e)
            {
                this.Content = LanguageHelper.GetUIString(TranslationKey);
            }
        }
        public ManufacturingLine(IManufacturingLineVM viewmodel)
        {
            InitializeComponent();
            //List<string> sortBy = new List<string>() {
            //    "Nimikekoodi",
            //    "Lokaatio",
            //    "RipustusAika",
            //    "SaapumisAika"
            //};
            //foreach (string s in sortBy)
            //{
            //    this.Items.SortDescriptions.Add(new SortDescription(s, ListSortDirection.Descending));
            //}

            //CreateColumns();
            //TrolleyLocations.ItemsChangedEvent += (a, b) =>
            //{
            //    (DataContext as LinjaVM).GenerateItems();
            //};
            //Helpers.Updates.RipustettuChanged += (a, b) =>
            //{
            //    var index = this.SelectedIndex;
            //    (DataContext as LinjaVM).GenerateItems();
            //    if (this.Items.Count - 1 >= index)
            //    {
            //        this.SelectedIndex = index;
            //    }
            //};
            //Helpers.Updates.SettingsChanged += (a, b) => (DataContext as LinjaVM).ToggleHideableColumns();
            //(DataContext as LinjaVM).GenerateItems();
        }

        private void CreateColumns()
        {

            //Style styleForClicking = new Style(typeof(GridViewColumnHeader))
            //{
            //    Setters =
            //                {
            //                    new EventSetter()
            //                    {
            //                        Event = MouseUpEvent,
            //                        Handler = new MouseButtonEventHandler(MouseDummyEventHandler)
            //                    }
            //                }
            //};
            //using (var db = new MyDbContext())
            //{
            //    var result_ppds = from ppd in db.ProductPropertyDescriptions
            //                      select ppd;

            //    if (result_ppds.Count() > 0)
            //    {
            //        foreach (var ppd in result_ppds)
            //        {
            //            if (ppd.Id == 3) { }
            //            else
            //            {
            //                var col = new GridViewColumn();
            //                col.DisplayMemberBinding = new Binding(string.Format("Tuote.TuoteProperties[{0}]", ppd.Id));
            //                var head = new LinjaViewColumnHeader(ppd.Description)
            //                {
            //                    Tag = string.Format("Tuote.TuoteProperties[{0}]", ppd.Id)
            //                };
            //                head.Style = styleForClicking;
            //                col.Header = head;
            //                if (ppd.Id != 2)
            //                {
            //                    this.lista.Columns.Add(col);
            //                }
            //            }
            //        }
            //    }
            //}


            //this.lista.Columns.Add(new GridViewColumn()
            //{
            //    DisplayMemberBinding = new Binding("RipustusAika"),
            //    Header = new LinjaViewColumnHeader("LoadTime")
            //    {
            //        Tag = "RipustusAika",
            //        Style = styleForClicking
            //    }
            //});

            //this.lista.Columns.Add(new GridViewColumn()
            //{
            //    DisplayMemberBinding = new Binding("SaapumisAika"),
            //    Header = new LinjaViewColumnHeader("ArrivalTime")
            //    {
            //        Tag = "SaapumisAika",
            //        Style = styleForClicking
            //    }
            //});

            ////create data template
            //DataTemplate template = new DataTemplate();
            //var imageFactory = new FrameworkElementFactory(typeof(Image));
            //var containerFactory = new FrameworkElementFactory(typeof(StackPanel));
            
            //imageFactory.AddHandler(Image.MouseUpEvent, new MouseButtonEventHandler(Image_MouseDown));
            ////img width
            //imageFactory.SetValue(Image.WidthProperty, (double)18);
            ////img height
            //imageFactory.SetValue(Image.HeightProperty, (double)18);
            ////img source
            //imageFactory.SetValue(Image.SourceProperty, (BitmapImage)Application.Current.MainWindow.TryFindResource("iconDelete"));

            //containerFactory.AppendChild(imageFactory);

            //template.VisualTree = containerFactory;

            //this.lista.Columns.Add(new GridViewColumn()
            //{
            //    CellTemplate = template,
            //    Header = new LinjaViewColumnHeader("CancelLoading")
            //});

        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                this.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            this.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }
        private void MouseDummyEventHandler(object sender, MouseButtonEventArgs e)
        {
            GridViewColumnHeader_Click(sender, new RoutedEventArgs());
        }
        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            //AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
            //this.Items.SortDescriptions.Clear();

            

            //(DataContext as LinjaVM).GenerateItems();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Peruuta ripustus :
            //var item = (FrameworkElement)e.OriginalSource;
            //var itemContext = (LinjaVM.LinjaItem)item.DataContext;
            //if (new CustomWindows.KyllaEiWindow(Helpers.Language.GetUIString("Yes"), Helpers.Language.GetUIString("No"), Helpers.Language.GetUIString("Confirmation"), Helpers.Language.GetUIString("ConfirmCancelLoading"))
            //    .ShowDialog() != true) return;

            //using (var db = new MyDbContext())
            //{
            //    var rip = db.Ripustetut.Where(r => r.Id == itemContext.id).FirstOrDefault();

            //    if (rip == null) return;
            //    else
            //    {
            //        int maara = rip.RipustettavaMaara;

            //        db.Entry(rip).State = System.Data.Entity.EntityState.Deleted;
            //        if (db.SaveChanges() > 0)
            //        {
            //            if (rip.TyoId != 0)
            //            {
            //                var result_tyot = from _tyo in db.Tyojono
            //                                  where _tyo.Id == rip.TyoId
            //                                  select _tyo;
            //                var tyo = result_tyot.FirstOrDefault();

            //                if (tyo == null)
            //                {
            //                    var Tyo = new Tyo()
            //                    {
            //                        JaljellaLkm = maara,
            //                        LuomisAika = System.DateTime.Now,
            //                        Nimikekoodi = rip.Nimikekoodi,
            //                        Vari = rip.Vari,
            //                        Maara = maara
            //                    };
            //                    db.Tyojono.Add(Tyo);
            //                }
            //                else
            //                {
            //                    tyo.JaljellaLkm += maara;
            //                    db.Entry(tyo).State = System.Data.Entity.EntityState.Modified;
            //                }
            //                db.SaveChanges();
            //                Helpers.Updates.UpdateTyojono();
            //            }
            //        }
            //        Helpers.Updates.UpdateRipustettu();
            //    }
            //}
        }

        private void PeruutaRipustus_Click(object sender, MouseEventArgs e)
        {
            //var dataContext = (sender as FrameworkElement).DataContext as LinjaVM.LinjaItem;
            //if (dataContext != null)
            //{
            //    var mainwindow = (Application.Current.MainWindow as MainWindow);

            //    if (mainwindow == null) return;

            //    string childname = "QuickLoadControl1";
            //    var quickLoadControl = Helpers.UINavigation.FindChildByName<QuickLoad>(mainwindow, childname);
            //    if (quickLoadControl == null) return;

            //    (quickLoadControl as QuickLoad).ProductNumberTextBox.SetText(dataContext.Nimikekoodi);
                
            //}
        }
    }
}