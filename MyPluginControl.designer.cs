namespace Field_Seeker
{
    partial class MyPluginControl
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
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.searchField = new System.Windows.Forms.ToolStripButton();
            this.resultLabel = new System.Windows.Forms.Label();
            this.fieldNameLabel = new System.Windows.Forms.Label();
            this.fieldName = new System.Windows.Forms.TextBox();
            this.resultsTree = new System.Windows.Forms.TreeView();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.searchField});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1472, 27);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(107, 24);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // searchField
            // 
            this.searchField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(93, 24);
            this.searchField.Text = "Search Field";
            this.searchField.ToolTipText = "Search field in all entities.";
            this.searchField.Click += new System.EventHandler(this.searchField_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(150, 41);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(55, 17);
            this.resultLabel.TabIndex = 6;
            this.resultLabel.Text = "Results";
            // 
            // fieldNameLabel
            // 
            this.fieldNameLabel.AutoSize = true;
            this.fieldNameLabel.Location = new System.Drawing.Point(12, 41);
            this.fieldNameLabel.Name = "fieldNameLabel";
            this.fieldNameLabel.Size = new System.Drawing.Size(79, 17);
            this.fieldNameLabel.TabIndex = 7;
            this.fieldNameLabel.Text = "Field Name";
            // 
            // fieldName
            // 
            this.fieldName.Location = new System.Drawing.Point(15, 61);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(132, 22);
            this.fieldName.TabIndex = 8;
            // 
            // resultsTree
            // 
            this.resultsTree.Location = new System.Drawing.Point(153, 61);
            this.resultsTree.Name = "resultsTree";
            this.resultsTree.Size = new System.Drawing.Size(811, 753);
            this.resultsTree.TabIndex = 9;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsTree);
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.fieldNameLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1472, 835);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton searchField;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label fieldNameLabel;
        private System.Windows.Forms.TextBox fieldName;
        private System.Windows.Forms.TreeView resultsTree;
    }
}
