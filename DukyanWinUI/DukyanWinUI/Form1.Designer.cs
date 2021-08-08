
namespace DukyanWinUI
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
            this.lstView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtNeighborhood = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtAptNo = new System.Windows.Forms.TextBox();
            this.txtFlat = new System.Windows.Forms.TextBox();
            this.txtDistrcit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstView
            // 
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(12, 12);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(907, 663);
            this.lstView.TabIndex = 1;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ürün Fiyatı";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stok";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ürün Adı";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 600;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(989, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Çeşit ürün bulunmaktadır.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("PMingLiU-ExtB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(953, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 3;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(927, 216);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(117, 20);
            this.txtID.TabIndex = 4;
            this.txtID.Text = "Satın alınacak ürün ID";
            this.txtID.Click += new System.EventHandler(this.txtID_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(927, 242);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(117, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.Text = "Miktar";
            this.txtAmount.Click += new System.EventHandler(this.txtAmount_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(927, 615);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(331, 42);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.Text = "Siparişi Tamamla";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(997, 78);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(131, 64);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Listeyi Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(1048, 216);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(154, 121);
            this.lstBox.TabIndex = 8;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(927, 268);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(117, 69);
            this.btnAddOrder.TabIndex = 9;
            this.btnAddOrder.Text = "Siparişe ekle";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1045, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sipariş Listesi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1208, 216);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 121);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Sipariş Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(998, 373);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(204, 20);
            this.txtFullName.TabIndex = 12;
            this.txtFullName.Text = "İsim Soyisim";
            this.txtFullName.Click += new System.EventHandler(this.txtFullName_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(998, 399);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(204, 20);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.Text = "TelNo";
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Click);
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(998, 425);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(204, 20);
            this.txtCountry.TabIndex = 12;
            this.txtCountry.Text = "Ülke";
            this.txtCountry.Click += new System.EventHandler(this.txtCountry_Click);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(998, 451);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(204, 20);
            this.txtCity.TabIndex = 12;
            this.txtCity.Text = "Şehir";
            this.txtCity.Click += new System.EventHandler(this.txtCity_Click);
            // 
            // txtNeighborhood
            // 
            this.txtNeighborhood.Location = new System.Drawing.Point(998, 503);
            this.txtNeighborhood.Name = "txtNeighborhood";
            this.txtNeighborhood.Size = new System.Drawing.Size(204, 20);
            this.txtNeighborhood.TabIndex = 12;
            this.txtNeighborhood.Text = "Mahalle";
            this.txtNeighborhood.Click += new System.EventHandler(this.txtNeighborhood_Click);
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(998, 529);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(204, 20);
            this.txtStreet.TabIndex = 12;
            this.txtStreet.Text = "Sokak";
            this.txtStreet.Click += new System.EventHandler(this.txtStreet_Click);
            // 
            // txtAptNo
            // 
            this.txtAptNo.Location = new System.Drawing.Point(998, 555);
            this.txtAptNo.Name = "txtAptNo";
            this.txtAptNo.Size = new System.Drawing.Size(204, 20);
            this.txtAptNo.TabIndex = 12;
            this.txtAptNo.Text = "AptNo";
            this.txtAptNo.Click += new System.EventHandler(this.txtAptNo_Click);
            // 
            // txtFlat
            // 
            this.txtFlat.Location = new System.Drawing.Point(998, 581);
            this.txtFlat.Name = "txtFlat";
            this.txtFlat.Size = new System.Drawing.Size(204, 20);
            this.txtFlat.TabIndex = 12;
            this.txtFlat.Text = "KapıNo (Var ise)";
            this.txtFlat.Click += new System.EventHandler(this.txtFlat_Click);
            // 
            // txtDistrcit
            // 
            this.txtDistrcit.Location = new System.Drawing.Point(998, 477);
            this.txtDistrcit.Name = "txtDistrcit";
            this.txtDistrcit.Size = new System.Drawing.Size(204, 20);
            this.txtDistrcit.TabIndex = 12;
            this.txtDistrcit.Text = "İlçe";
            this.txtDistrcit.Click += new System.EventHandler(this.txtDistrcit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 687);
            this.Controls.Add(this.txtFlat);
            this.Controls.Add(this.txtAptNo);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtNeighborhood);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtDistrcit);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstView;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtNeighborhood;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtAptNo;
        private System.Windows.Forms.TextBox txtFlat;
        private System.Windows.Forms.TextBox txtDistrcit;
    }
}

