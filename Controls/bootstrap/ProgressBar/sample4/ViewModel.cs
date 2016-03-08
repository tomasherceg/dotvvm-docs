using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ProgressBar.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Width { get; set; } = 95;
        public ContextualColor Color { get; set; } = ContextualColor.Info;
        public bool Striped { get; set; } = true;
        public bool Animated { get; set; } = true;

        public void ChangeWidth()
        {
            var random = new Random();
            Width = random.Next(101);
        }

        public void ChangeColor()
        {
            var colors = Enum.GetValues(typeof(ContextualColor)).Cast<ContextualColor>().ToList(); ;
            var random = new Random();
            var c = random.Next(colors.Count);
            Color = colors[c];
        }

        public void ChangeStriped()
        {
            Striped = !Striped;
        }

        public void ChangeAnimated()
        {
            Animated = !Animated;
        }
    }
}
