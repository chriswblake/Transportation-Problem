namespace Task1Transportation
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
            System.Windows.Forms.Label lblSamples;
            this.btnSample81 = new System.Windows.Forms.Button();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabsInputs = new System.Windows.Forms.TabControl();
            this.tabCosts = new System.Windows.Forms.TabPage();
            this.tabMinimumDelivery = new System.Windows.Forms.TabPage();
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnSample81_MinDel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.wbResults = new System.Windows.Forms.WebBrowser();
            this.gridCosts = new Task1Transportation.TransportProblemGridInput();
            this.gridMinDelivery = new Task1Transportation.TransportProblemGridInput();
            lblSamples = new System.Windows.Forms.Label();
            this.layoutPanel.SuspendLayout();
            this.tabsInputs.SuspendLayout();
            this.tabCosts.SuspendLayout();
            this.tabMinimumDelivery.SuspendLayout();
            this.panButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSamples
            // 
            lblSamples.AutoSize = true;
            lblSamples.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSamples.Location = new System.Drawing.Point(10, 8);
            lblSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblSamples.Name = "lblSamples";
            lblSamples.Size = new System.Drawing.Size(201, 32);
            lblSamples.TabIndex = 41;
            lblSamples.Text = "Sample Problems";
            // 
            // btnSample81
            // 
            this.btnSample81.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSample81.Location = new System.Drawing.Point(14, 48);
            this.btnSample81.Margin = new System.Windows.Forms.Padding(4);
            this.btnSample81.Name = "btnSample81";
            this.btnSample81.Size = new System.Drawing.Size(182, 56);
            this.btnSample81.TabIndex = 39;
            this.btnSample81.Text = "81";
            this.btnSample81.UseVisualStyleBackColor = true;
            this.btnSample81.Click += new System.EventHandler(this.btnSample81_Click);
            // 
            // layoutPanel
            // 
            this.layoutPanel.AutoSize = true;
            this.layoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPanel.ColumnCount = 2;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanel.Controls.Add(this.tabsInputs, 0, 0);
            this.layoutPanel.Controls.Add(this.panButtons, 0, 1);
            this.layoutPanel.Controls.Add(this.wbResults, 1, 0);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 2;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanel.Size = new System.Drawing.Size(1174, 1074);
            this.layoutPanel.TabIndex = 2;
            // 
            // tabsInputs
            // 
            this.tabsInputs.Controls.Add(this.tabCosts);
            this.tabsInputs.Controls.Add(this.tabMinimumDelivery);
            this.tabsInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsInputs.Location = new System.Drawing.Point(6, 6);
            this.tabsInputs.Margin = new System.Windows.Forms.Padding(6);
            this.tabsInputs.MaximumSize = new System.Drawing.Size(0, 400);
            this.tabsInputs.Name = "tabsInputs";
            this.tabsInputs.SelectedIndex = 0;
            this.tabsInputs.Size = new System.Drawing.Size(550, 400);
            this.tabsInputs.TabIndex = 2;
            this.tabsInputs.SelectedIndexChanged += new System.EventHandler(this.tabsInputs_SelectedIndexChanged);
            // 
            // tabCosts
            // 
            this.tabCosts.Controls.Add(this.gridCosts);
            this.tabCosts.Location = new System.Drawing.Point(8, 46);
            this.tabCosts.Margin = new System.Windows.Forms.Padding(6);
            this.tabCosts.Name = "tabCosts";
            this.tabCosts.Padding = new System.Windows.Forms.Padding(6);
            this.tabCosts.Size = new System.Drawing.Size(534, 346);
            this.tabCosts.TabIndex = 0;
            this.tabCosts.Text = "Costs";
            this.tabCosts.UseVisualStyleBackColor = true;
            // 
            // tabMinimumDelivery
            // 
            this.tabMinimumDelivery.Controls.Add(this.gridMinDelivery);
            this.tabMinimumDelivery.Location = new System.Drawing.Point(8, 46);
            this.tabMinimumDelivery.Margin = new System.Windows.Forms.Padding(6);
            this.tabMinimumDelivery.Name = "tabMinimumDelivery";
            this.tabMinimumDelivery.Padding = new System.Windows.Forms.Padding(6);
            this.tabMinimumDelivery.Size = new System.Drawing.Size(0, 346);
            this.tabMinimumDelivery.TabIndex = 1;
            this.tabMinimumDelivery.Text = "Minimum Delivery";
            this.tabMinimumDelivery.UseVisualStyleBackColor = true;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.btnSample81_MinDel);
            this.panButtons.Controls.Add(lblSamples);
            this.panButtons.Controls.Add(this.btnReset);
            this.panButtons.Controls.Add(this.btnGo);
            this.panButtons.Controls.Add(this.btnSample81);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panButtons.Location = new System.Drawing.Point(0, 412);
            this.panButtons.Margin = new System.Windows.Forms.Padding(0);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(562, 669);
            this.panButtons.TabIndex = 3;
            // 
            // btnSample81_MinDel
            // 
            this.btnSample81_MinDel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSample81_MinDel.Location = new System.Drawing.Point(14, 112);
            this.btnSample81_MinDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnSample81_MinDel.Name = "btnSample81_MinDel";
            this.btnSample81_MinDel.Size = new System.Drawing.Size(182, 56);
            this.btnSample81_MinDel.TabIndex = 42;
            this.btnSample81_MinDel.Text = "81, Min Del";
            this.btnSample81_MinDel.UseVisualStyleBackColor = true;
            this.btnSample81_MinDel.Click += new System.EventHandler(this.btnSample81_MinDel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(241, 22);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 100);
            this.btnReset.TabIndex = 40;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(410, 22);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(138, 100);
            this.btnGo.TabIndex = 31;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // wbResults
            // 
            this.wbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbResults.Location = new System.Drawing.Point(568, 6);
            this.wbResults.Margin = new System.Windows.Forms.Padding(6);
            this.wbResults.MinimumSize = new System.Drawing.Size(600, 0);
            this.wbResults.Name = "wbResults";
            this.layoutPanel.SetRowSpan(this.wbResults, 2);
            this.wbResults.ScrollBarsEnabled = false;
            this.wbResults.Size = new System.Drawing.Size(600, 1069);
            this.wbResults.TabIndex = 1;
            this.wbResults.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbResults_DocumentCompleted);
            // 
            // gridCosts
            // 
            this.gridCosts.Demand = null;
            this.gridCosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCosts.Grid = null;
            this.gridCosts.Location = new System.Drawing.Point(6, 6);
            this.gridCosts.Margin = new System.Windows.Forms.Padding(4);
            this.gridCosts.MinimumSize = new System.Drawing.Size(256, 228);
            this.gridCosts.Name = "gridCosts";
            this.gridCosts.ShowDemand = true;
            this.gridCosts.ShowSupply = true;
            this.gridCosts.Size = new System.Drawing.Size(522, 334);
            this.gridCosts.Supply = null;
            this.gridCosts.TabIndex = 0;
            // 
            // gridMinDelivery
            // 
            this.gridMinDelivery.Demand = null;
            this.gridMinDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMinDelivery.Grid = null;
            this.gridMinDelivery.Location = new System.Drawing.Point(6, 6);
            this.gridMinDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.gridMinDelivery.MinimumSize = new System.Drawing.Size(256, 228);
            this.gridMinDelivery.Name = "gridMinDelivery";
            this.gridMinDelivery.ShowDemand = false;
            this.gridMinDelivery.ShowSupply = false;
            this.gridMinDelivery.Size = new System.Drawing.Size(522, 341);
            this.gridMinDelivery.Supply = null;
            this.gridMinDelivery.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1174, 1074);
            this.Controls.Add(this.layoutPanel);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Task 1 - Transportation Problem";
            this.layoutPanel.ResumeLayout(false);
            this.tabsInputs.ResumeLayout(false);
            this.tabCosts.ResumeLayout(false);
            this.tabMinimumDelivery.ResumeLayout(false);
            this.panButtons.ResumeLayout(false);
            this.panButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.WebBrowser wbResults;
        private System.Windows.Forms.Button btnSample81;
        private System.Windows.Forms.TabControl tabsInputs;
        private System.Windows.Forms.TabPage tabMinimumDelivery;
        private TransportProblemGridInput gridMinDelivery;
        private System.Windows.Forms.TabPage tabCosts;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Button btnGo;
        private TransportProblemGridInput gridCosts;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSample81_MinDel;
    }
}

