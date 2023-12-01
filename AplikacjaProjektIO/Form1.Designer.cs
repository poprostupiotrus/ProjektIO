namespace AplikacjaProjektIO
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.scrollablePanel = new System.Windows.Forms.Panel();
            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.scrollablePanel.Location = new System.Drawing.Point(0, 0);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(200, 570);
            this.scrollablePanel.TabIndex = 0;
            // 
            // cartesianChart
            // 
            this.cartesianChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cartesianChart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cartesianChart.Location = new System.Drawing.Point(201, 0);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(600, 415);
            this.cartesianChart.TabIndex = 0;
            this.cartesianChart.Text = "cartesianChart1";
            this.cartesianChart.DataClick += new LiveCharts.Events.DataClickHandler(this.cartesianChart_DataClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(207, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(752, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kliknij na konkretny punkt wykresu aby zobaczyć najbliższy jemu artykuł";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(210, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(752, 92);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tresc artykulu";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(207, 548);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Link do artykulu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(807, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 344);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ticker:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(863, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 344);
            this.label4.TabIndex = 5;
            this.label4.Text = "ChatGPT:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(927, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 344);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bard:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(807, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 58);
            this.label6.TabIndex = 7;
            this.label6.Text = "Prawdopodobieństwo zmiany kursu na podstawie artykulu według LLM";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(810, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Poprzedni";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(892, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Następny";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 570);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cartesianChart);
            this.Controls.Add(this.scrollablePanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel scrollablePanel;
        private LiveCharts.WinForms.CartesianChart cartesianChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

