using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjReversingPuzzleSolver.Classes
{
    /// <summary>
    /// 【解答探索クラス（実験）】
    /// </summary>
    class clsSolve
    {
        /// <summary>
        /// 【初期状態】
        /// </summary>
        public clsIntArray insInitial;

        /// <summary>
        /// 【最終状態】
        /// </summary>
        public clsIntArray insFinal;

        /// <summary>
        /// 【解答リスト】
        /// </summary>
        public List<clsIntArray> lstAns;

        /// <summary>
        /// 【回転方法】
        /// </summary>
        public Forms.Enum_TurnMode enmTurnMode;

        /// <summary>
        /// 【座標は存在するか？】
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool m_blnInRange(int x,int y)
        {
            return x >= 0 && x < this.insInitial.intWidth && y >= 0 && y < this.insInitial.intHeight;
        }

        public void subSolve()
        {
            this.lstAns = new List<clsIntArray>();


            //クリックしたときに影響が出る範囲のリスト
            //着目している位置からの相対座標としてリストアップ
            var lstRelated = new List<System.Drawing.Point>();
            lstRelated.Add(new System.Drawing.Point(0, 0));     //自分自身
            lstRelated.Add(new System.Drawing.Point(-1, 0));    //左隣
            lstRelated.Add(new System.Drawing.Point(1, 0));     //右隣
            lstRelated.Add(new System.Drawing.Point(0, -1));    //真上
            lstRelated.Add(new System.Drawing.Point(0, 1));     //真下
            lstRelated.Add(new System.Drawing.Point(-1, -1));   //左上
            lstRelated.Add(new System.Drawing.Point(-1, 1));    //左下
            lstRelated.Add(new System.Drawing.Point(1, -1));    //右上
            lstRelated.Add(new System.Drawing.Point(1, 1));     //右下

            //行列作成
            var insMatrix = new Classes.clsMatrix(this.insInitial.intWidth, this.insInitial.intHeight, this.insInitial.intBase);
            for(int y = 0; y < this.insInitial.intHeight; y++)
            {
                for(int x = 0; x < this.insInitial.intWidth; x++)
                {
                    //各マスについて方程式作成
                    //左辺：影響範囲記述
                    for(int i = 0; i <= (int)this.enmTurnMode; i++)
                    {
                        //該当のマスがout of rangeでなければフラグを立てる
                        if (this.m_blnInRange(x + lstRelated[i].X, y + lstRelated[i].Y))
                        {
                            insMatrix.insMatrix[y, x].insLeft[y + lstRelated[i].Y, x + lstRelated[i].X] = 1;
                        }
                    }

                    //右辺：最初と最後の差分
                    insMatrix.insMatrix[y, x].insRight[y, x] = this.insFinal[y, x] - this.insInitial[y, x];
                }
            }

            insMatrix.subOutputFile("初期状態");

        }

    }
}
