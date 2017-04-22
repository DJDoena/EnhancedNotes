namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SaveButton = new System.Windows.Forms.Button();
            this.DiscardButton = new System.Windows.Forms.Button();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFromXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.PreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyCurrentTextBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteCurrentTextBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.InvelosDataTabPage = new System.Windows.Forms.TabPage();
            this.InvelosDataTabControl = new System.Windows.Forms.TabControl();
            this.StandardNotesTabPage = new System.Windows.Forms.TabPage();
            this.StandardNotesTextBox = new System.Windows.Forms.TextBox();
            this.PluginDataTabPage = new System.Windows.Forms.TabPage();
            this.NotesTabControl = new System.Windows.Forms.TabControl();
            this.Note1TabPage = new System.Windows.Forms.TabPage();
            this.Note1CheckBox = new System.Windows.Forms.CheckBox();
            this.Note1TextBox = new System.Windows.Forms.TextBox();
            this.Note2TabPage = new System.Windows.Forms.TabPage();
            this.Note2CheckBox = new System.Windows.Forms.CheckBox();
            this.Note2TextBox = new System.Windows.Forms.TextBox();
            this.Note3TabPage = new System.Windows.Forms.TabPage();
            this.Note3CheckBox = new System.Windows.Forms.CheckBox();
            this.Note3TextBox = new System.Windows.Forms.TextBox();
            this.Note4TabPage = new System.Windows.Forms.TabPage();
            this.Note4CheckBox = new System.Windows.Forms.CheckBox();
            this.Note4TextBox = new System.Windows.Forms.TextBox();
            this.Note5TabPage = new System.Windows.Forms.TabPage();
            this.Note5CheckBox = new System.Windows.Forms.CheckBox();
            this.Note5TextBox = new System.Windows.Forms.TextBox();
            this.MainMenu.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.InvelosDataTabPage.SuspendLayout();
            this.InvelosDataTabControl.SuspendLayout();
            this.StandardNotesTabPage.SuspendLayout();
            this.PluginDataTabPage.SuspendLayout();
            this.NotesTabControl.SuspendLayout();
            this.Note1TabPage.SuspendLayout();
            this.Note2TabPage.SuspendLayout();
            this.Note3TabPage.SuspendLayout();
            this.Note4TabPage.SuspendLayout();
            this.Note5TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(616, 478);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // DiscardButton
            // 
            this.DiscardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscardButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardButton.Location = new System.Drawing.Point(697, 478);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(75, 23);
            this.DiscardButton.TabIndex = 2;
            this.DiscardButton.Text = "Cancel";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.OnDiscardButtonClick);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsToolStripMenuItem,
            this.ExportToXMLToolStripMenuItem,
            this.ImportFromXMLToolStripMenuItem,
            this.ExportOptionsToolStripMenuItem,
            this.ImportOptionsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ToolsToolStripMenuItem.Text = "&Tools";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.OptionsToolStripMenuItem.Text = "&Options";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OnOptionsToolStripMenuItemClick);
            // 
            // ExportToXMLToolStripMenuItem
            // 
            this.ExportToXMLToolStripMenuItem.Name = "ExportToXMLToolStripMenuItem";
            this.ExportToXMLToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ExportToXMLToolStripMenuItem.Text = "&Export to XML";
            this.ExportToXMLToolStripMenuItem.Click += new System.EventHandler(this.OnExportToXMLToolStripMenuItemClick);
            // 
            // ImportFromXMLToolStripMenuItem
            // 
            this.ImportFromXMLToolStripMenuItem.Name = "ImportFromXMLToolStripMenuItem";
            this.ImportFromXMLToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ImportFromXMLToolStripMenuItem.Text = "&Import from XML";
            this.ImportFromXMLToolStripMenuItem.Click += new System.EventHandler(this.OnImportFromXMLToolStripMenuItemClick);
            // 
            // ExportOptionsToolStripMenuItem
            // 
            this.ExportOptionsToolStripMenuItem.Name = "ExportOptionsToolStripMenuItem";
            this.ExportOptionsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ExportOptionsToolStripMenuItem.Text = "Export Options";
            this.ExportOptionsToolStripMenuItem.Click += new System.EventHandler(this.OnExportOptionsToolStripMenuItemClick);
            // 
            // ImportOptionsToolStripMenuItem
            // 
            this.ImportOptionsToolStripMenuItem.Name = "ImportOptionsToolStripMenuItem";
            this.ImportOptionsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.ImportOptionsToolStripMenuItem.Text = "Import Options";
            this.ImportOptionsToolStripMenuItem.Click += new System.EventHandler(this.OnImportOptionsToolStripMenuItemClick);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForUpdatesToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            this.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            this.CheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.CheckForUpdatesToolStripMenuItem.Text = "&Check for Updates";
            this.CheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.OnCheckForUpdatesToolStripMenuItemClick);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreviewToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // PreviewToolStripMenuItem
            // 
            this.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem";
            this.PreviewToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.PreviewToolStripMenuItem.Text = "Preview";
            this.PreviewToolStripMenuItem.Click += new System.EventHandler(this.OnPreviewToolStripMenuItemClick);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyCurrentTextBoxToolStripMenuItem,
            this.PasteCurrentTextBoxToolStripMenuItem,
            this.CopyAllToolStripMenuItem,
            this.PasteAllToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "&Edit";
            // 
            // CopyAllToolStripMenuItem
            // 
            this.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem";
            this.CopyAllToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.CopyAllToolStripMenuItem.Text = "&Copy all";
            this.CopyAllToolStripMenuItem.Click += new System.EventHandler(this.OnCopyAllToolStripMenuItemClick);
            // 
            // PasteAllToolStripMenuItem
            // 
            this.PasteAllToolStripMenuItem.Name = "PasteAllToolStripMenuItem";
            this.PasteAllToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.PasteAllToolStripMenuItem.Text = "&Paste all";
            this.PasteAllToolStripMenuItem.Click += new System.EventHandler(this.OnPasteAllToolStripMenuItemClick);
            // 
            // CopyCurrentTextBoxToolStripMenuItem
            // 
            this.CopyCurrentTextBoxToolStripMenuItem.Name = "CopyCurrentTextBoxToolStripMenuItem";
            this.CopyCurrentTextBoxToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.CopyCurrentTextBoxToolStripMenuItem.Text = "Copy current text box";
            this.CopyCurrentTextBoxToolStripMenuItem.Click += new System.EventHandler(this.OnCopyCurrentTextBoxToolStripMenuItemClick);
            // 
            // PasteCurrentTextBoxToolStripMenuItem
            // 
            this.PasteCurrentTextBoxToolStripMenuItem.Name = "PasteCurrentTextBoxToolStripMenuItem";
            this.PasteCurrentTextBoxToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.PasteCurrentTextBoxToolStripMenuItem.Text = "Paste current text box";
            this.PasteCurrentTextBoxToolStripMenuItem.Click += new System.EventHandler(this.OnPasteCurrentTextBoxToolStripMenuItemClick);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.InvelosDataTabPage);
            this.MainTabControl.Controls.Add(this.PluginDataTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 27);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(760, 445);
            this.MainTabControl.TabIndex = 4;
            this.MainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabPageSelected);
            // 
            // InvelosDataTabPage
            // 
            this.InvelosDataTabPage.Controls.Add(this.InvelosDataTabControl);
            this.InvelosDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.InvelosDataTabPage.Name = "InvelosDataTabPage";
            this.InvelosDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InvelosDataTabPage.Size = new System.Drawing.Size(752, 419);
            this.InvelosDataTabPage.TabIndex = 0;
            this.InvelosDataTabPage.Text = "Invelos Data";
            this.InvelosDataTabPage.UseVisualStyleBackColor = true;
            // 
            // InvelosDataTabControl
            // 
            this.InvelosDataTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InvelosDataTabControl.Controls.Add(this.StandardNotesTabPage);
            this.InvelosDataTabControl.Location = new System.Drawing.Point(6, 6);
            this.InvelosDataTabControl.Name = "InvelosDataTabControl";
            this.InvelosDataTabControl.SelectedIndex = 0;
            this.InvelosDataTabControl.Size = new System.Drawing.Size(740, 407);
            this.InvelosDataTabControl.TabIndex = 0;
            this.InvelosDataTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabPageSelected);
            // 
            // StandardNotesTabPage
            // 
            this.StandardNotesTabPage.Controls.Add(this.StandardNotesTextBox);
            this.StandardNotesTabPage.Location = new System.Drawing.Point(4, 22);
            this.StandardNotesTabPage.Name = "StandardNotesTabPage";
            this.StandardNotesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StandardNotesTabPage.Size = new System.Drawing.Size(732, 381);
            this.StandardNotesTabPage.TabIndex = 1;
            this.StandardNotesTabPage.Text = "Standard Notes";
            this.StandardNotesTabPage.UseVisualStyleBackColor = true;
            // 
            // StandardNotesTextBox
            // 
            this.StandardNotesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StandardNotesTextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.StandardNotesTextBox.Location = new System.Drawing.Point(6, 6);
            this.StandardNotesTextBox.MaxLength = 10000000;
            this.StandardNotesTextBox.Multiline = true;
            this.StandardNotesTextBox.Name = "StandardNotesTextBox";
            this.StandardNotesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StandardNotesTextBox.Size = new System.Drawing.Size(720, 369);
            this.StandardNotesTextBox.TabIndex = 0;
            this.StandardNotesTextBox.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // PluginDataTabPage
            // 
            this.PluginDataTabPage.Controls.Add(this.NotesTabControl);
            this.PluginDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.PluginDataTabPage.Name = "PluginDataTabPage";
            this.PluginDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PluginDataTabPage.Size = new System.Drawing.Size(752, 419);
            this.PluginDataTabPage.TabIndex = 1;
            this.PluginDataTabPage.Text = "Plugin Data";
            this.PluginDataTabPage.UseVisualStyleBackColor = true;
            // 
            // NotesTabControl
            // 
            this.NotesTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotesTabControl.Controls.Add(this.Note1TabPage);
            this.NotesTabControl.Controls.Add(this.Note2TabPage);
            this.NotesTabControl.Controls.Add(this.Note3TabPage);
            this.NotesTabControl.Controls.Add(this.Note4TabPage);
            this.NotesTabControl.Controls.Add(this.Note5TabPage);
            this.NotesTabControl.Location = new System.Drawing.Point(6, 6);
            this.NotesTabControl.Name = "NotesTabControl";
            this.NotesTabControl.SelectedIndex = 0;
            this.NotesTabControl.Size = new System.Drawing.Size(740, 407);
            this.NotesTabControl.TabIndex = 0;
            this.NotesTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabPageSelected);
            // 
            // Note1TabPage
            // 
            this.Note1TabPage.Controls.Add(this.Note1CheckBox);
            this.Note1TabPage.Controls.Add(this.Note1TextBox);
            this.Note1TabPage.Location = new System.Drawing.Point(4, 22);
            this.Note1TabPage.Name = "Note1TabPage";
            this.Note1TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Note1TabPage.Size = new System.Drawing.Size(732, 381);
            this.Note1TabPage.TabIndex = 0;
            this.Note1TabPage.Text = "Note 1";
            this.Note1TabPage.UseVisualStyleBackColor = true;
            // 
            // Note1CheckBox
            // 
            this.Note1CheckBox.AutoSize = true;
            this.Note1CheckBox.Location = new System.Drawing.Point(6, 6);
            this.Note1CheckBox.Name = "Note1CheckBox";
            this.Note1CheckBox.Size = new System.Drawing.Size(67, 17);
            this.Note1CheckBox.TabIndex = 2;
            this.Note1CheckBox.Text = "Is HTML";
            this.Note1CheckBox.UseVisualStyleBackColor = true;
            this.Note1CheckBox.CheckedChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note1TextBox
            // 
            this.Note1TextBox.AcceptsReturn = true;
            this.Note1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note1TextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.Note1TextBox.Location = new System.Drawing.Point(6, 29);
            this.Note1TextBox.MaxLength = 10000;
            this.Note1TextBox.Multiline = true;
            this.Note1TextBox.Name = "Note1TextBox";
            this.Note1TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Note1TextBox.Size = new System.Drawing.Size(720, 346);
            this.Note1TextBox.TabIndex = 1;
            this.Note1TextBox.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note2TabPage
            // 
            this.Note2TabPage.Controls.Add(this.Note2CheckBox);
            this.Note2TabPage.Controls.Add(this.Note2TextBox);
            this.Note2TabPage.Location = new System.Drawing.Point(4, 22);
            this.Note2TabPage.Name = "Note2TabPage";
            this.Note2TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Note2TabPage.Size = new System.Drawing.Size(732, 381);
            this.Note2TabPage.TabIndex = 1;
            this.Note2TabPage.Text = "Note 2";
            this.Note2TabPage.UseVisualStyleBackColor = true;
            // 
            // Note2CheckBox
            // 
            this.Note2CheckBox.AutoSize = true;
            this.Note2CheckBox.Location = new System.Drawing.Point(6, 6);
            this.Note2CheckBox.Name = "Note2CheckBox";
            this.Note2CheckBox.Size = new System.Drawing.Size(67, 17);
            this.Note2CheckBox.TabIndex = 4;
            this.Note2CheckBox.Text = "Is HTML";
            this.Note2CheckBox.UseVisualStyleBackColor = true;
            this.Note2CheckBox.CheckedChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note2TextBox
            // 
            this.Note2TextBox.AcceptsReturn = true;
            this.Note2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note2TextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.Note2TextBox.Location = new System.Drawing.Point(6, 29);
            this.Note2TextBox.MaxLength = 10000;
            this.Note2TextBox.Multiline = true;
            this.Note2TextBox.Name = "Note2TextBox";
            this.Note2TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Note2TextBox.Size = new System.Drawing.Size(720, 346);
            this.Note2TextBox.TabIndex = 3;
            this.Note2TextBox.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note3TabPage
            // 
            this.Note3TabPage.Controls.Add(this.Note3CheckBox);
            this.Note3TabPage.Controls.Add(this.Note3TextBox);
            this.Note3TabPage.Location = new System.Drawing.Point(4, 22);
            this.Note3TabPage.Name = "Note3TabPage";
            this.Note3TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Note3TabPage.Size = new System.Drawing.Size(732, 381);
            this.Note3TabPage.TabIndex = 2;
            this.Note3TabPage.Text = "Note 3";
            this.Note3TabPage.UseVisualStyleBackColor = true;
            // 
            // Note3CheckBox
            // 
            this.Note3CheckBox.AutoSize = true;
            this.Note3CheckBox.Location = new System.Drawing.Point(6, 6);
            this.Note3CheckBox.Name = "Note3CheckBox";
            this.Note3CheckBox.Size = new System.Drawing.Size(67, 17);
            this.Note3CheckBox.TabIndex = 4;
            this.Note3CheckBox.Text = "Is HTML";
            this.Note3CheckBox.UseVisualStyleBackColor = true;
            this.Note3CheckBox.CheckedChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note3TextBox
            // 
            this.Note3TextBox.AcceptsReturn = true;
            this.Note3TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note3TextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.Note3TextBox.Location = new System.Drawing.Point(6, 29);
            this.Note3TextBox.MaxLength = 10000;
            this.Note3TextBox.Multiline = true;
            this.Note3TextBox.Name = "Note3TextBox";
            this.Note3TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Note3TextBox.Size = new System.Drawing.Size(720, 346);
            this.Note3TextBox.TabIndex = 3;
            this.Note3TextBox.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note4TabPage
            // 
            this.Note4TabPage.Controls.Add(this.Note4CheckBox);
            this.Note4TabPage.Controls.Add(this.Note4TextBox);
            this.Note4TabPage.Location = new System.Drawing.Point(4, 22);
            this.Note4TabPage.Name = "Note4TabPage";
            this.Note4TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Note4TabPage.Size = new System.Drawing.Size(732, 381);
            this.Note4TabPage.TabIndex = 3;
            this.Note4TabPage.Text = "Note 4";
            this.Note4TabPage.UseVisualStyleBackColor = true;
            // 
            // Note4CheckBox
            // 
            this.Note4CheckBox.AutoSize = true;
            this.Note4CheckBox.Location = new System.Drawing.Point(6, 6);
            this.Note4CheckBox.Name = "Note4CheckBox";
            this.Note4CheckBox.Size = new System.Drawing.Size(67, 17);
            this.Note4CheckBox.TabIndex = 4;
            this.Note4CheckBox.Text = "Is HTML";
            this.Note4CheckBox.UseVisualStyleBackColor = true;
            this.Note4CheckBox.CheckedChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note4TextBox
            // 
            this.Note4TextBox.AcceptsReturn = true;
            this.Note4TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note4TextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.Note4TextBox.Location = new System.Drawing.Point(6, 29);
            this.Note4TextBox.MaxLength = 10000;
            this.Note4TextBox.Multiline = true;
            this.Note4TextBox.Name = "Note4TextBox";
            this.Note4TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Note4TextBox.Size = new System.Drawing.Size(720, 346);
            this.Note4TextBox.TabIndex = 3;
            this.Note4TextBox.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note5TabPage
            // 
            this.Note5TabPage.Controls.Add(this.Note5CheckBox);
            this.Note5TabPage.Controls.Add(this.Note5TextBox);
            this.Note5TabPage.Location = new System.Drawing.Point(4, 22);
            this.Note5TabPage.Name = "Note5TabPage";
            this.Note5TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Note5TabPage.Size = new System.Drawing.Size(732, 381);
            this.Note5TabPage.TabIndex = 4;
            this.Note5TabPage.Text = "Note 5";
            this.Note5TabPage.UseVisualStyleBackColor = true;
            // 
            // Note5CheckBox
            // 
            this.Note5CheckBox.AutoSize = true;
            this.Note5CheckBox.Location = new System.Drawing.Point(6, 6);
            this.Note5CheckBox.Name = "Note5CheckBox";
            this.Note5CheckBox.Size = new System.Drawing.Size(67, 17);
            this.Note5CheckBox.TabIndex = 4;
            this.Note5CheckBox.Text = "Is HTML";
            this.Note5CheckBox.UseVisualStyleBackColor = true;
            this.Note5CheckBox.CheckedChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // Note5TextBox
            // 
            this.Note5TextBox.AcceptsReturn = true;
            this.Note5TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note5TextBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.Note5TextBox.Location = new System.Drawing.Point(6, 29);
            this.Note5TextBox.MaxLength = 10000;
            this.Note5TextBox.Multiline = true;
            this.Note5TextBox.Name = "Note5TextBox";
            this.Note5TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Note5TextBox.Size = new System.Drawing.Size(720, 346);
            this.Note5TextBox.TabIndex = 3;
            this.Note5TextBox.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.DiscardButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Enhanced Notes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.InvelosDataTabPage.ResumeLayout(false);
            this.InvelosDataTabControl.ResumeLayout(false);
            this.StandardNotesTabPage.ResumeLayout(false);
            this.StandardNotesTabPage.PerformLayout();
            this.PluginDataTabPage.ResumeLayout(false);
            this.NotesTabControl.ResumeLayout(false);
            this.Note1TabPage.ResumeLayout(false);
            this.Note1TabPage.PerformLayout();
            this.Note2TabPage.ResumeLayout(false);
            this.Note2TabPage.PerformLayout();
            this.Note3TabPage.ResumeLayout(false);
            this.Note3TabPage.PerformLayout();
            this.Note4TabPage.ResumeLayout(false);
            this.Note4TabPage.PerformLayout();
            this.Note5TabPage.ResumeLayout(false);
            this.Note5TabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox Note1CheckBox;
        private System.Windows.Forms.CheckBox Note2CheckBox;
        private System.Windows.Forms.CheckBox Note3CheckBox;
        private System.Windows.Forms.CheckBox Note4CheckBox;
        private System.Windows.Forms.CheckBox Note5CheckBox;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.TabControl InvelosDataTabControl;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabControl NotesTabControl;
        private System.Windows.Forms.TabPage InvelosDataTabPage;
        private System.Windows.Forms.TabPage Note1TabPage;
        private System.Windows.Forms.TabPage Note2TabPage;
        private System.Windows.Forms.TabPage Note3TabPage;
        private System.Windows.Forms.TabPage Note4TabPage;
        private System.Windows.Forms.TabPage Note5TabPage;
        private System.Windows.Forms.TabPage PluginDataTabPage;
        private System.Windows.Forms.TabPage StandardNotesTabPage;
        private System.Windows.Forms.TextBox Note1TextBox;
        private System.Windows.Forms.TextBox Note2TextBox;
        private System.Windows.Forms.TextBox Note3TextBox;
        private System.Windows.Forms.TextBox Note4TextBox;
        private System.Windows.Forms.TextBox Note5TextBox;
        private System.Windows.Forms.TextBox StandardNotesTextBox;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyCurrentTextBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFromXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteCurrentTextBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;

    }
}