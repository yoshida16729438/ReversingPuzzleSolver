using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjReversingPuzzleSolver.Classes
{
    /// <summary>
    /// 【行列演算用一次元配列】
    /// </summary>
    public class clsArray<T>
    {

        #region ●変数

        /// <summary>
        /// 【幅】
        /// </summary>
        private readonly int m_intWidth;

        /// <summary>
        /// 【高さ】
        /// </summary>
        private readonly int m_intHeight;

        /// <summary>
        /// 【値】
        /// </summary>
        private readonly T[] m_tVal;

        #endregion

        #region ●Property

        /// <summary>
        /// 【インデックスで値を取得・設定】
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.m_tVal[index]; }
            set { this.m_tVal[index] = value; }
        }

        /// <summary>
        /// 【座標で値を取得・設定】
        /// </summary>
        /// <param name="y">y座標</param>
        /// <param name="x">x座標</param>
        /// <returns></returns>
        public T this[int y, int x]
        {
            get { return this.m_tVal[y * this.m_intWidth + x]; }
            set { this.m_tVal[y * this.m_intWidth + x] = value; }
        }

        /// <summary>
        /// 【幅を取得】
        /// </summary>
        public int intWidth
        {
            get { return this.m_intWidth; }
        }

        /// <summary>
        /// 【高さを取得】
        /// </summary>
        public int intHeight
        {
            get { return this.m_intHeight; }
        }

        /// <summary>
        /// 【要素数を取得】
        /// </summary>
        public int intLen
        {
            get { return this.m_intHeight * this.m_intWidth; }
        }

        #endregion

        /// <summary>
        /// 【New】
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public clsArray(int width, int height)
        {
            this.m_intWidth = width;
            this.m_intHeight = height;

            this.m_tVal = new T[width * height];

        }

    }

    /// <summary>
    /// 【int型配列】
    /// </summary>
    public class clsIntArray : clsArray<int>
    {

        /// <summary>
        /// 【合同式の法】
        /// </summary>
        public readonly int intBase;

        #region ●Property

        /// <summary>
        /// 【座標でのアクセス】
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public new int this[int y,int x]
        {
            get { return base[y, x]; }
            set { base[y, x] = (value % this.intBase + this.intBase) % this.intBase; }
        }

        /// <summary>
        /// 【インデックスでのアクセス】
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new int this[int index]
        {
            get { return base[index]; }
            set { base[index] = (value % this.intBase + this.intBase) % this.intBase; }
        }

        #endregion

        #region ●Operator

        /// <summary>
        /// 【+】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsIntArray operator +(clsIntArray A, clsIntArray B)
        {
            if (A.intWidth != B.intWidth || A.intHeight != B.intHeight || A.intBase != B.intBase)
            {
                throw new ArgumentException("配列の幅、高さ、合同式の法のいずれかが異なります。");
            }
            var Ans = new clsIntArray(A.intWidth, A.intHeight, A.intBase);

            for (int i = 0; i < A.intWidth * A.intHeight; i++)
            {
                Ans[i] = A[i] + B[i];
            }

            return Ans;
        }

        /// <summary>
        /// 【-】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsIntArray operator -(clsIntArray A, clsIntArray B)
        {
            return A + (-1 * B);
        }

        /// <summary>
        /// 【*】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsIntArray operator *(clsIntArray A, int B)
        {
            var Ans = new clsIntArray(A.intWidth, A.intHeight, A.intBase);

            for (int i = 0; i < A.intWidth * A.intHeight; i++)
            {
                Ans[i] = A[i] * B;
            }

            return Ans;
        }

        /// <summary>
        /// 【*】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsIntArray operator *(int A,clsIntArray B)
        {
            return B * A;
        }

        #endregion

        #region ●処理

        /// <summary>
        /// 【New】
        /// </summary>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <param name="bas">合同式の法</param>
        public clsIntArray(int width,int height,int bas):base(width,height)
        {
            this.intBase = bas;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    base[y, x] = 0;
                }
            }
        }

        /// <summary>
        /// 【コピーを作成】
        /// </summary>
        /// <returns></returns>
        public clsIntArray insCreateCopy()
        {
            var insCopy = new clsIntArray(this.intWidth, this.intHeight, this.intBase);
            
            for(int i = 0; i < this.intLen; i++)
            {
                insCopy[i] = this[i];
            }
            return insCopy;
        }

        /// <summary>
        /// 【出力用1行文字列作成】
        /// </summary>
        /// <returns></returns>
        public string strOneLine()
        {
            var insBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < this.intLen; i++) insBuilder.Append(this[i].ToString().PadLeft(3));
            return insBuilder.ToString();
        }

        /// <summary>
        /// 【出力】
        /// </summary>
        public void subPrint()
        {
            var insBuilder = new System.Text.StringBuilder();

            for (int y = 0; y < this.intHeight; y++)
            {
                for (int x = 0; x < this.intWidth; x++)
                {
                    insBuilder.Append(this[y, x].ToString() + ", ");
                }
                insBuilder.AppendLine();
            }


            System.Diagnostics.Debug.WriteLine(insBuilder.ToString());
        }

        #endregion

    }

    /// <summary>
    /// 【方程式（左辺・右辺のペア）】
    /// </summary>
    public class clsEquation
    {

        #region ●変数

        /// <summary>
        /// 【左辺（最初はクリック時の影響範囲を記述する）】
        /// </summary>
        private clsIntArray m_insLeft;

        /// <summary>
        /// 【右辺（最初は結果と初期値の差分を設定する）】
        /// </summary>
        private clsIntArray m_insRight;

        #endregion

        #region ●Property

        /// <summary>
        /// 【左辺】
        /// </summary>
        public clsIntArray insLeft
        {
            get { return this.m_insLeft; }
            //set { this.m_insLeft = value; }
        }

        /// <summary>
        /// 【右辺】
        /// </summary>
        public clsIntArray insRight
        {
            get { return this.m_insRight; }
            //set { this.m_insRight = value; }
        }

        #endregion

        #region ●Operator

        /// <summary>
        /// 【+】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsEquation operator +(clsEquation A,clsEquation B)
        {
            if (A.m_insLeft.intWidth != B.m_insLeft.intWidth || A.m_insLeft.intHeight != B.m_insLeft.intHeight || A.m_insLeft.intBase != B.m_insLeft.intBase)
            {
                throw new ArgumentException("配列の幅、高さ、合同式の法のいずれかが異なります。");
            }

            var Ans = new clsEquation(A.m_insLeft.intWidth, A.m_insLeft.intHeight, A.m_insLeft.intBase);
            Ans.m_insLeft = A.m_insLeft + B.m_insLeft;
            Ans.m_insRight = A.m_insRight + B.m_insRight;

            return Ans;
        }

        /// <summary>
        /// 【*】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsEquation operator *(clsEquation A,int B)
        {
            var Ans = new clsEquation(A.insLeft.intWidth, A.insLeft.intHeight, A.insLeft.intBase);
            Ans.m_insLeft = A.m_insLeft.insCreateCopy() * B;
            Ans.m_insRight = A.m_insRight.insCreateCopy() * B;
            return Ans;
        }

        /// <summary>
        /// 【*】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsEquation operator *(int A,clsEquation B)
        {
            return B * A;
        }

        /// <summary>
        /// 【-】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsEquation operator -(clsEquation A,clsEquation B)
        {
            return A + (-1 * B);
        }

        #endregion

        /// <summary>
        /// 【New】
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bas"></param>
        public clsEquation(int width,int height,int bas)
        {
            this.m_insLeft = new clsIntArray(width, height, bas);
            this.m_insRight = new clsIntArray(width, height, bas);
        }
    }

    /// <summary>
    /// 【行列管理クラス】
    /// </summary>
    public class clsMatrix
    {
        #region ●変数

        /// <summary>
        /// 【幅】
        /// </summary>
        public readonly int intWidth;

        /// <summary>
        /// 【高さ】
        /// </summary>
        public readonly int intHeight;

        /// <summary>
        /// 【配列長さ】
        /// </summary>
        public readonly int intLen;

        /// <summary>
        /// 【合同式の法】
        /// </summary>
        public readonly int intBase;

        /// <summary>
        /// 【行列実体】
        /// </summary>
        public clsArray<clsEquation> insEquation;

        #endregion

        #region ●処理

        /// <summary>
        /// 【New】
        /// </summary>
        /// <param name="intWidth">幅</param>
        /// <param name="intHeight">高さ</param>
        /// <param name="intBas">合同式の法</param>
        public clsMatrix(int intWidth,int intHeight,int intBas)
        {
            this.intWidth = intWidth;
            this.intHeight = intHeight;
            this.intLen = intWidth * intHeight;
            this.intBase = intBas;

            this.insEquation = new clsArray<clsEquation>(intWidth, intHeight);
            for(int i = 0; i < intWidth * intHeight; i++)
            {
                this.insEquation[i] = new clsEquation(intWidth, intHeight, intBas);
            }
        }

        /// <summary>
        /// 【インデックス入れ替え】
        /// </summary>
        /// <param name="index1">入れ替え対象インデックス1</param>
        /// <param name="index2">入れ替え対象インデックス2</param>
        public void subSwap(int index1,int index2)
        {
            var temp = this.insEquation[index1];
            this.insEquation[index1] = this.insEquation[index2];
            this.insEquation[index2] = temp;
        }

        /// <summary>
        /// 【行列を全てファイル出力】
        /// </summary>
        /// <param name="strOptional">オプション文字列</param>
        public void subOutputFile(string strOptional = "")
        {
            var insBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < this.insEquation.intLen; i++) insBuilder.AppendLine(this.insEquation[i].insLeft.strOneLine() + " = " + this.insEquation[i].insRight.strOneLine());
            
            using(var insWriter=new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Out.txt", true))
            {
                if (strOptional != string.Empty) insWriter.WriteLine(strOptional);
                insWriter.WriteLine(insBuilder.ToString());
                insWriter.Close();
            }
        }

        #endregion

    }
}
