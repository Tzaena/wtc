namespace WindowsFormsApplication1
{
    partial class Lists
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
            this.buttonHide = new System.Windows.Forms.Button();
            this.comboBoxTeams = new System.Windows.Forms.ComboBox();
            this.comboBoxArmies = new System.Windows.Forms.ComboBox();
            this.labelError = new System.Windows.Forms.Label();
            this.listViewList1 = new System.Windows.Forms.ListView();
            this.listViewList2 = new System.Windows.Forms.ListView();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(579, 10);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(48, 36);
            this.buttonHide.TabIndex = 0;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // comboBoxTeams
            // 
            this.comboBoxTeams.FormattingEnabled = true;
            this.comboBoxTeams.Location = new System.Drawing.Point(13, 3);
            this.comboBoxTeams.Name = "comboBoxTeams";
            this.comboBoxTeams.Size = new System.Drawing.Size(198, 21);
            this.comboBoxTeams.TabIndex = 1;
            // 
            // comboBoxArmies
            // 
            this.comboBoxArmies.FormattingEnabled = true;
            this.comboBoxArmies.Location = new System.Drawing.Point(13, 31);
            this.comboBoxArmies.Name = "comboBoxArmies";
            this.comboBoxArmies.Size = new System.Drawing.Size(198, 21);
            this.comboBoxArmies.TabIndex = 2;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(251, 10);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(322, 13);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "Vous devez ajouter un fichier lists.json au même endroit que le .exe";
            // 
            // listViewList1
            // 
            this.listViewList1.Location = new System.Drawing.Point(13, 103);
            this.listViewList1.Name = "listViewList1";
            this.listViewList1.Size = new System.Drawing.Size(304, 583);
            this.listViewList1.TabIndex = 4;
            this.listViewList1.UseCompatibleStateImageBehavior = false;
            // 
            // listViewList2
            // 
            this.listViewList2.Location = new System.Drawing.Point(321, 103);
            this.listViewList2.Name = "listViewList2";
            this.listViewList2.Size = new System.Drawing.Size(304, 583);
            this.listViewList2.TabIndex = 5;
            this.listViewList2.UseCompatibleStateImageBehavior = false;
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Location = new System.Drawing.Point(13, 69);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(0, 13);
            this.labelPlayer.TabIndex = 6;
            // 
            // Lists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 698);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.listViewList2);
            this.Controls.Add(this.listViewList1);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.comboBoxArmies);
            this.Controls.Add(this.comboBoxTeams);
            this.Controls.Add(this.buttonHide);
            this.Name = "Lists";
            this.Text = "Teams";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.ComboBox comboBoxTeams;
        private System.Windows.Forms.ComboBox comboBoxArmies;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ListView listViewList1;
        private System.Windows.Forms.ListView listViewList2;
        private System.Windows.Forms.Label labelPlayer;
    }
}