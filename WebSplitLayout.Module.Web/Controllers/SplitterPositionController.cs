using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Web.Templates;

namespace WebSplitLayout.Module.Web.Controllers
{
    public partial class SplitterPositionController : WindowController, IXafCallbackHandler
    {
        public SplitterPositionController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        public void ProcessAction(string parameter)
        {
        }
    }
}
