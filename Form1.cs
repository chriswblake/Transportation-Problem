using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1Transportation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //solveProblemAndDisplay(SampleProblems.p81_Normal);
            this.Height = 600;
        }

        //Methods
        private void solveProblemAndDisplay(TransportProblem p)
        {
            //Result variable
            string sHTML = "";

            #region Check Problem
            sHTML += "Balanced Problem: " + p.isBalanced + "</br>";
            if (!p.isBalanced)
            {
                sHTML += "Transport problem is not balanced!" + "</br>";
                sHTML += "Suppliers: " + p.Suppliers.Sum() + "</br>";
                sHTML += "Demanders: " + p.Demanders.Sum() + "</br>";
            }
            #endregion

            //Spacer
            sHTML += "</br>";

            //If a proper problem, then solve
            if(p.isBalanced)
            {

                #region Method 1: NorthWest
                double[,] solutionNorthWest = p.solveNorthWest();
                double costNorthWest = p.calculateCost(solutionNorthWest); //632 <-- correct
                sHTML += "<b>Solution: North West Method</b>" + "</br>";
                sHTML += "Cost: " + costNorthWest + "</br>";
                sHTML += p.solutionToHTML(solutionNorthWest);
                #endregion

                //Spacer
                sHTML += "</br>";

                #region Method 2: Minimum Cost Element
                double[,] solutionMinimumCostElement = p.solveMinimumCostElement();
                double costMinimumCostElement = p.calculateCost(solutionMinimumCostElement);
                sHTML += "<b>Solution: Minimum Cost Element Method</b>" + "</br>";
                sHTML += "Cost: " + costMinimumCostElement + "</br>";
                sHTML += p.solutionToHTML(solutionMinimumCostElement);
                #endregion

                //Spacer
                sHTML += "</br>";

                #region Method 3: UV
                int cycles = 0;
                double[,] solutionUV = p.solveUV(out cycles);
                double costUV = p.calculateCost(solutionUV);
                sHTML += "<b>Solution: Least Potentials Optimization</b>" + "</br>";
                sHTML += "Cost: " + costUV + "</br>";
                sHTML += "Cycles: " + cycles + "</br>";
                sHTML += p.solutionToHTML(solutionUV);
                #endregion

            }
            //Send to Browser
            wbResults.Url = new Uri("about: blank");
            wbResults.DocumentText = "<html>" + p.styleHTML() + sHTML + "</html>";
            wbResults.Visible = true;
        }

        //Controls
        private void btnGo_Click(object sender, EventArgs e)
        {
            //Define the default problem
            TransportProblem p = new TransportProblem(4, 5);
            p.Suppliers = gridCosts.Supply;
            p.Demanders = gridCosts.Demand; 
            p.Costs = gridCosts.Grid;
            p.MinimumDelivery = gridMinDelivery.Grid;

            //Solve the problem and display in the web browser
            if (p.isReady)
            solveProblemAndDisplay(p);          
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            gridCosts.Supply = null;
            gridCosts.Demand = null;
            gridCosts.Grid = null;

            gridMinDelivery.Grid = null;

            wbResults.DocumentText = "";
        }
        private void btnSample81_Click(object sender, EventArgs e)
        {
            TransportProblem p = SampleProblems.p81_Normal;
            gridCosts.Supply = p.Suppliers;
            gridCosts.Demand = p.Demanders;
            gridCosts.Grid = p.Costs;
            gridMinDelivery.Grid = p.MinimumDelivery;
        }
        private void btnSample81_MinDel_Click(object sender, EventArgs e)
        {
            TransportProblem p = SampleProblems.p81_MinimumDelivery;
            gridCosts.Supply = p.Suppliers;
            gridCosts.Demand = p.Demanders;
            gridCosts.Grid = p.Costs;
            gridMinDelivery.Grid = p.MinimumDelivery;
        }

        private void tabsInputs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wbResults_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }

    public class TransportProblem
    {
        //Fields
        private double[] suppliers = null;
        private double[] demanders = null;
        private double[,] costs = null;
        private double[,] minimumDelivery = null;

        //Constructor
        public TransportProblem(int numSuppliers, int numDemanders)
        {
            this.suppliers = new double[numSuppliers];
            this.demanders = new double[numDemanders];
            this.costs = new double[numSuppliers, numDemanders];
            this.minimumDelivery = new double[numSuppliers, numDemanders];
        }

        //Properties
        public bool isReady
        {
            get
            {
                if (suppliers == null) return false;
                if (demanders == null) return false;
                if (costs == null) return false;

                //Else
                return true;
            }
        }
        public bool isBalanced
        {
            get
            {
                if (suppliers.Sum() == demanders.Sum())
                    return true;
                else
                    return false;
            }          
        }
        public double[] Suppliers
        {
            get { return suppliers; }
            set
            {
                //check if new array matches size
                if(value != null)
                if (value.Length != suppliers.Length)
                        throw new ArgumentException("Array size must be the same.");

                //Save data
                suppliers = value;
                
            }
        }
        public double[] Demanders
        {
            get { return demanders; }
            set
            {
                //check if new array matches size
                if (value != null)
                if (value.Length != demanders.Length)
                    throw new ArgumentException("Array size must be the same.");

                //Save Data
                demanders = value;

            }
        }
        public double[,] Costs
        {
            get { return costs; }
            set
            {
                //check if new array matches size
                if (value != null)
                if (value.GetLength(0) != costs.GetLength(0) || value.GetLength(1) != costs.GetLength(1))
                throw new ArgumentException("Array size must be the same.");

                //Save Data
                costs = value;
            }
        }
        public double[,] MinimumDelivery
        {
            get { return minimumDelivery; }
            set
            {
                //check if new array matches size
                if (value != null)
                if (value.GetLength(0) != costs.GetLength(0) || value.GetLength(1) != costs.GetLength(1))
                    throw new ArgumentException("Array size must be the same.");

                //Save Data
                minimumDelivery = value;
                
            }
        }

        //Methods - Display
        public string styleHTML()
        {
            return @"
                    <style>
                    body {
                        background: #EEEEEE;
                        text-align: left;
                        font: 14px Calibri;
                    }
                    table {

                        border-collapse: collapse;
                    }

                    table, th, td {
                        border: 1px solid black;
                        text-align: center;
                        vertical-align: middle;
                    }

                    th {
                        font: 15px Calibri;
                        height: 20px;
                        width:  22px;
                    }

                    td {
                        font: 15px;
                        height: 20px;
                        width:  42px;
                    }

                    td.highlight {
                        background-color: green;
                   }

                </style>
                ";
        }
        public string solutionToHTML(double[,] solution)
        {
            //Get dimensions
            int rows = solution.GetLength(0);
            int cols = solution.GetLength(1);

            //Start Table
            string results = "<table>";

            //Add Headers
            results += "<tr>";
            results += "<th></th>";
            for (int d = 0; d < cols; d++)
            {
                results += "<th>D" + d + "</th>";
            }
            results += "</tr>";

            //Add rows
            results += "<tr>";
            for (int s = 0; s < rows; s++)
            {
                //Add row header
                results += "<th>S" + s + "</th>";

                //Add columns
                for (int d = 0; d < cols; d++)
                {
                    if (solution[s,d] > 0)
                        results += "<td class='highlight'>" + solution[s, d] + "</td>";
                    else
                        results += "<td>" + solution[s, d] + "</td>";
                }

                //Next row
                results += "</tr>";
            }

            //Close table
            results += "</table>";

            return results;
        }

        //Methods - Solvers
        public double[,] solveNorthWest()
        {
            return solveNorthWest(true);
        }
        public double[,] solveNorthWest(bool enableLimations)
        {
            //Switch for limations modifications
            if (enableLimations)
            {
                //Account for minimum delivery
                adjustMinimumDelivery_FromSupplyAndDemand(false); //Subtract away
            }

            //Create temporary variables
            double[] sup = (double[]) suppliers.Clone();
            double[] dem = (double[]) demanders.Clone();
            double[,] solution = new double[suppliers.Length, demanders.Length];
           
            //Cycle through each solution position
            int s = 0;
            int d = 0;
            while (s < sup.Length && d < dem.Length)
            {
                //Get min of supply and demand
                double min = (new double[] { sup[s], dem[d] }).Min();

                //Set to solution
                solution[s, d] = min;

                //Remove from supply and demand
                sup[s] -= min;
                dem[d] -= min;

                //Find next most northwest position
                try
                { 
                    while (sup[s] == 0) { s++; }
                    while (dem[d] == 0) { d++; }
                }
                catch
                {
                    //All finished
                    break;
                }
            }

            //Switch for limations modifications
            if (enableLimations)
            {
                //Account for minimum delivery
                addMinimumDelivery_ToSolution(solution);
                adjustMinimumDelivery_FromSupplyAndDemand(true); //Add back
            }

            //Return the results
            return solution;
        }
        public double[,] solveMinimumCostElement()
        {
            //Account for minimum delivery
            adjustMinimumDelivery_FromSupplyAndDemand(false); //Subtract away

            //Create temporary variables
            double[] sup = (double[])suppliers.Clone();
            double[] dem = (double[])demanders.Clone();
            double[,] solution = new double[suppliers.Length, demanders.Length];

            //Get dimensions
            int rows = solution.GetLength(0);
            int cols = solution.GetLength(1);

            //Cycle through each solution position
            while (sup.Sum() > 0 && dem.Sum() > 0)
            {
                //Find min cost position, that has no solution value
                double currMinCost = double.PositiveInfinity;
                int rMin = 0;
                int cMin = 0;
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                    {
                        //Skips finished solutions
                        if (solution[r,c] != 0) { continue; }
                        if (sup[r] == 0) { continue; }
                        if (dem[c] == 0) { continue; }

                        if (costs[r,c] < currMinCost)
                        {
                            rMin = r;
                            cMin = c;
                            currMinCost = costs[r, c];
                        }
                    }
                int s = rMin;
                int d = cMin;

                //Get min of supply and demand
                double min = (new double[] { sup[s], dem[d] }).Min();

                //Set to solution
                solution[s, d] = min;

                //Remove from supply and demand
                sup[s] -= min;
                dem[d] -= min;
            }

            //Account for minimum delivery
            addMinimumDelivery_ToSolution(solution);
            adjustMinimumDelivery_FromSupplyAndDemand(true); //Add back

            return solution;
        }
        public double[,] solveUV(out int cycles)
        {
            //Account for minimum delivery
            adjustMinimumDelivery_FromSupplyAndDemand(false); //Subtract away

            //Get dimensions
            int rows = Costs.GetLength(0);
            int cols = Costs.GetLength(1);

            //Get Northwest approximation
            double[,] solutionCurr = solveNorthWest(false);

            //Cycle until end condion met
            cycles = 0; //For statistics
            while (true)
            {

                #region Calculate UV values
                double[] u;
                double[] v;
                calculateUV_Values(solutionCurr, out u, out v);
                #endregion

                #region  Calculate penalty values, track location of greatest penalty
                double[,] penalties = new double[rows, cols];
                int rMax = -1;
                int cMax = -1;
                double penaltyMax = double.NegativeInfinity;
                bool allNegative = true;

                //Calculate penalties 
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        //Calculate only for unassigned cells
                        if (solutionCurr[r, c] == 0)
                        {
                            //Get and store value
                            double penalty = u[r] + v[c] - Costs[r, c];
                            penalties[r, c] = penalty;

                            //Check sign
                            if (penalty > 0) allNegative = false;

                            //Check for max
                            if (penalty > penaltyMax)
                            {
                                penaltyMax = penalty;
                                rMax = r;
                                cMax = c;
                            }
                        }
                    }
                }
                #endregion

                //Check end condion
                if (allNegative)
                {
                    //Finished
                    break;
                }

                #region Generate new iteration of solution
                //Identify loop
                int rLoopStart = rMax;
                int cLoopStart = cMax;
                int[,] loop = findLoop(solutionCurr, rLoopStart, cLoopStart);

                //Get lowest number in "negative" group (odd entries of loop)
                double minValue = double.PositiveInfinity;
                for (int p = 0; p < loop.GetLength(0); p++)
                {
                    //Get cell value
                    int r = loop[p, 0];
                    int c = loop[p, 1];

                    //Determine current operation
                    if (p % 2 == 1) //odd (negative operation numbers)
                    {
                        if (solutionCurr[r, c] < minValue)
                            minValue = solutionCurr[r, c];
                    }
                }

                //Adjust current solution
                for (int p = 0; p < loop.GetLength(0); p++)
                {
                    //Get cell value
                    int r = loop[p, 0];
                    int c = loop[p, 1];

                    //Determine current operation
                    if (p % 2 == 0) //even or zero
                    {
                        //Add the minimum value to the solution
                        solutionCurr[r, c] += minValue;
                    }
                    else //odd
                    {
                        //Remove the minimum value from the solution
                        solutionCurr[r, c] -= minValue;
                    }
                }
                #endregion

                cycles++;
            }

            //Account for minimum delivery
            addMinimumDelivery_ToSolution(solutionCurr);
            adjustMinimumDelivery_FromSupplyAndDemand(true); //Add back

            return solutionCurr;
        }
        public double calculateCost(double[,] solution)
        {
            //Get dimensions
            int rows = solution.GetLength(0);
            int cols = solution.GetLength(1);

            //Check dimensions
            if (rows != costs.GetLength(0) || cols != costs.GetLength(1))
            { throw new ArgumentException("Solution array must have same dimensions as cost array"); }

            //Sum costs
            double cost = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    cost += solution[r, c] * costs[r, c];
                }

            //Return result
            return cost;
        }

        //Method - Support UV method
        private void calculateUV_Values(double[,] solution, out double[] u, out double[] v)
        {
            //Get dimensions
            int rows = solution.GetLength(0);
            int cols = solution.GetLength(1);

            //Result variables
            double?[] U = new double?[rows];
            double?[] V = new double?[cols];

            //Assume U0 = 0 for row 0, Solve for 
            U[0] = 0;

            //Repeat loop until all values of U and V are solved
            while (true)
            {
                #region Check if U and V finished
                //Check U values
                bool uFinished = true;
                for (int i = 0; i < U.Length; i++)
                {
                    if (U[i] == null)
                    {
                        uFinished = false;
                        break;
                    }
                }

                //Check V values
                bool vFinished = true;
                for (int i = 0; i < V.Length; i++)
                {
                    if (V[i] == null)
                    {
                        vFinished = false;
                        break;
                    }
                }

                //Both finished
                if (uFinished && vFinished) break;
                #endregion

                //Try to solve for V values
                for (int r = 0; r < rows; r++)
                {
                    //If U not set, V cannot be determined
                    if (U[r] == null)
                        continue;

                    //Set values of V for assigned cells
                    for (int c = 0; c < cols; c++)
                    {
                        //If already set, move to next
                        if (V[c] != null)
                            continue;

                        //Set the value
                        if (solution[r, c] > 0)
                            V[c] = Costs[r, c] - U[r];
                    }
                }

                //Try to solve for U values       
                for (int c = 0; c < cols; c++)
                {
                    //If V not set, U cannot be determined
                    if (V[c] == null)
                        continue;

                    //Set values of U for assigned cells
                    for (int r = 0; r < rows; r++)
                    {
                        //If already set, move to next
                        if (U[r] != null)
                            continue;

                        //Set the value
                        if (solution[r, c] > 0)
                            U[r] = Costs[r, c] - V[c];
                    }
                }
            }

            //Return results
            u = new double[rows];
            for (int i = 0; i < rows; i++)
                u[i] = (double)U[i];

            v = new double[cols];
            for (int i = 0; i < cols; i++)
                v[i] = (double)V[i];
        }
        private int[,] findLoop(double[,] solution, int rStart, int cStart)
        {
            //Get dimensions
            int rows = solution.GetLength(0);
            int cols = solution.GetLength(1);

            #region Generate possible directions
            //Add temporary value at start point (so it is included in directions generation)
            solution[rStart, cStart] = 1;

            //Compute possible directions at each cell
            List<int[]>[,] allowedDirections = new List<int[]>[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    //Ignore unassigned cells
                    if (solution[r, c] == 0)
                        continue;

                    //If not created yet, create it
                    allowedDirections[r, c] = new List<int[]>();

                    //Check row
                    for (int cCurr = 0; cCurr < cols; cCurr++)
                    {
                        if (cCurr != c & solution[r, cCurr] > 0)
                        {
                            allowedDirections[r, c].Add(new int[] { 0, cCurr - c });
                        }
                    }

                    //Check colum
                    for (int rCurr = 0; rCurr < rows; rCurr++)
                    {
                        if (rCurr != r & solution[rCurr, c] > 0)
                        {
                            allowedDirections[r, c].Add(new int[] { rCurr - r, 0 });
                        }
                    }
                }
            }

            //Remove temporary value at start point
            solution[rStart, cStart] = 0;
            #endregion

            #region Remove bad directions
            bool changeFound = true;
            while (changeFound)
            {
                //Assume no change first
                changeFound = false;

                //Remove items with one entry
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        List<int[]> ad = allowedDirections[r, c];
                        if (ad != null && ad.Count == 1)
                        {
                            //Get the entry
                            int[] dir = ad.First();

                            //Get the cell where it points, and remove the negative version
                            allowedDirections[r + dir[0], c + dir[1]].RemoveAll(i => i[0] == -dir[0] && i[1] == -dir[1]);

                            //Remove this list
                            allowedDirections[r, c] = null;

                            //Allow another loop
                            changeFound = true;
                        }
                    }
                }

                //Remove items that can't turn
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        List<int[]> ad = allowedDirections[r, c];
                        if (ad != null)
                        {
                            //Check if both row and column movement exist
                            int countColumnMovement = ad.FindAll(dir => dir[0] == 0).Count;
                            int countRowMovement = ad.FindAll(dir => dir[1] == 0).Count;

                            //If column move
                            if (countColumnMovement == 0 || countRowMovement == 0)
                            {
                                //For each entry
                                foreach (int[] dir in ad)
                                {
                                    //Get the cell where it points, and remove the negative version
                                    allowedDirections[r + dir[0], c + dir[1]].RemoveAll(i => i[0] == -dir[0] && i[1] == -dir[1]);
                                }

                                //Remove this list
                                allowedDirections[r, c] = null;

                                //Allow another loop
                                changeFound = true;
                            }
                        }

                    }
                }
            }
            #endregion

            #region Generate Path
            //Start at specified position
            List<int[]> path = new List<int[]>();
            path.Add(new int[] { rStart, cStart });
            int rCurrr = rStart;
            int cCurrr = cStart;

            //Start loop          
            while (true)
            {
                //Get current directions
                List<int[]> directionsCurr = allowedDirections[rCurrr, cCurrr];

                //Get first entry
                int[] dir = directionsCurr.First();

                //Move to this entry
                rCurrr += dir[0];
                cCurrr += dir[1];
                directionsCurr = allowedDirections[rCurrr, cCurrr];

                //Check if back at start
                if (rCurrr == rStart && cCurrr == cStart)
                    break;

                //Add to path
                path.Add(new int[] { rCurrr, cCurrr });

                //Remove negative reference, so as not to get sent back
                allowedDirections[rCurrr, cCurrr].RemoveAll(i => i[0] == -dir[0] && i[1] == -dir[1]);
            }
            #endregion

            #region Convert path
            //Copy from list to 2d array
            int[,] loop = new int[path.Count, 2];
            for (int i = 0; i < path.Count; i++)
            {
                //copy row value
                loop[i, 0] = path[i][0];

                //copy column value
                loop[i, 1] = path[i][1];
            }
            #endregion

            return loop;
        }

        //Methods - Limiations
        private void adjustMinimumDelivery_FromSupplyAndDemand(bool Add)
        {
            //If nothing provided
            if (minimumDelivery == null)
                return;

            //Determine add or subtract operation
            double sign = -1; //Default to subtrac
            if (Add)
                sign = 1; //Add

            //Get dimensions
            int rows = minimumDelivery.GetLength(0);
            int cols = minimumDelivery.GetLength(1);

            //Remove each delivery requirement from the supply and demand numbers
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    //Remove from Supply
                    suppliers[r] += sign * minimumDelivery[r, c];

                    //Remove from Demand
                    demanders[c] += sign * minimumDelivery[r, c];
                }
        }
        private void addMinimumDelivery_ToSolution(double[,] solution)
        {
            //If nothing provided
            if (minimumDelivery == null)
                return;

            //Get dimensions
            int rows = minimumDelivery.GetLength(0);
            int cols = minimumDelivery.GetLength(1);

            //Remove each delivery requirement from the supply and demand numbers
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    //Add minimum delivery value to solution
                    solution[r,c] += minimumDelivery[r, c];
                }
        }

        
    }
    static class SampleProblems
    {
        public static TransportProblem p81_Normal
        {
            get
            {
                TransportProblem p= new TransportProblem(4, 5);
                p.Suppliers = new double[] { 19, 14, 13, 18 };
                p.Demanders = new double[] { 14, 23, 7, 10, 10 };
                p.Costs = new double[,]
                {
                    { 24,  8, 10, 23, 18 },
                    { 19,  1, 11,  9,  6 },
                    {  5,  7,  4,  8,  9 },
                    {  6, 13,  3, 15,  5 }
                };

                return p;
            }
        }
        public static TransportProblem p81_MinimumDelivery
        {
            get
            {
                TransportProblem p = new TransportProblem(4, 5);
                p.Suppliers = new double[] { 19, 14, 13, 18 };
                p.Demanders = new double[] { 14, 23, 7, 10, 10 };
                p.Costs = new double[,]
                {
                    { 24,  8, 10, 23, 18 },
                    { 19,  1, 11,  9,  6 },
                    {  5,  7,  4,  8,  9 },
                    {  6, 13,  3, 15,  5 }
                };


                p.MinimumDelivery = new double[4, 5];
                Random rand = new Random();
                for (int i =0; i < 5; i++)
                {
                    //Random value to change
                    int r = rand.Next(0, 4); //0 to 3
                    int c = rand.Next(0, 5); //0 to 4

                    //Determine min deliver value
                    int v = rand.Next(0, 4); //0 to 3

                    //Save to array
                    p.MinimumDelivery[r, c] = v;
                }

                return p;
            }
        }
    }
}
