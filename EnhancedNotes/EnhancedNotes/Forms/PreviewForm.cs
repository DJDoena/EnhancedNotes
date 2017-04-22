using DoenaSoft.DVDProfiler.EnhancedNotes.Resources;
using System;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    public partial class PreviewForm : Form
    {
        public PreviewForm(String text
            , Boolean isHtml)
        {
            InitializeComponent();
            Text = Texts.Preview;
            WebBrowser.DocumentText = Plugin.HtmlEncode(text, isHtml);
        }
    }
}
