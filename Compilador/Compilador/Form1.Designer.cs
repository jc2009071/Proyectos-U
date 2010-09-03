namespace Compilador
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.Abrir = new System.Windows.Forms.Button();
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Guardar = new System.Windows.Forms.Button();
            this.Compilar = new System.Windows.Forms.Button();
            this.Nuevo = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // Abrir
            // 
            this.Abrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Abrir.Image = ((System.Drawing.Image)(resources.GetObject("Abrir.Image")));
            this.Abrir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Abrir.Location = new System.Drawing.Point(151, 29);
            this.Abrir.Name = "Abrir";
            this.Abrir.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.Abrir.Size = new System.Drawing.Size(95, 75);
            this.Abrir.TabIndex = 0;
            this.Abrir.Text = "Abrir";
            this.Abrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Abrir.UseVisualStyleBackColor = true;
            this.Abrir.Click += new System.EventHandler(this.Abrir_Click);
            // 
            // TextArea
            // 
            this.TextArea.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextArea.Location = new System.Drawing.Point(25, 150);
            this.TextArea.MaximumSize = new System.Drawing.Size(820, 380);
            this.TextArea.Name = "TextArea";
            this.TextArea.Size = new System.Drawing.Size(545, 380);
            this.TextArea.TabIndex = 2;
            this.TextArea.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 542);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // Guardar
            // 
            this.Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Guardar.Image")));
            this.Guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Guardar.Location = new System.Drawing.Point(252, 29);
            this.Guardar.Name = "Guardar";
            this.Guardar.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.Guardar.Size = new System.Drawing.Size(95, 75);
            this.Guardar.TabIndex = 4;
            this.Guardar.Text = "Guardar";
            this.Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // Compilar
            // 
            this.Compilar.Cursor = System.Windows.Forms.Cursors.No;
            this.Compilar.Image = ((System.Drawing.Image)(resources.GetObject("Compilar.Image")));
            this.Compilar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Compilar.Location = new System.Drawing.Point(353, 29);
            this.Compilar.Name = "Compilar";
            this.Compilar.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.Compilar.Size = new System.Drawing.Size(95, 75);
            this.Compilar.TabIndex = 5;
            this.Compilar.Text = "Compilar";
            this.Compilar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Compilar.UseVisualStyleBackColor = true;
            this.Compilar.Click += new System.EventHandler(this.Compilar_Click);
            // 
            // Nuevo
            // 
            this.Nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("Nuevo.Image")));
            this.Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Nuevo.Location = new System.Drawing.Point(50, 29);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.Nuevo.Size = new System.Drawing.Size(95, 75);
            this.Nuevo.TabIndex = 6;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(612, 150);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(310, 380);
            this.treeView1.TabIndex = 7;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(934, 542);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.Compilar);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.Abrir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(950, 580);
            this.MinimumSize = new System.Drawing.Size(560, 300);
            this.Name = "GUI";
            this.Text = "nuevo(1) | Compilador WiikDS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Abrir;
        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button Compilar;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.TreeView treeView1;

    }
}

