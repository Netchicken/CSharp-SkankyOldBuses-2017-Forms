using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_SkankyOldBusses2017
{
    public partial class Form1 : Form
    {
        private Single Ash , Tim, Om, Dun, Inv , Discount ;
        private string FName, LName;
        private int Age,  lowerAgeDiscount, UpperAgeDiscount;
        private bool IsDisabled, isWeekend ;


        // Discounted gets a discount on weekend of 25%
        //everyone else gets weekend discount of 25%
        #region Weekend Calculations
        private void chkIsWeekend_CheckedChanged(object sender, EventArgs e)
        {
            bool IsWeekend = false;
            if (chkIsWeekend.Checked == true)
            {
                //gets the discount price
                IsWeekend = true;
                Discount = Convert.ToSingle(txtWeekendDicount.Text);
            }
            else
            {//gets the full price
                Discount = Convert.ToSingle(txtDiscount.Text);
            }
            DiscountVisibility(IsWeekend);
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
           
            
        }
        private void btnGo_Click(object sender, EventArgs e)
        { 
                  PassToVariables();
        
             CalculateDiscount();
        }

        



        private void CalculateDiscount()
        { // if person is disabled, or <12 or >64 gets discount 20%
          //calculate criteria for discount price

            //  this is the weekend
            //if (chkIsWeekend.Checked == true)
            //{
            //    Discount = Convert.ToSingle(txtWeekendDicount.Text);
            //}

            if (IsDisabled == true || Age <= lowerAgeDiscount || Age >= UpperAgeDiscount)
            {
                Ash = DiscountFormula(Ash, Discount);
                Tim = DiscountFormula(Tim, Discount);
                Om = DiscountFormula(Om, Discount);
                Dun = DiscountFormula(Dun, Discount);
                Inv = DiscountFormula(Inv, Discount);
            }
            // calculate full fare
            // Display output
            lbxOutput.Items.Add(FName + " " + LName + " Ash=" + Ash + " Tim=" + Tim + " Om=" + Om + " Dun=" + Dun + " Inv=" + Inv);
        }

        public Single DiscountFormula(Single City, Single Discount)
        {

            Single answer = City - (City * Discount);
            return (float) Math.Round(answer, 2);
        }



        //I made this with an underscore _ISWeekEnd to seperate it from teh nasty global Variable of IsWeekEnd. The Underscore is a sign that its a private variable.
        private void DiscountVisibility(bool _IsWeekEnd)
        {
            if (_IsWeekEnd)
            {
                txtWeekendDicount.Visible = true;
                txtDiscount.Visible = false;
            }
            else
            {
                txtWeekendDicount.Visible = false;
                txtDiscount.Visible = true;
            }
        }
        //DRY = Don't Repeat Yourself 




        //Pass all the textboxes to variables
        private void PassToVariables()
        {
            FName = txtFName.Text;
            LName = txtLName.Text;
            Ash = Convert.ToSingle(txtAsh.Text);
            Tim = Convert.ToSingle(txtTim.Text);
            Om = Convert.ToSingle(txtOm.Text);
            Dun = Convert.ToSingle(txtDun.Text);
            Inv = Convert.ToSingle(txtInv.Text);

            Age = Convert.ToInt16(txtAge.Text);
            IsDisabled = chkIsDisabled.Checked;
            Discount = Convert.ToSingle(txtDiscount.Text);
            lowerAgeDiscount = Convert.ToInt32(txtLowerAgeDiscount.Text);
            UpperAgeDiscount = Convert.ToInt32(txtUpperAgeDiscount.Text);
            //IsWeekend = chkIsWeekend.Checked;
        }
    }
}
