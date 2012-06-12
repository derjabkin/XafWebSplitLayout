using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Web.Layout;
using System.Web.UI.WebControls;
using System.Web.UI;
using DevExpress.ExpressApp.Model;
using DevExpress.Web.ASPxCallbackPanel;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using System.Globalization;
using DevExpress.Web.ASPxGridView;
using System.IO;
using WebSplitLayout.Module.Web.Controllers;

namespace WebSplitLayout.Module.Web
{
    public class SplitLayoutManager : WebLayoutManager
    {
        private ViewItemsCollection viewItems;

        public SplitLayoutManager(bool simple, bool delayedViewItemsInitialization)
        {

        }

        public override object LayoutControls(DevExpress.ExpressApp.Model.IModelNode layoutInfo, DevExpress.ExpressApp.Layout.ViewItemsCollection detailViewItems)
        {
            IModelSplitLayout splitLayout = layoutInfo as IModelSplitLayout;
            if (splitLayout != null && detailViewItems.Count > 1)
            {
                viewItems = detailViewItems;
                DevExpress.Web.ASPxSplitter.ASPxSplitter splitter = new DevExpress.Web.ASPxSplitter.ASPxSplitter();
                splitter.ID = "MasterDetailSplitter";
                splitter.ClientIDMode = ClientIDMode.Static;
                splitter.Orientation = (splitLayout.Direction == FlowDirection.Horizontal) ? Orientation.Horizontal : Orientation.Vertical;
                var listPane = splitter.Panes.Add();
                listPane.Name = "listPane";
                Control listControl = (Control)detailViewItems[0].Control;
                listControl.ClientIDMode = ClientIDMode.Predictable;
                listPane.Controls.Add(listControl);
                splitter.ClientSideEvents.Init = "function (s,e) {s.AdjustControl(); s.GetMainElement().ClientControl = s; document.getElementById('CP').style.height='0px';AdjustSize();}";

                XafCallbackManager callbackManager = ((ICallbackManagerHolder)WebWindow.CurrentRequestPage).CallbackManager;
                var positionController = WebWindow.CurrentRequestWindow.GetController<SplitterPositionController>();
                callbackManager.RegisterHandler("SplitterPositionController", positionController);
                var callbackScript = callbackManager.GetScript("SplitterPositionController", "'testresize'");

                splitter.ShowCollapseBackwardButton = true;
                splitter.ShowCollapseForwardButton = true;

                ASPxGridView gridView = listControl as ASPxGridView;

                if (gridView != null)
                {
                    if (string.IsNullOrEmpty(gridView.ClientInstanceName))
                        gridView.ClientInstanceName = "gridViewInSplitter";
                    splitter.ClientSideEvents.PaneResized = string.Format(CultureInfo.InvariantCulture,
                        "function (s,e) {{ if (e.pane.name==='listPane') {{ {0}.SetWidth(e.pane.GetClientWidth()); {0}.SetHeight(e.pane.GetClientHeight()); }}}}",
                        gridView.ClientInstanceName);
                }

                var detailPane = splitter.Panes.Add();
                detailPane.ScrollBars = ScrollBars.Auto;
                ASPxCallbackPanel updatePanel = new ASPxCallbackPanel();
                updatePanel.ID = "DetailUpdatePanel";
                updatePanel.ClientIDMode = ClientIDMode.Static;
                updatePanel.ClientSideEvents.Init = "function (s,e) {s.GetMainElement().ClientControl = s;}";
                Control detailControl = (Control)detailViewItems[1].Control;
                detailControl.ClientIDMode = ClientIDMode.Predictable;
                updatePanel.Controls.Add(detailControl);
                detailPane.Controls.Add(updatePanel);
                return splitter;
            }
            else
                return base.LayoutControls(layoutInfo, detailViewItems);
        }

        public override void BreakLinksToControls()
        {
            base.BreakLinksToControls();
            if (viewItems != null)
            {
                foreach (ViewItem item in viewItems)
                {
                    item.BreakLinksToControl(false);
                    IFrameContainer frameContainer = item as IFrameContainer;
                    if (frameContainer != null)
                        frameContainer.Frame.View.BreakLinksToControls();
                }
            }
        }
    }
}
