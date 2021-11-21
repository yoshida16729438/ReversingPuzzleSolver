using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjReversingPuzzleSolver.Classes
{
    static class clsUtils
    {
        /// <summary>
        /// メッセージボックスの種類
        /// </summary>
        public enum Enum_MsgBoxStyle
        {
            Information,
            Exclamation,
            Critical,
            Question
        }

        private static Dictionary<Enum_MsgBoxStyle, MessageBoxButtons> m_dicMsgBoxButton;
        private static Dictionary<Enum_MsgBoxStyle, MessageBoxIcon> m_dicMsgBoxIcon;
        private static Dictionary<Enum_MsgBoxStyle, MessageBoxDefaultButton> m_dicMsgBoxDefButton;

        /// <summary>
        /// メッセージボックス表示
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="enmIcon"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool blnShowMsgBox(string msg,Enum_MsgBoxStyle enmIcon,string title = "")
        {
            string cap = (title == string.Empty ? System.Reflection.Assembly.GetExecutingAssembly().GetName().Name : title);
            var insResult = MessageBox.Show(msg, cap, m_dicMsgBoxButton[enmIcon], m_dicMsgBoxIcon[enmIcon], m_dicMsgBoxDefButton[enmIcon]);
            return insResult == DialogResult.OK || insResult == DialogResult.Yes;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public static void subInit()
        {
            m_dicMsgBoxButton = new Dictionary<Enum_MsgBoxStyle, MessageBoxButtons>();
            m_dicMsgBoxDefButton = new Dictionary<Enum_MsgBoxStyle, MessageBoxDefaultButton>();
            m_dicMsgBoxIcon = new Dictionary<Enum_MsgBoxStyle, MessageBoxIcon>();

            m_dicMsgBoxButton.Add(Enum_MsgBoxStyle.Information, MessageBoxButtons.OK);
            m_dicMsgBoxButton.Add(Enum_MsgBoxStyle.Exclamation, MessageBoxButtons.OK);
            m_dicMsgBoxButton.Add(Enum_MsgBoxStyle.Critical, MessageBoxButtons.OK);
            m_dicMsgBoxButton.Add(Enum_MsgBoxStyle.Question, MessageBoxButtons.YesNo);

            m_dicMsgBoxDefButton.Add(Enum_MsgBoxStyle.Information, MessageBoxDefaultButton.Button1);
            m_dicMsgBoxDefButton.Add(Enum_MsgBoxStyle.Exclamation, MessageBoxDefaultButton.Button1);
            m_dicMsgBoxDefButton.Add(Enum_MsgBoxStyle.Critical, MessageBoxDefaultButton.Button1);
            m_dicMsgBoxDefButton.Add(Enum_MsgBoxStyle.Question, MessageBoxDefaultButton.Button2);

            m_dicMsgBoxIcon.Add(Enum_MsgBoxStyle.Information, MessageBoxIcon.Information);
            m_dicMsgBoxIcon.Add(Enum_MsgBoxStyle.Exclamation, MessageBoxIcon.Exclamation);
            m_dicMsgBoxIcon.Add(Enum_MsgBoxStyle.Critical, MessageBoxIcon.Error);
            m_dicMsgBoxIcon.Add(Enum_MsgBoxStyle.Question, MessageBoxIcon.Question);
        }
    }
}
