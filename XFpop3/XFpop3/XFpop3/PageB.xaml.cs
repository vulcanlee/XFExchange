using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFpop3
{
    public partial class PageB : ContentPage
    {
        public bool NeedRollBack { get; set; } = false;
        public PageB()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(NeedRollBack == true)
            {
                var fooPageE = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageE");
                var fooPageD = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageD");
                var fooPageC = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageC");
                var fooPageB = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageB");
                Navigation.RemovePage(fooPageE);
                Debug.WriteLine(this.Navigation.NavigationStack.Count);
                Navigation.RemovePage(fooPageD);
                Debug.WriteLine(this.Navigation.NavigationStack.Count);
                Navigation.RemovePage(fooPageC);
                Debug.WriteLine(this.Navigation.NavigationStack.Count);
                Navigation.RemovePage(fooPageB);
                Debug.WriteLine(this.Navigation.NavigationStack.Count);
                NeedRollBack = false;
            }
        }

        public PageB(string title)
        {
            InitializeComponent();

            this.Title = title;

            //var fooPageE = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageE");
            //var fooPageD = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageD");
            //var fooPageC = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageC");
            //var fooPageB = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageB");
            //Navigation.RemovePage(fooPageE);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
            //Navigation.RemovePage(fooPageD);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
            //Navigation.RemovePage(fooPageC);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
            //Navigation.RemovePage(fooPageB);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageC());
        }
    }
}
