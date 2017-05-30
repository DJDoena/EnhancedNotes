using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.EnhancedNotes.Resources;
using Invelos.DVDProfilerPlugin;
using System;
using System.IO;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    internal sealed partial class MainForm : Form
    {
        private readonly Plugin Plugin;

        private readonly IDVDInfo Profile;

        private readonly NoteManager NoteManager;

        private readonly Boolean FullEdit;

        private Boolean DataChanged;

        private SelectedTabPage SelectedTab;

        internal MainForm(Plugin plugin
            , IDVDInfo profile
            , Boolean fullEdit)
        {
            Plugin = plugin;
            Profile = profile;
            FullEdit = fullEdit;
            SelectedTab = SelectedTabPage.StandardNotes;

            InitializeComponent();

            NoteManager = new NoteManager(Profile);

            SetTextBoxes();
            SetCheckBoxes();
            SetLabels();
            SetReadOnlies();

            DataChanged = false;
        }

        private void SetReadOnlies()
        {
            StandardNotesTextBox.Enabled = FullEdit;

            if (Plugin.IsRemoteAccess)
            {
                ImportFromXMLToolStripMenuItem.Enabled = false;
                PasteAllToolStripMenuItem.Enabled = false;
                PasteCurrentTextBoxToolStripMenuItem.Enabled = false;
                SaveButton.Enabled = false;

                SetControlsReadonly(Controls);
            }
        }

        private void SetControlsReadonly(Control.ControlCollection controls)
        {
            if (controls != null)
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).ReadOnly = true;
                    }
                    else
                    {
                        SetControlsReadonly(control.Controls);
                    }
                }
            }
        }

        private void SetCheckBoxes()
        {
            Note1CheckBox.Checked = NoteManager.GetNote1IsHtml();
            Note2CheckBox.Checked = NoteManager.GetNote2IsHtml();
            Note3CheckBox.Checked = NoteManager.GetNote3IsHtml();
            Note4CheckBox.Checked = NoteManager.GetNote4IsHtml();
            Note5CheckBox.Checked = NoteManager.GetNote5IsHtml();
        }

        private void SetTextBoxes()
        {
            #region Invelos Data

            StandardNotesTextBox.Text = NoteManager.GetStandardNotes();

            #endregion

            #region Plugin Data

            Note1TextBox.Text = NoteManager.GetNote1WithFallback();
            Note2TextBox.Text = NoteManager.GetNote2WithFallback();
            Note3TextBox.Text = NoteManager.GetNote3WithFallback();
            Note4TextBox.Text = NoteManager.GetNote4WithFallback();
            Note5TextBox.Text = NoteManager.GetNote5WithFallback();

            #endregion
        }

        private void SetLabels()
        {
            DefaultValues dv;

            dv = Plugin.Settings.DefaultValues;

            #region Invelos Data

            StandardNotesTabPage.Text = Texts.StandardNote;

            #endregion

            #region Plugin Data

            Note1TabPage.Text = dv.Note1Label;
            Note2TabPage.Text = dv.Note2Label;
            Note3TabPage.Text = dv.Note3Label;
            Note4TabPage.Text = dv.Note4Label;
            Note5TabPage.Text = dv.Note5Label;

            #endregion

            #region Misc

            #region TabPages

            InvelosDataTabPage.Text = Texts.InvelosData;
            PluginDataTabPage.Text = Texts.PluginData;

            #endregion

            #region CheckBoxes

            Note1CheckBox.Text = Texts.IsHtml;
            Note2CheckBox.Text = Texts.IsHtml;
            Note3CheckBox.Text = Texts.IsHtml;
            Note4CheckBox.Text = Texts.IsHtml;
            Note5CheckBox.Text = Texts.IsHtml;

            #endregion

            #region Menu

            PreviewToolStripMenuItem.Text = Texts.Preview;

            EditToolStripMenuItem.Text = Texts.Edit;
            CopyCurrentTextBoxToolStripMenuItem.Text = Texts.CopyCurrentToClipboard;
            PasteCurrentTextBoxToolStripMenuItem.Text = Texts.PasteCurrentFromClipboard;
            CopyAllToolStripMenuItem.Text = Texts.CopyAllToClipboard;
            PasteAllToolStripMenuItem.Text = Texts.PasteAllFromClipboard;

            ToolsToolStripMenuItem.Text = Texts.Tools;
            OptionsToolStripMenuItem.Text = Texts.Options;
            ExportToXMLToolStripMenuItem.Text = Texts.ExportToXml;
            ImportFromXMLToolStripMenuItem.Text = Texts.ImportFromXml;
            ExportOptionsToolStripMenuItem.Text = Texts.ExportOptions;
            ImportOptionsToolStripMenuItem.Text = Texts.ImportOptions;

            AboutToolStripMenuItem.Text = Texts.About;
            CheckForUpdatesToolStripMenuItem.Text = Texts.CheckForUpdates;
            HelpToolStripMenuItem.Text = Texts.Help;

            #endregion

            #region Buttons

            SaveButton.Text = Texts.Save;
            DiscardButton.Text = Texts.Cancel;

            #endregion

            #endregion
        }

        private void OnSaveButtonClick(Object sender, EventArgs e)
        {
            #region Invelos Data

            if (FullEdit)
            {
                NoteManager.SetStandardNote(StandardNotesTextBox.Text);
            }

            #endregion

            #region Plugin Data

            NoteManager.SetNote1(Note1TextBox.Text);
            NoteManager.SetNote2(Note2TextBox.Text);
            NoteManager.SetNote3(Note3TextBox.Text);
            NoteManager.SetNote4(Note4TextBox.Text);
            NoteManager.SetNote5(Note5TextBox.Text);

            NoteManager.SetNote1IsHtml(Note1CheckBox.Checked);
            NoteManager.SetNote2IsHtml(Note2CheckBox.Checked);
            NoteManager.SetNote3IsHtml(Note3CheckBox.Checked);
            NoteManager.SetNote4IsHtml(Note4CheckBox.Checked);
            NoteManager.SetNote5IsHtml(Note5CheckBox.Checked);

            #endregion

            if (FullEdit)
            {
                Plugin.Api.SaveDVDToCollection(Profile);
            }

            Plugin.Api.ReloadCurrentDVD();

            DataChanged = false;

            Close();
        }

        private void OnDiscardButtonClick(Object sender, EventArgs e)
        {
            Close();
        }

        private void OnOptionsToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm(Plugin))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SetLabels();
                    Plugin.RegisterCustomFields();
                }
            }
        }

        private void OnExportToXMLToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.DefaultExt = ".xml";
                sfd.Filter = "XML files|*.xml";
                sfd.OverwritePrompt = true;
                sfd.RestoreDirectory = true;
                sfd.Title = Texts.SaveXmlFile;
                sfd.FileName = "EnhancedNotes." + Profile.GetProfileID() + ".xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    EnhancedNotes en;

                    en = GetEnhancedNotesForXmlStructure();

                    try
                    {
                        en.Serialize(sfd.FileName);
                        MessageBox.Show(MessageBoxTexts.Done, MessageBoxTexts.InformationHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, sfd.FileName, ex.Message)
                            , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private EnhancedNotes GetEnhancedNotesForXmlStructure()
        {
            EnhancedNotes en;
            DefaultValues dv;

            dv = Plugin.Settings.DefaultValues;
            en = new EnhancedNotes();

            en.Note1 = GetText(Note1TextBox, Note1CheckBox, dv.Note1Label);
            en.Note2 = GetText(Note2TextBox, Note2CheckBox, dv.Note2Label);
            en.Note3 = GetText(Note3TextBox, Note3CheckBox, dv.Note3Label);
            en.Note4 = GetText(Note4TextBox, Note4CheckBox, dv.Note4Label);
            en.Note5 = GetText(Note5TextBox, Note5CheckBox, dv.Note5Label);

            en.InvelosData = new InvelosData();
            en.InvelosData.Notes = StandardNotesTextBox.Text;

            return (en);
        }

        private Text GetText(TextBox textBox
            , CheckBox checkBox
            , String displayName)
        {
            Text text;
            String standardNotes;

            standardNotes = textBox.Text;
            if (String.IsNullOrEmpty(standardNotes) == false)
            {
                text = new Text();
                text.Value = standardNotes;
                text.IsHtml = checkBox.Checked;
                text.DisplayName = displayName;
            }
            else
            {
                text = null;
            }
            return (text);
        }

        private void OnImportFromXMLToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Filter = "XML files|*.xml";
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.Title = Texts.LoadXmlFile;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    EnhancedNotes en;

                    try
                    {
                        en = EnhancedNotes.Deserialize(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        en = null;
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, ofd.FileName, ex.Message)
                           , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (en != null)
                    {
                        SetEnhancedNotesFromXmlStructure(en);
                    }
                }
            }
        }

        private void SetEnhancedNotesFromXmlStructure(EnhancedNotes en)
        {
            SetText(en.Note1, Note1TextBox, Note1CheckBox);
            SetText(en.Note2, Note2TextBox, Note2CheckBox);
            SetText(en.Note3, Note3TextBox, Note3CheckBox);
            SetText(en.Note4, Note4TextBox, Note4CheckBox);
            SetText(en.Note5, Note5TextBox, Note5CheckBox);
        }

        private void SetText(Text text
            , TextBox textBox
            , CheckBox checkBox)
        {
            textBox.Text = String.Empty;
            checkBox.Checked = false;
            if (text != null)
            {
                if (text.Value != null)
                {
                    textBox.Text = RestoreLineBreaks(text.Value);
                }
                checkBox.Checked = text.IsHtml;
            }
        }

        private void OnCheckForUpdatesToolStripMenuItemClick(Object sender, EventArgs e)
        {
            OnlineAccess.Init("Doena Soft.", "EnhancedNotes");
            OnlineAccess.CheckForNewVersion("http://doena-soft.de/dvdprofiler/4.0.0/versions.xml", this, "EnhancedNotes", GetType().Assembly);
        }

        private void OnAboutToolStripMenuItemClick(Object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox(GetType().Assembly))
            {
                aboutBox.ShowDialog();
            }
        }

        private void OnDataChanged(Object sender, EventArgs e)
        {
            DataChanged = true;
        }

        private void OnFormClosing(Object sender, FormClosingEventArgs e)
        {
            if (DataChanged)
            {
                if (MessageBox.Show(MessageBoxTexts.AbandonChangesText, MessageBoxTexts.AbandonChangesHeader, MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void OnImportOptionsToolStripMenuItemClick(Object sender, EventArgs e)
        {
            Plugin.ImportOptions();
            SetLabels();
        }

        private void OnExportOptionsToolStripMenuItemClick(Object sender, EventArgs e)
        {
            Plugin.ExportOptions();
        }

        private void OnPreviewToolStripMenuItemClick(Object sender, EventArgs e)
        {
            switch (SelectedTab)
            {
                case (SelectedTabPage.StandardNotes):
                    {
                        ShowPreview(StandardNotesTextBox, null);
                        break;
                    }
                case (SelectedTabPage.Note1):
                    {
                        ShowPreview(Note1TextBox, Note1CheckBox);
                        break;
                    }
                case (SelectedTabPage.Note2):
                    {
                        ShowPreview(Note2TextBox, Note2CheckBox);
                        break;
                    }
                case (SelectedTabPage.Note3):
                    {
                        ShowPreview(Note3TextBox, Note3CheckBox);
                        break;
                    }
                case (SelectedTabPage.Note4):
                    {
                        ShowPreview(Note4TextBox, Note4CheckBox);
                        break;
                    }
                case (SelectedTabPage.Note5):
                    {
                        ShowPreview(Note5TextBox, Note5CheckBox);
                        break;
                    }
            }
        }

        private void ShowPreview(TextBox textBox
            , CheckBox checkBox)
        {
            Boolean isHtml;

            isHtml = true;
            if (checkBox != null)
            {
                isHtml = checkBox.Checked;
            }
            using (PreviewForm form = new PreviewForm(textBox.Text, isHtml))
            {
                form.ShowDialog();
            }
        }

        private void OnTabPageSelected(Object sender, TabControlEventArgs e)
        {
            TabPage tabPage;

            tabPage = e.TabPage;

            if (tabPage == InvelosDataTabPage)
            {
                SetSelectedTab(InvelosDataTabControl.SelectedTab);
            }
            else if (tabPage == PluginDataTabPage)
            {
                SetSelectedTab(NotesTabControl.SelectedTab);
            }
            else
            {
                SetSelectedTab(tabPage);
            }
        }

        private void SetSelectedTab(TabPage tabPage)
        {
            if (tabPage == StandardNotesTabPage)
            {
                SelectedTab = SelectedTabPage.StandardNotes;
            }
            else if (tabPage == Note1TabPage)
            {
                SelectedTab = SelectedTabPage.Note1;
            }
            else if (tabPage == Note2TabPage)
            {
                SelectedTab = SelectedTabPage.Note2;
            }
            else if (tabPage == Note3TabPage)
            {
                SelectedTab = SelectedTabPage.Note3;
            }
            else if (tabPage == Note4TabPage)
            {
                SelectedTab = SelectedTabPage.Note4;
            }
            else if (tabPage == Note5TabPage)
            {
                SelectedTab = SelectedTabPage.Note5;
            }
        }

        private void OnCopyAllToolStripMenuItemClick(Object sender, EventArgs e)
        {
            EnhancedNotes en;
            String xml;

            en = GetEnhancedNotesForXmlStructure();

            using (Utf8StringWriter sw = new Utf8StringWriter())
            {
                EnhancedNotes.XmlSerializer.Serialize(sw, en);

                xml = sw.ToString();
            }

            try
            {
                Clipboard.SetDataObject(xml, true, 4, 250);
            }
            catch
            {
                MessageBox.Show(MessageBoxTexts.CopyToClipboardFailed, MessageBoxTexts.ErrorHeader
                 , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OnPasteAllToolStripMenuItemClick(Object sender, EventArgs e)
        {
            EnhancedNotes en;

            try
            {
                String xml;

                xml = Clipboard.GetText();

                using (StringReader sr = new StringReader(xml))
                {
                    en = (EnhancedNotes)(EnhancedNotes.XmlSerializer.Deserialize(sr));
                }
            }
            catch
            {
                en = null;
                MessageBox.Show(MessageBoxTexts.PasteFromClipboardFailed, MessageBoxTexts.ErrorHeader
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (en != null)
            {
                SetEnhancedNotesFromXmlStructure(en);

                SetStandardNotes(en);
            }
        }

        private void SetStandardNotes(EnhancedNotes en)
        {
            if (FullEdit == false)
            {
                return;
            }

            if ((en.InvelosData != null) && (String.IsNullOrEmpty(en.InvelosData.Notes) == false))
            {
                StandardNotesTextBox.Text = RestoreLineBreaks(en.InvelosData.Notes);
            }
            else
            {
                StandardNotesTextBox.Text = String.Empty;
            }
        }

        private static String RestoreLineBreaks(String text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                text = text.Replace("\r\n", "\n").Replace("\n", "\r\n");
            }

            return (text);
        }

        private void OnCopyCurrentTextBoxToolStripMenuItemClick(Object sender, EventArgs e)
        {
            switch (SelectedTab)
            {
                case (SelectedTabPage.StandardNotes):
                    {
                        CopyNoteToClipboard(StandardNotesTextBox);
                        break;
                    }
                case (SelectedTabPage.Note1):
                    {
                        CopyNoteToClipboard(Note1TextBox);
                        break;
                    }
                case (SelectedTabPage.Note2):
                    {
                        CopyNoteToClipboard(Note2TextBox);
                        break;
                    }
                case (SelectedTabPage.Note3):
                    {
                        CopyNoteToClipboard(Note3TextBox);
                        break;
                    }
                case (SelectedTabPage.Note4):
                    {
                        CopyNoteToClipboard(Note4TextBox);
                        break;
                    }
                case (SelectedTabPage.Note5):
                    {
                        CopyNoteToClipboard(Note5TextBox);
                        break;
                    }
            }
        }

        private void CopyNoteToClipboard(TextBox textBox)
        {
            try
            {
                Clipboard.SetDataObject(textBox.Text, true, 4, 250);
            }
            catch
            {
                MessageBox.Show(MessageBoxTexts.CopyToClipboardFailed, MessageBoxTexts.ErrorHeader
                 , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OnPasteCurrentTextBoxToolStripMenuItemClick(Object sender, EventArgs e)
        {
            switch (SelectedTab)
            {
                case (SelectedTabPage.StandardNotes):
                    {
                        PasteNoteFromClipboard(StandardNotesTextBox);
                        break;
                    }
                case (SelectedTabPage.Note1):
                    {
                        PasteNoteFromClipboard(Note1TextBox);
                        break;
                    }
                case (SelectedTabPage.Note2):
                    {
                        PasteNoteFromClipboard(Note2TextBox);
                        break;
                    }
                case (SelectedTabPage.Note3):
                    {
                        PasteNoteFromClipboard(Note3TextBox);
                        break;
                    }
                case (SelectedTabPage.Note4):
                    {
                        PasteNoteFromClipboard(Note4TextBox);
                        break;
                    }
                case (SelectedTabPage.Note5):
                    {
                        PasteNoteFromClipboard(Note5TextBox);
                        break;
                    }
            }
        }

        private void PasteNoteFromClipboard(TextBox textBox)
        {
            String text;

            textBox.Text = String.Empty;

            text = Clipboard.GetText();

            if (String.IsNullOrEmpty(text) == false)
            {
                textBox.Text = RestoreLineBreaks(text);
            }
        }
    }
}