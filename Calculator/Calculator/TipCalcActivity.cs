using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    [Activity(Label = "TipcalcActivity", Theme = "@style/CustomTheme")]
    public class TipcalcActivity : Activity
    {
        EditText _subTotalEditText;
        TextView _tipTextView;
        SeekBar _tipSeekbar;
        Button _button1;
        TextView _billTotalTextView;
        TextView _tipTotalTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tipcalc_layout);
            // Create your application here

            _subTotalEditText = FindViewById<EditText>(Resource.Id.subTotalEditText);
            _tipTextView = FindViewById<TextView>(Resource.Id.tipTextView);
            _tipSeekbar = FindViewById<SeekBar>(Resource.Id.tipSeekBar);
            var _button1 = FindViewById<Button>(Resource.Id.button1);
            _billTotalTextView = FindViewById<TextView>(Resource.Id.billTotalTextView);
            _tipTotalTextView = FindViewById<TextView>(Resource.Id.tipTotalTextView);

            _tipSeekbar.ProgressChanged += TipSeekbar_ProgressChanged;

            _button1.Click += CalculateButton_Click;
        }

        private void TipSeekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            _tipTextView.Text = e.Progress.ToString();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            float protsent = float.Parse(_tipTextView.Text) / 100;
            var tipTotal = float.Parse(_subTotalEditText.Text) * protsent;
            var billTotal = float.Parse(_subTotalEditText.Text) + tipTotal;
            _tipTotalTextView.Text = tipTotal.ToString();
            _billTotalTextView.Text = billTotal.ToString();
        }


    }
}