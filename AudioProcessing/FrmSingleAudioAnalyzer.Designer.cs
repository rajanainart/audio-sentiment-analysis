namespace AudioProcessing
{
    partial class FrmSingleAudioAnalyzer
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
            this.txtParsedText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAudioResult = new System.Windows.Forms.TextBox();
            this.chkPlay = new System.Windows.Forms.CheckBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtParsedText
            // 
            this.txtParsedText.Location = new System.Drawing.Point(314, 242);
            this.txtParsedText.Multiline = true;
            this.txtParsedText.Name = "txtParsedText";
            this.txtParsedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtParsedText.Size = new System.Drawing.Size(1470, 670);
            this.txtParsedText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parsed Text";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(495, 113);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(338, 71);
            this.btnParse.TabIndex = 3;
            this.btnParse.Text = "Parse Text";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1256, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(180, 64);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(321, 45);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(910, 38);
            this.txtFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the audio file";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 947);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Audio Result";
            // 
            // txtAudioResult
            // 
            this.txtAudioResult.Location = new System.Drawing.Point(318, 946);
            this.txtAudioResult.Multiline = true;
            this.txtAudioResult.Name = "txtAudioResult";
            this.txtAudioResult.ReadOnly = true;
            this.txtAudioResult.Size = new System.Drawing.Size(1465, 101);
            this.txtAudioResult.TabIndex = 7;
            // 
            // chkPlay
            // 
            this.chkPlay.AutoSize = true;
            this.chkPlay.Location = new System.Drawing.Point(321, 126);
            this.chkPlay.Name = "chkPlay";
            this.chkPlay.Size = new System.Drawing.Size(109, 36);
            this.chkPlay.TabIndex = 8;
            this.chkPlay.Text = "Play";
            this.chkPlay.UseVisualStyleBackColor = true;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(873, 113);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(338, 71);
            this.btnAnalyze.TabIndex = 9;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // FrmSingleAudioAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1870, 1174);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.chkPlay);
            this.Controls.Add(this.txtAudioResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtParsedText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmSingleAudioAnalyzer";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 50, 50);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParsedText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAudioResult;
        private System.Windows.Forms.CheckBox chkPlay;
        private System.Windows.Forms.Button btnAnalyze;
    }
}