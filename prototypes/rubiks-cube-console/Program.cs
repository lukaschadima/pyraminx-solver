using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubic_2x2x2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Cube rubicCube = new Cube();
            for (SByte i = 0; i < 8; i++)
            {
                rubicCube.corners[i] = new Cubie();
                rubicCube.corners[i].index = i;
            }
            for (SByte i = 0; i < 12; i++)
            {
                rubicCube.edges[i] = new Cubie();
                rubicCube.edges[i].index = i;//inicializujeme základní stav
            }
            rubicCube.B2();
            rubicCube.U2();
            rubicCube.R();
            rubicCube.F();
            rubicCube.L2();
            rubicCube.U2();


            
            rubicCube.Main2();
        }
        class Cubie
        {
            public SByte index; //každá kostička má svůj index a orientaci    
            public SByte orientation;
            public Cubie()
            {
                index = new SByte();
                orientation = new SByte();
            }
            
            public void ChangeCornerOririentation(SByte shift) 
            {
                this.orientation +=shift;
                if (this.orientation == 3)
                    this.orientation = 0;
                else if (this.orientation == 4)
                    this.orientation = 1;
            }
            public void ChangeEdgeOririentation()
            {
                this.orientation ^= 1;  //orientace hran se mění  jen 1-0-1-0
            }
        }
        class Node
        {
            public Cube cube;
            public SByte move;
            public SByte depth;
            public Node()
            {
                cube = new Cube();
            }
            public Node(Node node)
            {
                cube = new Cube();
                for (SByte i = 0; i < 8; i++)
                {
                    SByte a=node.cube.corners[i].index ;
                    cube.corners[i].index=a;
                    a = node.cube.corners[i].orientation;
                    cube.corners[i].orientation= a;
                }
                for (SByte i = 0; i < 12; i++)
                {
                    SByte a = node.cube.edges[i].index;
                    cube.edges[i].index = a;
                    a = node.cube.edges[i].orientation;
                    cube.edges[i].orientation = a;
                }

            } 
            public int indexG1()
            {
                int index = 0;
                for (int i = 0; i < 12; i++)
                {
                    index += (cube.edges[i].orientation*Convert.ToInt16(Math.Pow(11-i,2)));
                }
                return index;
            }
        }
        class Cube
        {
            public Cube()
            {
                for (int i = 0; i < 8; i++)
                {
                    corners[i] = new Cubie();
                }
                for (int i = 0; i < 12; i++)
                {
                   edges[i] = new Cubie();
                }
            }

            //public int y = 0;
            public Cubie[] corners = new Cubie[8];
            public Cubie[] edges = new Cubie[12];
            public void End(SByte[] moves)
            {
                for (SByte i = 0; moves[i] != 127; i++)
                {
                    Console.WriteLine(moves[i]);
                }
                Environment.Exit(0);
            }
            
            
            public void Main2()
            {
                Node node = new Node();
                node.cube = this;
                Stack<Node> nodeStack = new Stack<Node>();
                Node curNode;
                SByte[] moves = new SByte[21];
                
                while (true)
                {
                    if (nodeStack.Count == 0)
                        nodeStack.Push(node);
                    curNode = nodeStack.Pop();
                    if (curNode.depth != 0)
                        moves[curNode.depth - 1] = curNode.move;
                    moves[curNode.depth] = 127;

                    
                    if (curNode.cube.IsSolved())
                        End(moves);
                    
                    if (curNode.depth < 7)
                    {
                        for (SByte i = 0; i < 18; i++)
                        {
                            if (curNode.depth == 0 || Prune(i, curNode.move))
                            {
                                Node nodeCopy = new Node(curNode);
                                nodeCopy.cube.Move(i);
                                nodeCopy.move = i;
                                nodeCopy.depth = curNode.depth;
                                nodeCopy.depth++;
                                nodeStack.Push(nodeCopy);
                            }
                        }

                    }
                }
            }
            private void Move(int x)
            {
                switch (x)
                {
                    case 0:
                        this.R();
                        break;
                    case 1:
                        this.RPrime();
                        break;
                    case 2:
                        this.R2();
                        break;
                    case 3:
                        this.L();
                        break;
                    case 4:
                        this.LPrime();
                        break;
                    case 5:
                        this.L2();
                        break;
                    case 6:
                        this.U();
                        break;
                    case 7:
                        this.UPrime();
                        break;
                    case 8:
                        this.U2();
                        break;
                    case 9:
                        this.D();
                        break;
                    case 10:
                        this.DPrime();
                        break;
                    case 11:
                        this.D2();
                        break;
                    case 12:
                        this.F();
                        break;
                    case 13:
                        this.FPrime();
                        break;
                    case 14:
                        this.F2();
                        break;
                    case 15:
                        this.B();
                        break;
                    case 16:
                        this.BPrime();
                        break;
                    case 17:
                        this.B2();
                        break;

                }

            }
            private bool Prune(int futureMove, sbyte lastMove)
            {
                //opakovani stejných tahů
                if ((futureMove == 0 || futureMove == 1 || futureMove == 2) && (lastMove == 0 || lastMove == 1 || lastMove == 2))
                    return false;
                if ((futureMove == 3 || futureMove == 4 || futureMove == 5) && (lastMove == 3 || lastMove == 4 || lastMove == 5))
                    return false;
                if ((futureMove == 6 || futureMove == 7 || futureMove == 8) && (lastMove == 6 || lastMove == 7 || lastMove == 8))
                    return false;
                if ((futureMove == 9 || futureMove == 10 || futureMove == 11) && (lastMove == 9 || lastMove == 10 || lastMove == 11))
                    return false;
                if ((futureMove == 12 || futureMove == 13 || futureMove == 14) && (lastMove == 12 || lastMove == 13 || lastMove == 14))
                    return false;
                if ((futureMove == 15 || futureMove == 16 || futureMove == 17) && (lastMove == 15 || lastMove == 16 || lastMove == 17))
                    return false;
                //dva opacne tahy 
                if ((futureMove == 0 || futureMove == 1 || futureMove == 2) && (lastMove == 3 || lastMove == 4 || lastMove == 5))
                    return false;
                if ((futureMove == 6 || futureMove == 7 || futureMove == 8) && (lastMove == 9 || lastMove == 10 || lastMove == 11))
                    return false;
                if ((futureMove == 12 || futureMove == 13 || futureMove == 14) && (lastMove == 15 || lastMove == 16 || lastMove == 17))
                    return false;

                return true;
            }
            
            private bool IsSolved()
            {
                // FIX: puvodni verze mela oba testy v jednom cyklu do 8, takze
                // hrany s indexem 8-11 se nikdy nekontrolovaly a solver mohl
                // ohlasit "slozeno" pro stav, ktery slozeny nebyl.
                for (int i = 0; i < 8; i++)
                {
                    if (corners[i].index != (SByte)i || corners[i].orientation != 0)
                        return false;
                }
                for (int i = 0; i < 12; i++)
                {
                    if (edges[i].index != (SByte)i || edges[i].orientation != 0)
                        return false;
                }
                return true;
            }

            public void U()
            {
                Cubie odklad = this.corners[3];
                this.corners[3] = this.corners[2];
                this.corners[2] = this.corners[1];
                this.corners[1] = this.corners[0];
                this.corners[0] = odklad;
                odklad = this.edges[3];
                this.edges[3] = this.edges[4];
                this.edges[4] = this.edges[0];
                this.edges[0] = this.edges[1];
                this.edges[1] = odklad;
                edges[1].ChangeEdgeOririentation();
                edges[3].ChangeEdgeOririentation();
                edges[0].ChangeEdgeOririentation();
                edges[4].ChangeEdgeOririentation();
            }
            public void UPrime()
            {
                Cubie odklad = this.corners[3];
                this.corners[3] = this.corners[0];
                this.corners[0] = this.corners[1];
                this.corners[1] = this.corners[2];
                this.corners[2] = odklad;
                odklad = this.edges[3];
                this.edges[3] = this.edges[1];
                this.edges[1] = this.edges[0];
                this.edges[0] = this.edges[4];
                this.edges[4] = odklad;
                edges[1].ChangeEdgeOririentation();
                edges[3].ChangeEdgeOririentation();
                edges[0].ChangeEdgeOririentation();
                edges[4].ChangeEdgeOririentation();
            }
            public void U2()
            {
                Cubie odklad = this.corners[3];
                this.corners[3] = this.corners[1];
                this.corners[1] = odklad;
                odklad = this.corners[2];
                this.corners[2] = this.corners[0];
                this.corners[0] = odklad;
                odklad = this.edges[3];
                this.edges[3] = this.edges[0];
                this.edges[0] = odklad;
                odklad = this.edges[1];
                this.edges[1] = this.edges[4];
                this.edges[4] = odklad;
            }
            public void DPrime()
            {
                Cubie odklad = this.corners[4];
                this.corners[4] = this.corners[7];
                this.corners[7] = this.corners[6];
                this.corners[6] = this.corners[5];
                this.corners[5] = odklad;
                odklad = this.edges[6];
                this.edges[6] = this.edges[7];
                this.edges[7] = this.edges[9];
                this.edges[9] = this.edges[10];
                this.edges[10] = odklad;
                edges[6].ChangeEdgeOririentation();
                edges[7].ChangeEdgeOririentation();
                edges[10].ChangeEdgeOririentation();
                edges[9].ChangeEdgeOririentation();
            }
            public void D()
            {
                Cubie odklad = this.corners[4];
                this.corners[4] = this.corners[5];
                this.corners[5] = this.corners[6];
                this.corners[6] = this.corners[7];
                this.corners[7] = odklad;
                odklad = this.edges[6];
                this.edges[6] = this.edges[10];
                this.edges[10] = this.edges[9];
                this.edges[9] = this.edges[7];
                this.edges[7] = odklad;
                edges[6].ChangeEdgeOririentation();
                edges[10].ChangeEdgeOririentation();
                edges[7].ChangeEdgeOririentation();
                edges[9].ChangeEdgeOririentation();
            }
            public void D2()
            {
                Cubie odklad = this.corners[4];
                this.corners[4] = this.corners[6];
                this.corners[6] = odklad;
                odklad = this.corners[7];
                this.corners[7] = this.corners[5];
                this.corners[5] = odklad;
                odklad = this.edges[6];
                this.edges[6] = this.edges[9];
                this.edges[9] = odklad;
                odklad = this.edges[10];
                this.edges[10] = this.edges[7];
                this.edges[7] = odklad;
            }
            public void R()
            {
                Cubie odklad = this.corners[1];
                this.corners[1] = this.corners[2];
                this.corners[2] = this.corners[7];
                this.corners[7] = this.corners[6];
                this.corners[6] = odklad;
                this.corners[2].ChangeCornerOririentation(2);
                this.corners[1].ChangeCornerOririentation(1);
                this.corners[6].ChangeCornerOririentation(2);
                this.corners[7].ChangeCornerOririentation(1);
                odklad = this.edges[3];
                this.edges[3] = this.edges[11];
                this.edges[11] = this.edges[6];
                this.edges[6] = this.edges[8];
                this.edges[8] = odklad;
            }
            public void RPrime()
            {
                Cubie odklad = this.corners[1];
                this.corners[1] = this.corners[6];
                this.corners[6] = this.corners[7];
                this.corners[7] = this.corners[2];
                this.corners[2] = odklad;
                this.corners[2].ChangeCornerOririentation(2);
                this.corners[1].ChangeCornerOririentation(1);
                this.corners[6].ChangeCornerOririentation(2);
                this.corners[7].ChangeCornerOririentation(1);
                odklad = this.edges[3];
                this.edges[3] = this.edges[8];
                this.edges[8] = this.edges[6];
                this.edges[6] = this.edges[11];
                this.edges[11] = odklad;
            }
            public void R2()
            {
                Cubie odklad = this.corners[1];
                this.corners[1] = this.corners[7];
                this.corners[7] = odklad;
                odklad = this.corners[2];
                this.corners[2] = this.corners[6];
                this.corners[6] = odklad;
                odklad = this.edges[6];
                this.edges[6] = this.edges[3];
                this.edges[3] = odklad;
                odklad = this.edges[11];
                this.edges[11] = this.edges[8];
                this.edges[8] = odklad;
            }
            public void LPrime()
            {
                Cubie odklad = this.corners[0];
                this.corners[0] = this.corners[3];
                this.corners[3] = this.corners[4];
                this.corners[4] = this.corners[5];
                this.corners[5] = odklad;
                this.corners[3].ChangeCornerOririentation(1);
                this.corners[0].ChangeCornerOririentation(2);
                this.corners[5].ChangeCornerOririentation(1);
                this.corners[4].ChangeCornerOririentation(2);
                odklad = this.edges[0];
                this.edges[0] = this.edges[5];
                this.edges[5] = this.edges[9];
                this.edges[9] = this.edges[2];
                this.edges[2] = odklad;
            }
            public void L()
            {
                Cubie odklad = this.corners[0];
                this.corners[0] = this.corners[5];
                this.corners[5] = this.corners[4];
                this.corners[4] = this.corners[3];
                this.corners[3] = odklad;
                this.corners[3].ChangeCornerOririentation(1);
                this.corners[0].ChangeCornerOririentation(2);
                this.corners[5].ChangeCornerOririentation(1);
                this.corners[4].ChangeCornerOririentation(2);
                odklad = this.edges[0];
                this.edges[0] = this.edges[5];
                this.edges[5] = this.edges[9];
                this.edges[9] = this.edges[2];
                this.edges[2] = odklad;
            }
            public void L2()
            {
                Cubie odklad = this.corners[0];
                this.corners[0] = this.corners[4];
                this.corners[4] = odklad;
                odklad = this.corners[3];
                this.corners[3] = this.corners[5];
                this.corners[5] = odklad;
                odklad = this.edges[5];
                this.edges[5] = this.edges[2];
                this.edges[2] = odklad;
                odklad = this.edges[0];
                this.edges[0] = this.edges[9];
                this.edges[9] = odklad;
            }
            public void F()
            {
                Cubie odklad = this.corners[2];
                this.corners[2] = this.corners[3];
                this.corners[3] = this.corners[4];
                this.corners[4] = this.corners[7];
                this.corners[7] = odklad;
                this.corners[2].ChangeCornerOririentation(1);
                this.corners[3].ChangeCornerOririentation(2);
                this.corners[4].ChangeCornerOririentation(1);
                this.corners[7].ChangeCornerOririentation(2);
                odklad = this.edges[1];
                this.edges[1] = this.edges[2];
                this.edges[2] = this.edges[10];
                this.edges[10] = this.edges[11];
                this.edges[11] = odklad;
                
            }
            public void FPrime()
            {
                Cubie odklad = this.corners[2];
                this.corners[2] = this.corners[7];
                this.corners[7] = this.corners[4];
                this.corners[4] = this.corners[3];
                this.corners[3] = odklad;
                this.corners[2].ChangeCornerOririentation(1);
                this.corners[3].ChangeCornerOririentation(2);
                this.corners[4].ChangeCornerOririentation(1);
                this.corners[7].ChangeCornerOririentation(2);
                odklad = this.edges[1];
                this.edges[1] = this.edges[11];
                this.edges[11] = this.edges[10];
                this.edges[10] = this.edges[2];
                this.edges[2] = odklad;
            }
            public void F2()
            {
                Cubie odklad = this.corners[2];
                this.corners[2] = this.corners[4];
                this.corners[4] = odklad;
                odklad = this.corners[3];
                this.corners[3] = this.corners[7];
                this.corners[7] = odklad;
                odklad = this.edges[1];
                this.edges[1] = this.edges[10];
                this.edges[10] = odklad;
                odklad = this.edges[2];
                this.edges[2] = this.edges[11];
                this.edges[11] = odklad;
            }
            public void BPrime()
            {
                Cubie odklad = this.corners[1];
                this.corners[1] = this.corners[0];
                this.corners[0] = this.corners[5];
                this.corners[5] = this.corners[6];
                this.corners[6] = odklad;
                this.corners[1].ChangeCornerOririentation(2);
                this.corners[0].ChangeCornerOririentation(1);
                this.corners[5].ChangeCornerOririentation(2);
                this.corners[6].ChangeCornerOririentation(1);
                odklad = this.edges[4];
                this.edges[4] = this.edges[5];
                this.edges[5] = this.edges[7];
                this.edges[7] = this.edges[8];
                this.edges[8] = odklad;
            }
            public void B()
            {
                Cubie odklad = this.corners[1];
                this.corners[1] = this.corners[6];
                this.corners[6] = this.corners[5];
                this.corners[5] = this.corners[0];
                this.corners[0] = odklad;
                this.corners[1].ChangeCornerOririentation(2);
                this.corners[0].ChangeCornerOririentation(1);
                this.corners[5].ChangeCornerOririentation(2);
                this.corners[6].ChangeCornerOririentation(1);
                odklad = this.edges[4];
                this.edges[4] = this.edges[8];
                this.edges[8] = this.edges[7];
                this.edges[7] = this.edges[5];
                this.edges[5] = odklad;
            }
            public void B2()
            {
                Cubie odklad = this.corners[1];
                this.corners[1] = this.corners[5];
                this.corners[5] = odklad;
                odklad = this.corners[0];
                this.corners[0] = this.corners[6];
                this.corners[6] = odklad;
                odklad = this.edges[4];
                this.edges[4] = this.edges[7];
                this.edges[7] = odklad;
                odklad = this.edges[8];
                this.edges[8] = this.edges[5];
                this.edges[5] = odklad;
            }
        }
    }
}
