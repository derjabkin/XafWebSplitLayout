using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using System.Threading;

public partial class Default : BaseXafPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewSiteControl = VSC;
        WebApplication.Instance.CreateControls(this);
        if (WebWindow.CurrentRequestWindow != null)
        {
            WebWindow.CurrentRequestWindow.PagePreRender += new EventHandler(CurrentRequestWindow_PagePreRender);
        }
    }

    public override void ProcessRequest(System.Web.HttpContext context)
    {
        try
        {
            
            //Thread t = new Thread(() => { for (int i = 0; i >= 0; i++) Thread.Sleep(10); });
            //t.Start();
            //t.Abort();
        
            base.ProcessRequest(context);
        }
        catch (ThreadAbortException ex) 
        {
            string s = ex.ToString();
            throw;
        }
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        var callbackId = Request.Form["__CALLBACKID"];
        System.Diagnostics.Debug.WriteLine("CallbackId: " + callbackId);
        if (callbackId != null)
        {
            var control = FindControl(callbackId);
        }
        base.OnLoadComplete(e);
    }
    private void CurrentRequestWindow_PagePreRender(object sender, EventArgs e)
    {
        WebWindow window = (WebWindow)sender;
        window.PagePreRender -= new EventHandler(CurrentRequestWindow_PagePreRender);
        string isLeftPanelVisible = (VTC.HasActiveActions() || DAC.HasActiveActions()).ToString().ToLower();
        window.RegisterStartupScript("OnLoadCore", string.Format(@"Init(""{1}"", ""DefaultCS"");OnLoadCore(""LPcell"", ""separatorCell"", ""separatorImage"", {0}, true);", isLeftPanelVisible, Theme), true);
    }
    protected override ContextActionsMenu CreateContextActionsMenu()
    {
        return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
    }
    protected override IActionContainer GetDefaultContainer()
    {
        return TB.FindActionContainerById("View");
    }
    public override void SetStatus(System.Collections.Generic.ICollection<string> statusMessages)
    {
        InfoMessagesPanel.Text = string.Join("<br>", new List<string>(statusMessages).ToArray());
    }
}
