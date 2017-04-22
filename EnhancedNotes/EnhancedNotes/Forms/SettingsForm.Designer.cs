namespace DoenaSoft.DVDProfiler.EnhancedNotes
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.DiscardButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.LabelTabPage = new System.Windows.Forms.TabPage();
            this.ResetNote1Button = new System.Windows.Forms.Button();
            this.Note1Label = new System.Windows.Forms.Label();
            this.Note1TextBox = new System.Windows.Forms.TextBox();
            this.ResetNote3Button = new System.Windows.Forms.Button();
            this.ResetNote2Button = new System.Windows.Forms.Button();
            this.Note3label = new System.Windows.Forms.Label();
            this.Note2Label = new System.Windows.Forms.Label();
            this.Note3TextBox = new System.Windows.Forms.TextBox();
            this.Note2TextBox = new System.Windows.Forms.TextBox();
            this.ResetNote5Button = new System.Windows.Forms.Button();
            this.ResetNote4Button = new System.Windows.Forms.Button();
            this.Note5Label = new System.Windows.Forms.Label();
            this.Note4Label = new System.Windows.Forms.Label();
            this.Note5TextBox = new System.Windows.Forms.TextBox();
            this.Note4TextBox = new System.Windows.Forms.TextBox();
            this.MiscTabPage = new System.Windows.Forms.TabPage();
            this.ExportToCollectionXmlCheckBox = new System.Windows.Forms.CheckBox();
            this.UiLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.UiLanguageLabel = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.LabelTabPage.SuspendLayout();
            this.MiscTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiscardButton
            // 
            this.DiscardButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardButton.Location = new System.Drawing.Point(367, 426);
            this.DiscardButton.Name = "DiscardButton";
            this.DiscardButton.Size = new System.Drawing.Size(75, 23);
            this.DiscardButton.TabIndex = 2;
            this.DiscardButton.Text = "Cancel";
            this.DiscardButton.UseVisualStyleBackColor = true;
            this.DiscardButton.Click += new System.EventHandler(this.OnDiscardButtonClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(286, 426);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.LabelTabPage);
            this.MainTabControl.Controls.Add(this.MiscTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(434, 408);
            this.MainTabControl.TabIndex = 0;
            // 
            // LabelTabPage
            // 
            this.LabelTabPage.Controls.Add(this.ResetNote1Button);
            this.LabelTabPage.Controls.Add(this.Note1Label);
            this.LabelTabPage.Controls.Add(this.Note1TextBox);
            this.LabelTabPage.Controls.Add(this.ResetNote3Button);
            this.LabelTabPage.Controls.Add(this.ResetNote2Button);
            this.LabelTabPage.Controls.Add(this.Note3label);
            this.LabelTabPage.Controls.Add(this.Note2Label);
            this.LabelTabPage.Controls.Add(this.Note3TextBox);
            this.LabelTabPage.Controls.Add(this.Note2TextBox);
            this.LabelTabPage.Controls.Add(this.ResetNote5Button);
            this.LabelTabPage.Controls.Add(this.ResetNote4Button);
            this.LabelTabPage.Controls.Add(this.Note5Label);
            this.LabelTabPage.Controls.Add(this.Note4Label);
            this.LabelTabPage.Controls.Add(this.Note5TextBox);
            this.LabelTabPage.Controls.Add(this.Note4TextBox);
            this.LabelTabPage.Location = new System.Drawing.Point(4, 22);
            this.LabelTabPage.Name = "LabelTabPage";
            this.LabelTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LabelTabPage.Size = new System.Drawing.Size(426, 382);
            this.LabelTabPage.TabIndex = 0;
            this.LabelTabPage.Text = "Labels";
            this.LabelTabPage.UseVisualStyleBackColor = true;
            // 
            // ResetNote1Button
            // 
            this.ResetNote1Button.Location = new System.Drawing.Point(393, 6);
            this.ResetNote1Button.Name = "ResetNote1Button";
            this.ResetNote1Button.Size = new System.Drawing.Size(27, 23);
            this.ResetNote1Button.TabIndex = 2;
            this.ResetNote1Button.Text = "R";
            this.ResetNote1Button.UseVisualStyleBackColor = true;
            this.ResetNote1Button.Click += new System.EventHandler(this.OnResetNote1ButtonClick);
            // 
            // Note1Label
            // 
            this.Note1Label.AutoSize = true;
            this.Note1Label.Location = new System.Drawing.Point(6, 11);
            this.Note1Label.Name = "Note1Label";
            this.Note1Label.Size = new System.Drawing.Size(128, 13);
            this.Note1Label.TabIndex = 0;
            this.Note1Label.Text = "Note 1:";
            // 
            // Note1TextBox
            // 
            this.Note1TextBox.Location = new System.Drawing.Point(220, 8);
            this.Note1TextBox.MaxLength = 25;
            this.Note1TextBox.Name = "Note1TextBox";
            this.Note1TextBox.Size = new System.Drawing.Size(168, 20);
            this.Note1TextBox.TabIndex = 1;
            // 
            // ResetNote3Button
            // 
            this.ResetNote3Button.Location = new System.Drawing.Point(393, 64);
            this.ResetNote3Button.Name = "ResetNote3Button";
            this.ResetNote3Button.Size = new System.Drawing.Size(27, 23);
            this.ResetNote3Button.TabIndex = 8;
            this.ResetNote3Button.Text = "R";
            this.ResetNote3Button.UseVisualStyleBackColor = true;
            this.ResetNote3Button.Click += new System.EventHandler(this.OnResetNote3ButtonClick);
            // 
            // ResetNote2Button
            // 
            this.ResetNote2Button.Location = new System.Drawing.Point(393, 35);
            this.ResetNote2Button.Name = "ResetNote2Button";
            this.ResetNote2Button.Size = new System.Drawing.Size(27, 23);
            this.ResetNote2Button.TabIndex = 5;
            this.ResetNote2Button.Text = "R";
            this.ResetNote2Button.UseVisualStyleBackColor = true;
            this.ResetNote2Button.Click += new System.EventHandler(this.OnResetNote2ButtonClick);
            // 
            // Note3label
            // 
            this.Note3label.AutoSize = true;
            this.Note3label.Location = new System.Drawing.Point(6, 69);
            this.Note3label.Name = "Note3label";
            this.Note3label.Size = new System.Drawing.Size(114, 13);
            this.Note3label.TabIndex = 6;
            this.Note3label.Text = "Note 3:";
            // 
            // Note2Label
            // 
            this.Note2Label.AutoSize = true;
            this.Note2Label.Location = new System.Drawing.Point(6, 40);
            this.Note2Label.Name = "Note2Label";
            this.Note2Label.Size = new System.Drawing.Size(113, 13);
            this.Note2Label.TabIndex = 3;
            this.Note2Label.Text = "Note 2:";
            // 
            // Note3TextBox
            // 
            this.Note3TextBox.Location = new System.Drawing.Point(220, 66);
            this.Note3TextBox.MaxLength = 25;
            this.Note3TextBox.Name = "Note3TextBox";
            this.Note3TextBox.Size = new System.Drawing.Size(167, 20);
            this.Note3TextBox.TabIndex = 7;
            // 
            // Note2TextBox
            // 
            this.Note2TextBox.Location = new System.Drawing.Point(220, 37);
            this.Note2TextBox.MaxLength = 25;
            this.Note2TextBox.Name = "Note2TextBox";
            this.Note2TextBox.Size = new System.Drawing.Size(167, 20);
            this.Note2TextBox.TabIndex = 4;
            // 
            // ResetNote5Button
            // 
            this.ResetNote5Button.Location = new System.Drawing.Point(393, 122);
            this.ResetNote5Button.Name = "ResetNote5Button";
            this.ResetNote5Button.Size = new System.Drawing.Size(27, 23);
            this.ResetNote5Button.TabIndex = 14;
            this.ResetNote5Button.Text = "R";
            this.ResetNote5Button.UseVisualStyleBackColor = true;
            this.ResetNote5Button.Click += new System.EventHandler(this.OnResetAdditionalPrice2ButtonClick);
            // 
            // ResetNote4Button
            // 
            this.ResetNote4Button.Location = new System.Drawing.Point(393, 93);
            this.ResetNote4Button.Name = "ResetNote4Button";
            this.ResetNote4Button.Size = new System.Drawing.Size(27, 23);
            this.ResetNote4Button.TabIndex = 11;
            this.ResetNote4Button.Text = "R";
            this.ResetNote4Button.UseVisualStyleBackColor = true;
            this.ResetNote4Button.Click += new System.EventHandler(this.OnResetAdditionalPrice1ButtonClick);
            // 
            // Note5Label
            // 
            this.Note5Label.AutoSize = true;
            this.Note5Label.Location = new System.Drawing.Point(6, 127);
            this.Note5Label.Name = "Note5Label";
            this.Note5Label.Size = new System.Drawing.Size(95, 13);
            this.Note5Label.TabIndex = 12;
            this.Note5Label.Text = "Note 5:";
            // 
            // Note4Label
            // 
            this.Note4Label.AutoSize = true;
            this.Note4Label.Location = new System.Drawing.Point(6, 98);
            this.Note4Label.Name = "Note4Label";
            this.Note4Label.Size = new System.Drawing.Size(95, 13);
            this.Note4Label.TabIndex = 9;
            this.Note4Label.Text = "Note 4:";
            // 
            // Note5TextBox
            // 
            this.Note5TextBox.Location = new System.Drawing.Point(220, 124);
            this.Note5TextBox.MaxLength = 25;
            this.Note5TextBox.Name = "Note5TextBox";
            this.Note5TextBox.Size = new System.Drawing.Size(167, 20);
            this.Note5TextBox.TabIndex = 13;
            // 
            // Note4TextBox
            // 
            this.Note4TextBox.Location = new System.Drawing.Point(220, 95);
            this.Note4TextBox.MaxLength = 25;
            this.Note4TextBox.Name = "Note4TextBox";
            this.Note4TextBox.Size = new System.Drawing.Size(167, 20);
            this.Note4TextBox.TabIndex = 10;
            // 
            // MiscTabPage
            // 
            this.MiscTabPage.Controls.Add(this.ExportToCollectionXmlCheckBox);
            this.MiscTabPage.Controls.Add(this.UiLanguageComboBox);
            this.MiscTabPage.Controls.Add(this.UiLanguageLabel);
            this.MiscTabPage.Location = new System.Drawing.Point(4, 22);
            this.MiscTabPage.Name = "MiscTabPage";
            this.MiscTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MiscTabPage.Size = new System.Drawing.Size(426, 382);
            this.MiscTabPage.TabIndex = 1;
            this.MiscTabPage.Text = "Misc.";
            this.MiscTabPage.UseVisualStyleBackColor = true;
            // 
            // ExportToCollectionXmlCheckBox
            // 
            this.ExportToCollectionXmlCheckBox.AutoSize = true;
            this.ExportToCollectionXmlCheckBox.Location = new System.Drawing.Point(9, 33);
            this.ExportToCollectionXmlCheckBox.Name = "ExportToCollectionXmlCheckBox";
            this.ExportToCollectionXmlCheckBox.Size = new System.Drawing.Size(135, 17);
            this.ExportToCollectionXmlCheckBox.TabIndex = 9;
            this.ExportToCollectionXmlCheckBox.Text = "Export to Collection.xml";
            this.ExportToCollectionXmlCheckBox.UseVisualStyleBackColor = true;
            // 
            // UiLanguageComboBox
            // 
            this.UiLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UiLanguageComboBox.FormattingEnabled = true;
            this.UiLanguageComboBox.Location = new System.Drawing.Point(270, 6);
            this.UiLanguageComboBox.Name = "UiLanguageComboBox";
            this.UiLanguageComboBox.Size = new System.Drawing.Size(150, 21);
            this.UiLanguageComboBox.TabIndex = 8;
            // 
            // UiLanguageLabel
            // 
            this.UiLanguageLabel.AutoSize = true;
            this.UiLanguageLabel.Location = new System.Drawing.Point(6, 9);
            this.UiLanguageLabel.Name = "UiLanguageLabel";
            this.UiLanguageLabel.Size = new System.Drawing.Size(69, 13);
            this.UiLanguageLabel.TabIndex = 7;
            this.UiLanguageLabel.Text = "UI Language";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DiscardButton;
            this.ClientSize = new System.Drawing.Size(459, 466);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.DiscardButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(475, 505);
            this.MinimumSize = new System.Drawing.Size(475, 505);
            this.Name = "SettingsForm";
            this.Text = "Options";
            this.MainTabControl.ResumeLayout(false);
            this.LabelTabPage.ResumeLayout(false);
            this.LabelTabPage.PerformLayout();
            this.MiscTabPage.ResumeLayout(false);
            this.MiscTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DiscardButton;
        private System.Windows.Forms.Button ResetNote4Button;
        private System.Windows.Forms.Button ResetNote5Button;
        private System.Windows.Forms.Button ResetNote2Button;
        private System.Windows.Forms.Button ResetNote1Button;
        private System.Windows.Forms.Button ResetNote3Button;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox UiLanguageComboBox;
        private System.Windows.Forms.Label Note4Label;
        private System.Windows.Forms.Label Note5Label;
        private System.Windows.Forms.Label Note2Label;
        private System.Windows.Forms.Label Note1Label;
        private System.Windows.Forms.Label Note3label;
        private System.Windows.Forms.Label UiLanguageLabel;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage LabelTabPage;
        private System.Windows.Forms.TabPage MiscTabPage;
        private System.Windows.Forms.TextBox Note4TextBox;
        private System.Windows.Forms.TextBox Note5TextBox;
        private System.Windows.Forms.TextBox Note2TextBox;
        private System.Windows.Forms.TextBox Note1TextBox;
        private System.Windows.Forms.TextBox Note3TextBox;
        private System.Windows.Forms.CheckBox ExportToCollectionXmlCheckBox;
    }
}