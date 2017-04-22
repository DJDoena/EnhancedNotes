using DoenaSoft.DVDProfiler.EnhancedNotes.Resources;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    [ComVisible(false)]
    [Serializable]
    public sealed class DefaultValues
    {
        #region Labels

        public String Note1Label = Texts.Note1;

        public String Note2Label = Texts.Note2;

        public String Note3Label = Texts.Note3;

        public String Note4Label = Texts.Note4;

        public String Note5Label = Texts.Note5;

        #endregion

        #region Misc

        public Int32 UiLcid
        {
            get
            {
                return (UiLanguage.LCID);
            }
            set
            {
                UiLanguage = CultureInfo.GetCultureInfo(value);
            }
        }

        [XmlIgnore]
        internal CultureInfo UiLanguage;

        public Boolean ExportToCollectionXml = false;

        #endregion

        public DefaultValues()
        {
            UiLanguage = GetUILanguage();
        }

        internal static CultureInfo GetUILanguage()
            => ((Thread.CurrentThread.CurrentUICulture.Name.StartsWith("de")) ? (CultureInfo.GetCultureInfo("de")) : (CultureInfo.GetCultureInfo("en")));
    }
}