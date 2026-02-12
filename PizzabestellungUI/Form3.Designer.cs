namespace PizzabestellungUI
{
    partial class Form3
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
            Bestellungen = new ListView();
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // Bestellungen
            // 
            Bestellungen.Location = new Point(34, 97);
            Bestellungen.MultiSelect = false;
            Bestellungen.Name = "Bestellungen";
            Bestellungen.Size = new Size(280, 338);
            Bestellungen.TabIndex = 3;
            Bestellungen.UseCompatibleStateImageBehavior = false;
            Bestellungen.View = View.Details;
            Bestellungen.SelectedIndexChanged += Bestellungen_SelectedIndexChanged;
            // 
            // listView1
            // 
            listView1.Location = new Point(474, 97);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(280, 338);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 69);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 5;
            label1.Text = "Deine Best";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(474, 69);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 6;
            label2.Text = "Deine Best";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 21);
            label3.Name = "label3";
            label3.Size = new Size(143, 25);
            label3.TabIndex = 7;
            label3.Text = "Kundennummer:";
            // 
            // button1
            // 
            button1.Location = new Point(378, 12);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(183, 19);
            numericUpDown1.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 31);
            numericUpDown1.TabIndex = 10;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(Bestellungen);
            Name = "Form3";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView Bestellungen;
        private ListView listView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private NumericUpDown numericUpDown1;
    }
}