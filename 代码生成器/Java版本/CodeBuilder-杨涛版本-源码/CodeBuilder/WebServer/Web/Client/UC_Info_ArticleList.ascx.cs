using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Esint.Common.Model;
using Esint.Common.Web;
using Esint.CodeSite.BLL;

namespace Esint.CodeSite.Web
{
    /// <summary>
    /// ģ�����ƣ� ���ؼ�
    /// ��    �ߣ���ΰͨ
    /// ��    �ڣ�2012��09��18��
    /// �޸����ڣ�
    /// �� �� �ˣ�
    /// </summary>
    public partial class UC_Info_ArticleList: BaseUserControl
    {

       #region �ؼ��¼���
        //GridView �������¼� 
        public event GridViewCommandEventHandler OnRowCommand;

        //GridView �����ݰ��¼� 
        public event GridViewRowEventHandler  OnRowDataBound;

       #endregion

       #region �ؼ�������
        ///<summary>
        ///�����
        ///<summary>
        public Guid Category
        {
            get { return (Guid)ViewState["Category"]; }
            set { ViewState["Category"] = value; }
        }
       #endregion

        #region ҳ�����

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
                //JsHelper.Window.OpenModalDialog(btn_Add, "Client/Info_ArticlePage.aspx?category=" + Category, 900, 700);
            }
        }
        #endregion

        #region GridView ���ݲ�����[�󶨣����򣬷�ҳ]

        #region  ���ݱ���

        /// <summary>
        /// ���ݱ���
        /// </summary>
        public void DataGridBinding()
        {
            //
            // �����ֶ���ҳ
            //
            PageSplit pages = new PageSplit();
            pages.IsPageView = true;
            pages.PageSize = AspNetPager1.PageSize;
            pages.PageIndex = AspNetPager1.CurrentPageIndex;

            // ��ѯ����Դ
            ReturnTable returnTable = new Info_ArticleService().GetInfo_ArticleTable(pages, SortExpression,txt_Title.Text.Trim(),Category); 

            // �󶨷�ҳ�ؼ�
            AspNetPager1.RecordCount = returnTable.PageInfo.RecordCount;
            if (AspNetPager1.CurrentPageIndex != returnTable.PageInfo.PageIndex)
                AspNetPager1.CurrentPageIndex = returnTable.PageInfo.PageIndex;

            // ��GridView
            gv_Info_Article.DataSource = returnTable.Table;
            gv_Info_Article.DataBind();
        }

        #endregion

        #region GridView �����ݰ��¼� 

        /// <summary>
        /// �����ݰ��¼�
        /// </summary>
        protected void gv_Info_Article_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType== DataControlRowType.DataRow)
            {
                 e.Row.SetDeleteMsg("lbtn_delete");
                 this.OnRowDataBound(sender, e);
            }
        }

        #endregion

        #region GridView ������ �¼� 

        /// <summary>
        /// �� ���� RowCommand �¼�
        /// </summary>
        protected void gv_Info_Article_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.OnRowCommand(sender, e);
            
        }

        #endregion

        #region GridView ��ͷ���� �¼� 

        /// <summary>
        /// ��ͷ���򷽷�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_Info_Article_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortExpression = e.ToSortString(sender);
            DataGridBinding();
        }

        #endregion

        #region GridView ��ҳ �¼� 

        /// <summary>
        /// ��ҳ�¼�
        /// </summary>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        #endregion

        #endregion

        #region ��ѯ��ť��ѯ �¼� 

        /// <summary>
        /// ��ѯ��ť �����¼� 
        /// </summary>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        #endregion

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Info_ArticlePage.aspx?category=" + Category);
           // DataGridBinding();
        }

        
    }
}
