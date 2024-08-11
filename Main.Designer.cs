namespace w2_volume
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tblDesign = new System.Windows.Forms.TableLayoutPanel();
            this.lblMixer = new System.Windows.Forms.Label();
            this.lblBGM = new System.Windows.Forms.Label();
            this.flwBGM = new System.Windows.Forms.FlowLayoutPanel();
            this.tbBGM = new System.Windows.Forms.TrackBar();
            this.lblBGMval = new System.Windows.Forms.Label();
            this.btnMixer = new System.Windows.Forms.Button();
            this.tblDesign.SuspendLayout();
            this.flwBGM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBGM)).BeginInit();
            this.SuspendLayout();
            // 
            // tblDesign
            // 
            this.tblDesign.AutoSize = true;
            this.tblDesign.ColumnCount = 2;
            this.tblDesign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDesign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblDesign.Controls.Add(this.lblMixer, 0, 1);
            this.tblDesign.Controls.Add(this.lblBGM, 0, 0);
            this.tblDesign.Controls.Add(this.flwBGM, 1, 0);
            this.tblDesign.Controls.Add(this.btnMixer, 1, 1);
            this.tblDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDesign.Location = new System.Drawing.Point(0, 0);
            this.tblDesign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tblDesign.Name = "tblDesign";
            this.tblDesign.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.tblDesign.RowCount = 2;
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDesign.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDesign.Size = new System.Drawing.Size(435, 138);
            this.tblDesign.TabIndex = 0;
            // 
            // lblMixer
            // 
            this.lblMixer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMixer.AutoSize = true;
            this.lblMixer.Location = new System.Drawing.Point(44, 119);
            this.lblMixer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMixer.Name = "lblMixer";
            this.lblMixer.Size = new System.Drawing.Size(155, 27);
            this.lblMixer.TabIndex = 5;
            this.lblMixer.Text = "Volume Mixer";
            this.lblMixer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBGM
            // 
            this.lblBGM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBGM.AutoSize = true;
            this.lblBGM.Location = new System.Drawing.Point(16, 47);
            this.lblBGM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBGM.Name = "lblBGM";
            this.lblBGM.Size = new System.Drawing.Size(211, 27);
            this.lblBGM.TabIndex = 2;
            this.lblBGM.Text = "Background Music";
            this.lblBGM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flwBGM
            // 
            this.flwBGM.AutoScroll = true;
            this.flwBGM.AutoSize = true;
            this.flwBGM.Controls.Add(this.tbBGM);
            this.flwBGM.Controls.Add(this.lblBGMval);
            this.flwBGM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwBGM.Location = new System.Drawing.Point(235, 16);
            this.flwBGM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flwBGM.Name = "flwBGM";
            this.flwBGM.Size = new System.Drawing.Size(267, 89);
            this.flwBGM.TabIndex = 4;
            // 
            // tbBGM
            // 
            this.tbBGM.AutoSize = false;
            this.tbBGM.Location = new System.Drawing.Point(2, 2);
            this.tbBGM.Margin = new System.Windows.Forms.Padding(2);
            this.tbBGM.Maximum = 100;
            this.tbBGM.Name = "tbBGM";
            this.tbBGM.Size = new System.Drawing.Size(233, 58);
            this.tbBGM.TabIndex = 0;
            this.tbBGM.TickFrequency = 10;
            this.tbBGM.Value = 100;
            this.tbBGM.ValueChanged += new System.EventHandler(this.tbBGM_ValueChanged);
            // 
            // lblBGMval
            // 
            this.lblBGMval.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBGMval.AutoSize = true;
            this.lblBGMval.Location = new System.Drawing.Point(4, 62);
            this.lblBGMval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBGMval.MinimumSize = new System.Drawing.Size(58, 0);
            this.lblBGMval.Name = "lblBGMval";
            this.lblBGMval.Size = new System.Drawing.Size(58, 27);
            this.lblBGMval.TabIndex = 1;
            this.lblBGMval.Text = "100";
            this.lblBGMval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMixer
            // 
            this.btnMixer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMixer.AutoSize = true;
            this.btnMixer.Location = new System.Drawing.Point(233, 111);
            this.btnMixer.Margin = new System.Windows.Forms.Padding(2);
            this.btnMixer.Name = "btnMixer";
            this.btnMixer.Size = new System.Drawing.Size(271, 43);
            this.btnMixer.TabIndex = 6;
            this.btnMixer.Text = "Open Volume Mixer";
            this.btnMixer.UseVisualStyleBackColor = true;
            this.btnMixer.Click += new System.EventHandler(this.btnMixer_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(435, 138);
            this.Controls.Add(this.tblDesign);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Worms 2 Volume";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tblDesign.ResumeLayout(false);
            this.tblDesign.PerformLayout();
            this.flwBGM.ResumeLayout(false);
            this.flwBGM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBGM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblDesign;
        private System.Windows.Forms.TrackBar tbBGM;
        private System.Windows.Forms.Label lblBGMval;
        private System.Windows.Forms.Label lblBGM;
        private System.Windows.Forms.FlowLayoutPanel flwBGM;
        private System.Windows.Forms.Label lblMixer;
        private System.Windows.Forms.Button btnMixer;
    }
}

