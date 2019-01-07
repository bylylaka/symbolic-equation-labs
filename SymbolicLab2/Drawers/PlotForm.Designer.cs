namespace SymbolicLab2.Drawers
{
    partial class PlotForm
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
            this.scottPlotUC1 = new ScottPlot.ScottPlotUC();
            this.SuspendLayout();
            // 
            // scottPlotUC1
            // 
            this.scottPlotUC1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.scottPlotUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scottPlotUC1.Location = new System.Drawing.Point(0, 0);
            this.scottPlotUC1.Margin = new System.Windows.Forms.Padding(2);
            this.scottPlotUC1.Name = "scottPlotUC1";
            this.scottPlotUC1.Size = new System.Drawing.Size(800, 450);
            this.scottPlotUC1.TabIndex = 0;
            this.scottPlotUC1.Load += new System.EventHandler(this.scottPlotUC1_Load);
            // 
            // PlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scottPlotUC1);
            this.Name = "PlotForm";
            this.Text = "Plot";
            this.Load += new System.EventHandler(this.PlotForm_Load);
            this.ResumeLayout(false);

        }


        public void DrawPlot(DrawerModel drawModel)
        {
            var x = drawModel.X.ToArray();
            var y = drawModel.Y.ToArray();

            scottPlotUC1.PlotXY(x, y);
            scottPlotUC1.AxisAuto();
        }

        #endregion

        private ScottPlot.ScottPlotUC scottPlotUC1;
    }
}