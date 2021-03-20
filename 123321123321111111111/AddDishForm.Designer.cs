namespace _123321123321111111111
{
    partial class AddDishForm
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
            this.desc_txtb = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.desc_lbl = new System.Windows.Forms.Label();
            this.meal_combox = new System.Windows.Forms.ComboBox();
            this.meal_lbl = new System.Windows.Forms.Label();
            this.dish_txtb = new System.Windows.Forms.TextBox();
            this.dish_lbl = new System.Windows.Forms.Label();
            this.prot_lbl = new System.Windows.Forms.Label();
            this.prot__txtb = new System.Windows.Forms.TextBox();
            this.carb_txtb = new System.Windows.Forms.TextBox();
            this.carb_lbl = new System.Windows.Forms.Label();
            this.cal_txtb = new System.Windows.Forms.TextBox();
            this.cal_lbl = new System.Windows.Forms.Label();
            this.fat_txtb = new System.Windows.Forms.TextBox();
            this.fat_lbl = new System.Windows.Forms.Label();
            this.gram_lbl = new System.Windows.Forms.Label();
            this.gram_txtb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // desc_txtb
            // 
            this.desc_txtb.Location = new System.Drawing.Point(15, 184);
            this.desc_txtb.Multiline = true;
            this.desc_txtb.Name = "desc_txtb";
            this.desc_txtb.Size = new System.Drawing.Size(332, 112);
            this.desc_txtb.TabIndex = 0;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(240, 302);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(107, 31);
            this.save_btn.TabIndex = 1;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(15, 302);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(107, 31);
            this.back_btn.TabIndex = 2;
            this.back_btn.Text = "Назад";
            this.back_btn.UseVisualStyleBackColor = true;
            // 
            // desc_lbl
            // 
            this.desc_lbl.AutoSize = true;
            this.desc_lbl.Location = new System.Drawing.Point(12, 168);
            this.desc_lbl.Name = "desc_lbl";
            this.desc_lbl.Size = new System.Drawing.Size(57, 13);
            this.desc_lbl.TabIndex = 3;
            this.desc_lbl.Text = "Описание";
            // 
            // meal_combox
            // 
            this.meal_combox.FormattingEnabled = true;
            this.meal_combox.Items.AddRange(new object[] {
            "Завтрак",
            "Обед",
            "Полдник"});
            this.meal_combox.Location = new System.Drawing.Point(181, 144);
            this.meal_combox.Name = "meal_combox";
            this.meal_combox.Size = new System.Drawing.Size(166, 21);
            this.meal_combox.TabIndex = 4;
            // 
            // meal_lbl
            // 
            this.meal_lbl.AutoSize = true;
            this.meal_lbl.Location = new System.Drawing.Point(178, 128);
            this.meal_lbl.Name = "meal_lbl";
            this.meal_lbl.Size = new System.Drawing.Size(81, 13);
            this.meal_lbl.TabIndex = 5;
            this.meal_lbl.Text = "Время приема";
            // 
            // dish_txtb
            // 
            this.dish_txtb.Location = new System.Drawing.Point(15, 25);
            this.dish_txtb.Name = "dish_txtb";
            this.dish_txtb.Size = new System.Drawing.Size(332, 20);
            this.dish_txtb.TabIndex = 6;
            // 
            // dish_lbl
            // 
            this.dish_lbl.AutoSize = true;
            this.dish_lbl.Location = new System.Drawing.Point(12, 9);
            this.dish_lbl.Name = "dish_lbl";
            this.dish_lbl.Size = new System.Drawing.Size(118, 13);
            this.dish_lbl.TabIndex = 7;
            this.dish_lbl.Text = "Наименование блюда";
            // 
            // prot_lbl
            // 
            this.prot_lbl.AutoSize = true;
            this.prot_lbl.Location = new System.Drawing.Point(12, 48);
            this.prot_lbl.Name = "prot_lbl";
            this.prot_lbl.Size = new System.Drawing.Size(105, 13);
            this.prot_lbl.TabIndex = 8;
            this.prot_lbl.Text = "Количество белков";
            // 
            // prot__txtb
            // 
            this.prot__txtb.Location = new System.Drawing.Point(15, 64);
            this.prot__txtb.Name = "prot__txtb";
            this.prot__txtb.Size = new System.Drawing.Size(160, 20);
            this.prot__txtb.TabIndex = 9;
            // 
            // carb_txtb
            // 
            this.carb_txtb.Location = new System.Drawing.Point(15, 145);
            this.carb_txtb.Name = "carb_txtb";
            this.carb_txtb.Size = new System.Drawing.Size(160, 20);
            this.carb_txtb.TabIndex = 11;
            // 
            // carb_lbl
            // 
            this.carb_lbl.AutoSize = true;
            this.carb_lbl.Location = new System.Drawing.Point(12, 129);
            this.carb_lbl.Name = "carb_lbl";
            this.carb_lbl.Size = new System.Drawing.Size(127, 13);
            this.carb_lbl.TabIndex = 10;
            this.carb_lbl.Text = "Количество углевовдов";
            // 
            // cal_txtb
            // 
            this.cal_txtb.Location = new System.Drawing.Point(181, 64);
            this.cal_txtb.Name = "cal_txtb";
            this.cal_txtb.Size = new System.Drawing.Size(166, 20);
            this.cal_txtb.TabIndex = 13;
            // 
            // cal_lbl
            // 
            this.cal_lbl.AutoSize = true;
            this.cal_lbl.Location = new System.Drawing.Point(181, 48);
            this.cal_lbl.Name = "cal_lbl";
            this.cal_lbl.Size = new System.Drawing.Size(93, 13);
            this.cal_lbl.TabIndex = 12;
            this.cal_lbl.Text = "Количество ккал";
            // 
            // fat_txtb
            // 
            this.fat_txtb.Location = new System.Drawing.Point(15, 103);
            this.fat_txtb.Name = "fat_txtb";
            this.fat_txtb.Size = new System.Drawing.Size(160, 20);
            this.fat_txtb.TabIndex = 15;
            // 
            // fat_lbl
            // 
            this.fat_lbl.AutoSize = true;
            this.fat_lbl.Location = new System.Drawing.Point(12, 87);
            this.fat_lbl.Name = "fat_lbl";
            this.fat_lbl.Size = new System.Drawing.Size(101, 13);
            this.fat_lbl.TabIndex = 14;
            this.fat_lbl.Text = "Количество жиров";
            // 
            // gram_lbl
            // 
            this.gram_lbl.AutoSize = true;
            this.gram_lbl.Location = new System.Drawing.Point(178, 89);
            this.gram_lbl.Name = "gram_lbl";
            this.gram_lbl.Size = new System.Drawing.Size(100, 13);
            this.gram_lbl.TabIndex = 17;
            this.gram_lbl.Text = "Граммовка блюда";
            // 
            // gram_txtb
            // 
            this.gram_txtb.Location = new System.Drawing.Point(181, 105);
            this.gram_txtb.Name = "gram_txtb";
            this.gram_txtb.Size = new System.Drawing.Size(166, 20);
            this.gram_txtb.TabIndex = 16;
            // 
            // AddDishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 344);
            this.Controls.Add(this.gram_lbl);
            this.Controls.Add(this.gram_txtb);
            this.Controls.Add(this.fat_txtb);
            this.Controls.Add(this.fat_lbl);
            this.Controls.Add(this.cal_txtb);
            this.Controls.Add(this.cal_lbl);
            this.Controls.Add(this.carb_txtb);
            this.Controls.Add(this.carb_lbl);
            this.Controls.Add(this.prot__txtb);
            this.Controls.Add(this.prot_lbl);
            this.Controls.Add(this.dish_lbl);
            this.Controls.Add(this.dish_txtb);
            this.Controls.Add(this.meal_lbl);
            this.Controls.Add(this.meal_combox);
            this.Controls.Add(this.desc_lbl);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.desc_txtb);
            this.Name = "AddDishForm";
            this.Text = "Добавление блюда";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox desc_txtb;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Label desc_lbl;
        private System.Windows.Forms.ComboBox meal_combox;
        private System.Windows.Forms.Label meal_lbl;
        private System.Windows.Forms.TextBox dish_txtb;
        private System.Windows.Forms.Label dish_lbl;
        private System.Windows.Forms.Label prot_lbl;
        private System.Windows.Forms.TextBox prot__txtb;
        private System.Windows.Forms.TextBox carb_txtb;
        private System.Windows.Forms.Label carb_lbl;
        private System.Windows.Forms.TextBox cal_txtb;
        private System.Windows.Forms.Label cal_lbl;
        private System.Windows.Forms.TextBox fat_txtb;
        private System.Windows.Forms.Label fat_lbl;
        private System.Windows.Forms.Label gram_lbl;
        private System.Windows.Forms.TextBox gram_txtb;
    }
}