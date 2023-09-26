namespace MsCrmTools.UserSettingsUtility.UserControls
{
    partial class UserSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSelector));
            this.cbbViews = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ilUserAndTeams = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.llInvertSelection = new System.Windows.Forms.LinkLabel();
            this.llCheckNone = new System.Windows.Forms.LinkLabel();
            this.llCheckAll = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.chLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBusinessUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbViews
            // 
            this.cbbViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbViews.FormattingEnabled = true;
            this.cbbViews.Location = new System.Drawing.Point(66, 5);
            this.cbbViews.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbbViews.Name = "cbbViews";
            this.cbbViews.Size = new System.Drawing.Size(492, 28);
            this.cbbViews.TabIndex = 2;
            this.cbbViews.SelectedIndexChanged += new System.EventHandler(this.cbbViews_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "View";
            // 
            // ilUserAndTeams
            // 
            this.ilUserAndTeams.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilUserAndTeams.ImageStream")));
            this.ilUserAndTeams.TransparentColor = System.Drawing.Color.Transparent;
            this.ilUserAndTeams.Images.SetKeyName(0, "ico_16_8.gif");
            this.ilUserAndTeams.Images.SetKeyName(1, "ico_16_9.gif");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbViews);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 38);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.llInvertSelection);
            this.panel2.Controls.Add(this.llCheckNone);
            this.panel2.Controls.Add(this.llCheckAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(561, 32);
            this.panel2.TabIndex = 7;
            // 
            // llInvertSelection
            // 
            this.llInvertSelection.AutoSize = true;
            this.llInvertSelection.Location = new System.Drawing.Point(182, 3);
            this.llInvertSelection.Name = "llInvertSelection";
            this.llInvertSelection.Size = new System.Drawing.Size(116, 20);
            this.llInvertSelection.TabIndex = 2;
            this.llInvertSelection.TabStop = true;
            this.llInvertSelection.Text = "Invert selection";
            this.llInvertSelection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llInvertSelection_LinkClicked);
            // 
            // llCheckNone
            // 
            this.llCheckNone.AutoSize = true;
            this.llCheckNone.Location = new System.Drawing.Point(82, 3);
            this.llCheckNone.Name = "llCheckNone";
            this.llCheckNone.Size = new System.Drawing.Size(94, 20);
            this.llCheckNone.TabIndex = 1;
            this.llCheckNone.TabStop = true;
            this.llCheckNone.Text = "Check none";
            this.llCheckNone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCheckNone_LinkClicked);
            // 
            // llCheckAll
            // 
            this.llCheckAll.AutoSize = true;
            this.llCheckAll.Location = new System.Drawing.Point(3, 3);
            this.llCheckAll.Name = "llCheckAll";
            this.llCheckAll.Size = new System.Drawing.Size(73, 20);
            this.llCheckAll.TabIndex = 0;
            this.llCheckAll.TabStop = true;
            this.llCheckAll.Text = "Check all";
            this.llCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCheckAll_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtFilter);
            this.panel3.Controls.Add(this.lblFilter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(561, 30);
            this.panel3.TabIndex = 8;
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilter.Location = new System.Drawing.Point(56, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(505, 26);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFilter.Location = new System.Drawing.Point(0, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(56, 30);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // lvUsers
            // 
            this.lvUsers.CheckBoxes = true;
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLastName,
            this.chFirstName,
            this.chBusinessUnit});
            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(0, 100);
            this.lvUsers.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(561, 530);
            this.lvUsers.SmallImageList = this.ilUserAndTeams;
            this.lvUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvUsers.TabIndex = 10;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvUsers_ColumnClick);
            this.lvUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvUsers_ItemSelectionChanged);
            // 
            // chLastName
            // 
            this.chLastName.Text = "Last name";
            this.chLastName.Width = 150;
            // 
            // chFirstName
            // 
            this.chFirstName.Text = "First name";
            this.chFirstName.Width = 150;
            // 
            // chBusinessUnit
            // 
            this.chBusinessUnit.Text = "Business unit";
            this.chBusinessUnit.Width = 150;
            // 
            // UserSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UserSelector";
            this.Size = new System.Drawing.Size(561, 630);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbViews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList ilUserAndTeams;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel llInvertSelection;
        private System.Windows.Forms.LinkLabel llCheckNone;
        private System.Windows.Forms.LinkLabel llCheckAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader chLastName;
        private System.Windows.Forms.ColumnHeader chFirstName;
        private System.Windows.Forms.ColumnHeader chBusinessUnit;
    }
}
