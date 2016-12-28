namespace DegarashiShop
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.cartListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MyricaM M", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品一覧";
            // 
            // purchaseButton
            // 
            this.purchaseButton.Font = new System.Drawing.Font("MyricaM M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.purchaseButton.Location = new System.Drawing.Point(660, 294);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(178, 44);
            this.purchaseButton.TabIndex = 2;
            this.purchaseButton.Text = "購入";
            this.purchaseButton.UseVisualStyleBackColor = true;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click);
            // 
            // itemListBox
            // 
            this.itemListBox.Font = new System.Drawing.Font("MyricaM M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.ItemHeight = 16;
            this.itemListBox.Location = new System.Drawing.Point(12, 32);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(404, 260);
            this.itemListBox.TabIndex = 3;
            // 
            // addToCartButton
            // 
            this.addToCartButton.Font = new System.Drawing.Font("MyricaM M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addToCartButton.Location = new System.Drawing.Point(238, 294);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(178, 44);
            this.addToCartButton.TabIndex = 4;
            this.addToCartButton.Text = "カートに入れる";
            this.addToCartButton.UseVisualStyleBackColor = true;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click);
            // 
            // cartListBox
            // 
            this.cartListBox.Font = new System.Drawing.Font("MyricaM M", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cartListBox.FormattingEnabled = true;
            this.cartListBox.ItemHeight = 16;
            this.cartListBox.Location = new System.Drawing.Point(434, 32);
            this.cartListBox.Name = "cartListBox";
            this.cartListBox.Size = new System.Drawing.Size(404, 260);
            this.cartListBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MyricaM M", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(430, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "カート";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cartListBox);
            this.Controls.Add(this.addToCartButton);
            this.Controls.Add(this.itemListBox);
            this.Controls.Add(this.purchaseButton);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "でがらし商会";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.ListBox itemListBox;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.ListBox cartListBox;
        private System.Windows.Forms.Label label2;
    }
}

