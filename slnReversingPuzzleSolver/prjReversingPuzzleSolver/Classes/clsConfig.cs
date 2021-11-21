using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace prjReversingPuzzleSolver.Classes
{
    static class clsConfig
    {
        #region ●const

        /// <summary>
        /// コンフィグファイル名
        /// </summary>
        private const string M_STR_CONFIG_FILE_NAME = "Config.RC";

        #region ●項目名

        /// <summary>
        /// 項目名（最小サイズ）
        /// </summary>
        private const string M_STR_NAME_MINSIZE = "MinimumSize";

        /// <summary>
        /// 項目名（最大サイズ）
        /// </summary>
        private const string M_STR_NAME_MAXSIZE = "MaximumSize";

        /// <summary>
        /// 項目名（ピクセルサイズ）
        /// </summary>
        private const string M_STR_NAME_PIXSIZE = "PixelSize";

        /// <summary>
        /// 項目名（カラーコード）
        /// </summary>
        private const string M_STR_NAME_COLCODE = "ColorCode";

        #endregion

        #region ●初期値

        /// <summary>
        /// 盤面最小サイズ
        /// </summary>
        private const int M_INT_DEF_MIN_BOARD_SIZE = 2;

        /// <summary>
        /// 盤面最大サイズ
        /// </summary>
        private const int M_INT_DEF_MAX_BOARD_SIZE = 5;

        /// <summary>
        /// 盤面ピクセルサイズ
        /// </summary>
        private const int M_INT_DEF_PIXEL_SIZE = 50;

        /// <summary>
        /// カラーコード文字列
        /// </summary>
        private static readonly string[] m_str_Def_Color_Code = { "#FFFFFF", "#000000","#FF0000","#00FF00","#0000FF" };

        #endregion

        #endregion

        #region ●valuables

        /// <summary>
        /// 色リスト
        /// </summary>
        private static List<Color> m_lstColor;

        /// <summary>
        /// 盤面の最小サイズ
        /// </summary>
        private static int m_intMinBoardSize;

        /// <summary>
        /// 盤面の最大サイズ
        /// </summary>
        private static int m_intMaxBoardSize;

        /// <summary>
        /// 盤面ピクセルサイズ
        /// </summary>
        private static int m_intPixelSize;

        #endregion

        #region ●Property

        /// <summary>
        /// 色リスト
        /// </summary>
        public static List<Color> lstColor
        {
            get { return m_lstColor; }
        }

        /// <summary>
        /// 盤面最小サイズ
        /// </summary>
        public static int intMinBoardSize
        {
            get { return m_intMinBoardSize; }
        }

        /// <summary>
        /// 盤面最大サイズ
        /// </summary>
        public static int intMaxBoardSize
        {
            get { return m_intMaxBoardSize; }
        }

        /// <summary>
        /// 盤面ピクセルサイズ
        /// </summary>
        public static int intPixelSize
        {
            get { return m_intPixelSize; }
        }

        #endregion

        #region ●ロード

        /// <summary>
        /// コンフィグロード
        /// </summary>
        public static void subLoad()
        {

            m_lstColor = new List<Color>();

            //無効値設定
            m_subSetUnuseableVal();

            //ファイルがない場合は初期値で作成
            if (!System.IO.File.Exists(M_STR_CONFIG_FILE_NAME)) m_subOuputDefaultFile();

            using(var insReader=new System.IO.StreamReader(M_STR_CONFIG_FILE_NAME))
            {
                while (insReader.Peek() > -1)
                {
                    string[] s = insReader.ReadLine().Split('=');
                    switch (s[0])
                    {
                        case M_STR_NAME_MINSIZE:
                            m_intMinBoardSize = m_intReadInteger(s[1]);
                            break;
                        case M_STR_NAME_MAXSIZE:
                            m_intMaxBoardSize = m_intReadInteger(s[1]);
                            break;
                        case M_STR_NAME_PIXSIZE:
                            m_intPixelSize = m_intReadInteger(s[1]);
                            break;
                        case M_STR_NAME_COLCODE:
                            m_subReadColor(s[1]);
                            break;
                    }
                }
                insReader.Close();
            }

            //取得内容チェック
            m_subCheck();
        }

        /// <summary>
        /// 入力された文字が数値か判定し値を返す
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        private static int m_intReadInteger(string strVal)
        {
            return int.TryParse(strVal, out int intVal) ? intVal : 0;
        }

        /// <summary>
        /// カラーコード解釈
        /// </summary>
        /// <param name="strVal"></param>
        private static void m_subReadColor(string strVal)
        {
            if(int.TryParse(strVal.Replace("#", ""),System.Globalization.NumberStyles.HexNumber,null,out int intVal))
            {
                if (intVal >= 0 && intVal <= 0xFFFFFF) m_lstColor.Add(ColorTranslator.FromWin32(intVal));
            }
        }

        /// <summary>
        /// コンフィグ内容チェック
        /// </summary>
        private static void m_subCheck()
        {
            string s = string.Empty;

            //最小・最大の大小関係
            if (m_intMaxBoardSize < m_intMinBoardSize)
            {
                s += "・盤面最大・最小サイズの大小関係\n";
                m_intMinBoardSize = M_INT_DEF_MIN_BOARD_SIZE;
                m_intMaxBoardSize = M_INT_DEF_MAX_BOARD_SIZE;
            }

            //最小サイズの制限
            if (m_intMinBoardSize < 2)
            {
                s += "・盤面最小サイズ\n";
                m_intMinBoardSize = M_INT_DEF_MIN_BOARD_SIZE;
            }

            //最大サイズの制限
            if (m_intMaxBoardSize < 2)
            {
                s += "・盤面最大サイズ\n";
                m_intMaxBoardSize = M_INT_DEF_MAX_BOARD_SIZE;
            }

            //カラーコード2種類未満
            if (m_lstColor.Count < 2)
            {
                s += "・カラーコード\n";
                m_lstColor.Clear();
                foreach(string strVal in m_str_Def_Color_Code)
                {
                    m_lstColor.Add(ColorTranslator.FromWin32(int.Parse(strVal.Replace("#",""), System.Globalization.NumberStyles.HexNumber)));
                }
            }

            //カラーコード重複
            bool blnDuplicate = false;
            for(int i = 0; i < m_lstColor.Count - 1; i++)
            {
                for(int j = i+1; j < m_lstColor.Count; j++)
                {
                    if (m_lstColor[i] == m_lstColor[j])
                    {
                        blnDuplicate = true;
                        break;
                    }
                }
                if (blnDuplicate) break;
            }

            if (blnDuplicate)
            {
                s += "・カラーコード重複\n";
                m_lstColor.Clear();
                foreach (string strVal in m_str_Def_Color_Code)
                {
                    m_lstColor.Add(ColorTranslator.FromWin32(int.Parse(strVal.Replace("#", ""), System.Globalization.NumberStyles.HexNumber)));
                }
            }

            if (s != string.Empty) clsUtils.blnShowMsgBox("以下の項目に異常があったため、初期値を設定しました。\n" + s, clsUtils.Enum_MsgBoxStyle.Information);
        }

        #endregion

        #region ●初期値（無効値）設定

        private static void m_subSetUnuseableVal()
        {
            m_intMinBoardSize = 0;
            m_intMaxBoardSize = 0;
            m_intPixelSize = 0;
        }

        #endregion

        #region ●初期値ファイル出力

        /// <summary>
        /// 初期値ファイル出力
        /// </summary>
        private static void m_subOuputDefaultFile()
        {
            var lstConfig = new List<string>();
            lstConfig.Add("#コンフィグファイル");
            lstConfig.Add("#初期値に戻したい場合は、本ファイルを削除してソフトを起動してください。");

            lstConfig.Add("#盤面最小サイズ");
            lstConfig.Add("#2以上かつ最大サイズ以下で設定してください。");
            lstConfig.Add(M_STR_NAME_MINSIZE + '=' + M_INT_DEF_MIN_BOARD_SIZE);
            lstConfig.Add("");

            lstConfig.Add("#盤面最大サイズ");
            lstConfig.Add("#2以上かつ最小サイズ以上で設定してください。");
            lstConfig.Add(M_STR_NAME_MAXSIZE + '=' + M_INT_DEF_MAX_BOARD_SIZE);
            lstConfig.Add("");

            lstConfig.Add("#ピクセルサイズ");
            lstConfig.Add("#1以上で設定してください。（30以上推奨）");
            lstConfig.Add(M_STR_NAME_PIXSIZE + '=' + M_INT_DEF_PIXEL_SIZE);
            lstConfig.Add("");
            lstConfig.Add("#カラーコード");
            lstConfig.Add("#RGBを16進数で先頭に「#」を付けてください。");
            foreach(string s in m_str_Def_Color_Code)
            {
                lstConfig.Add(M_STR_NAME_COLCODE + '=' + s);
            }
            lstConfig.Add("");

            using(var insWriter=new System.IO.StreamWriter(M_STR_CONFIG_FILE_NAME, false))
            {
                foreach(string s in lstConfig)
                {
                    insWriter.WriteLine(s);
                }
                insWriter.Flush();
                insWriter.Close();
            }

        }

        #endregion

    }
}
