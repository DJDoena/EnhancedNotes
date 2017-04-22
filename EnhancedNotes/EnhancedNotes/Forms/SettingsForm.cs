using DoenaSoft.DVDProfiler.EnhancedNotes.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    public partial class SettingsForm : Form
    {
        private readonly Plugin Plugin;

        public SettingsForm(Plugin plugin)
        {
            Plugin = plugin;

            InitializeComponent();

            SetSettings();
            SetLabels();
            SetToolTips();
            SetComboBoxes();
        }

        private void SetToolTips()
        {
            ToolTip tt;

            tt = new ToolTip();
            tt.SetToolTip(ResetNote1Button, Texts.Reset);
            tt.SetToolTip(ResetNote2Button, Texts.Reset);
            tt.SetToolTip(ResetNote3Button, Texts.Reset);
            tt.SetToolTip(ResetNote4Button, Texts.Reset);
            tt.SetToolTip(ResetNote5Button, Texts.Reset);
        }

        private void SetSettings()
        {
            DefaultValues dv;

            dv = Plugin.Settings.DefaultValues;

            #region Labels

            Note1TextBox.Text = dv.Note1Label;
            Note2TextBox.Text = dv.Note2Label;
            Note3TextBox.Text = dv.Note3Label;
            Note4TextBox.Text = dv.Note4Label;
            Note5TextBox.Text = dv.Note5Label;

            #endregion

            ExportToCollectionXmlCheckBox.Checked = dv.ExportToCollectionXml;
        }

        private void SetComboBoxes()
        {
            Dictionary<Int32, CultureInfo> uiLanguages;
            CultureInfo ci;

            uiLanguages = new Dictionary<Int32, CultureInfo>(2);
            ci = CultureInfo.GetCultureInfo("en");
            uiLanguages.Add(ci.LCID, ci);
            ci = CultureInfo.GetCultureInfo("de");
            uiLanguages.Add(ci.LCID, ci);
            UiLanguageComboBox.DataSource = new BindingSource(uiLanguages, null);
            UiLanguageComboBox.DisplayMember = "Value";
            UiLanguageComboBox.ValueMember = "Key";
            UiLanguageComboBox.Text = Plugin.Settings.DefaultValues.UiLanguage.DisplayName;
        }

        private void SetLabels()
        {
            #region Labels

            Note1Label.Text = Texts.Note1;
            Note2Label.Text = Texts.Note2;
            Note3label.Text = Texts.Note3;
            Note4Label.Text = Texts.Note4;
            Note5Label.Text = Texts.Note5;

            #endregion

            #region Misc

            Text = Texts.Options;

            #region TabPages

            LabelTabPage.Text = Texts.Labels;
            MiscTabPage.Text = Texts.Misc;

            #endregion

            #region Labels

            UiLanguageLabel.Text = Texts.UiLanguage;
            ExportToCollectionXmlCheckBox.Text = Texts.ExportToCollectionXml;

            #endregion

            #region Buttons

            ResetNote1Button.Text = Texts.ResetLabel;
            ResetNote2Button.Text = Texts.ResetLabel;
            ResetNote3Button.Text = Texts.ResetLabel;
            ResetNote4Button.Text = Texts.ResetLabel;
            ResetNote5Button.Text = Texts.ResetLabel;

            SaveButton.Text = Texts.Save;
            DiscardButton.Text = Texts.Cancel;

            #endregion

            #endregion
        }

        private void OnDiscardButtonClick(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSaveButtonClick(Object sender, EventArgs e)
        {
            CultureInfo uiLanguage;
            DefaultValues dv;

            dv = Plugin.Settings.DefaultValues;

            #region Labels

            dv.Note1Label = Note1TextBox.Text;
            dv.Note2Label = Note2TextBox.Text;
            dv.Note3Label = Note3TextBox.Text;
            dv.Note4Label = Note4TextBox.Text;
            dv.Note5Label = Note5TextBox.Text;

            #endregion

            dv.ExportToCollectionXml = ExportToCollectionXmlCheckBox.Checked;

            uiLanguage = GetUiLanguage();
            dv.UiLanguage = uiLanguage;
            Texts.Culture = uiLanguage;
            MessageBoxTexts.Culture = uiLanguage;

            DialogResult = DialogResult.OK;

            Close();
        }

        private CultureInfo GetUiLanguage()
        {
            CultureInfo ci;
            KeyValuePair<Int32, CultureInfo> kvp;

            kvp = (KeyValuePair<Int32, CultureInfo>)(UiLanguageComboBox.SelectedItem);
            ci = kvp.Value;
            return (ci);
        }

        #region OnResetButtonClick

        private void OnResetNote1ButtonClick(Object sender, EventArgs e)
        {
            CultureInfo ci;

            ci = SetTempLanguage();
            Note1TextBox.Text = Texts.Note1;
            UnsetTempLanguage(ci);
        }

        private void OnResetNote2ButtonClick(Object sender, EventArgs e)
        {
            CultureInfo ci;

            ci = SetTempLanguage();
            Note2TextBox.Text = Texts.Note2;
            UnsetTempLanguage(ci);
        }

        private void OnResetNote3ButtonClick(Object sender, EventArgs e)
        {
            CultureInfo ci;

            ci = SetTempLanguage();
            Note3TextBox.Text = Texts.Note3;
            UnsetTempLanguage(ci);
        }

        private void OnResetAdditionalPrice1ButtonClick(Object sender, EventArgs e)
        {
            CultureInfo ci;

            ci = SetTempLanguage();
            Note4TextBox.Text = Texts.Note4;
            UnsetTempLanguage(ci);
        }

        private void OnResetAdditionalPrice2ButtonClick(Object sender, EventArgs e)
        {
            CultureInfo ci;

            ci = SetTempLanguage();
            Note5TextBox.Text = Texts.Note5;
            UnsetTempLanguage(ci);
        }

        private CultureInfo SetTempLanguage()
        {
            CultureInfo previousCI;
            CultureInfo currentCI;

            previousCI = Texts.Culture;
            currentCI = GetUiLanguage();
            Texts.Culture = currentCI;
            return (previousCI);
        }

        private void UnsetTempLanguage(CultureInfo ci)
        {
            Texts.Culture = ci;
        }

        #endregion
    }
}