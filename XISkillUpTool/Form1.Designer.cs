namespace XISkillUpTool
{
    partial class Form1
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
            this.pbPlayerHPP = new System.Windows.Forms.ProgressBar();
            this.pbPlayerMPP = new System.Windows.Forms.ProgressBar();
            this.pbPlayerTP = new System.Windows.Forms.ProgressBar();
            this.pbTargetHPP = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lboxSkillUp = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPlayerHPP
            // 
            this.pbPlayerHPP.Location = new System.Drawing.Point(13, 13);
            this.pbPlayerHPP.Name = "pbPlayerHPP";
            this.pbPlayerHPP.Size = new System.Drawing.Size(100, 23);
            this.pbPlayerHPP.TabIndex = 0;
            // 
            // pbPlayerMPP
            // 
            this.pbPlayerMPP.Location = new System.Drawing.Point(12, 42);
            this.pbPlayerMPP.Name = "pbPlayerMPP";
            this.pbPlayerMPP.Size = new System.Drawing.Size(100, 23);
            this.pbPlayerMPP.TabIndex = 0;
            // 
            // pbPlayerTP
            // 
            this.pbPlayerTP.Location = new System.Drawing.Point(12, 71);
            this.pbPlayerTP.Name = "pbPlayerTP";
            this.pbPlayerTP.Size = new System.Drawing.Size(100, 23);
            this.pbPlayerTP.TabIndex = 0;
            // 
            // pbTargetHPP
            // 
            this.pbTargetHPP.Location = new System.Drawing.Point(119, 13);
            this.pbTargetHPP.Name = "pbTargetHPP";
            this.pbTargetHPP.Size = new System.Drawing.Size(153, 23);
            this.pbTargetHPP.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 100);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCommand.Location = new System.Drawing.Point(12, 201);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(182, 20);
            this.txtCommand.TabIndex = 2;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(200, 199);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lboxSkillUp
            // 
            this.lboxSkillUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxSkillUp.FormattingEnabled = true;
            this.lboxSkillUp.Location = new System.Drawing.Point(118, 40);
            this.lboxSkillUp.Name = "lboxSkillUp";
            this.lboxSkillUp.Size = new System.Drawing.Size(154, 108);
            this.lboxSkillUp.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 229);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 251);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lboxSkillUp);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pbTargetHPP);
            this.Controls.Add(this.pbPlayerTP);
            this.Controls.Add(this.pbPlayerMPP);
            this.Controls.Add(this.pbPlayerHPP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbPlayerHPP;
        private System.Windows.Forms.ProgressBar pbPlayerMPP;
        private System.Windows.Forms.ProgressBar pbPlayerTP;
        private System.Windows.Forms.ProgressBar pbTargetHPP;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lboxSkillUp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

