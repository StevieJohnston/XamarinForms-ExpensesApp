using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinForms_ExpensesApp.iOS.CustomRenderers;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressbarRenderer))]
namespace XamarinForms_ExpensesApp.iOS.CustomRenderers
{
    public class CustomProgressbarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            LayoutSubviews();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            float x = 1.0f;
            float y = 4.0f;

            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);
            Transform = transform;
        }
    }
}
