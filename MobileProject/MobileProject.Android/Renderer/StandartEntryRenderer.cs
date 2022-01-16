using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileProject.Droid.Renderer;
using MobileProject.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(StandardEntry), typeof(StandartEntryRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete

namespace MobileProject.Droid.Renderer
{
    [System.Obsolete]

    public class StandartEntryRenderer : EntryRenderer
    {
            protected override FormsEditText CreateNativeControl()
            {
                var control = base.CreateNativeControl();
                UpdateBackground(control);
                return control;
            }
            public StandardEntry ElementV2 => Element as StandardEntry;

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == StandardEntry.CornerRadiusProperty.PropertyName)
                {
                    UpdateBackground();
                }
                else if (e.PropertyName == StandardEntry.BorderThicknessProperty.PropertyName)
                {
                    UpdateBackground();
                }
                else if (e.PropertyName == StandardEntry.BorderColorProperty.PropertyName)
                {
                    UpdateBackground();
                }

                base.OnElementPropertyChanged(sender, e);
            }

            protected override void UpdateBackgroundColor()
            {
                UpdateBackground();
            }
            protected void UpdateBackground(FormsEditText control)
            {
                if (control == null) return;

                var gd = new GradientDrawable();
                gd.SetColor(Element.BackgroundColor.ToAndroid());
                gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
                gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
                control.SetBackground(gd);

                var padTop = (int)Context.ToPixels(ElementV2.Padding.Top);
                var padBottom = (int)Context.ToPixels(ElementV2.Padding.Bottom);
                var padLeft = (int)Context.ToPixels(ElementV2.Padding.Left);
                var padRight = (int)Context.ToPixels(ElementV2.Padding.Right);

                control.SetPadding(padLeft, padTop, padRight, padBottom);
            }
            protected override void UpdateBackground()
            {
                UpdateBackground(Control);
            }
    }
}