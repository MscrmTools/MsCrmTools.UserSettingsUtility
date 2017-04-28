namespace MsCrmTools.UserSettingsUtility
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadCrmItems = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditInFXB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdateUserSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userSelector1 = new MsCrmTools.UserSettingsUtility.UserControls.UserSelector();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbOutlookForms = new System.Windows.Forms.GroupBox();
            this.cbbUseCrmFormTask = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbbUseCrmFormAppt = new System.Windows.Forms.ComboBox();
            this.cbbUseCrmFormContact = new System.Windows.Forms.ComboBox();
            this.cbbUseCrmFormEmail = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.gbLanguages = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbbUiLanguage = new System.Windows.Forms.ComboBox();
            this.cbbHelpLanguage = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gbPrivacy = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbbReportScriptErrors = new System.Windows.Forms.ComboBox();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.cbbSendAsAllowed = new System.Windows.Forms.ComboBox();
            this.cbbTrackMessages = new System.Windows.Forms.ComboBox();
            this.cbbCreateRecords = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbActivities = new System.Windows.Forms.GroupBox();
            this.cbbCalendar = new System.Windows.Forms.ComboBox();
            this.cbbWorkStartTime = new System.Windows.Forms.ComboBox();
            this.cbbWorkStopTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbbCurrencies = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbbAdvancedFindMode = new System.Windows.Forms.ComboBox();
            this.cbbStartupPane = new System.Windows.Forms.ComboBox();
            this.cbbSiteMapSubArea = new System.Windows.Forms.ComboBox();
            this.cbbSiteMapArea = new System.Windows.Forms.ComboBox();
            this.cbbPagingLimit = new System.Windows.Forms.ComboBox();
            this.cbbTimeZones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbOutlookForms.SuspendLayout();
            this.gbLanguages.SuspendLayout();
            this.gbPrivacy.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.gbActivities.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tsbLoadCrmItems,
            this.toolStripSeparator2,
            this.tsbEditInFXB,
            this.toolStripSeparator3,
            this.tsbUpdateUserSettings,
            this.toolStripSeparator4,
            this.tsbReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(2190, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(44, 45);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.TsbCloseClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbLoadCrmItems
            // 
            this.tsbLoadCrmItems.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadCrmItems.Image")));
            this.tsbLoadCrmItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadCrmItems.Name = "tsbLoadCrmItems";
            this.tsbLoadCrmItems.Size = new System.Drawing.Size(378, 45);
            this.tsbLoadCrmItems.Text = "Load Users and settings";
            this.tsbLoadCrmItems.Click += new System.EventHandler(this.tsbLoadCrmItems_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbEditInFXB
            // 
            this.tsbEditInFXB.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditInFXB.Image")));
            this.tsbEditInFXB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditInFXB.Name = "tsbEditInFXB";
            this.tsbEditInFXB.Size = new System.Drawing.Size(369, 45);
            this.tsbEditInFXB.Text = "Choose users from FXB";
            this.tsbEditInFXB.Click += new System.EventHandler(this.tsbEditInFXB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbUpdateUserSettings
            // 
            this.tsbUpdateUserSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateUserSettings.Image")));
            this.tsbUpdateUserSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateUserSettings.Name = "tsbUpdateUserSettings";
            this.tsbUpdateUserSettings.Size = new System.Drawing.Size(374, 45);
            this.tsbUpdateUserSettings.Text = "Update User(s) Settings";
            this.tsbUpdateUserSettings.Click += new System.EventHandler(this.tsbUpdateUserSettings_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // tsbReset
            // 
            this.tsbReset.Image = ((System.Drawing.Image)(resources.GetObject("tsbReset.Image")));
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(134, 45);
            this.tsbReset.Text = "Reset";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userSelector1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(2190, 1132);
            this.splitContainer1.SplitterDistance = 930;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // userSelector1
            // 
            this.userSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userSelector1.Location = new System.Drawing.Point(0, 0);
            this.userSelector1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.userSelector1.Name = "userSelector1";
            this.userSelector1.Size = new System.Drawing.Size(930, 1132);
            this.userSelector1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gbOutlookForms);
            this.panel1.Controls.Add(this.gbLanguages);
            this.panel1.Controls.Add(this.gbPrivacy);
            this.panel1.Controls.Add(this.gbEmail);
            this.panel1.Controls.Add(this.gbActivities);
            this.panel1.Controls.Add(this.gbGeneral);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 1132);
            this.panel1.TabIndex = 0;
            // 
            // gbOutlookForms
            // 
            this.gbOutlookForms.Controls.Add(this.cbbUseCrmFormTask);
            this.gbOutlookForms.Controls.Add(this.label20);
            this.gbOutlookForms.Controls.Add(this.cbbUseCrmFormAppt);
            this.gbOutlookForms.Controls.Add(this.cbbUseCrmFormContact);
            this.gbOutlookForms.Controls.Add(this.cbbUseCrmFormEmail);
            this.gbOutlookForms.Controls.Add(this.label17);
            this.gbOutlookForms.Controls.Add(this.label18);
            this.gbOutlookForms.Controls.Add(this.label19);
            this.gbOutlookForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOutlookForms.Location = new System.Drawing.Point(0, 1185);
            this.gbOutlookForms.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbOutlookForms.Name = "gbOutlookForms";
            this.gbOutlookForms.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbOutlookForms.Size = new System.Drawing.Size(1209, 303);
            this.gbOutlookForms.TabIndex = 59;
            this.gbOutlookForms.TabStop = false;
            this.gbOutlookForms.Text = "Outlook Forms";
            // 
            // cbbUseCrmFormTask
            // 
            this.cbbUseCrmFormTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbUseCrmFormTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUseCrmFormTask.FormattingEnabled = true;
            this.cbbUseCrmFormTask.Items.AddRange(new object[] {
            "No change",
            "No",
            "Yes"});
            this.cbbUseCrmFormTask.Location = new System.Drawing.Point(414, 213);
            this.cbbUseCrmFormTask.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbUseCrmFormTask.Name = "cbbUseCrmFormTask";
            this.cbbUseCrmFormTask.Size = new System.Drawing.Size(767, 39);
            this.cbbUseCrmFormTask.TabIndex = 57;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 217);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(297, 32);
            this.label20.TabIndex = 58;
            this.label20.Text = "Use CRM form for task";
            // 
            // cbbUseCrmFormAppt
            // 
            this.cbbUseCrmFormAppt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbUseCrmFormAppt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUseCrmFormAppt.FormattingEnabled = true;
            this.cbbUseCrmFormAppt.Items.AddRange(new object[] {
            "No change",
            "No",
            "Yes"});
            this.cbbUseCrmFormAppt.Location = new System.Drawing.Point(414, 41);
            this.cbbUseCrmFormAppt.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbUseCrmFormAppt.Name = "cbbUseCrmFormAppt";
            this.cbbUseCrmFormAppt.Size = new System.Drawing.Size(767, 39);
            this.cbbUseCrmFormAppt.TabIndex = 51;
            // 
            // cbbUseCrmFormContact
            // 
            this.cbbUseCrmFormContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbUseCrmFormContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUseCrmFormContact.FormattingEnabled = true;
            this.cbbUseCrmFormContact.Items.AddRange(new object[] {
            "No change",
            "No",
            "Yes"});
            this.cbbUseCrmFormContact.Location = new System.Drawing.Point(414, 97);
            this.cbbUseCrmFormContact.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbUseCrmFormContact.Name = "cbbUseCrmFormContact";
            this.cbbUseCrmFormContact.Size = new System.Drawing.Size(767, 39);
            this.cbbUseCrmFormContact.TabIndex = 52;
            // 
            // cbbUseCrmFormEmail
            // 
            this.cbbUseCrmFormEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbUseCrmFormEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUseCrmFormEmail.FormattingEnabled = true;
            this.cbbUseCrmFormEmail.Items.AddRange(new object[] {
            "No change",
            "No",
            "Yes"});
            this.cbbUseCrmFormEmail.Location = new System.Drawing.Point(414, 157);
            this.cbbUseCrmFormEmail.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbUseCrmFormEmail.Name = "cbbUseCrmFormEmail";
            this.cbbUseCrmFormEmail.Size = new System.Drawing.Size(767, 39);
            this.cbbUseCrmFormEmail.TabIndex = 53;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 45);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(309, 32);
            this.label17.TabIndex = 54;
            this.label17.Text = "Use CRM form for appt.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 103);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(337, 32);
            this.label18.TabIndex = 55;
            this.label18.Text = "Use CRM form for contact";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 162);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(314, 32);
            this.label19.TabIndex = 56;
            this.label19.Text = "Use CRM form for email";
            // 
            // gbLanguages
            // 
            this.gbLanguages.Controls.Add(this.label15);
            this.gbLanguages.Controls.Add(this.cbbUiLanguage);
            this.gbLanguages.Controls.Add(this.cbbHelpLanguage);
            this.gbLanguages.Controls.Add(this.label14);
            this.gbLanguages.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLanguages.Location = new System.Drawing.Point(0, 1030);
            this.gbLanguages.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbLanguages.Name = "gbLanguages";
            this.gbLanguages.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbLanguages.Size = new System.Drawing.Size(1209, 155);
            this.gbLanguages.TabIndex = 58;
            this.gbLanguages.TabStop = false;
            this.gbLanguages.Text = "Languages";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 100);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(200, 32);
            this.label15.TabIndex = 64;
            this.label15.Text = "Help language";
            // 
            // cbbUiLanguage
            // 
            this.cbbUiLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbUiLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUiLanguage.FormattingEnabled = true;
            this.cbbUiLanguage.Location = new System.Drawing.Point(416, 41);
            this.cbbUiLanguage.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbUiLanguage.Name = "cbbUiLanguage";
            this.cbbUiLanguage.Size = new System.Drawing.Size(778, 39);
            this.cbbUiLanguage.TabIndex = 61;
            // 
            // cbbHelpLanguage
            // 
            this.cbbHelpLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbHelpLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHelpLanguage.FormattingEnabled = true;
            this.cbbHelpLanguage.Location = new System.Drawing.Point(414, 95);
            this.cbbHelpLanguage.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbHelpLanguage.Name = "cbbHelpLanguage";
            this.cbbHelpLanguage.Size = new System.Drawing.Size(778, 39);
            this.cbbHelpLanguage.TabIndex = 63;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 45);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 32);
            this.label14.TabIndex = 62;
            this.label14.Text = "UI language";
            // 
            // gbPrivacy
            // 
            this.gbPrivacy.Controls.Add(this.label13);
            this.gbPrivacy.Controls.Add(this.cbbReportScriptErrors);
            this.gbPrivacy.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPrivacy.Location = new System.Drawing.Point(0, 913);
            this.gbPrivacy.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbPrivacy.Name = "gbPrivacy";
            this.gbPrivacy.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbPrivacy.Size = new System.Drawing.Size(1209, 117);
            this.gbPrivacy.TabIndex = 57;
            this.gbPrivacy.TabStop = false;
            this.gbPrivacy.Text = "Privacy";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 45);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(237, 32);
            this.label13.TabIndex = 55;
            this.label13.Text = "Error notifications";
            // 
            // cbbReportScriptErrors
            // 
            this.cbbReportScriptErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbReportScriptErrors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbReportScriptErrors.FormattingEnabled = true;
            this.cbbReportScriptErrors.Items.AddRange(new object[] {
            "No change",
            "Ask me for permission to send an error report to Microsoft",
            "Automatically send an error report to Microsoft without asking me for permission",
            "Never send an error report to Microsoft about Microsoft Dynamics CRM"});
            this.cbbReportScriptErrors.Location = new System.Drawing.Point(414, 41);
            this.cbbReportScriptErrors.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbReportScriptErrors.Name = "cbbReportScriptErrors";
            this.cbbReportScriptErrors.Size = new System.Drawing.Size(767, 39);
            this.cbbReportScriptErrors.TabIndex = 54;
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.cbbSendAsAllowed);
            this.gbEmail.Controls.Add(this.cbbTrackMessages);
            this.gbEmail.Controls.Add(this.cbbCreateRecords);
            this.gbEmail.Controls.Add(this.label8);
            this.gbEmail.Controls.Add(this.label9);
            this.gbEmail.Controls.Add(this.label10);
            this.gbEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEmail.Location = new System.Drawing.Point(0, 682);
            this.gbEmail.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbEmail.Size = new System.Drawing.Size(1209, 231);
            this.gbEmail.TabIndex = 56;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = "Email Settings";
            // 
            // cbbSendAsAllowed
            // 
            this.cbbSendAsAllowed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSendAsAllowed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSendAsAllowed.FormattingEnabled = true;
            this.cbbSendAsAllowed.Items.AddRange(new object[] {
            "No change",
            "No",
            "Yes"});
            this.cbbSendAsAllowed.Location = new System.Drawing.Point(414, 41);
            this.cbbSendAsAllowed.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbSendAsAllowed.Name = "cbbSendAsAllowed";
            this.cbbSendAsAllowed.Size = new System.Drawing.Size(767, 39);
            this.cbbSendAsAllowed.TabIndex = 35;
            // 
            // cbbTrackMessages
            // 
            this.cbbTrackMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTrackMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrackMessages.FormattingEnabled = true;
            this.cbbTrackMessages.Items.AddRange(new object[] {
            "No change",
            "All email messages",
            "Email messages in response to CRM email",
            "Email messages from CRM Leads, Contacts and Accounts",
            "Email messages from CRM records that are email enabled"});
            this.cbbTrackMessages.Location = new System.Drawing.Point(414, 97);
            this.cbbTrackMessages.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbTrackMessages.Name = "cbbTrackMessages";
            this.cbbTrackMessages.Size = new System.Drawing.Size(767, 39);
            this.cbbTrackMessages.TabIndex = 36;
            // 
            // cbbCreateRecords
            // 
            this.cbbCreateRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbCreateRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCreateRecords.FormattingEnabled = true;
            this.cbbCreateRecords.Items.AddRange(new object[] {
            "No change",
            "No",
            "Contacts",
            "Leads"});
            this.cbbCreateRecords.Location = new System.Drawing.Point(414, 157);
            this.cbbCreateRecords.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbCreateRecords.Name = "cbbCreateRecords";
            this.cbbCreateRecords.Size = new System.Drawing.Size(767, 39);
            this.cbbCreateRecords.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(343, 32);
            this.label8.TabIndex = 48;
            this.label8.Text = "Allow emails on my behalf";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 103);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 32);
            this.label9.TabIndex = 49;
            this.label9.Text = "Track email messages";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 162);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 32);
            this.label10.TabIndex = 50;
            this.label10.Text = "Create records";
            // 
            // gbActivities
            // 
            this.gbActivities.Controls.Add(this.cbbCalendar);
            this.gbActivities.Controls.Add(this.cbbWorkStartTime);
            this.gbActivities.Controls.Add(this.cbbWorkStopTime);
            this.gbActivities.Controls.Add(this.label5);
            this.gbActivities.Controls.Add(this.label6);
            this.gbActivities.Controls.Add(this.label7);
            this.gbActivities.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbActivities.Location = new System.Drawing.Point(0, 458);
            this.gbActivities.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbActivities.Name = "gbActivities";
            this.gbActivities.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbActivities.Size = new System.Drawing.Size(1209, 224);
            this.gbActivities.TabIndex = 55;
            this.gbActivities.TabStop = false;
            this.gbActivities.Text = "Activities";
            // 
            // cbbCalendar
            // 
            this.cbbCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCalendar.FormattingEnabled = true;
            this.cbbCalendar.Items.AddRange(new object[] {
            "No change",
            "Day",
            "Week",
            "Month"});
            this.cbbCalendar.Location = new System.Drawing.Point(414, 41);
            this.cbbCalendar.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbCalendar.Name = "cbbCalendar";
            this.cbbCalendar.Size = new System.Drawing.Size(778, 39);
            this.cbbCalendar.TabIndex = 32;
            // 
            // cbbWorkStartTime
            // 
            this.cbbWorkStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbWorkStartTime.FormattingEnabled = true;
            this.cbbWorkStartTime.Items.AddRange(new object[] {
            "No change",
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cbbWorkStartTime.Location = new System.Drawing.Point(414, 100);
            this.cbbWorkStartTime.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbWorkStartTime.Name = "cbbWorkStartTime";
            this.cbbWorkStartTime.Size = new System.Drawing.Size(778, 39);
            this.cbbWorkStartTime.TabIndex = 33;
            // 
            // cbbWorkStopTime
            // 
            this.cbbWorkStopTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbWorkStopTime.FormattingEnabled = true;
            this.cbbWorkStopTime.Items.AddRange(new object[] {
            "No change",
            "00:00",
            "00:30",
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cbbWorkStopTime.Location = new System.Drawing.Point(414, 157);
            this.cbbWorkStopTime.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbWorkStopTime.Name = "cbbWorkStopTime";
            this.cbbWorkStopTime.Size = new System.Drawing.Size(778, 39);
            this.cbbWorkStopTime.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 32);
            this.label5.TabIndex = 45;
            this.label5.Text = "Calendar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 32);
            this.label6.TabIndex = 46;
            this.label6.Text = "Start time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 32);
            this.label7.TabIndex = 47;
            this.label7.Text = "End time";
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.label16);
            this.gbGeneral.Controls.Add(this.cbbCurrencies);
            this.gbGeneral.Controls.Add(this.label12);
            this.gbGeneral.Controls.Add(this.label11);
            this.gbGeneral.Controls.Add(this.cbbAdvancedFindMode);
            this.gbGeneral.Controls.Add(this.cbbStartupPane);
            this.gbGeneral.Controls.Add(this.cbbSiteMapSubArea);
            this.gbGeneral.Controls.Add(this.cbbSiteMapArea);
            this.gbGeneral.Controls.Add(this.cbbPagingLimit);
            this.gbGeneral.Controls.Add(this.cbbTimeZones);
            this.gbGeneral.Controls.Add(this.label1);
            this.gbGeneral.Controls.Add(this.label2);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGeneral.Location = new System.Drawing.Point(0, 0);
            this.gbGeneral.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbGeneral.Size = new System.Drawing.Size(1209, 458);
            this.gbGeneral.TabIndex = 54;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 379);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(221, 32);
            this.label16.TabIndex = 62;
            this.label16.Text = "Default currency";
            // 
            // cbbCurrencies
            // 
            this.cbbCurrencies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbCurrencies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCurrencies.FormattingEnabled = true;
            this.cbbCurrencies.Location = new System.Drawing.Point(416, 374);
            this.cbbCurrencies.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbCurrencies.Name = "cbbCurrencies";
            this.cbbCurrencies.Size = new System.Drawing.Size(778, 39);
            this.cbbCurrencies.TabIndex = 61;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 322);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(283, 32);
            this.label12.TabIndex = 60;
            this.label12.Text = "Advanced Find mode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 265);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(251, 32);
            this.label11.TabIndex = 59;
            this.label11.Text = "Show startup pane";
            // 
            // cbbAdvancedFindMode
            // 
            this.cbbAdvancedFindMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbAdvancedFindMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAdvancedFindMode.FormattingEnabled = true;
            this.cbbAdvancedFindMode.Items.AddRange(new object[] {
            "No change",
            "Simple",
            "Detailed"});
            this.cbbAdvancedFindMode.Location = new System.Drawing.Point(416, 317);
            this.cbbAdvancedFindMode.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbAdvancedFindMode.Name = "cbbAdvancedFindMode";
            this.cbbAdvancedFindMode.Size = new System.Drawing.Size(778, 39);
            this.cbbAdvancedFindMode.TabIndex = 58;
            // 
            // cbbStartupPane
            // 
            this.cbbStartupPane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbStartupPane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStartupPane.FormattingEnabled = true;
            this.cbbStartupPane.Items.AddRange(new object[] {
            "No change",
            "False",
            "True"});
            this.cbbStartupPane.Location = new System.Drawing.Point(416, 260);
            this.cbbStartupPane.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbStartupPane.Name = "cbbStartupPane";
            this.cbbStartupPane.Size = new System.Drawing.Size(778, 39);
            this.cbbStartupPane.TabIndex = 57;
            // 
            // cbbSiteMapSubArea
            // 
            this.cbbSiteMapSubArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSiteMapSubArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSiteMapSubArea.FormattingEnabled = true;
            this.cbbSiteMapSubArea.Location = new System.Drawing.Point(416, 89);
            this.cbbSiteMapSubArea.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbSiteMapSubArea.Name = "cbbSiteMapSubArea";
            this.cbbSiteMapSubArea.Size = new System.Drawing.Size(778, 39);
            this.cbbSiteMapSubArea.TabIndex = 29;
            // 
            // cbbSiteMapArea
            // 
            this.cbbSiteMapArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSiteMapArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSiteMapArea.FormattingEnabled = true;
            this.cbbSiteMapArea.Location = new System.Drawing.Point(416, 29);
            this.cbbSiteMapArea.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbSiteMapArea.Name = "cbbSiteMapArea";
            this.cbbSiteMapArea.Size = new System.Drawing.Size(778, 39);
            this.cbbSiteMapArea.TabIndex = 28;
            this.cbbSiteMapArea.SelectedIndexChanged += new System.EventHandler(this.cbbSiteMapArea_SelectedIndexChanged);
            // 
            // cbbPagingLimit
            // 
            this.cbbPagingLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbPagingLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPagingLimit.FormattingEnabled = true;
            this.cbbPagingLimit.Items.AddRange(new object[] {
            "No change",
            "25",
            "50",
            "75",
            "100",
            "250"});
            this.cbbPagingLimit.Location = new System.Drawing.Point(416, 148);
            this.cbbPagingLimit.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbPagingLimit.Name = "cbbPagingLimit";
            this.cbbPagingLimit.Size = new System.Drawing.Size(778, 39);
            this.cbbPagingLimit.TabIndex = 30;
            // 
            // cbbTimeZones
            // 
            this.cbbTimeZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTimeZones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTimeZones.FormattingEnabled = true;
            this.cbbTimeZones.Location = new System.Drawing.Point(416, 205);
            this.cbbTimeZones.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbbTimeZones.Name = "cbbTimeZones";
            this.cbbTimeZones.Size = new System.Drawing.Size(778, 39);
            this.cbbTimeZones.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 41;
            this.label1.Text = "Default Pane";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 32);
            this.label2.TabIndex = 42;
            this.label2.Text = "Default Tab";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 32);
            this.label3.TabIndex = 43;
            this.label3.Text = "Records per page";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 210);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 32);
            this.label4.TabIndex = 44;
            this.label4.Text = "Time zone";
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(2190, 1180);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbOutlookForms.ResumeLayout(false);
            this.gbOutlookForms.PerformLayout();
            this.gbLanguages.ResumeLayout(false);
            this.gbLanguages.PerformLayout();
            this.gbPrivacy.ResumeLayout(false);
            this.gbPrivacy.PerformLayout();
            this.gbEmail.ResumeLayout(false);
            this.gbEmail.PerformLayout();
            this.gbActivities.ResumeLayout(false);
            this.gbActivities.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private UserControls.UserSelector userSelector1;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadCrmItems;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbCreateRecords;
        private System.Windows.Forms.ComboBox cbbTrackMessages;
        private System.Windows.Forms.ComboBox cbbSendAsAllowed;
        private System.Windows.Forms.ComboBox cbbWorkStopTime;
        private System.Windows.Forms.ComboBox cbbWorkStartTime;
        private System.Windows.Forms.ComboBox cbbCalendar;
        private System.Windows.Forms.ComboBox cbbTimeZones;
        private System.Windows.Forms.ComboBox cbbPagingLimit;
        private System.Windows.Forms.ComboBox cbbSiteMapSubArea;
        private System.Windows.Forms.ComboBox cbbSiteMapArea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbUpdateUserSettings;
        private System.Windows.Forms.GroupBox gbPrivacy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbReportScriptErrors;
        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.GroupBox gbActivities;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbAdvancedFindMode;
        private System.Windows.Forms.ComboBox cbbStartupPane;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbbHelpLanguage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbbUiLanguage;
        private System.Windows.Forms.GroupBox gbLanguages;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbbCurrencies;
        private System.Windows.Forms.GroupBox gbOutlookForms;
        private System.Windows.Forms.ComboBox cbbUseCrmFormTask;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbbUseCrmFormAppt;
        private System.Windows.Forms.ComboBox cbbUseCrmFormContact;
        private System.Windows.Forms.ComboBox cbbUseCrmFormEmail;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbEditInFXB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
