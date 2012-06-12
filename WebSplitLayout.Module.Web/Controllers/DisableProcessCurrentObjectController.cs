using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.SystemModule;
using WebSplitLayout.Module.BusinessObjects;

namespace WebSplitLayout.Module.Web
{
    public class DisableProcessCurrentObjectController : ViewController
    {
        public DisableProcessCurrentObjectController()
        {
            TargetViewType = ViewType.ListView;
            TargetObjectType = typeof(MyPerson);
        }
        protected override void OnDeactivated()
        {
            Frame.GetController<ListViewProcessCurrentObjectController>().ProcessCurrentObjectAction.Active["HideViewElementsController"] = true;
            Frame.GetController<ListViewController>().EditAction.Active["DisableProcessCurrentObjectController"] = true;
            base.OnDeactivated();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            Frame.GetController<ListViewProcessCurrentObjectController>().ProcessCurrentObjectAction.Active["DisableProcessCurrentObjectController"] = false;
            //Frame.GetController<ListViewController>().EditAction.Active["DisableProcessCurrentObjectController"] = false;
        }
    }
}
