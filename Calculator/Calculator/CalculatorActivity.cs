using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace Calculator
{
    [Activity(Label = "CalculatorActivity", Theme = "@style/CustomTheme")]
    public class CalculatorActivity : Activity
    {

        EditText firstEditText;
        EditText secondEditText;
        TextView answerText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.calculator_layout);

             firstEditText = FindViewById<EditText>(Resource.Id.firstEditText);
             secondEditText = FindViewById<EditText>(Resource.Id.secondEditText);
            var addButton = FindViewById<Button>(Resource.Id.addButton);
            var subtractButton = FindViewById<Button>(Resource.Id.subtractButton);
            var multiplyButton = FindViewById<Button>(Resource.Id.multiplyButton);
            var divideButton = FindViewById<Button>(Resource.Id.divideButton);
             answerText = FindViewById<TextView>(Resource.Id.answerText);

            addButton.Click += AddButton_Click;
            subtractButton.Click += SubtractButton_Click;
            divideButton.Click += DivideButton_Click;
            multiplyButton.Click += MultiplyButton_Click;

        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var answer = int.Parse(firstEditText.Text) + int.Parse(secondEditText.Text);
            answerText.Text = answer.ToString();
        }
        private void SubtractButton_Click(object sender, EventArgs e)
        {
            var answer = int.Parse(firstEditText.Text) - int.Parse(secondEditText.Text);
            answerText.Text = answer.ToString();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            var answer = int.Parse(firstEditText.Text) * int.Parse(secondEditText.Text);
            answerText.Text = answer.ToString();
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            var answer = int.Parse(firstEditText.Text) / int.Parse(secondEditText.Text);
            answerText.Text = answer.ToString();
        }
    }



}