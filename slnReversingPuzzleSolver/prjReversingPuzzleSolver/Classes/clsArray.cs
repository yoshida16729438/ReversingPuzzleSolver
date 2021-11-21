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
        private int m_intBase;

        #region ●Property

        /// <summary>
        /// 【合同式の法】
        /// </summary>
        public int intBase
        {
            get { return this.m_intBase; }
        }

        /// <summary>
        /// 【座標でのアクセス】
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public new int this[int y,int x]
        {
            get { return base[y, x]; }
            set { base[y, x] = value % this.m_intBase; }
        }

        /// <summary>
        /// 【インデックスでのアクセス】
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new int this[int index]
        {
            get { return base[index]; }
            set { base[index] = value % this.m_intBase; }
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
            if (A.intWidth != B.intWidth || A.intHeight != B.intHeight || A.m_intBase != B.m_intBase)
            {
                throw new ArgumentException("配列の幅、高さ、合同式の法のいずれかが異なります。");
            }
            var Ans = new clsIntArray(A.intWidth, A.intHeight, A.m_intBase);

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
            var Ans = new clsIntArray(A.intWidth, A.intHeight, A.m_intBase);

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
            this.m_intBase = bas;

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
            var insCopy = new clsIntArray(this.intWidth, this.intHeight, this.m_intBase);
            
            for(int i = 0; i < this.intLen; i++)
            {
                insCopy[i] = this[i];
            }
            return insCopy;
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
    /// 【左辺・右辺のペア】
    /// </summary>
    public class clsBoardAnsPair
    {

        /// <summary>
        /// 【左辺（最初はクリック時の影響範囲を記述する）】
        /// </summary>
        private clsIntArray m_insLeft;

        /// <summary>
        /// 【右辺（最初は結果と初期値の差分を設定する）】
        /// </summary>
        private clsIntArray m_insRight;

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
        public static clsBoardAnsPair operator +(clsBoardAnsPair A,clsBoardAnsPair B)
        {
            if (A.m_insLeft.intWidth != B.m_insLeft.intWidth || A.m_insLeft.intHeight != B.m_insLeft.intHeight || A.m_insLeft.intBase != B.m_insLeft.intBase)
            {
                throw new ArgumentException("配列の幅、高さ、合同式の法のいずれかが異なります。");
            }

            var Ans = new clsBoardAnsPair(A.m_insLeft.intWidth, A.m_insLeft.intHeight, A.m_insLeft.intBase);
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
        public static clsBoardAnsPair operator *(clsBoardAnsPair A,int B)
        {
            var Ans = new clsBoardAnsPair(A.insLeft.intWidth, A.insLeft.intHeight, A.insLeft.intBase);
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
        public static clsBoardAnsPair operator *(int A,clsBoardAnsPair B)
        {
            return B * A;
        }

        /// <summary>
        /// 【-】
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static clsBoardAnsPair operator -(clsBoardAnsPair A,clsBoardAnsPair B)
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
        public clsBoardAnsPair(int width,int height,int bas)
        {
            this.m_insLeft = new clsIntArray(width, height, bas);
            this.m_insRight = new clsIntArray(width, height, bas);
        }
    }

    /// <summary>
    /// 【Swap可能なリスト】
    /// </summary>
    /// <typeparam name="T">型パラメータ</typeparam>
    public class clsSwapList<T>:List<T>{

        /// <summary>
        /// 【Swap】
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public void subSwap(int index1,int index2)
        {
            var temp = this[index1];
            this[index1] = this[index2];
            this[index2] = temp;
        }
    }
}
