using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjReversingPuzzleSolver.Classes
{
    class clsSolve
    {
        public clsIntArray insInitial;
        public clsIntArray insFinal;
        public List<clsIntArray> lstAns;
        public int intTurn;

        private bool m_blnInRange(int x,int y)
        {
            return x >= 0 && x < this.insInitial.intWidth && y >= 0 && y < this.insInitial.intHeight;
        }

        public void subSolve()
        {
            this.lstAns = new List<clsIntArray>();

            //縦：マス数、横：マス数+1（右辺分）の二次元配列を用意
            //（変数の番号、マスの番号）の順で使用
            int size = this.insInitial.intLen;
            var insArray = new clsIntArray(size+1, size,this.intTurn);

            var lstTarget = new List<clsPair>();
            lstTarget.Add(new clsPair(0, 0));
            lstTarget.Add(new clsPair(0,-1));
            lstTarget.Add(new clsPair(0, 1));
            lstTarget.Add(new clsPair(-1, 0));
            lstTarget.Add(new clsPair(1, 0));
            lstTarget.Add(new clsPair(-1, -1));
            lstTarget.Add(new clsPair(-1, 1));
            lstTarget.Add(new clsPair(1, -1));
            lstTarget.Add(new clsPair(1, 1));

            //必要な項に1を立てる
            for(int y = 0; y < this.insInitial.intHeight; y++)
            {
                for(int x = 0; x < this.insInitial.intWidth; x++)
                {
                    for(int i = 0; i <= this.intTurn; i++)
                    {
                        if (this.m_blnInRange(x + lstTarget[i].v1, y + lstTarget[i].v2))
                        {
                            insArray[(y + lstTarget[i].v2) * this.insInitial.intWidth + x + lstTarget[i].v1, y * this.insInitial.intWidth + x] = 1;
                        }
                    }
                    insArray[size, y * this.insInitial.intWidth + x] = (this.insInitial[x, y] - this.insFinal[x, y]) % this.insInitial.intBase;
                }
            }

            insArray.subPrint();
            
        }

        private class clsPair
        {
            public int v1
            {
                get;
            }

            public int v2
            {
                get;
            }
            public clsPair(int v1, int v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
        }
    }
}
