using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSearchApp.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketSearchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketInfoPage : MvxContentPage<DetailsViewModel>
    {
        public TicketInfoPage()
        {
            InitializeComponent();
        }
    }
}