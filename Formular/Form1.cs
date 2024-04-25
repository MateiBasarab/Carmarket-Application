using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using ClassCar;

using DataStorageLevel;
using CarMarket;

namespace Formular
{
    public partial class Form1 : Form
    {
        CarAdministration_FileText carAdmin;

        private int ID = 0;

        private Label Testlbl;

        private Label lblBrand;
        private Label lblModel;
        private Label lblManufacturing_Year;
        private Label lblColor;
        private Label lblPrice;
        private Label lblOptions;

        private Label lblBrandForTextBox;
        private Label lblModelForTextBox;
        private Label lblManufacturing_YearForTextbox;
        private Label lblColorForTextbox;
        private Label lblPriceForTextbox;
        private Label lblOptionsForTextbox;
        

        private TextBox txtBrand;
        private TextBox txtModel;
        private TextBox txtManufacturing_Year;
        private TextBox txtColor;
        private TextBox txtPrice;
        private TextBox txtOptions;

        private Button btnAdd;
        private Button btnRefresh;

        private Label[] lblsBrand;
        private Label[] lblsModel;
        private Label[] lblsManufacturing_Year;
        private Label[] lblsColor;
        private Label[] lblsPrice;
        private Label[] lblsOptions;

        private const char SEPARATOR = ',';
        private const int MAX_CHARACTER = 15;
        private const int WIDTH_CONTROL = 150;
        private const int yStep = 30;
        private const int xStep = 180;
        public Form1()
        {
            InitializeComponent();
            //For some unknown reason , the text file is still being created in Formular\bin\Debug\{Storage.txt}
            string fileName = ConfigurationManager.AppSettings["fileName"];
            //string fileName = "Storage.txt";
            string solutionFileLocation = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string completeFilePath = solutionFileLocation + "\\" + fileName;
            carAdmin =  new CarAdministration_FileText(completeFilePath);
            int noCars = 0; //number of cars

            Car[] cars = carAdmin.GetCars(out noCars);



            this.Size = new Size(1900, 350);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0,200);
            this.Font = new Font("Times New Roman", 11, FontStyle.Bold);
            this.ForeColor = Color.DodgerBlue;
            this.Text = "Cars Info";

            lblBrand = new Label();
            lblBrand.Width = WIDTH_CONTROL;
            lblBrand.Text = "Brand";
            lblBrand.Left = 0 * xStep;
            lblBrand.Top = yStep;
            lblBrand.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblBrand);

