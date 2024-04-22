namespace darwinGameV1
{
    partial class darwin
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
            this.startLabel = new System.Windows.Forms.Label();
            this.playerStrengthLabel = new System.Windows.Forms.Label();
            this.playerDefenceLabel = new System.Windows.Forms.Label();
            this.environmentStrengthLabel = new System.Windows.Forms.Label();
            this.environmentDefenceLabel = new System.Windows.Forms.Label();
            this.playerDietTypeLabel = new System.Windows.Forms.Label();
            this.pastMutationsLabel = new System.Windows.Forms.ListView();
            this.genCountLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pastStrengthLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pastDefenceLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pastDietLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pastPopulationLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mutationLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pastSizeLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pastHabitatLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerPopulationLabel = new System.Windows.Forms.Label();
            this.kLabel = new System.Windows.Forms.Label();
            this.playerHabitatLabel = new System.Windows.Forms.Label();
            this.playerSizeLabel = new System.Windows.Forms.Label();
            this.mutationMessageLabel = new System.Windows.Forms.Label();
            this.eventLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBoxLabel = new System.Windows.Forms.Label();
            this.pastEventLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // startLabel
            // 
            this.startLabel.BackColor = System.Drawing.Color.Transparent;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.startLabel.Location = new System.Drawing.Point(163, 326);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(499, 35);
            this.startLabel.TabIndex = 1;
            this.startLabel.Text = "Press to Enter Start!";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // playerStrengthLabel
            // 
            this.playerStrengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerStrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playerStrengthLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.playerStrengthLabel.Location = new System.Drawing.Point(12, 9);
            this.playerStrengthLabel.Name = "playerStrengthLabel";
            this.playerStrengthLabel.Size = new System.Drawing.Size(184, 35);
            this.playerStrengthLabel.TabIndex = 2;
            this.playerStrengthLabel.Text = "playerStrengthLabel";
            // 
            // playerDefenceLabel
            // 
            this.playerDefenceLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerDefenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playerDefenceLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.playerDefenceLabel.Location = new System.Drawing.Point(12, 44);
            this.playerDefenceLabel.Name = "playerDefenceLabel";
            this.playerDefenceLabel.Size = new System.Drawing.Size(184, 35);
            this.playerDefenceLabel.TabIndex = 3;
            this.playerDefenceLabel.Text = "playerDefenceLabel";
            // 
            // environmentStrengthLabel
            // 
            this.environmentStrengthLabel.BackColor = System.Drawing.Color.Transparent;
            this.environmentStrengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.environmentStrengthLabel.Location = new System.Drawing.Point(604, 9);
            this.environmentStrengthLabel.Name = "environmentStrengthLabel";
            this.environmentStrengthLabel.Size = new System.Drawing.Size(184, 35);
            this.environmentStrengthLabel.TabIndex = 5;
            this.environmentStrengthLabel.Text = "environmentStrengthLabel";
            this.environmentStrengthLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // environmentDefenceLabel
            // 
            this.environmentDefenceLabel.BackColor = System.Drawing.Color.Transparent;
            this.environmentDefenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.environmentDefenceLabel.Location = new System.Drawing.Point(604, 44);
            this.environmentDefenceLabel.Name = "environmentDefenceLabel";
            this.environmentDefenceLabel.Size = new System.Drawing.Size(184, 35);
            this.environmentDefenceLabel.TabIndex = 6;
            this.environmentDefenceLabel.Text = "environmentDefenceLabel";
            this.environmentDefenceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // playerDietTypeLabel
            // 
            this.playerDietTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerDietTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playerDietTypeLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.playerDietTypeLabel.Location = new System.Drawing.Point(607, 103);
            this.playerDietTypeLabel.Name = "playerDietTypeLabel";
            this.playerDietTypeLabel.Size = new System.Drawing.Size(184, 35);
            this.playerDietTypeLabel.TabIndex = 8;
            this.playerDietTypeLabel.Text = "dietTypeLabel";
            this.playerDietTypeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pastMutationsLabel
            // 
            this.pastMutationsLabel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.genCountLabel,
            this.pastStrengthLabel,
            this.pastDefenceLabel,
            this.pastDietLabel,
            this.pastPopulationLabel,
            this.mutationLabel,
            this.pastSizeLabel,
            this.pastHabitatLabel,
            this.pastEventLabel});
            this.pastMutationsLabel.HideSelection = false;
            this.pastMutationsLabel.Location = new System.Drawing.Point(12, 222);
            this.pastMutationsLabel.MultiSelect = false;
            this.pastMutationsLabel.Name = "pastMutationsLabel";
            this.pastMutationsLabel.Size = new System.Drawing.Size(200, 216);
            this.pastMutationsLabel.TabIndex = 11;
            this.pastMutationsLabel.UseCompatibleStateImageBehavior = false;
            this.pastMutationsLabel.View = System.Windows.Forms.View.Details;
            // 
            // genCountLabel
            // 
            this.genCountLabel.Text = "Generation:";
            // 
            // pastStrengthLabel
            // 
            this.pastStrengthLabel.Text = "Strength:";
            // 
            // pastDefenceLabel
            // 
            this.pastDefenceLabel.Text = "Defence:";
            // 
            // pastDietLabel
            // 
            this.pastDietLabel.Text = "Diet:";
            this.pastDietLabel.Width = 80;
            // 
            // pastPopulationLabel
            // 
            this.pastPopulationLabel.Text = "Population:";
            // 
            // mutationLabel
            // 
            this.mutationLabel.Text = "Mutations:";
            this.mutationLabel.Width = 120;
            // 
            // pastSizeLabel
            // 
            this.pastSizeLabel.Text = "Size:";
            // 
            // pastHabitatLabel
            // 
            this.pastHabitatLabel.Text = "Habitat:";
            this.pastHabitatLabel.Width = 80;
            // 
            // playerPopulationLabel
            // 
            this.playerPopulationLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerPopulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playerPopulationLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.playerPopulationLabel.Location = new System.Drawing.Point(12, 79);
            this.playerPopulationLabel.Name = "playerPopulationLabel";
            this.playerPopulationLabel.Size = new System.Drawing.Size(184, 35);
            this.playerPopulationLabel.TabIndex = 12;
            this.playerPopulationLabel.Text = "playerPopulationLabel";
            // 
            // kLabel
            // 
            this.kLabel.BackColor = System.Drawing.Color.Transparent;
            this.kLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.kLabel.Location = new System.Drawing.Point(505, 244);
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size(286, 62);
            this.kLabel.TabIndex = 13;
            this.kLabel.Text = "Press K to Move On to Next Generation!";
            this.kLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // playerHabitatLabel
            // 
            this.playerHabitatLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerHabitatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playerHabitatLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.playerHabitatLabel.Location = new System.Drawing.Point(607, 129);
            this.playerHabitatLabel.Name = "playerHabitatLabel";
            this.playerHabitatLabel.Size = new System.Drawing.Size(184, 35);
            this.playerHabitatLabel.TabIndex = 14;
            this.playerHabitatLabel.Text = "playerHabitatLabel";
            this.playerHabitatLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // playerSizeLabel
            // 
            this.playerSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.playerSizeLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.playerSizeLabel.Location = new System.Drawing.Point(12, 114);
            this.playerSizeLabel.Name = "playerSizeLabel";
            this.playerSizeLabel.Size = new System.Drawing.Size(184, 35);
            this.playerSizeLabel.TabIndex = 15;
            this.playerSizeLabel.Text = "playerSizeLabel";
            // 
            // mutationMessageLabel
            // 
            this.mutationMessageLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mutationMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.mutationMessageLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.mutationMessageLabel.Location = new System.Drawing.Point(215, 9);
            this.mutationMessageLabel.Name = "mutationMessageLabel";
            this.mutationMessageLabel.Size = new System.Drawing.Size(375, 82);
            this.mutationMessageLabel.TabIndex = 16;
            this.mutationMessageLabel.Text = "mutationMessageLabel";
            this.mutationMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eventLabel
            // 
            this.eventLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.eventLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.eventLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.eventLabel.Location = new System.Drawing.Point(187, 98);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(422, 116);
            this.eventLabel.TabIndex = 17;
            this.eventLabel.Text = "eventLabel";
            this.eventLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameBox
            // 
            this.nameBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameBox.Location = new System.Drawing.Point(285, 222);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(239, 20);
            this.nameBox.TabIndex = 18;
            this.nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.nameLabel.Location = new System.Drawing.Point(12, 166);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(170, 35);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "nameLabel";
            // 
            // nameBoxLabel
            // 
            this.nameBoxLabel.AutoSize = true;
            this.nameBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameBoxLabel.Location = new System.Drawing.Point(359, 255);
            this.nameBoxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameBoxLabel.Name = "nameBoxLabel";
            this.nameBoxLabel.Size = new System.Drawing.Size(77, 13);
            this.nameBoxLabel.TabIndex = 20;
            this.nameBoxLabel.Text = "nameBoxLabel";
            // 
            // pastEventLabel
            // 
            this.pastEventLabel.Width = 150;
            // 
            // darwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nameBoxLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.eventLabel);
            this.Controls.Add(this.mutationMessageLabel);
            this.Controls.Add(this.playerSizeLabel);
            this.Controls.Add(this.playerHabitatLabel);
            this.Controls.Add(this.kLabel);
            this.Controls.Add(this.playerPopulationLabel);
            this.Controls.Add(this.pastMutationsLabel);
            this.Controls.Add(this.playerDietTypeLabel);
            this.Controls.Add(this.environmentDefenceLabel);
            this.Controls.Add(this.environmentStrengthLabel);
            this.Controls.Add(this.playerDefenceLabel);
            this.Controls.Add(this.playerStrengthLabel);
            this.Controls.Add(this.startLabel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "darwin";
            this.Text = "Darwin";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.darwin_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label playerStrengthLabel;
        private System.Windows.Forms.Label playerDefenceLabel;
        private System.Windows.Forms.Label environmentStrengthLabel;
        private System.Windows.Forms.Label environmentDefenceLabel;
        private System.Windows.Forms.Label playerDietTypeLabel;
        private System.Windows.Forms.ListView pastMutationsLabel;
        private System.Windows.Forms.ColumnHeader genCountLabel;
        private System.Windows.Forms.ColumnHeader pastStrengthLabel;
        private System.Windows.Forms.ColumnHeader pastDefenceLabel;
        private System.Windows.Forms.ColumnHeader pastDietLabel;
        private System.Windows.Forms.ColumnHeader pastPopulationLabel;
        private System.Windows.Forms.Label playerPopulationLabel;
        private System.Windows.Forms.ColumnHeader mutationLabel;
        private System.Windows.Forms.Label kLabel;
        private System.Windows.Forms.ColumnHeader pastSizeLabel;
        private System.Windows.Forms.ColumnHeader pastHabitatLabel;
        private System.Windows.Forms.Label playerHabitatLabel;
        private System.Windows.Forms.Label playerSizeLabel;
        private System.Windows.Forms.Label mutationMessageLabel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label nameBoxLabel;
        private System.Windows.Forms.ColumnHeader pastEventLabel;
    }
}

