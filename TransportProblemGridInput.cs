using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1Transportation
{
    public partial class TransportProblemGridInput : UserControl
    {
        //Initializers
        public TransportProblemGridInput()
        {
            InitializeComponent();
        }

        //Properties
        public double[] Supply
        {
            get
            {
                //Blank array
                double[] supply = new double[4];

                //Load from GUI
                double sum = 0;
                try
                { 
                    for (int s = 0; s < 4; s++)
                    {
                        //Get text box
                        string tbName = "tbS" + s;
                        TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];

                        //Check if empty box
                        string t = tb.Text;
                        if (t == "") { t = "0"; }

                        //Convert number
                        supply[s] = Convert.ToDouble(t);
                        sum += supply[s];

                    }
                }
                catch (Exception e) { throw new ArgumentException("Only numeric values are allowed. " + e.Message); }

                //Check for empty
                if (sum == 0)
                    return null;

                //Return results
                return supply;
            }
            set
            {
                //Check length
                if (value != null)
                if (value.Length != 4)
                    throw new Exception("The array length must be 4.");

                //Show on controls
                for (int s = 0; s < 4; s++)
                {
                    string tbName = "tbS" + s;
                    TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];
                    string newValue = "";
                    if (value != null) { newValue = value[s].ToString(); }
                    tb.Text = newValue;
                }
            }
        }
        public double[] Demand
        {
            get
            {
                //Blank array
                double[] demand = new double[5];

                //Load from GUI
                double sum = 0;
                try
                {
                    for (int d = 0; d < 5; d++)
                    {
                        //Get text box
                        string tbName = "tbD" + d;
                        TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];

                        //Check if empty box
                        string t = tb.Text;
                        if (t == "") { t = "0"; }

                        //Convert to number
                        demand[d] = Convert.ToDouble(t);
                        sum += demand[d];
                    }
                }
                catch { throw new ArgumentException("Only numeric values are allowed."); }

                //Check for empty
                if (sum == 0)
                    return null;

                //Return results
                return demand;
            }
            set
            {
                //Check length
                if (value != null)
                if (value.Length != 5)
                    throw new Exception("The array length must be 5.");

                //Show on controls
                for (int d = 0; d < 5; d++)
                {
                    string tbName = "tbD" + d;
                    TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];
                    string newValue = "";
                    if (value != null) { newValue = value[d].ToString(); }
                    tb.Text = newValue;
                }
            }  
        }
        public double[,] Grid
        {
            get
            {
                //Empty array
                double[,] grid = new double[4, 5];

                //Load from GUI
                double sum = 0;
                try
                {              
                    for (int r = 0; r < 4; r++)
                    for (int c = 0; c < 5; c++)
                    {
                        //Get text box
                        string tbName = "tb" + r + c;
                        TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];

                        //Check if empty box
                        string t = tb.Text;
                        if (t == "") { t = "0"; }

                        //Convert text to number
                        grid[r,c] = Convert.ToDouble(t);
                        sum += grid[r, c];
                    }
                }
                catch { throw new ArgumentException("Only numeric values are allowed."); }

                //Check for empty
                if (sum == 0)
                    return null;

                //Return
                return grid;
            }
            set
            {
                //Check Length
                if (value != null)
                if ((value.GetLength(0) != 4) || (value.GetLength(1) != 5))
                throw new ArgumentException("The array size must be 4 row and 5 columns.");

                //Show on controls
                for (int r = 0; r < 4; r++)
                for (int c = 0; c < 5; c++)
                {
                    string tbName = "tb" + r + c;
                    TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];
                    string newValue = "";
                    if (value != null) { newValue = value[r, c].ToString(); }
                    tb.Text = newValue;
                }
            }
        }
        public bool ShowSupply
        {
            get
            {
                if (panInputs.ColumnStyles[6].Width > 0)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    panInputs.ColumnStyles[6].Width = 15;
                else
                    panInputs.ColumnStyles[6].Width = 0;
            }
        }
        public bool ShowDemand
        {
            get
            {
                if (panInputs.RowStyles[5].SizeType == SizeType.AutoSize)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                {
                    panInputs.RowStyles[5].SizeType = SizeType.AutoSize;
                    panInputs.RowStyles[5].Height = 15;
                }
                else
                {
                    panInputs.RowStyles[5].SizeType = SizeType.Percent;
                    panInputs.RowStyles[5].Height = 0;
                }

                //Hide/Show controls
                for (int d = 0; d < 5; d++)
                {
                    string tbName = "tbD" + d;
                    TextBox tb = (TextBox)panInputs.Controls.Find(tbName, false)[0];
                    tb.Visible = value;
                }
            }
        }
    }
}
