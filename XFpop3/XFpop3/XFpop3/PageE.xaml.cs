using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFpop3
{
    public partial class PageE : ContentPage
    {
        public PageE()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //@AlessandroCaliaro
            //You could push B and then remove E, D, C and first B.In this way you have(at the end) A and B but B cover E,D,C and firts B "pop"
            //await Navigation.PushAsync(new PageB("New PageB"));
            await Navigation.PushAsync(new PageB() { Title = "New PageB", NeedRollBack = true });

            //var fooPageE = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageE");
            //var fooPageD = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageD");
            //var fooPageC = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageC");
            //var fooPageB = this.Navigation.NavigationStack.FirstOrDefault(x => x.Title == "PageB");
            ////Navigation.RemovePage(fooPageE);
            ////Debug.WriteLine(this.Navigation.NavigationStack.Count);
            //Navigation.RemovePage(fooPageD);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
            //Navigation.RemovePage(fooPageC);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
            //Navigation.RemovePage(fooPageB);
            //Debug.WriteLine(this.Navigation.NavigationStack.Count);
        }
    }
}
