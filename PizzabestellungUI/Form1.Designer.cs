namespace PizzabestellungUI
{
    partial class Form1
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
            BestellListe = new ListView();
            Anzahl = new ColumnHeader();
            Pizza = new ColumnHeader();
            Groesse = new ColumnHeader();
            SuspendLayout();
            // 
            // BestellListe
            // 
            BestellListe.Columns.AddRange(new ColumnHeader[] { Anzahl, Pizza, Groesse });
            BestellListe.Location = new Point(12, 56);
            BestellListe.Name = "BestellListe";
            BestellListe.Size = new Size(526, 420);
            BestellListe.TabIndex = 0;
            BestellListe.UseCompatibleStateImageBehavior = false;
            BestellListe.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Anzahl
            // 
            Anzahl.Text = "Anzahl";
            // 
            // Pizza
            // 
            Pizza.Text = "Pizza";
            // 
            // Groesse
            // 
            Groesse.Text = "Größe";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 695);
            Controls.Add(BestellListe);
            Name = "Form1";
            Text = "Pizzabestellung";
            ResumeLayout(false);
        }

        #endregion

        private ListView BestellListe;
        private ColumnHeader Pizza;
        private ColumnHeader Groesse;
        private ColumnHeader Anzahl;
    }
}
