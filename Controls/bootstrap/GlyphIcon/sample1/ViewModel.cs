using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls.Bootstrap;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.GlyphIcon.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCorrect { get; set; }
        public GlyphIcons Check { get; set; } = GlyphIcons.Check;
        public GlyphIcons Warning_sign { get; set; } = GlyphIcons.Warning_sign;
    }
}