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

        /// <summary>
        /// 【最大公約数】
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int m_intGCD(int a,int b)
        {
            if (a < b) clsUtils.subSwap(ref a, ref b);
            if (a % b == 0) return b;
            else return this.m_intGCD(b, a % b);
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
                            insMatrix.insEquation[y, x].insLeft[y + lstRelated[i].Y, x + lstRelated[i].X] = 1;
                        }
                    }

                    //右辺：最初と最後の差分
                    insMatrix.insEquation[y, x].insRight[y, x] = this.insFinal[y, x] - this.insInitial[y, x];
                }
            }

            insMatrix.subOutputFile("初期状態");

            //基準にする位置（3なら3項目目まで掃き出し終わってることになる）
            for(int intKijun = 0; intKijun < insMatrix.intLen; intKijun++)
            {
                //現在行は1、あるいは1にできる（した）か、または0しかないので不要？
                if(this.m_blnContinueCalc(ref insMatrix, intKijun))
                {
                    //現在位置が0→処理せず探索続行
                    if (insMatrix.insEquation[intKijun].insLeft[intKijun] == 0) continue;

                    //現在行1→他の行を0にするよう足し引きする
                    this.m_subMergeEquationTo0(ref insMatrix, intKijun);
                }
                else
                {
                    clsUtils.blnShowMsgBox("探索中止", clsUtils.Enum_MsgBoxStyle.Critical);
                    //探索中止
                    return;
                }
            }

            insMatrix.subOutputFile("操作終了");
            clsUtils.blnShowMsgBox("探索終了", clsUtils.Enum_MsgBoxStyle.Information);
        }

        /// <summary>
        /// 【計算続行可能？（続行可能な状態に変更する）】
        /// </summary>
        /// <param name="insMatrix"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool m_blnContinueCalc(ref clsMatrix insMatrix,int index)
        {
            int i, j = 0;
            
            //指定位置がすでに1ならそのままでOK
            if (insMatrix.insEquation[index].insLeft[index] == 1) return true;

            //1がどこかにあれば入れ替えてOK
            for(i = index + 1; i < insMatrix.intLen; i++)
            {
                if (insMatrix.insEquation[i].insLeft[index] == 1)
                {
                    insMatrix.subSwap(index, i);
                    insMatrix.subOutputFile("入れ替え実施（" + i.ToString() + "⇔" + index.ToString() + "）");
                    return true;
                }
            }

            //1がない
            //0以外をリストアップ
            var lstVal = new List<KeyValuePair<int, int>>();
            for (i = index; i < insMatrix.intLen; i++)
            {
                if (insMatrix.insEquation[i].insLeft[index] > 1) lstVal.Add(new KeyValuePair<int, int>(i, insMatrix.insEquation[i].insLeft[index]));
            }

            //リストが0件→全行が0なので何もせず次の行に進んでよい
            if (lstVal.Count == 0) return true;

            //互いに素の組を選んで係数1の項を作る
            bool blnFind = false;
            for (i = 0; i < lstVal.Count - 1; i++)
            {
                for (j = i + 1; j < lstVal.Count; j++)
                {
                    if (this.m_intGCD(lstVal[i].Value, lstVal[j].Value) == 1)
                    {
                        blnFind = true;
                        break;
                    }
                }
                if (blnFind) break;
            }

            //互いに素の組が見つからない→探索不可
            if (!blnFind) return false;

            //組が見つかった→マージ
            this.m_subMergeEquationTo1(ref insMatrix, i, j, index);

            return true;
        }

        /// <summary>
        /// 【係数が1になるようにマージ】
        /// </summary>
        /// <param name="insMatrix">行列</param>
        /// <param name="index1">マージ対称の行インデックス1</param>
        /// <param name="index2">マージ対称の行インデックス2</param>
        /// <param name="mergeIndex">マージ対称の列インデックス</param>
        private void m_subMergeEquationTo1(ref clsMatrix insMatrix,int index1,int index2,int mergeIndex)
        {
            //1にしたい元の値を取得（a>bとする）
            int a, b;
            if (insMatrix.insEquation[index1].insLeft[mergeIndex] < insMatrix.insEquation[index2].insLeft[mergeIndex])
            {
                clsUtils.subSwap(ref index1, ref index2);
            }
            a = insMatrix.insEquation[index1].insLeft[mergeIndex];
            b = insMatrix.insEquation[index2].insLeft[mergeIndex];

            /*      aの係数 bの係数 実際の値
             * 第1項  x1      y1      v1
             * 第2項  x2      y2      v2
             * 
             */
            int x1, x2, y1, y2, v1, v2;
            x1 = 1;y1 = 0;x2 = 0;y2 = 1;v1 = a;v2 = b;
            while (v2 > 1)
            {
                int div = v1 / v2;
                //x2,y2,v2をそれぞれx1,y1,v1に移動
                clsUtils.subSwap(ref x1, ref x2);
                clsUtils.subSwap(ref y1, ref y2);
                clsUtils.subSwap(ref v1, ref v2);

                //x2,y2,v2を更新
                x2 -= div * x1;
                y2 -= div * y1;
                v2 = a * x2 + b * y2;
            }

            //a*x2+b*y2=1となっているはず
            System.Diagnostics.Debug.Assert(a * x2 + b * y2 == 1);

            //係数が求まったので行列に反映
            //x2：index1の係数、y2:index2の係数
            insMatrix.insEquation[index1] = insMatrix.insEquation[index1] * x2 + insMatrix.insEquation[index2] * y2;

            //現在行と交換
            insMatrix.subSwap(index1, mergeIndex);

            insMatrix.subOutputFile(string.Format("{0}と{1}をマージ→{2}と交換：{0}×({3})+{1}×({4})", index1, index2, mergeIndex, x2, y2));
        }

        /// <summary>
        /// 【指定列を指定行以外0になるよう足し引き】
        /// </summary>
        /// <param name="insMatrix">行列</param>
        /// <param name="mergeIndex">指定行（=列）</param>
        private void m_subMergeEquationTo0(ref clsMatrix insMatrix,int mergeIndex)
        {
            for(int i = 0; i < insMatrix.intLen; i++)
            {
                if (i == mergeIndex) continue;
                if (insMatrix.insEquation[i].insLeft[mergeIndex] == 0) continue;

                insMatrix.insEquation[i] -= insMatrix.insEquation[mergeIndex] * insMatrix.insEquation[i].insLeft[mergeIndex];

                insMatrix.subOutputFile(string.Format("マージ（列（=基準行） 行：{1}）", mergeIndex, i));
            }
        }

    }
}
