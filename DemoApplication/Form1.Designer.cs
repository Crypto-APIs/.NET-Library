namespace DemoApplication
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
            this.getSymbolsButton = new System.Windows.Forms.Button();
            this.getExchangesButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.symbolGroupBox = new System.Windows.Forms.GroupBox();
            this.symbolListBox = new System.Windows.Forms.ListBox();
            this.exchangeGroupBox = new System.Windows.Forms.GroupBox();
            this.exchangeListBox = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.symbolGroupBox.SuspendLayout();
            this.exchangeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // getSymbolsButton
            // 
            this.getSymbolsButton.Location = new System.Drawing.Point(21, 245);
            this.getSymbolsButton.Name = "getSymbolsButton";
            this.getSymbolsButton.Size = new System.Drawing.Size(200, 31);
            this.getSymbolsButton.TabIndex = 0;
            this.getSymbolsButton.Text = "Get symbols sync";
            this.getSymbolsButton.UseVisualStyleBackColor = true;
            this.getSymbolsButton.Click += new System.EventHandler(this.getAssetsButton_Click);
            // 
            // getExchangesButton
            // 
            this.getExchangesButton.Location = new System.Drawing.Point(254, 245);
            this.getExchangesButton.Name = "getExchangesButton";
            this.getExchangesButton.Size = new System.Drawing.Size(200, 31);
            this.getExchangesButton.TabIndex = 1;
            this.getExchangesButton.Text = "Get exchanges async";
            this.getExchangesButton.UseVisualStyleBackColor = true;
            this.getExchangesButton.Click += new System.EventHandler(this.getExchangesButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(254, 282);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 28);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // symbolGroupBox
            // 
            this.symbolGroupBox.Controls.Add(this.symbolListBox);
            this.symbolGroupBox.Location = new System.Drawing.Point(21, 23);
            this.symbolGroupBox.Name = "symbolGroupBox";
            this.symbolGroupBox.Size = new System.Drawing.Size(200, 214);
            this.symbolGroupBox.TabIndex = 4;
            this.symbolGroupBox.TabStop = false;
            this.symbolGroupBox.Text = "Symbols";
            // 
            // symbolListBox
            // 
            this.symbolListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.symbolListBox.FormattingEnabled = true;
            this.symbolListBox.ItemHeight = 16;
            this.symbolListBox.Location = new System.Drawing.Point(12, 21);
            this.symbolListBox.Name = "symbolListBox";
            this.symbolListBox.Size = new System.Drawing.Size(182, 180);
            this.symbolListBox.TabIndex = 4;
            // 
            // exchangeGroupBox
            // 
            this.exchangeGroupBox.Controls.Add(this.exchangeListBox);
            this.exchangeGroupBox.Location = new System.Drawing.Point(254, 25);
            this.exchangeGroupBox.Name = "exchangeGroupBox";
            this.exchangeGroupBox.Size = new System.Drawing.Size(200, 214);
            this.exchangeGroupBox.TabIndex = 5;
            this.exchangeGroupBox.TabStop = false;
            this.exchangeGroupBox.Text = "Exchanges";
            // 
            // exchangeListBox
            // 
            this.exchangeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exchangeListBox.FormattingEnabled = true;
            this.exchangeListBox.ItemHeight = 16;
            this.exchangeListBox.Location = new System.Drawing.Point(12, 21);
            this.exchangeListBox.Name = "exchangeListBox";
            this.exchangeListBox.Size = new System.Drawing.Size(182, 180);
            this.exchangeListBox.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 328);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(480, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 350);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.exchangeGroupBox);
            this.Controls.Add(this.symbolGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.getExchangesButton);
            this.Controls.Add(this.getSymbolsButton);
            this.Name = "Form1";
            this.Text = "Demo Application";
            this.symbolGroupBox.ResumeLayout(false);
            this.exchangeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getSymbolsButton;
        private System.Windows.Forms.Button getExchangesButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox symbolGroupBox;
        private System.Windows.Forms.ListBox symbolListBox;
        private System.Windows.Forms.GroupBox exchangeGroupBox;
        private System.Windows.Forms.ListBox exchangeListBox;
        private System.Windows.Forms.StatusStrip statusStrip;
    }
}

