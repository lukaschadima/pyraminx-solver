using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pyraminx_solver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Main();
        }
        Pyraminx myPyraminx = new Pyraminx();
        void Main()
        {
            hintPictureBox.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("pyraminx");
            GenerateButtons1();
            WindowState = FormWindowState.Maximized;
            for (SByte i = 0; i < 8; i++)
            {
                myPyraminx.topsOrientation[i].orientation = 0;//zakladni stav
            }

            for (SByte i = 0; i < 12; i++)
            {
                SByte k = Convert.ToSByte((int)i / 3);
                myPyraminx.halfEdgesPosition[i].index = k;//zakladni stav
            }
            for (int i = 0; i < 18; i++)
            {
                color[i] = Brushes.Lime;
            }
            halfEdgeToColor.Add(0, Brushes.Red);
            halfEdgeToColor.Add(1, Brushes.Blue);
            halfEdgeToColor.Add(2, Brushes.Yellow);
            halfEdgeToColor.Add(3, Brushes.Lime);
            tipLToColor.Add(0, Brushes.Red);
            tipLToColor.Add(1, Brushes.Yellow);
            tipLToColor.Add(2, Brushes.Blue);
            tipRToColor.Add(0, Brushes.Lime);
            tipRToColor.Add(1, Brushes.Blue);
            tipRToColor.Add(2, Brushes.Yellow);
            tipUlToColor.Add(0, Brushes.Red);
            tipUlToColor.Add(1, Brushes.Blue);
            tipUlToColor.Add(2, Brushes.Lime);
            tipUrToColor.Add(0, Brushes.Lime);
            tipUrToColor.Add(1, Brushes.Red);
            tipUrToColor.Add(2, Brushes.Blue);
            tipFlToColor.Add(0, Brushes.Red);
            tipFlToColor.Add(1, Brushes.Lime);
            tipFlToColor.Add(2, Brushes.Yellow);
            tipFrToColor.Add(0, Brushes.Lime);
            tipFrToColor.Add(1, Brushes.Yellow);
            tipFrToColor.Add(2, Brushes.Red);
            
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Enabled = false;
            for (int i = 0; moves[i] != 127; i++)
            {
                movesTable.GetControlFromPosition(i + 1, 0).BackColor = Color.Orange;
                movesTable.GetControlFromPosition(i + 1, 0).Refresh();
                hintPictureBox.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("_" + moves[i]);
                hintPictureBox.Refresh();
                Task.Delay(3500).Wait();
                switch (moves[i])
                {
                    case 0:
                        myPyraminx.L();
                        break;
                    case 1:
                        myPyraminx.LPrime();
                        break;
                    case 2:
                        myPyraminx.F();
                        break;
                    case 3:
                        myPyraminx.FPrime();
                        break;
                    case 4:
                        myPyraminx.U();
                        break;
                    case 5:
                        myPyraminx.UPrime();
                        break;
                    case 6:
                        myPyraminx.R();
                        break;
                    case 7:
                        myPyraminx.RPrime();
                        break;
                    case 8:
                        myPyraminx.l();
                        break;
                    case 9:
                        myPyraminx.lPrime();
                        break;
                    case 10:
                        myPyraminx.f();
                        break;
                    case 11:
                        myPyraminx.fPrime();
                        break;
                    case 12:
                        myPyraminx.u();
                        break;
                    case 13:
                        myPyraminx.uPrime();
                        break;
                    case 14:
                        myPyraminx.r();
                        break;
                    case 15:
                        myPyraminx.rPrime();
                        break;
                }
                pyraminxPictureBox.Refresh();
                movesTable.GetControlFromPosition(i + 1, 0).BackColor = Color.Gray;
                movesTable.GetControlFromPosition(i + 1, 0).Refresh();
            }
            hintPictureBox.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("pyraminx");
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            popisek.Text = "výstup";
            startButton.Enabled = false;
            randomButton.Enabled = false;
            playButton.Enabled = true;
            for (int i = 1; i < 17; i++)
            {
                movesTable.Controls.Remove(movesTable.GetControlFromPosition(i, 0));
            }

            myPyraminx.Main2();
            for (int i = 0; moves[i] != 127; i++)
            {
                string text = "";
                switch (moves[i])
                {
                    case 0:
                        text = "L";
                        break;
                    case 1:
                        text = "L'";
                        break;
                    case 2:
                        text = "F";
                        break;
                    case 3:
                        text = "F'";
                        break;
                    case 4:
                        text = "U";
                        break;
                    case 5:
                        text = "U'";
                        break;
                    case 6:
                        text = "R";
                        break;
                    case 7:
                        text = "R'";
                        break;
                    case 8:
                        text = "l";
                        break;
                    case 9:
                        text = "l'";
                        break;
                    case 10:
                        text = "f";
                        break;
                    case 11:
                        text = "f'";
                        break;
                    case 12:
                        text = "u";
                        break;
                    case 13:
                        text = "u'";
                        break;
                    case 14:
                        text = "r";
                        break;
                    case 15:
                        text = "r'";
                        break;
                }
                Button move = new Button(); // vytvoříme zcela nové tlačítko
                move.Text = text; // smažeme text tlačítka
                move.Font = new Font(move.Font.FontFamily, 16);//tlačítku nastavíme font na 16 akorat musime volat nový font protože ten je primarně neni "set"
                move.BackColor = Color.Gray; // tlačítku nastavíme černé pozadí (třeba, rozhdoně není nutné)
                move.Enabled = false; // zatím na tlačítko nejde kliknout
                move.Dock = DockStyle.Fill; // tlačítkem chceme vyplnit celou přihrádku TableLayoutPanelu
                move.Click += MoveScrambel; // tlačítku přidáme metodu Card_Clicked(), která se zavolá po kliknutí na tlačítko
                movesTable.Controls.Add(move, i+1, 0); // přidá nově vytvořené tlačítko do TableLayoutPanelu na pozici (i,j)
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            popisek.Text = "zvolte vstup";
            startButton.Enabled = true;
            randomButton.Enabled = true;
            playButton.Enabled = false;
            for (SByte i = 0; i < 8; i++)
            {
                myPyraminx.topsOrientation[i].orientation = 0;//zakladni stav
            }

            for (SByte i = 0; i < 12; i++)
            {
                SByte k = Convert.ToSByte((int)i / 3);
                myPyraminx.halfEdgesPosition[i].index = k;//zakladni stav
            }
            for (int i = 1; i < 17; i++)
            {
                movesTable.Controls.Remove(movesTable.GetControlFromPosition(i, 0));
            }
            GenerateButtons1();
            pyraminxPictureBox.Refresh();
            scrambleLabel.Text = "";
            scrambleMoves = "";
        }

        private void randomButton_Click(object sender, EventArgs e)
        {

            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 20; i++)
            {
               
                switch (rnd.Next(0, 16))   // FIX: bylo (0,15) - horni mez je vylucujici, tah r' nikdy nepadl
                {
                    case 0:
                        myPyraminx.L();
                        scrambleMoves += " L";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 1:
                        myPyraminx.LPrime();
                        scrambleMoves += " L'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 2:
                        myPyraminx.F();
                        scrambleMoves += " F";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 3:
                        myPyraminx.FPrime();
                        scrambleMoves += " F'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 4:
                        myPyraminx.U();
                        scrambleMoves += " U";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 5:
                        myPyraminx.UPrime();
                        scrambleMoves += " U'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 6:
                        myPyraminx.R();
                        scrambleMoves += " R";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 7:
                        myPyraminx.RPrime();
                        scrambleMoves += " R'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 8:
                        myPyraminx.l();
                        scrambleMoves += " l";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 9:
                        myPyraminx.lPrime();
                        scrambleMoves += " l'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 10:
                        myPyraminx.f();
                        scrambleMoves += " f";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 11:
                        myPyraminx.fPrime();
                        scrambleMoves += " f'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 12:
                        myPyraminx.u();
                        scrambleMoves += " u";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 13:
                        myPyraminx.uPrime();
                        scrambleMoves += " u'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 14:
                        myPyraminx.r();
                        scrambleMoves += " r";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                    case 15:
                        myPyraminx.rPrime();
                        scrambleMoves += " r'";
                        scrambleLabel.Text = scrambleMoves;
                        break;
                }
            }
            pyraminxPictureBox.Refresh();
        }
        static int[] moves = new int[32];   // FIX: bylo 15 - preteceni u reseni na 11 tahu + az 4 tahy vrcholku + zarazka
        static string  scrambleMoves="" ;
        static List<Point> shadePoints = new List<Point>();
        static Brush[] color = new Brush[18];
        static Dictionary<SByte, Brush> halfEdgeToColor = new Dictionary<SByte, Brush>();
        static Dictionary<SByte, Brush> tipLToColor = new Dictionary<SByte, Brush>();
        static Dictionary<SByte, Brush> tipRToColor = new Dictionary<SByte, Brush>();
        static Dictionary<SByte, Brush> tipFlToColor = new Dictionary<SByte, Brush>();
        static Dictionary<SByte, Brush> tipUlToColor = new Dictionary<SByte, Brush>();
        static Dictionary<SByte, Brush> tipFrToColor = new Dictionary<SByte, Brush>();
        static Dictionary<SByte, Brush> tipUrToColor = new Dictionary<SByte, Brush>();
        static Dictionary<int, string> numberToMove = new Dictionary<int, string>();

        private void GenerateButtons1()
        {
            for (int i = 1; i < 17; i++)
            {
                string text="";
                switch (i-1)
                {
                    case 0:
                        text = "L";
                        break;
                    case 1:
                        text = "L'";
                        break;
                    case 2:
                        text = "F";
                        break;
                    case 3:
                        text = "F'";
                        break;
                    case 4:
                        text = "U";
                        break;
                    case 5:
                        text = "U'";
                        break;
                    case 6:
                        text = "R";
                        break;
                    case 7:
                        text = "R'";
                        break;
                    case 8:
                        text = "l";
                        break;
                    case 9:
                        text = "l'";
                        break;
                    case 10:
                        text = "f";
                        break;
                    case 11:
                        text = "f'";
                        break;
                    case 12:
                        text = "u";
                        break;
                    case 13:
                        text = "u'";
                        break;
                    case 14:
                        text = "r";
                        break;
                    case 15:
                        text = "r'";
                        break;
                }
                Button move = new Button(); // vytvoříme zcela nové tlačítko
                move.Text = text; // smažeme text tlačítka
                move.Font = new Font(move.Font.FontFamily, 16);//tlačítku nastavíme font na 16 akorat musime volat nový font protože ten je primarně neni "set"
                move.BackColor = Color.Gray; // tlačítku nastavíme černé pozadí (třeba, rozhdoně není nutné)
                move.Enabled = true; // zatím na tlačítko nejde kliknout
                move.Dock = DockStyle.Fill; // tlačítkem chceme vyplnit celou přihrádku TableLayoutPanelu
                move.Click += MoveScrambel; // tlačítku přidáme metodu Card_Clicked(), která se zavolá po kliknutí na tlačítko
                movesTable.Controls.Add(move, i, 0); // přidá nnově vytvořené tlačítko do TableLayoutPanelu na pozici (i,j)
            }
        }
        
        private  void MoveScrambel(object sender, EventArgs e)// hýbat kostkou
        {
            switch (movesTable.GetPositionFromControl((Button)sender).Column-1)
            {
                case 0:
                    myPyraminx.L();
                    scrambleMoves += " L";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 1:
                    myPyraminx.LPrime();
                    scrambleMoves += " L'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 2:
                    myPyraminx.F();
                    scrambleMoves += " F";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 3:
                    myPyraminx.FPrime();
                    scrambleMoves += " F'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 4:
                    myPyraminx.U();
                    scrambleMoves += " U";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 5:
                    myPyraminx.UPrime();
                    scrambleMoves += " U'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 6:
                    myPyraminx.R();
                    scrambleMoves += " R";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 7:
                    myPyraminx.RPrime();
                    scrambleMoves += " R'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 8:
                    myPyraminx.l();
                    scrambleMoves += " l";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 9:
                    myPyraminx.lPrime();
                    scrambleMoves += " l'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 10:
                    myPyraminx.f();
                    scrambleMoves += " f";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 11:
                    myPyraminx.fPrime();
                    scrambleMoves += " f'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 12:
                    myPyraminx.u();
                    scrambleMoves += " u";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 13:
                    myPyraminx.uPrime();
                    scrambleMoves += " u'";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 14:
                    myPyraminx.r();
                    scrambleMoves += " r";
                    scrambleLabel.Text = scrambleMoves;
                    break;
                case 15:
                    myPyraminx.rPrime();
                    scrambleMoves += " r'";
                    scrambleLabel.Text = scrambleMoves;
                    break;

            }

            pyraminxPictureBox.Refresh();

        }
        
        
        
        
        static int[] x1 = new int[18] {  0, 16, 33, 33, 34, 34, 50, 34, 50, 51, 66, 51, 51, 51, 67, 83, 67, 84 };
        static int[] y1 = new int[18] { 55, 36, 51, 86, 87, 86, 66, 50, 35, 35, 50, 37, 67, 69, 85, 70, 50, 37};
        static int[] x2 = new int[18] { 15, 33, 16, 33, 50, 34, 34, 50, 34, 66, 66, 66, 66, 66, 83, 67, 83,100 };
        static int[] y2 = new int[18] { 37, 18, 37, 52,100, 52, 51, 36, 16, 16, 17, 51, 52, 87, 71, 51, 36, 55};
        static int[] x3 = new int[18] { 15, 33, 16, 16, 50, 50, 50, 34, 50, 51, 51, 51, 66, 51, 67, 83, 67, 84};
        static int[] y3 = new int[18] { 70, 50, 70, 71, 68, 67, 37, 17,  0,  0, 36, 66, 86,100, 52, 37, 18, 70};
        
        
        private void pyraminxPictureBox_Paint(object sender, PaintEventArgs e)
        {
            color[0] = tipLToColor[myPyraminx.topsOrientation[4].orientation];
            color[1] = halfEdgeToColor[myPyraminx.halfEdgesPosition[1].index];
            color[2] = tipLToColor[myPyraminx.topsOrientation[0].orientation];
            color[3] = halfEdgeToColor[myPyraminx.halfEdgesPosition[0].index];
            color[4] = tipFlToColor[myPyraminx.topsOrientation[5].orientation];
            color[5] = tipFlToColor[myPyraminx.topsOrientation[1].orientation];
            color[6] = halfEdgeToColor[myPyraminx.halfEdgesPosition[2].index];
            color[7] = tipUlToColor[myPyraminx.topsOrientation[2].orientation];
            color[8] = tipUlToColor[myPyraminx.topsOrientation[6].orientation];
            color[9] = tipUrToColor[myPyraminx.topsOrientation[6].orientation];
            color[10] = tipUrToColor[myPyraminx.topsOrientation[2].orientation];
            color[11] = halfEdgeToColor[myPyraminx.halfEdgesPosition[9].index];
            color[12] = tipFrToColor[myPyraminx.topsOrientation[1].orientation];
            color[13] = tipFrToColor[myPyraminx.topsOrientation[5].orientation];
            color[14] = halfEdgeToColor[myPyraminx.halfEdgesPosition[11].index];
            color[15] = tipRToColor[myPyraminx.topsOrientation[3].orientation];
            color[16] = halfEdgeToColor[myPyraminx.halfEdgesPosition[10].index];
            color[17] = tipRToColor[myPyraminx.topsOrientation[7].orientation];


            pyraminxPictureBox.BackColor = Color.Black;
            // FIX vykreslovani: puvodne se souradnice pocitaly celociselnym delenim
            // (Width / 100 * x), coz zaokrouhlovalo dolu a nechavalo mezery mezi trojuhelniky.
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            double sx = pyraminxPictureBox.ClientSize.Width / 100.0;
            double sy = pyraminxPictureBox.ClientSize.Height / 100.0;
            for (int i = 0; i < 18; i++)
            {
                
                if (shadePoints.Count > 0)
                    shadePoints.RemoveRange(0, 3);
                shadePoints.Add(new Point((int)Math.Round(sx * x1[i]), (int)Math.Round(sy * y1[i])));
                shadePoints.Add(new Point((int)Math.Round(sx * x2[i]), (int)Math.Round(sy * y2[i])));
                shadePoints.Add(new Point((int)Math.Round(sx * x3[i]), (int)Math.Round(sy * y3[i])));
                e.Graphics.FillPolygon(color[i], shadePoints.ToArray());
            }
            
                        
        }

        class HalfEdge  //půl hrany, nemají orientaci pouze pozici
        {
            public SByte index;
            public HalfEdge()
            {
                index = new SByte();
            }
        }
        class Tip  // vrchol nebo roh má pouze orinetaci neboť s ním nejde hnout
        {

            public SByte orientation;
            public Tip()
            {
                orientation = new SByte();
            }

            public void ChangeOririentation(SByte shift) // mění orientaci 
            {
                this.orientation += shift;
                if (this.orientation == 3)
                    this.orientation = 0;
                else if (this.orientation == 4)
                    this.orientation = 1;
            }
        }
        class Node //uzel stromu 
        {
            public Pyraminx pyraminx; //každy uzel má svůj čtyřhran v nějakém stavu svůj poslední tah a hloubku od kořene
            public SByte move;
            public SByte depth;
            public Node()
            {
                pyraminx = new Pyraminx();  //na vytvoření nového uzlu
            }
            public Node(Node node) //deepcopy uzlu
            {
                pyraminx = new Pyraminx();
                for (SByte i = 0; i < 8; i++)
                {
                    SByte a = node.pyraminx.topsOrientation[i].orientation;
                    pyraminx.topsOrientation[i].orientation = a;
                }
                for (SByte i = 0; i < 12; i++)
                {
                    SByte a = node.pyraminx.halfEdgesPosition[i].index;
                    pyraminx.halfEdgesPosition[i].index = a;
                }
                depth = node.depth;
            }
        }
        class Pyraminx
        {
            public Pyraminx() //vytvoření čtyřstěnu
            {
                for (int i = 0; i < 8; i++)
                {
                    topsOrientation[i] = new Tip();
                }
                for (int i = 0; i < 12; i++)
                {
                    halfEdgesPosition[i] = new HalfEdge();
                }
            }
            public Tip[] topsOrientation = new Tip[8];
            public HalfEdge[] halfEdgesPosition = new HalfEdge[12]; //každý čtyřhran ma 8 vrcholů a 6 hran respektive 12polohran
            public void SolvingSmallTips(Node solvedNode )
            {
                for (int i = 0; i < 4; i++)
                {
                    if (solvedNode.pyraminx.topsOrientation[4 + i].orientation == 1)
                    {
                        
                        switch (i)
                        {
                            case 0:
                                moves[solvedNode.depth] = 8;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                            case 1:
                                moves[solvedNode.depth] = 10;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                            case 2:
                                moves[solvedNode.depth] = 12;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                            case 3:
                                moves[solvedNode.depth] = 14;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                        }

                    }
                    else if (solvedNode.pyraminx.topsOrientation[4 + i].orientation == 2)
                    {
                        switch (i)
                        {
                            case 0:
                                moves[solvedNode.depth] = 9;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                            case 1:
                                moves[solvedNode.depth] = 11;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                            case 2:
                                moves[solvedNode.depth] = 13;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                            case 3:
                                moves[solvedNode.depth] = 15;
                                moves[solvedNode.depth + 1] = 127;
                                solvedNode.depth++;
                                break;
                        }

                    }
                }
            }
            public void Main2()// muj main hledani řešení
            {
                for (int x = 0; x <= 11; x++)   // FIX: bylo < 11 - 32 nejtezsich zamichani potrebuje hloubku 11// abychom našli optimalní řešení procházíme DFS postupně nejdříve do Hloubky 1 2 atd asi by slo použit BFS ale ta pamět mě u 3x3x3 kostky strasila
                {

                    int y = 0;
                    Node mezinode = new Node(); // udelame deep copy aby se nám nehýbalo se "zadáním"
                    mezinode.pyraminx = this;
                    Node node = new Node(mezinode);
                    Stack<Node> nodeStack = new Stack<Node>(); //zasobník pro DFS 
                    Node curNode;
                    
                    nodeStack.Push(node);
                    while (nodeStack.Count != 0)
                    {
                        curNode = nodeStack.Pop();
                        if (curNode.depth != 0)
                            moves[curNode.depth - 1] = curNode.move; // zápis tahů  a zaražka na konec 
                        moves[curNode.depth] = 127;
                        if (curNode.depth == x)
                        {
                            if (curNode.pyraminx.IsSolved()) // když jsme v cílové hloubce zkoušíme zda nemáme složeno
                            {
                                SolvingSmallTips(curNode);
                                return;
                            }
                               
                        }

                        else //jinak otvírame cestu k novým uzlům 
                        {
                            for (SByte i = 0; i < 8; i++) //forcyklem zavoláme všecny tahy 
                            {
                                if (curNode.depth == 0 || Prune(i, curNode.move)) // zbytečné mažeme
                                {
                                    y++;                                // pro každý tah 
                                    Node nodeCopy = new Node(curNode); //udělame deepcopy 
                                    nodeCopy.pyraminx.Move(i);//provedem na ni daný tah
                                    nodeCopy.move = i; //zapíšeme 
                                    nodeCopy.depth++; // zvýšíme hloubku 
                                    nodeStack.Push(nodeCopy); //a přidáme do zásobníku
                                }
                            }

                        }
                    }
                }

            }
            
            public void Move(int x) //metoda volá konkrétní tahy
            {
                switch (x)
                {
                    case 0:
                        this.L();
                        break;
                    case 1:
                        this.LPrime();
                        break;
                    case 2:
                        this.F();
                        break;
                    case 3:
                        this.FPrime();
                        break;
                    case 4:
                        this.U();
                        break;
                    case 5:
                        this.UPrime();
                        break;
                    case 6:
                        this.R();
                        break;
                    case 7:
                        this.RPrime();
                        break;
                    case 8:
                        this.l();
                        break;
                    case 9:
                        this.lPrime();
                        break;
                    case 10:
                        this.f();
                        break;
                    case 11:
                        this.fPrime();
                        break;
                    case 12:
                        this.u();
                        break;
                    case 13:
                        this.uPrime();
                        break;
                    case 14:
                        this.r();
                        break;
                    case 15:
                        this.rPrime();
                        break;
                }

            }
            private bool Prune(int futureMove, sbyte lastMove)// metoda maže tahy které jsou zbytečné dělat 
            {
                if ((futureMove == 0 || futureMove == 1) && (lastMove == 0 || lastMove == 1))
                    return false;
                if ((futureMove == 2 || futureMove == 3) && (lastMove == 2 || lastMove == 3))
                    return false;
                if ((futureMove == 4 || futureMove == 5) && (lastMove == 4 || lastMove == 5))
                    return false;
                if ((futureMove == 6 || futureMove == 7) && (lastMove == 6 || lastMove == 7))
                    return false;
                return true;
            }
            private bool IsSolved()// metoda ověřuje zda li nemame složeno
            {
                for (SByte i = 0; i < 4; i++)
                {
                    if (topsOrientation[i].orientation != 0)
                        return false;
                }
                for (SByte i = 0; i < 12; i++)
                {
                    SByte k = Convert.ToSByte((int)i / 3);
                    if (halfEdgesPosition[i].index != k)
                        return false;
                }
                return true;

            }
            //konkrétní tahy vždy prohodí pozice 3 hran neboli 6 půlhran a otočí vrchol a vrchulek
            public void L()
            {
                HalfEdge odklad = halfEdgesPosition[0];
                halfEdgesPosition[0] = halfEdgesPosition[3];
                halfEdgesPosition[3] = halfEdgesPosition[8];
                halfEdgesPosition[8] = odklad;
                odklad = halfEdgesPosition[6];
                halfEdgesPosition[6] = halfEdgesPosition[1];
                halfEdgesPosition[1] = halfEdgesPosition[4];
                halfEdgesPosition[4] = odklad;
                topsOrientation[0].ChangeOririentation(2);
                topsOrientation[4].ChangeOririentation(2);
            }
            public void l()
            {
                topsOrientation[4].ChangeOririentation(2);
            }
            public void LPrime()
            {
                HalfEdge odklad = halfEdgesPosition[0];
                halfEdgesPosition[0] = halfEdgesPosition[8];
                halfEdgesPosition[8] = halfEdgesPosition[3];
                halfEdgesPosition[3] = odklad;
                odklad = halfEdgesPosition[6];
                halfEdgesPosition[6] = halfEdgesPosition[4];
                halfEdgesPosition[4] = halfEdgesPosition[1];
                halfEdgesPosition[1] = odklad;
                topsOrientation[0].ChangeOririentation(1);
                topsOrientation[4].ChangeOririentation(1);
            }
            public void lPrime()
            {
                topsOrientation[4].ChangeOririentation(1);
            }
            public void F()
            {
                HalfEdge odklad = halfEdgesPosition[7];
                halfEdgesPosition[7] = halfEdgesPosition[9];
                halfEdgesPosition[9] = halfEdgesPosition[0];
                halfEdgesPosition[0] = odklad;
                odklad = halfEdgesPosition[11];
                halfEdgesPosition[11] = halfEdgesPosition[2];
                halfEdgesPosition[2] = halfEdgesPosition[6];
                halfEdgesPosition[6] = odklad;
                topsOrientation[1].ChangeOririentation(2);
                topsOrientation[5].ChangeOririentation(2);
            }
            public void f()
            {
                topsOrientation[5].ChangeOririentation(2);
            }
            public void FPrime()
            {
                HalfEdge odklad = halfEdgesPosition[7];
                halfEdgesPosition[7] = halfEdgesPosition[0];
                halfEdgesPosition[0] = halfEdgesPosition[9];
                halfEdgesPosition[9] = odklad;
                odklad = halfEdgesPosition[11];
                halfEdgesPosition[11] = halfEdgesPosition[6];
                halfEdgesPosition[6] = halfEdgesPosition[2];
                halfEdgesPosition[2] = odklad;
                topsOrientation[1].ChangeOririentation(1);
                topsOrientation[5].ChangeOririentation(1);
            }
            public void fPrime()
            {
                topsOrientation[5].ChangeOririentation(1);
            }
            public void U()
            {
                HalfEdge odklad = halfEdgesPosition[5];
                halfEdgesPosition[5] = halfEdgesPosition[1];
                halfEdgesPosition[1] = halfEdgesPosition[9];
                halfEdgesPosition[9] = odklad;
                odklad = halfEdgesPosition[10];
                halfEdgesPosition[10] = halfEdgesPosition[3];
                halfEdgesPosition[3] = halfEdgesPosition[2];
                halfEdgesPosition[2] = odklad;
                topsOrientation[2].ChangeOririentation(2);
                topsOrientation[6].ChangeOririentation(2);
            }
            public void u()
            {
                topsOrientation[6].ChangeOririentation(2);
            }
            public void UPrime()
            {
                HalfEdge odklad = halfEdgesPosition[5];
                halfEdgesPosition[5] = halfEdgesPosition[9];
                halfEdgesPosition[9] = halfEdgesPosition[1];
                halfEdgesPosition[1] = odklad;
                odklad = halfEdgesPosition[10];
                halfEdgesPosition[10] = halfEdgesPosition[2];
                halfEdgesPosition[2] = halfEdgesPosition[3];
                halfEdgesPosition[3] = odklad;
                topsOrientation[2].ChangeOririentation(1);
                topsOrientation[6].ChangeOririentation(1);
            }
            public void uPrime()
            {
                topsOrientation[6].ChangeOririentation(1);
            }
            public void R()
            {
                HalfEdge odklad = halfEdgesPosition[5];
                halfEdgesPosition[5] = halfEdgesPosition[11];
                halfEdgesPosition[11] = halfEdgesPosition[8];
                halfEdgesPosition[8] = odklad;
                odklad = halfEdgesPosition[10];
                halfEdgesPosition[10] = halfEdgesPosition[7];
                halfEdgesPosition[7] = halfEdgesPosition[4];
                halfEdgesPosition[4] = odklad;
                topsOrientation[3].ChangeOririentation(2);
                topsOrientation[7].ChangeOririentation(2);
            }
            public void r()
            {
                topsOrientation[7].ChangeOririentation(2);
            }
            public void RPrime()
            {
                HalfEdge odklad = halfEdgesPosition[5];
                halfEdgesPosition[5] = halfEdgesPosition[8];
                halfEdgesPosition[8] = halfEdgesPosition[11];
                halfEdgesPosition[11] = odklad;
                odklad = halfEdgesPosition[10];
                halfEdgesPosition[10] = halfEdgesPosition[4];
                halfEdgesPosition[4] = halfEdgesPosition[7];
                halfEdgesPosition[7] = odklad;
                topsOrientation[3].ChangeOririentation(1);
                topsOrientation[7].ChangeOririentation(1);
            }
            public void rPrime()
            {
                topsOrientation[7].ChangeOririentation(1);
            }

        }

        
    }
}
