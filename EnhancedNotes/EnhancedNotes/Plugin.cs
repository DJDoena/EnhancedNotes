﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using DoenaSoft.DVDProfiler.DVDProfilerHelper;
using DoenaSoft.DVDProfiler.EnhancedNotes.Resources;
using Invelos.DVDProfilerPlugin;

namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    [Guid(ClassGuid.ClassID), ComVisible(true)]
    public class Plugin : IDVDProfilerPlugin, IDVDProfilerPluginInfo, IDVDProfilerDataAwarePlugin
    {
        private readonly String SettingsFile;

        private readonly String ErrorFile;

        private readonly String ApplicationPath;

        internal IDVDProfilerAPI Api { get; private set; }

        internal Settings Settings { get; private set; }

        private String CurrentProfileId;

        private Boolean DatabaseRestoreRunning = false;

        internal Boolean IsRemoteAccess { get; private set; }

        #region MenuTokens

        private String DvdMenuToken = "";

        private const Int32 DvdMenuId = 1;

        private String PersonalizeScreenToken = "";

        private const Int32 PersonalizeScreenId = 11;

        private String CollectionExportMenuToken = "";

        private const Int32 CollectionExportMenuId = 21;

        private String CollectionImportMenuToken = "";

        private const Int32 CollectionImportMenuId = 22;

        private String CollectionFlaggedExportMenuToken = "";

        private const Int32 CollectionFlaggedExportMenuId = 31;

        private String CollectionFlaggedImportMenuToken = "";

        private const Int32 CollectionFlaggedImportMenuId = 32;

        private String ToolsOptionsMenuToken = "";

        private const Int32 ToolsOptionsMenuId = 41;

        private String ToolsExportOptionsMenuToken = "";

        private const Int32 ToolsExportOptionsMenuId = 42;

        private String ToolsImportOptionsMenuToken = "";

        private const Int32 ToolsImportOptionsMenuId = 43;

        #endregion

        public Plugin()
        {
            ApplicationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Doena Soft\EnhancedNotes\";
            SettingsFile = ApplicationPath + "EnhancedNotes.xml";
            ErrorFile = Environment.GetEnvironmentVariable("TEMP") + @"\EnhancedNotesCrash.xml";
        }

        #region I.. Members

        #region IDVDProfilerPlugin Members

        public void Load(IDVDProfilerAPI api)
        {
            //System.Diagnostics.Debugger.Launch();

            Api = api;

            if (Directory.Exists(ApplicationPath) == false)
            {
                Directory.CreateDirectory(ApplicationPath);
            }
            if (File.Exists(SettingsFile))
            {
                try
                {
                    Settings = Settings.Deserialize(SettingsFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, SettingsFile, ex.Message)
                        , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                        
            EnsureSettingsAndSetUILanguage();

            SetIsRemoteAccess();

            Api.RegisterForEvent(PluginConstants.EVENTID_FormCreated);
            Api.RegisterForEvent(PluginConstants.EVENTID_FormDestroyed);

            Api.RegisterForEvent(PluginConstants.EVENTID_DatabaseOpened);

            Api.RegisterForEvent(PluginConstants.EVENTID_DVDPersonalizeShown);

            Api.RegisterForEvent(PluginConstants.EVENTID_RestoreStarting);
            Api.RegisterForEvent(PluginConstants.EVENTID_RestoreFinished);
            Api.RegisterForEvent(PluginConstants.EVENTID_RestoreCancelled);

            DvdMenuToken = Api.RegisterMenuItemA(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
                , "DVD", Texts.EN, DvdMenuId, "", PluginConstants.SHORTCUT_KEY_A + 13, PluginConstants.SHORTCUT_MOD_Ctrl + PluginConstants.SHORTCUT_MOD_Shift, false);

            CollectionExportMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
             , @"Collection\" + Texts.EN, Texts.ExportToXml, CollectionExportMenuId);
            if (IsRemoteAccess == false)
            {
                CollectionImportMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
                , @"Collection\" + Texts.EN, Texts.ImportFromXml, CollectionImportMenuId);
            }

            CollectionFlaggedExportMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
                , @"Collection\Flagged\" + Texts.EN, Texts.ExportToXml, CollectionFlaggedExportMenuId);
            if (IsRemoteAccess == false)
            {
                CollectionFlaggedImportMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
               , @"Collection\Flagged\" + Texts.EN, Texts.ImportFromXml, CollectionFlaggedImportMenuId);
            }

            ToolsOptionsMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
               , @"Tools\" + Texts.EN, Texts.Options, ToolsOptionsMenuId);
            ToolsExportOptionsMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
                , @"Tools\" + Texts.EN, Texts.ExportOptions, ToolsExportOptionsMenuId);
            ToolsImportOptionsMenuToken = api.RegisterMenuItem(PluginConstants.FORMID_Main, PluginConstants.MENUID_Form
                , @"Tools\" + Texts.EN, Texts.ImportOptions, ToolsImportOptionsMenuId);

            RegisterCustomFields();
        }

        public void Unload()
        {
            Api.UnregisterMenuItem(DvdMenuToken);

            Api.UnregisterMenuItem(CollectionExportMenuToken);
            Api.UnregisterMenuItem(CollectionImportMenuToken);

            Api.UnregisterMenuItem(CollectionFlaggedExportMenuToken);
            Api.UnregisterMenuItem(CollectionFlaggedImportMenuToken);

            Api.UnregisterMenuItem(ToolsOptionsMenuToken);
            Api.UnregisterMenuItem(ToolsExportOptionsMenuToken);
            Api.UnregisterMenuItem(ToolsImportOptionsMenuToken);

            try
            {
                Settings.Serialize(SettingsFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, SettingsFile, ex.Message)
                    , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Api = null;
        }

        public void HandleEvent(Int32 EventType, Object EventData)
        {
            try
            {
                switch (EventType)
                {
                    case (PluginConstants.EVENTID_CustomMenuClick):
                        {
                            HandleMenuClick((Int32)EventData);
                            break;
                        }
                    case (PluginConstants.EVENTID_FormCreated):
                        {
                            if ((Int32)EventData == PluginConstants.FORMID_Personalize)
                            {
                                PersonalizeScreenToken = Api.RegisterMenuItemA(PluginConstants.FORMID_Personalize, PluginConstants.MENUID_Form
                                    , Texts.EN, Texts.EN, PersonalizeScreenId, "", PluginConstants.SHORTCUT_KEY_A + 13, PluginConstants.SHORTCUT_MOD_Ctrl + PluginConstants.SHORTCUT_MOD_Shift, false);
                            }
                            break;
                        }
                    case (PluginConstants.EVENTID_FormDestroyed):
                        {
                            if ((Int32)EventData == PluginConstants.FORMID_Personalize)
                            {
                                if (String.IsNullOrEmpty(PersonalizeScreenToken) == false)
                                {
                                    Api.UnregisterMenuItem(PersonalizeScreenToken);
                                }
                                CurrentProfileId = null;
                            }
                            break;
                        }
                    case (PluginConstants.EVENTID_RestoreStarting):
                        {
                            DatabaseRestoreRunning = true;
                            RegisterCustomFields();
                            break;
                        }
                    case (PluginConstants.EVENTID_DatabaseOpened):
                    case (PluginConstants.EVENTID_RestoreFinished):
                    case (PluginConstants.EVENTID_RestoreCancelled):
                        {
                            DatabaseRestoreRunning = false;
                            RegisterCustomFields();
                            break;
                        }
                    case (PluginConstants.EVENTID_DVDPersonalizeShown):
                        {
                            //System.Diagnostics.Debugger.Launch();
                            CurrentProfileId = (String)EventData;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.CriticalError, ex.Message, ErrorFile)
                        , MessageBoxTexts.CriticalErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (File.Exists(ErrorFile))
                    {
                        File.Delete(ErrorFile);
                    }
                    LogException(ex);
                }
                catch (Exception inEx)
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, ErrorFile, inEx.Message)
                        , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IDVDProfilerPluginInfo Members

        public String GetName()
        {
            return (Texts.PluginName);
        }

        public String GetDescription()
        {
            return (Texts.PluginDescription);
        }

        public String GetAuthorName()
        {
            return ("Doena Soft.");
        }

        public String GetAuthorWebsite()
        {
            return (Texts.PluginUrl);
        }

        public Int32 GetPluginAPIVersion()
        {
            return (PluginConstants.API_VERSION);
        }

        public Int32 GetVersionMajor()
        {
            Version version;

            version = System.Reflection.Assembly.GetAssembly(GetType()).GetName().Version;
            return (version.Major);
        }

        public Int32 GetVersionMinor()
        {
            Version version;

            version = System.Reflection.Assembly.GetAssembly(GetType()).GetName().Version;
            return (version.Minor * 100 + version.Build * 10 + version.Revision);
        }

        #endregion

        #region IDVDProfilerDataAwarePlugin

        public Boolean ExportsCustomDataXML()
        {
            Boolean exportsXml;

            exportsXml = ((Settings.DefaultValues.ExportToCollectionXml)
                && (DatabaseRestoreRunning == false));
            return (exportsXml);
        }

        public String GetCustomDataXMLForDVD(IDVDInfo SourceDVD)
        {
            String xml;
            String note1;
            Boolean hasNote1;
            String note2;
            Boolean hasNote2;
            String note3;
            Boolean hasNote3;
            String note4;
            Boolean hasNote4;
            String note5;
            Boolean hasNote5;
            NoteManager nm;

            if (Settings.DefaultValues.ExportToCollectionXml == false)
            {
                return (String.Empty);
            }

            nm = new NoteManager(SourceDVD);

            hasNote1 = nm.GetNote1(out note1);
            hasNote2 = nm.GetNote2(out note2);
            hasNote3 = nm.GetNote3(out note3);
            hasNote4 = nm.GetNote4(out note4);
            hasNote5 = nm.GetNote5(out note5);

            if (hasNote1 || hasNote2 || hasNote3 || hasNote4 || hasNote5)
            {
                StringBuilder sb;
                DefaultValues dv;
                Boolean isHtml;

                dv = Settings.DefaultValues;
                sb = new StringBuilder("<EnhancedNotes>");
                if (hasNote1)
                {
                    isHtml = nm.GetNote1IsHtml();
                    AddTag(sb, Constants.Note1, dv.Note1Label, note1, isHtml);
                }
                if (hasNote2)
                {
                    isHtml = nm.GetNote2IsHtml();
                    AddTag(sb, Constants.Note2, dv.Note2Label, note2, isHtml);
                }
                if (hasNote3)
                {
                    isHtml = nm.GetNote3IsHtml();
                    AddTag(sb, Constants.Note3, dv.Note3Label, note3, isHtml);
                }
                if (hasNote4)
                {
                    isHtml = nm.GetNote4IsHtml();
                    AddTag(sb, Constants.Note4, dv.Note4Label, note4, isHtml);
                }
                if (hasNote5)
                {
                    isHtml = nm.GetNote5IsHtml();
                    AddTag(sb, Constants.Note5, dv.Note5Label, note5, isHtml);
                }
                sb.Append("</EnhancedNotes>");
                xml = sb.ToString();
            }
            else
            {
                xml = String.Empty;
            }

            return (xml);
        }

        public String GetHTMLForDPVarsFunctionSection()
        {
            return (String.Empty);
        }

        public String GetHTMLForDPVarsDataSection(IDVDInfo SourceDVD, IDVDInfo CompareDVD)
        {
            return (String.Empty);
        }

        public String GetHTMLForTag(String TagName
            , String FullTag
            , IDVDInfo SourceDVD
            , IDVDInfo CompareDVD
            , out Boolean Handled)
        {
            NoteManager noteManager;
            String text;
            DefaultValues dv;

            if (String.IsNullOrEmpty(TagName))
            {
                Handled = false;

                return (null);
            }
            else if (TagName.StartsWith(Constants.HtmlPrefix + ".") == false)
            {
                Handled = false;

                return (null);
            }

            noteManager = new NoteManager(SourceDVD);
            Handled = true;
            dv = Settings.DefaultValues;
            switch (TagName)
            {
                #region Notes
                case (Constants.HtmlPrefix + "." + Constants.Note1):
                    {
                        text = HtmlEncode(noteManager.GetNote1WithFallback(), noteManager.GetNote1IsHtml());
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note2):
                    {
                        text = HtmlEncode(noteManager.GetNote2WithFallback(), noteManager.GetNote2IsHtml());
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note3):
                    {
                        text = HtmlEncode(noteManager.GetNote3WithFallback(), noteManager.GetNote3IsHtml());
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note4):
                    {
                        text = HtmlEncode(noteManager.GetNote4WithFallback(), noteManager.GetNote4IsHtml());
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note5):
                    {
                        text = HtmlEncode(noteManager.GetNote5WithFallback(), noteManager.GetNote5IsHtml());
                        break;
                    }
                #endregion
                #region Labels
                case (Constants.HtmlPrefix + "." + Constants.Note1 + Constants.LabelSuffix):
                    {
                        text = HtmlEncode(dv.Note1Label);
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note2 + Constants.LabelSuffix):
                    {
                        text = HtmlEncode(dv.Note2Label);
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note3 + Constants.LabelSuffix):
                    {
                        text = HtmlEncode(dv.Note3Label);
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note4 + Constants.LabelSuffix):
                    {
                        text = HtmlEncode(dv.Note4Label);
                        break;
                    }
                case (Constants.HtmlPrefix + "." + Constants.Note5 + Constants.LabelSuffix):
                    {
                        text = HtmlEncode(dv.Note5Label);
                        break;
                    }
                #endregion
                default:
                    {
                        Handled = false;
                        text = null;
                        break;
                    }
            }
            return (text);
        }

        public Object GetCustomHTMLTagNames()
        {
            String[] tags;

            tags = new String[] { Constants.HtmlPrefix + "." + Constants.Note1
                , Constants.HtmlPrefix + "." + Constants.Note2
                , Constants.HtmlPrefix + "." + Constants.Note3
                , Constants.HtmlPrefix + "." + Constants.Note4
                , Constants.HtmlPrefix + "." + Constants.Note5
                , Constants.HtmlPrefix + "." + Constants.Note1 + Constants.LabelSuffix
                , Constants.HtmlPrefix + "." + Constants.Note2 + Constants.LabelSuffix
                , Constants.HtmlPrefix + "." + Constants.Note3 + Constants.LabelSuffix
                , Constants.HtmlPrefix + "." + Constants.Note4 + Constants.LabelSuffix
                , Constants.HtmlPrefix + "." + Constants.Note5 + Constants.LabelSuffix };
            return (tags);
        }

        public Object GetCustomHTMLParamsForTag(String TagName)
        {
            return (null);
        }

        public Boolean FilterFieldMatch(String FieldFilterToken, Int32 ComparisonTypeIndex, Object ComparisonValue, IDVDInfo TestDVD)
        {
            return (false);
        }

        #endregion

        #endregion

        #region RegisterCustomFields

        internal void RegisterCustomFields()
        {
            try
            {
                DefaultValues dv;

                #region Schema

                using (Stream stream
                    = typeof(EnhancedNotes).Assembly.GetManifestResourceStream("DoenaSoft.DVDProfiler.EnhancedNotes.EnhancedNotes.xsd"))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        String xsd;

                        xsd = sr.ReadToEnd();
                        Api.SetGlobalSetting(Constants.FieldDomain, "EnhancedNotesSchema", xsd, Constants.ReadKey, Constants.WriteKey);
                    }
                }

                #endregion

                dv = Settings.DefaultValues;

                RegisterCustomField(Constants.Note1, dv.Note1Label);
                RegisterCustomField(Constants.Note2, dv.Note2Label);
                RegisterCustomField(Constants.Note3, dv.Note3Label);
                RegisterCustomField(Constants.Note4, dv.Note4Label);
                RegisterCustomField(Constants.Note5, dv.Note5Label);
            }
            catch (Exception ex)
            {
                ex = WrapCOMException(ex);
                try
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.CriticalError, ex.Message, ErrorFile)
                        , MessageBoxTexts.CriticalErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (File.Exists(ErrorFile))
                    {
                        File.Delete(ErrorFile);
                    }
                    LogException(ex);
                }
                catch (Exception inEx)
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, ErrorFile, inEx.Message)
                        , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterCustomField(String fieldName
            , String displayName)
        {
            RegisterCustomField(fieldName, PluginConstants.FIELD_TYPE_STRING);
            RegisterCustomField(fieldName + Constants.IsHtmlSuffix, PluginConstants.FIELD_TYPE_BOOL);

            //System.Diagnostics.Debugger.Launch();

            //var token = Api.SetCustomFieldFilterableA(displayName, PluginConstants.FILTER_INPUT_TEXT
            //    , new String[] { "Starts with", "Contains" }, null);
        }

        private void RegisterCustomField(String fieldName
            , Int32 fieldType)
        {
            Api.CreateCustomDVDField(Constants.FieldDomain, fieldName, fieldType, Constants.ReadKey, Constants.WriteKey);
            Api.SetCustomDVDFieldStorage(Constants.FieldDomain, fieldName, Constants.WriteKey, true, false);
        }

        #endregion

        private void SetIsRemoteAccess()
        {
            String name;
            Boolean isRemote;
            String localPath;

            Api.GetCurrentDatabaseInformation(out name, out isRemote, out localPath);

            //System.Diagnostics.Debugger.Launch();

            IsRemoteAccess = isRemote;
        }

        private static void AddTag(StringBuilder sb
            , String tagName
            , String displayName
            , String note
            , Boolean isHtml)
        {
            String base64;

            sb.Append("<");
            sb.Append(tagName);
            displayName = XmlConvertHelper.GetWindows1252Text(displayName, out base64);
            sb.Append(" DisplayName=\"");
            sb.Append(displayName);
            sb.Append("\"");
            if (base64 != null)
            {
                sb.Append(" Base64DisplayName=\"");
                sb.Append(base64);
                sb.Append("\"");
            }
            sb.Append(" IsHtml=\"");
            sb.Append(isHtml.ToString().ToLower());
            sb.Append("\"");
            note = XmlConvertHelper.GetWindows1252Text(note, out base64);
            if (base64 != null)
            {
                sb.Append(" Base64Note=\"");
                sb.Append(base64);
                sb.Append("\"");
            }
            sb.Append(">");
            sb.Append(note);
            sb.Append("</");
            sb.Append(tagName);
            sb.Append(">");
        }

        private void EnsureSettingsAndSetUILanguage()
        {
            Texts.Culture = DefaultValues.GetUILanguage();

            CultureInfo uiLanguage = EnsureSettings();

            Texts.Culture = uiLanguage;

            MessageBoxTexts.Culture = uiLanguage;
        }

        private CultureInfo EnsureSettings()
        {
            if (Settings == null)
            {
                Settings = new Settings();
            }

            if (Settings.DefaultValues == null)
            {
                Settings.DefaultValues = new DefaultValues();
            }

            return (Settings.DefaultValues.UiLanguage);
        }

        internal static String HtmlEncode(String decoded
            , Boolean isHtml = false)
        {
            String encoded;

            encoded = String.Join("", decoded.ToCharArray().Select(c =>
                {
                    Int32 number;
                    String newChar;

                    number = (Int32)c;
                    if (number > 127)
                    {
                        newChar = "&#" + number.ToString() + ";";
                    }
                    else if (isHtml == false)
                    {
                        newChar = HttpUtility.HtmlEncode(c.ToString());
                    }
                    else
                    {
                        newChar = c.ToString();
                    }
                    return (newChar);
                }).ToArray());
            if (isHtml == false)
            {
                encoded = encoded.Replace(Environment.NewLine, "<br />" + Environment.NewLine);
            }
            return (encoded);
        }

        private void HandleMenuClick(Int32 MenuEventID)
        {
            try
            {
                switch (MenuEventID)
                {
                    case (DvdMenuId):
                        {
                            OpenEditor(true);
                            break;
                        }
                    case (PersonalizeScreenId):
                        {
                            OpenEditor(false);
                            break;
                        }
                    case (CollectionExportMenuId):
                        {
                            XmlManager xmlManager;

                            xmlManager = new XmlManager(this);
                            xmlManager.Export(true);
                            break;
                        }
                    case (CollectionImportMenuId):
                        {
                            XmlManager xmlManager;

                            xmlManager = new XmlManager(this);
                            xmlManager.Import(true);
                            break;
                        }
                    case (CollectionFlaggedExportMenuId):
                        {
                            XmlManager xmlManager;

                            xmlManager = new XmlManager(this);
                            xmlManager.Export(false);
                            break;
                        }
                    case (CollectionFlaggedImportMenuId):
                        {
                            XmlManager xmlManager;

                            xmlManager = new XmlManager(this);
                            xmlManager.Import(false);
                            break;
                        }
                    case (ToolsOptionsMenuId):
                        {
                            OpenSettings();
                            break;
                        }
                    case (ToolsExportOptionsMenuId):
                        {
                            ExportOptions();
                            break;
                        }
                    case (ToolsImportOptionsMenuId):
                        {
                            ImportOptions();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.CriticalError, ex.Message, ErrorFile)
                        , MessageBoxTexts.CriticalErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (File.Exists(ErrorFile))
                    {
                        File.Delete(ErrorFile);
                    }
                    LogException(ex);
                }
                catch (Exception inEx)
                {
                    MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeWritten, ErrorFile, inEx.Message), MessageBoxTexts.ErrorHeader
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void ImportOptions()
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
                    DefaultValues dv;

                    dv = null;
                    try
                    {
                        dv = Serializer<DefaultValues>.Deserialize(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(MessageBoxTexts.FileCantBeRead, ofd.FileName, ex.Message)
                           , MessageBoxTexts.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (dv != null)
                    {
                        Settings.DefaultValues = dv;
                        Texts.Culture = dv.UiLanguage;
                        MessageBoxTexts.Culture = dv.UiLanguage;
                        MessageBox.Show(MessageBoxTexts.Done, MessageBoxTexts.InformationHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        internal void ExportOptions()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.DefaultExt = ".xml";
                sfd.Filter = "XML files|*.xml";
                sfd.OverwritePrompt = true;
                sfd.RestoreDirectory = true;
                sfd.Title = Texts.SaveXmlFile;
                sfd.FileName = "EnhancedNotesOptions.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DefaultValues dv = Settings.DefaultValues;

                    try
                    {
                        Serializer<DefaultValues>.Serialize(sfd.FileName, dv);

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

        private void OpenSettings()
        {
            using (SettingsForm form = new SettingsForm(this))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RegisterCustomFields();
                }
            }
        }

        private void OpenEditor(Boolean fullEdit)
        {
            IDVDInfo profile;
            String profileId;

            profileId = CurrentProfileId;
            if (String.IsNullOrEmpty(profileId))
            {
                profile = Api.GetDisplayedDVD();
                profileId = profile.GetProfileID();
            }
            if (String.IsNullOrEmpty(profileId) == false)
            {
                Api.DVDByProfileID(out profile, profileId, PluginConstants.DATASEC_AllSections, -1);
                if (profile.GetProfileID() == null)
                {
                    profile = Api.CreateDVD();
                    profile.SetProfileID(profileId);
                }
                using (MainForm form = new MainForm(this, profile, fullEdit))
                {
                    form.ShowDialog();
                }
            }
        }

        private void LogException(Exception ex)
        {
            ExceptionXml exceptionXml;

            ex = WrapCOMException(ex);

            exceptionXml = new ExceptionXml(ex);

            Serializer<ExceptionXml>.Serialize(ErrorFile, exceptionXml);
        }

        private Exception WrapCOMException(Exception ex)
        {
            COMException comEx;
            Exception returnEx;

            comEx = ex as COMException;

            if (comEx != null)
            {
                EnhancedCOMException newEx;
                String lastApiError;

                lastApiError = Api.GetLastError();
                newEx = new EnhancedCOMException(comEx, lastApiError);

                returnEx = newEx;
            }
            else
            {
                returnEx = ex;
            }

            return (returnEx);
        }

        #region Plugin Registering

        [DllImport("user32.dll")]
        public extern static int SetParent(int child, int parent);

        [ComImport(), Guid("0002E005-0000-0000-C000-000000000046")]
        internal class StdComponentCategoriesMgr { }

        [ComRegisterFunction()]
        public static void RegisterServer(Type t)
        {
            CategoryRegistrar.ICatRegister cr = (CategoryRegistrar.ICatRegister)new StdComponentCategoriesMgr();
            Guid clsidThis = new Guid(ClassGuid.ClassID);
            Guid catid = new Guid("833F4274-5632-41DB-8FC5-BF3041CEA3F1");

            cr.RegisterClassImplCategories(ref clsidThis, 1,
                new Guid[] { catid });
        }

        [ComUnregisterFunction()]
        public static void UnregisterServer(Type t)
        {
            CategoryRegistrar.ICatRegister cr = (CategoryRegistrar.ICatRegister)new StdComponentCategoriesMgr();
            Guid clsidThis = new Guid(ClassGuid.ClassID);
            Guid catid = new Guid("833F4274-5632-41DB-8FC5-BF3041CEA3F1");

            cr.UnRegisterClassImplCategories(ref clsidThis, 1,
                new Guid[] { catid });
        }

        #endregion
    }
}