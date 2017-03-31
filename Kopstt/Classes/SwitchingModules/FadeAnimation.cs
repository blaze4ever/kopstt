namespace Kopstt.Classes.SwitchingModules
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;

    public class FadeAnimation
    {
        public void CreateFade(double from, double to, DependencyObject element)
        {
          /*  DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(3));
            da.From = from;
            da.To = to;
            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));

            Storyboard sb = new Storyboard();
            sb.Children.Add(da);
            sb.Begin();
            */
        }
    }
}
