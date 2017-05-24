using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;

namespace colour_picker
{
    [Activity(Label = "Colour Picker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private SeekBar _sbRed, 
            _sbGreen, 
            _sbBlue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);

            _sbRed = FindViewById<SeekBar>(Resource.Id.sbRed);
            _sbGreen = FindViewById<SeekBar>(Resource.Id.sbGreen);
            _sbBlue = FindViewById<SeekBar>(Resource.Id.sbBlue);

            _sbRed.ProgressChanged += (s, e) => { SeekBarValueChanged(); };
            _sbGreen.ProgressChanged += (s, e) => { SeekBarValueChanged(); };
            _sbBlue.ProgressChanged += (s, e) => { SeekBarValueChanged(); };
        }

        void SeekBarValueChanged()
        {
            TextView txtColour = FindViewById<TextView>(Resource.Id.txtColour);
            TextView txtRed = FindViewById<TextView>(Resource.Id.txtRed);
            TextView txtGreen = FindViewById<TextView>(Resource.Id.txtGreen);
            TextView txtBlue = FindViewById<TextView>(Resource.Id.txtBlue);

            int red = _sbRed.Progress;
            int green = _sbGreen.Progress;
            int blue = _sbBlue.Progress;

            txtRed.Text = $"{Resources.GetString(Resource.String.Red)}: {red}";
            txtGreen.Text = $"{Resources.GetString(Resource.String.Green)}: {green}";
            txtBlue.Text = $"{Resources.GetString(Resource.String.Blue)}: {blue}";

            txtColour.SetBackgroundColor(Color.Rgb(red, green, blue));

            string hex = $"#{red:X2}{green:X2}{blue:X2}";
            txtColour.Text = hex;
            ChangeTextColour();
        }

        void ChangeTextColour()
        {
            TextView txtColour = FindViewById<TextView>(Resource.Id.txtColour);

            if (_sbBlue.Progress+_sbGreen.Progress+_sbRed.Progress>450)
                txtColour.SetTextColor(Color.Black);
            else
                txtColour.SetTextColor(Color.WhiteSmoke);
        }
    }
}

