using System;
using System.Text;
using Invelos.DVDProfilerPlugin;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    internal sealed class NoteManager
    {
        private const String TextNotSet = null;

        private const Boolean IsHtmlNotSet = false;

        private readonly IDVDInfo Profile;

        internal NoteManager(IDVDInfo profile)
        {
            Profile = profile;
        }

        #region Invelos Data

        #region Note

        internal void SetStandardNote(String note)
        {
            Profile.SetNotes(note);
        }

        internal String GetStandardNotes()
        {
            String note;

            note = Profile.GetNotes();
            return (note);
        }

        #endregion

        #endregion

        #region Plugin Data

        #region Note1
        internal String GetNote1WithFallback()
        {
            return (GetTextWithFallback(GetNote1));
        }

        internal Boolean GetNote1(out String note1)
        {
            return (GetText(Constants.Note1, out note1));
        }

        internal void SetNote1(String note1)
        {
            SetText(Constants.Note1, note1);
        }

        internal Boolean GetNote1IsHtml()
        {
            return (GetIsHtml(Constants.Note1));
        }

        internal void SetNote1IsHtml(Boolean isHtml)
        {
            SetIsHtml(Constants.Note1, isHtml);
        }
        #endregion

        #region Note2
        internal String GetNote2WithFallback()
        {
            return (GetTextWithFallback(GetNote2));
        }

        internal Boolean GetNote2(out String note2)
        {
            return (GetText(Constants.Note2, out note2));
        }

        internal void SetNote2(String note2)
        {
            SetText(Constants.Note2, note2);
        }

        internal Boolean GetNote2IsHtml()
        {
            return (GetIsHtml(Constants.Note2));
        }

        internal void SetNote2IsHtml(Boolean isHtml)
        {
            SetIsHtml(Constants.Note2, isHtml);
        }
        #endregion

        #region Note3
        internal String GetNote3WithFallback()
        {
            return (GetTextWithFallback(GetNote3));
        }

        internal Boolean GetNote3(out String note3)
        {
            return (GetText(Constants.Note3, out note3));
        }

        internal void SetNote3(String note3)
        {
            SetText(Constants.Note3, note3);
        }

        internal Boolean GetNote3IsHtml()
        {
            return (GetIsHtml(Constants.Note3));
        }

        internal void SetNote3IsHtml(Boolean isHtml)
        {
            SetIsHtml(Constants.Note3, isHtml);
        }
        #endregion

        #region Note4
        internal String GetNote4WithFallback()
        {
            return (GetTextWithFallback(GetNote4));
        }

        internal Boolean GetNote4(out String note4)
        {
            return (GetText(Constants.Note4, out note4));
        }

        internal void SetNote4(String note4)
        {
            SetText(Constants.Note4, note4);
        }

        internal Boolean GetNote4IsHtml()
        {
            return (GetIsHtml(Constants.Note4));
        }

        internal void SetNote4IsHtml(Boolean isHtml)
        {
            SetIsHtml(Constants.Note4, isHtml);
        }
        #endregion

        #region Note5
        internal String GetNote5WithFallback()
        {
            return (GetTextWithFallback(GetNote5));
        }

        internal Boolean GetNote5(out String note5)
        {
            return (GetText(Constants.Note5, out note5));
        }

        internal void SetNote5(String note5)
        {
            SetText(Constants.Note5, note5);
        }

        internal Boolean GetNote5IsHtml()
        {
            return (GetIsHtml(Constants.Note5));
        }

        internal void SetNote5IsHtml(Boolean isHtml)
        {
            SetIsHtml(Constants.Note5, isHtml);
        }
        #endregion

        #endregion

        #region Text
        internal delegate Boolean GetTextDelegate(out String text);

        internal Boolean GetText(String fieldName, out String text)
        {
            String encoded;
            String decoded;

            decoded = TextNotSet;
            encoded = Profile.GetCustomString(Constants.FieldDomain, fieldName, Constants.ReadKey, TextNotSet);
            if (encoded != TextNotSet)
            {
                decoded = Encoding.Unicode.GetString(Convert.FromBase64String(encoded));
            }
            text = decoded;
            return (text != TextNotSet);
        }

        private String GetTextWithFallback(GetTextDelegate getText)
        {
            String text;

            if (getText(out text) == false)
            {
                text = String.Empty;
            }
            return (text);
        }

        private void SetText(String fieldName, String decoded)
        {
            String encoded;

            encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(decoded));
            Profile.SetCustomString(Constants.FieldDomain, fieldName, Constants.WriteKey, encoded);
        }
        #endregion

        #region IsHtml

        internal Boolean GetIsHtml(String fieldName)
        {
            Boolean isHtml;

            isHtml = Profile.GetCustomBool(Constants.FieldDomain, fieldName + Constants.IsHtmlSuffix, Constants.ReadKey, IsHtmlNotSet);
            return (isHtml);
        }

        private void SetIsHtml(String fieldName, Boolean isHtml)
        {
            Profile.SetCustomBool(Constants.FieldDomain, fieldName + Constants.IsHtmlSuffix, Constants.WriteKey, isHtml);
        }

        #endregion
    }
}