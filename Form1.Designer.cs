
namespace WidjetSobaka
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.нужнаПомощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОКомпьютереToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нужнаПомощьToolStripMenuItem,
            this.информацияОКомпьютереToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 104);
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            // 
            // нужнаПомощьToolStripMenuItem
            // 
            this.нужнаПомощьToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.нужнаПомощьToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.нужнаПомощьToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.нужнаПомощьToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.нужнаПомощьToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.нужнаПомощьToolStripMenuItem.Name = "нужнаПомощьToolStripMenuItem";
            this.нужнаПомощьToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.нужнаПомощьToolStripMenuItem.Text = "Нужна помощь";
            this.нужнаПомощьToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.нужнаПомощьToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // информацияОКомпьютереToolStripMenuItem
            // 
            this.информацияОКомпьютереToolStripMenuItem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.информацияОКомпьютереToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.информацияОКомпьютереToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.информацияОКомпьютереToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.информацияОКомпьютереToolStripMenuItem.Name = "информацияОКомпьютереToolStripMenuItem";
            this.информацияОКомпьютереToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.информацияОКомпьютереToolStripMenuItem.Text = "Информация о компьютере";
            this.информацияОКомпьютереToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.информацияОКомпьютереToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 24);
            this.toolStripMenuItem1.Text = "Настройки";
            this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::WidjetSobaka.Properties.Resources.LM_00_00_02_28_Still001_removebg_preview_export;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(128, 128);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem нужнаПомощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияОКомпьютереToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

