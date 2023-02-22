namespace Backend
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LastDeviceIdLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeviceListBox = new System.Windows.Forms.ListBox();
            this.MappingsListView = new System.Windows.Forms.ListView();
            this.LayoutListBox = new System.Windows.Forms.ListBox();
            this.AddMappingButton = new System.Windows.Forms.Button();
            this.DeleteMappingButton = new System.Windows.Forms.Button();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.StatusStrip.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LastDeviceIdLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 366);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(325, 22);
            this.StatusStrip.TabIndex = 7;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // LastDeviceIdLabel
            // 
            this.LastDeviceIdLabel.Name = "LastDeviceIdLabel";
            this.LastDeviceIdLabel.Size = new System.Drawing.Size(104, 17);
            this.LastDeviceIdLabel.Text = "Press any button...";
            // 
            // DeviceListBox
            // 
            this.DeviceListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceListBox.FormattingEnabled = true;
            this.DeviceListBox.ItemHeight = 15;
            this.DeviceListBox.Location = new System.Drawing.Point(3, 3);
            this.DeviceListBox.Name = "DeviceListBox";
            this.DeviceListBox.Size = new System.Drawing.Size(156, 129);
            this.DeviceListBox.TabIndex = 8;
            // 
            // MappingsListView
            // 
            this.MainLayout.SetColumnSpan(this.MappingsListView, 2);
            this.MappingsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingsListView.Location = new System.Drawing.Point(3, 164);
            this.MappingsListView.Name = "MappingsListView";
            this.MappingsListView.Size = new System.Drawing.Size(319, 199);
            this.MappingsListView.TabIndex = 9;
            this.MappingsListView.UseCompatibleStateImageBehavior = false;
            // 
            // LayoutListBox
            // 
            this.LayoutListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutListBox.FormattingEnabled = true;
            this.LayoutListBox.ItemHeight = 15;
            this.LayoutListBox.Location = new System.Drawing.Point(165, 3);
            this.LayoutListBox.Name = "LayoutListBox";
            this.LayoutListBox.Size = new System.Drawing.Size(157, 129);
            this.LayoutListBox.TabIndex = 10;
            // 
            // AddMappingButton
            // 
            this.AddMappingButton.AutoSize = true;
            this.AddMappingButton.Location = new System.Drawing.Point(3, 138);
            this.AddMappingButton.Name = "AddMappingButton";
            this.AddMappingButton.Size = new System.Drawing.Size(129, 20);
            this.AddMappingButton.TabIndex = 11;
            this.AddMappingButton.Text = "Add Layout Mapping";
            this.AddMappingButton.UseVisualStyleBackColor = true;
            this.AddMappingButton.Click += new System.EventHandler(this.AddMappingButton_Click);
            // 
            // DeleteMappingButton
            // 
            this.DeleteMappingButton.AutoSize = true;
            this.DeleteMappingButton.Location = new System.Drawing.Point(165, 138);
            this.DeleteMappingButton.Name = "DeleteMappingButton";
            this.DeleteMappingButton.Size = new System.Drawing.Size(140, 20);
            this.DeleteMappingButton.TabIndex = 12;
            this.DeleteMappingButton.Text = "Delete Layout Mapping";
            this.DeleteMappingButton.UseVisualStyleBackColor = true;
            this.DeleteMappingButton.Click += new System.EventHandler(this.DeleteMappingButton_Click);
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayout.Controls.Add(this.DeviceListBox, 0, 0);
            this.MainLayout.Controls.Add(this.MappingsListView, 0, 2);
            this.MainLayout.Controls.Add(this.DeleteMappingButton, 1, 1);
            this.MainLayout.Controls.Add(this.LayoutListBox, 1, 0);
            this.MainLayout.Controls.Add(this.AddMappingButton, 0, 1);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 3;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.48624F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.51376F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.MainLayout.Size = new System.Drawing.Size(325, 366);
            this.MainLayout.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 388);
            this.Controls.Add(this.MainLayout);
            this.Controls.Add(this.StatusStrip);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel LastDeviceIdLabel;
        private ListBox DeviceListBox;
        private ListView MappingsListView;
        private TableLayoutPanel MainLayout;
        private Button DeleteMappingButton;
        private ListBox LayoutListBox;
        private Button AddMappingButton;
    }
}