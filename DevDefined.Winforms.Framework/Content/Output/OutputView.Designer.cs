﻿namespace DevDefined.Winforms.Framework.Content.Output
{
    partial class OutputView : IOutputView
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
            this.SuspendLayout();
            // 
            // OutputView
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "OutputView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "Output";
            this.Text = "Output";
            this.ResumeLayout(false);

        }

        #endregion
    }
}