using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using MvvmCross.Forms.Views;
using TicketSearchApp.Core.ViewModels;
using TicketSearchApp.Core.Models;
using MvvmCross.Navigation;

namespace TicketSearchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : MvxContentPage<SearchViewModel>
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (e.Item as AirportInfoModel);
            if (item != null)
            {
                var model = new AirportModel
                {
                    OriginIata = ViewModel.Iata,
                    Date = ViewModel.DateTime.ToString("yyyy-MM-dd"),
                    DestinyIata = item.Iata,
                    Name = item.Name
                };
                ViewModel.NavigationService.Navigate<DetailsViewModel, AirportModel>(model);
            }
        }
    }
}