            lblModel = new Label();
            lblModel.Width = WIDTH_CONTROL;
            lblModel.Text = "Model";
            lblModel.Left = xStep * 1;
            lblModel.Top = yStep;
            lblModel.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblModel);

            lblManufacturing_Year = new Label();
            lblManufacturing_Year.Width = WIDTH_CONTROL;
            lblManufacturing_Year.Text = "Manufacturing Year";
            lblManufacturing_Year.Left = xStep * 2;
            lblManufacturing_Year.Top = yStep;
            lblManufacturing_Year.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblManufacturing_Year);

            lblColor = new Label();
            lblColor.Width = WIDTH_CONTROL;
            lblColor.Text = "Color";
            lblColor.Left = xStep * 3;
            lblColor.Top = yStep;
            lblColor.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblColor);

            lblPrice = new Label();
            lblPrice.Width = WIDTH_CONTROL;
            lblPrice.Text = "Price";
            lblPrice.Left = xStep * 4;
            lblPrice.Top = yStep;
            lblPrice.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblPrice);

            lblOptions = new Label();
            lblOptions.Width = WIDTH_CONTROL;
            lblOptions.Text = "Options";
            lblOptions.Left = xStep * 5;
            lblOptions.Top = yStep;
            lblOptions.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblOptions);

            //Add data    ---------------------------------------------------------------
            lblBrandForTextBox = new Label();
            lblBrandForTextBox.Width = WIDTH_CONTROL;
            lblBrandForTextBox.Text = "Brand";
            lblBrandForTextBox.Left = 6 * xStep;
            lblBrandForTextBox.Top = yStep;
            lblBrandForTextBox.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblBrandForTextBox);

            lblModelForTextBox = new Label();
            lblModelForTextBox.Width = WIDTH_CONTROL;
            lblModelForTextBox.Text = "Model";
            lblModelForTextBox.Left = xStep * 6;
            lblModelForTextBox.Top = yStep * 2;
            lblModelForTextBox.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblModelForTextBox);

            lblManufacturing_YearForTextbox = new Label();
            lblManufacturing_YearForTextbox.Width = WIDTH_CONTROL;
            lblManufacturing_YearForTextbox.Text = "Manufacturing Year";
            lblManufacturing_YearForTextbox.Left = xStep * 6;
            lblManufacturing_YearForTextbox.Top = yStep * 3;
            lblManufacturing_YearForTextbox.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblManufacturing_YearForTextbox);

            lblColorForTextbox = new Label();
            lblColorForTextbox.Width = WIDTH_CONTROL;
            lblColorForTextbox.Text = "Color";
            lblColorForTextbox.Left = xStep * 6;
            lblColorForTextbox.Top = yStep * 4;
            lblColorForTextbox.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblColorForTextbox);

            lblPriceForTextbox = new Label();
            lblPriceForTextbox.Width = WIDTH_CONTROL;
            lblPriceForTextbox.Text = "Price";
            lblPriceForTextbox.Left = xStep * 6;
            lblPriceForTextbox.Top = yStep * 5;
            lblPriceForTextbox.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblPriceForTextbox);

            lblOptionsForTextbox = new Label();
            lblOptionsForTextbox.Width = WIDTH_CONTROL;
            lblOptionsForTextbox.Text = "Options";
            lblOptionsForTextbox.Left = xStep * 6;
            lblOptionsForTextbox.Top = yStep * 6;
            lblOptionsForTextbox.ForeColor = Color.DodgerBlue;
            this.Controls.Add(lblOptionsForTextbox);

            //textboxes --------------------------------------------
            txtBrand = new TextBox();
            txtBrand.Width = WIDTH_CONTROL;
            txtBrand.Left = xStep * 7;
            txtBrand.Top = yStep * 1;
            this.Controls.Add(txtBrand);

            txtModel = new TextBox();
            txtModel.Width = WIDTH_CONTROL;
            txtModel.Left = xStep * 7;
            txtModel.Top = yStep * 2;
            this.Controls.Add(txtModel);

            txtManufacturing_Year = new TextBox();
            txtManufacturing_Year.Width = WIDTH_CONTROL;
            txtManufacturing_Year.Left = xStep * 7;
            txtManufacturing_Year.Top = yStep * 3;
            this.Controls.Add(txtManufacturing_Year);

            txtColor = new TextBox();
            txtColor.Width = WIDTH_CONTROL;
            txtColor.Left = xStep * 7;
            txtColor.Top = yStep * 4;
            this.Controls.Add(txtColor);

            txtPrice = new TextBox();
            txtPrice.Width = WIDTH_CONTROL;
            txtPrice.Left = xStep * 7;
            txtPrice.Top = yStep * 5;
            this.Controls.Add(txtPrice);

            txtOptions = new TextBox();
            txtOptions.Width = WIDTH_CONTROL;
            txtOptions.Left = xStep * 7;
            txtOptions.Top = yStep * 6;
            this.Controls.Add(txtOptions);

            //button ---------------------------
            btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Width = WIDTH_CONTROL;
            btnAdd.Left = xStep * 7;
            btnAdd.Top = yStep * 7;
            btnAdd.Click += new EventHandler(Add_Click);
            this.Controls.Add(btnAdd);

            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Width = WIDTH_CONTROL;
            btnRefresh.Left = xStep * 7;
            btnRefresh.Top = yStep * 8;
            btnRefresh.Click += new EventHandler(Refresh_Click);
            this.Controls.Add(btnRefresh);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            DisplayCars();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string[] aOptions;
            int failCounter = 0;
            int aManufacturing_Year; //manufacturing year
            int aPrice; //price
            Car car = new Car();

            if(txtBrand.Text == "" || txtBrand.Text.Length > MAX_CHARACTER)
            {
                failCounter++;
                lblBrandForTextBox.ForeColor = Color.Red;
            }
            else
            {
                lblBrandForTextBox.ForeColor = Color.DodgerBlue;
            }

            if (txtModel.Text == "" || txtModel.Text.Length > MAX_CHARACTER)
            {
                failCounter++;
                lblModelForTextBox.ForeColor = Color.Red;
            }
            else
            {
                lblModelForTextBox.ForeColor = Color.DodgerBlue;
            }

            if(txtColor.Text == "" || txtColor.Text.Length > MAX_CHARACTER)
            {
                failCounter++;
                lblColorForTextbox.ForeColor = Color.Red;
            }
            else
            {
                lblColorForTextbox.ForeColor = Color.DodgerBlue;
            }

            if(txtOptions.Text == "")
            {
                failCounter++;
                lblOptionsForTextbox.ForeColor = Color.Red;
            }
            else
            {
                lblOptionsForTextbox.ForeColor = Color.DodgerBlue;
            }

            if (int.TryParse(txtManufacturing_Year.Text, out aManufacturing_Year))
            {
                lblManufacturing_YearForTextbox.ForeColor = Color.DodgerBlue;
            }
            else
            {
                failCounter++;
                lblManufacturing_YearForTextbox.ForeColor = Color.Red;
            }
            car.color = txtColor.Text;
            if(int.TryParse(txtPrice.Text, out aPrice))
            {
                lblPriceForTextbox.ForeColor = Color.DodgerBlue;
            }
            else 
            {
                failCounter++;
                lblPriceForTextbox.ForeColor= Color.Red;
            }

            aOptions = txtOptions.Text.Split(SEPARATOR);

            if (failCounter == 0)
            {
                car.SetCar(ID++, txtBrand.Text, txtModel.Text, aManufacturing_Year, txtColor.Text, aOptions, aPrice);
                carAdmin.AddCarInFile(car);

                txtBrand.Text = "";
                txtModel.Text = "";
                txtManufacturing_Year.Text = "";
                txtColor.Text = "";
                txtOptions.Text = "";
                txtPrice.Text = "";
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayCars();
        }


        private void DisplayCars()
        {
            
            string fileName = ConfigurationManager.AppSettings["fileName"];
            carAdmin = new CarAdministration_FileText(fileName);
            int noCars = 0;

            Car[] Cars = carAdmin.GetCars(out noCars);
            int i = 0;

            
            lblsBrand               = new Label[noCars];
            lblsModel               = new Label[noCars];
            lblsManufacturing_Year  = new Label[noCars];
            lblsColor               = new Label[noCars];
            lblsPrice               = new Label[noCars];
            lblsOptions             = new Label[noCars];

           
            foreach (Car car in Cars)
            {
                lblsBrand[i] = new Label
                {
                    Width = WIDTH_CONTROL,
                    Text = car.GetBrand(),
                    Left = 0 * xStep,
                    Top = (i + 3) * yStep,
                    ForeColor = Color.DodgerBlue
                };
                this.Controls.Add(lblsBrand[i]);

                lblsModel[i] = new Label();
                lblsModel[i].Width = WIDTH_CONTROL;
                lblsModel[i].Text = car.model;
                lblsModel[i].Left = xStep * 1;
                lblsModel[i].Top = (i + 3) * yStep;
                this.Controls.Add(lblsModel[i]);

                lblsManufacturing_Year[i] = new Label();
                lblsManufacturing_Year[i].Width = WIDTH_CONTROL;
                lblsManufacturing_Year[i].Text = Convert.ToString(car.manufacturing_year);
                lblsManufacturing_Year[i].Left = xStep * 2;
                lblsManufacturing_Year[i].Top = (i + 3) * yStep;
                this.Controls.Add(lblsManufacturing_Year[i]);

                lblsColor[i] = new Label();
                lblsColor[i].Width = WIDTH_CONTROL;
                lblsColor[i].Text = car.color;
                lblsColor[i].Left = xStep * 3;
                lblsColor[i].Top = (i + 3) * yStep;
                this.Controls.Add(lblsColor[i]);

                lblsPrice[i] = new Label();
                lblsPrice[i].Width = WIDTH_CONTROL;
                lblsPrice[i].Text = Convert.ToString(car.price);
                lblsPrice[i].Left = xStep * 4;
                lblsPrice[i].Top = (i + 3) * yStep;
                this.Controls.Add(lblsPrice[i]);

                lblsOptions[i] = new Label();
                lblsOptions[i].Width = WIDTH_CONTROL;
                lblsOptions[i].Text = car.GetOptionsAsString();
                lblsOptions[i].Left = xStep * 5;
                lblsOptions[i].Top = (i + 3) * yStep;
                this.Controls.Add(lblsOptions[i]);

                i++;
            } 
        }
        
    }
}
