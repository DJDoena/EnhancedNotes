using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.EnhancedNotes.Resources;
using Invelos.DVDProfilerPlugin;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    internal sealed class XmlManager
    {
        private readonly Plugin Plugin;

        public XmlManager(Plugin plugin)
        {
            Plugin = plugin;
        }

        #region Export

        internal void Export(Boolean exportAll)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.DefaultExt = ".xml";
                sfd.Filter = "XML files|*.xml";
                sfd.OverwritePrompt = true;
                sfd.RestoreDirectory = true;
                sfd.Title = Texts.SaveXmlFile;
                sfd.FileName = "EnhancedNotes.xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Object[] ids;
                    EnhancedNotesList ets;

                    Cursor.Current = Cursors.WaitCursor;
                    using (ProgressWindow progressWindow = new ProgressWindow())
                    {
                        #region Progress

                        Int32 onePercent;

                        progressWindow.ProgressBar.Minimum = 0;
                        progressWindow.ProgressBar.Step = 1;
                        progressWindow.CanClose = false;

                        #endregion

                        ids = GetProfileIds(exportAll);

                        ets = new EnhancedNotesList();
                        ets.Profiles = new Profile[ids.Length];

                        #region Progress

                        progressWindow.ProgressBar.Maximum = ids.Length;
                        progressWindow.Show();
                        if (TaskbarManager.IsPlatformSupported)
                        {
                            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                            TaskbarManager.Instance.SetProgressValue(0, progressWindow.ProgressBar.Maximum);
                        }
                        onePercent = progressWindow.ProgressBar.Maximum / 100;
                        if ((progressWindow.ProgressBar.Maximum % 100) != 0)
                        {
                            onePercent++;
                        }

                        #endregion

                        for (Int32 i = 0; i < ids.Length; i++)
                        {
                            String id;
                            IDVDInfo profile;

                            id = ids[i].ToString();
                            Plugin.Api.DVDByProfileID(out profile, id, PluginConstants.DATASEC_AllSections, 0);
                            ets.Profiles[i] = GetXmlProfile(profile);

                            #region Progress

                            progressWindow.ProgressBar.PerformStep();
                            if (TaskbarManager.IsPlatformSupported)
                            {
                                TaskbarManager.Instance.SetProgressValue(progressWindow.ProgressBar.Value, progressWindow.ProgressBar.Maximum);
                            }
                            if ((progressWindow.ProgressBar.Value % onePercent) == 0)
                            {
                                Application.DoEvents();
                            }

                            #endregion
                        }

                        try
                        {
                            ets.Serialize(sfd.FileName);

                            #region Progress

                            Application.DoEvents();
                            if (TaskbarManager.IsPlatformSupported)
                            {
                                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                            }
                            progressWindow.CanClose = true;
                            progressWindow.Close();

                            #endregion

                            MessageBox.Show(String.Format(MessageBoxTexts.DoneWithNumber, ids.Length, MessageBoxTexts.Exported)
                                , MessageBoxTexts.InformationHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, sfd.FileName, ex.Message)
                                , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            #region Progress

                            if (progressWindow.Visible)
                            {
                                if (TaskbarManager.IsPlatformSupported)
                                {
                                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                                }
                                progressWindow.CanClose = true;
                                progressWindow.Close();
                            }

                            #endregion
                        }
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private Profile GetXmlProfile(IDVDInfo profile)
        {
            NoteManager noteManager;
            Profile xmlProfile;
            EnhancedNotes en;
            DefaultValues dv;

            dv = Plugin.Settings.DefaultValues;

            noteManager = new NoteManager(profile);

            xmlProfile = new Profile();
            xmlProfile.Id = profile.GetProfileID();
            xmlProfile.Title = profile.GetTitle();
            en = new EnhancedNotes();

            xmlProfile.EnhancedNotes = en;

            en.Note1 = GetText(noteManager.GetNote1, noteManager.GetNote1IsHtml, dv.Note1Label);
            en.Note2 = GetText(noteManager.GetNote2, noteManager.GetNote2IsHtml, dv.Note2Label);
            en.Note3 = GetText(noteManager.GetNote3, noteManager.GetNote3IsHtml, dv.Note3Label);
            en.Note4 = GetText(noteManager.GetNote4, noteManager.GetNote4IsHtml, dv.Note4Label);
            en.Note5 = GetText(noteManager.GetNote5, noteManager.GetNote5IsHtml, dv.Note5Label);

            en.InvelosData = new InvelosData();
            en.InvelosData.Notes = noteManager.GetStandardNotes();

            return (xmlProfile);
        }

        private Text GetText(NoteManager.GetTextDelegate getText
            , Func<Boolean> getIsHtml
            , String displayName)
        {
            Text text;
            String note;

            if (getText(out note))
            {
                text = new Text();
                text.Value = note;
                text.IsHtml = getIsHtml();
                text.DisplayName = displayName;
            }
            else
            {
                text = null;
            }
            return (text);
        }

        #endregion

        #region Import

        internal void Import(Boolean importAll)
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
                    EnhancedNotesList ets;

                    Cursor.Current = Cursors.WaitCursor;

                    ets = null;

                    try
                    {
                        ets = EnhancedNotesList.Deserialize(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, ofd.FileName, ex.Message)
                           , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (ets != null)
                    {
                        Int32 count;

                        count = 0;
                        if ((ets.Profiles != null) && (ets.Profiles.Length > 0))
                        {
                            using (ProgressWindow progressWindow = new ProgressWindow())
                            {
                                Dictionary<String, Boolean> profileIds;
                                Object[] ids;

                                #region Progress

                                Int32 onePercent;

                                progressWindow.ProgressBar.Minimum = 0;
                                progressWindow.ProgressBar.Step = 1;
                                progressWindow.CanClose = false;

                                #endregion

                                ids = GetProfileIds(importAll);

                                profileIds = new Dictionary<String, Boolean>(ids.Length);

                                #region Progress

                                progressWindow.ProgressBar.Maximum = ids.Length;
                                progressWindow.Show();
                                if (TaskbarManager.IsPlatformSupported)
                                {
                                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                                    TaskbarManager.Instance.SetProgressValue(0, progressWindow.ProgressBar.Maximum);
                                }
                                onePercent = progressWindow.ProgressBar.Maximum / 100;
                                if ((progressWindow.ProgressBar.Maximum % 100) != 0)
                                {
                                    onePercent++;
                                }

                                #endregion

                                for (Int32 i = 0; i < ids.Length; i++)
                                {
                                    profileIds.Add(ids[i].ToString(), true);
                                }

                                foreach (Profile xmlProfile in ets.Profiles)
                                {
                                    if ((xmlProfile != null) && (xmlProfile.EnhancedNotes != null) && (profileIds.ContainsKey(xmlProfile.Id)))
                                    {
                                        IDVDInfo profile;
                                        EnhancedNotes en;
                                        NoteManager noteManager;

                                        profile = Plugin.Api.CreateDVD();
                                        profile.SetProfileID(xmlProfile.Id);

                                        noteManager = new NoteManager(profile);

                                        en = xmlProfile.EnhancedNotes;

                                        SetNote(en.Note1, noteManager.SetNote1, noteManager.SetNote1IsHtml);
                                        SetNote(en.Note2, noteManager.SetNote2, noteManager.SetNote2IsHtml);
                                        SetNote(en.Note3, noteManager.SetNote3, noteManager.SetNote3IsHtml);
                                        SetNote(en.Note4, noteManager.SetNote4, noteManager.SetNote4IsHtml);
                                        SetNote(en.Note5, noteManager.SetNote5, noteManager.SetNote5IsHtml);

                                        count++;
                                    }

                                    #region Progress

                                    progressWindow.ProgressBar.PerformStep();
                                    if (TaskbarManager.IsPlatformSupported)
                                    {
                                        TaskbarManager.Instance.SetProgressValue(progressWindow.ProgressBar.Value, progressWindow.ProgressBar.Maximum);
                                    }
                                    if ((progressWindow.ProgressBar.Value % onePercent) == 0)
                                    {
                                        Application.DoEvents();
                                    }

                                    #endregion
                                }

                                #region Progress

                                Application.DoEvents();
                                if (TaskbarManager.IsPlatformSupported)
                                {
                                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                                }
                                progressWindow.CanClose = true;
                                progressWindow.Close();

                                #endregion
                            }
                        }

                        MessageBox.Show(String.Format(MessageBoxTexts.DoneWithNumber, count, MessageBoxTexts.Imported)
                                , MessageBoxTexts.InformationHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void SetNote(Text text
            , Action<String> setText
            , Action<Boolean> setIsHtml)
        {
            if (text != null)
            {
                if (text.Value != null)
                {
                    setText(text.Value);
                }
                else
                {
                    setText(String.Empty);
                }
                setIsHtml(text.IsHtml);
            }
            else
            {
                setText(String.Empty);
                setIsHtml(false);
            }
        }

        #endregion

        private Object[] GetProfileIds(Boolean allIds)
        {
            Object[] ids;

            if (allIds)
            {
                ids = (Object[])(Plugin.Api.GetAllProfileIDs());
            }
            else
            {
                ids = (Object[])(Plugin.Api.GetFlaggedProfileIDs());
            }

            return (ids);
        }
    }
}