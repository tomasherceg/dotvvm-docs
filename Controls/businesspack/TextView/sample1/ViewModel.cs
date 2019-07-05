using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextView.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ContactInfo { get; set; } = "RIGANTI s.r.o.\nSokolovská 352/215\ninfo@riganti.cz\nwww.dotvvm.com";

        public string Paragraphs { get; set; } = @"TextView
                                                   Converts a multi-line texts to HTML with keeping the line endings. 
                                                   Detects URL and e-mail addresses and converts them to hyperlinks. 
                                                   The text is HTML encoded to prevent XSS attacks.

                                                   Usage & Scenarios
                                                   This control can render long texts and convert them into HTML. 
                                                   It can detect URLs and e-mail addresses and generate hyperlinks for them. 
                                                   It also preserves line endings and HTML encodes the content so it is safe to render as HTML.";
    }
}