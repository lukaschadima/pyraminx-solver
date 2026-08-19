using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyraminx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pyraminx myPyraminx = new Pyraminx();
            for (SByte i = 0; i < 8; i++)
            {
                myPyraminx.topsOrientation[i].orientation = 0;//zakladni stav
            }
            
            for (SByte i = 0; i < 12; i++)
            {
                SByte k = Convert.ToSByte((int)i/3);
                myPyraminx.halfEdgesPosition[i].index = k;//zakladni stav
            }
            
            myPyraminx.R();
            myPyraminx.L();
            myPyraminx.R();
            myPyraminx.U();
            myPyraminx.RPrime();
            myPyraminx.UPrime();
            myPyraminx.L();
            myPyraminx.R();
            
            //praktický vstup, sekvence 6 tahů li dvakrát zasebou má řešení jednou zopakovat celý vstup
            //celý kód nahoře generuje kostku na základní pozici a pak jí "míchá"

            myPyraminx.Main2();
        }
        class HalfEdge  //půl hrany   ,nemají orientaci pouze pozici
        {
            public SByte index;
            public HalfEdge()
            {
                index = new SByte();
            }
        }
        class Top  // vrchol nebo roh má pouze orinetaci neboť s ním nejde hnout
        {
            
            public SByte orientation;  
            public Top()
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
                    topsOrientation[i] = new Top();
                }
                for (int i = 0; i < 12; i++)
                {
                    halfEdgesPosition[i] = new HalfEdge();
                }
            }
            public Top[] topsOrientation = new Top[8];
            public HalfEdge[] halfEdgesPosition = new HalfEdge[12]; //každý čtyřhran ma 8 vrcholů a 6 hran respektive 12polohran
            public void Main2()// muj main 
            {
                for (int x = 0; x < 11; x++)// abychom našli optimalní řešení procházíme DFS postupně nejdříve do Hloubky 1 2 atd asi by slo použit BFS ale ta pamět mě u 3x3x3 kostky strasila
                {

                    int y = 0;

                    Node mezinode = new Node(); // udelame deep copy aby se nám nehýbalo se "zadáním"
                    mezinode.pyraminx = this;
                    Node node = new Node(mezinode); 
                    Stack<Node> nodeStack = new Stack<Node>(); //zasobník po DFS 
                    Node curNode;
                    SByte[] moves = new SByte[15];   
                    nodeStack.Push(node);
                    while (nodeStack.Count != 0) 
                    {
                        curNode = nodeStack.Pop();
                        if (curNode.depth != 0)
                            moves[curNode.depth - 1] = curNode.move; // zápis tahů  a zaražka na konec 
                        moves[curNode.depth] = 127;
                        if (curNode.depth == x)
                        {
                            if (curNode.pyraminx.IsSolved()) { }// když jsme v cílové hloubce zkoušíme zda nemáme složeno
                                //End(moves);
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
            public void End(SByte[] moves)
            {
                for (SByte i = 0; moves[i] != 127; i++)//metoda na vypsání výstupu, protože tahy uchováváme kvuli paměti jako SByte
                {
                    switch (moves[i])
                    {
                        case 0:
                            Console.WriteLine("L");
                            break;
                        case 1:
                            Console.WriteLine("LPrime");
                            break;
                        case 2:
                            Console.WriteLine("F");
                            break;
                        case 3:
                            Console.WriteLine("FPrime");
                            break;
                        case 4:
                            Console.WriteLine("U");
                            break;
                        case 5:
                            Console.WriteLine("UPrime");
                            break;
                        case 6:
                            Console.WriteLine("R");
                            break;
                        case 7:
                            Console.WriteLine("RPrime");
                            break;
                    }
                }
                Environment.Exit(0);
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

        }
    }
}
