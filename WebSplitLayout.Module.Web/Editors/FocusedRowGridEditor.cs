﻿// -----------------------------------------------------------------------
// <copyright file="ListBoxListEditor.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WebSplitLayout.Module.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DevExpress.ExpressApp.Web.Editors;
    using DevExpress.Web.ASPxEditors;
    using DevExpress.ExpressApp.Editors;
    using DevExpress.ExpressApp.Model;
    using DevExpress.ExpressApp.Core;
    using DevExpress.ExpressApp.Web.Editors.ASPx;
    using System.Globalization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [ListEditor(typeof(object), false)]
    public class FocusedRowGridEditor : ASPxGridListEditor
    {


        public FocusedRowGridEditor(IModelListView model)
            : base(model)
        {
        }

        
        protected override DevExpress.Web.ASPxGridView.ASPxGridView CreateGridControl()
        {
            var grid = base.CreateGridControl();
            grid.SettingsBehavior.AllowFocusedRow = true;
            grid.Load += (s, e) => OnFocusedObjectChanged();
            grid.FocusedRowChanged += new EventHandler(grid_FocusedRowChanged);
            SetFirstRowChangeAfterInit(grid, true);
            grid.ClientSideEvents.FocusedRowChanged =
                @"function(s,e) { 
                    var up = document.getElementById('DetailUpdatePanel');
                    if (s.firstRowChangedAfterInit!==true && up && up.ClientControl) { 
                        up.ClientControl.PerformCallback(s.GetFocusedRowIndex());} 
                    s.firstRowChangedAfterInit = false; }";

            grid.Settings.ShowVerticalScrollBar = true;
            return grid;
        }

        private static void SetFirstRowChangeAfterInit(DevExpress.Web.ASPxGridView.ASPxGridView grid, bool value)
        {
            grid.ClientSideEvents.Init = string.Format(CultureInfo.InvariantCulture,
                "function (s,e) {{ s.firstRowChangedAfterInit = {0};}}", value ? "true" : "false");
        }

        void grid_FocusedRowChanged(object sender, EventArgs e)
        {
            OnFocusedObjectChanged();
        }

        public override void Setup(DevExpress.ExpressApp.CollectionSourceBase collectionSource, DevExpress.ExpressApp.XafApplication application)
        {
            base.Setup(collectionSource, application);
            CollectionSource.CriteriaApplied += CollectionSource_CriteriaApplied;
        }

        void CollectionSource_CriteriaApplied(object sender, EventArgs e)
        {
            if (Grid!=null) SetFirstRowChangeAfterInit(Grid, false);
            if (Grid != null) Grid.FocusedRowIndex = -1;
            OnFocusedObjectChanged();
        }

        private bool inGetFocusedObject;

        public override object FocusedObject
        {
            get
            {
                if (inGetFocusedObject || Grid == null || Grid.FocusedRowIndex < 0 || Grid.FocusedRowIndex >= CollectionSource.List.Count) return null;
                try
                {
                    inGetFocusedObject = true;
                    return Grid.GetRow(Grid.FocusedRowIndex);
                }
                finally
                {
                    inGetFocusedObject = false;
                }
            }
            set
            {
                if (value != null)
                    Grid.FocusedRowIndex = Grid.FindVisibleIndexByKeyValue(ObjectSpace.GetKeyValue(value));
            }
        }

        private object lastFiredFocusedObject;


        protected override void OnFocusedObjectChanged()
        {
            if (lastFiredFocusedObject != FocusedObject)
            {
                base.OnFocusedObjectChanged();
                lastFiredFocusedObject = FocusedObject;
            }
        }


        protected override System.Collections.IList GetSelectedObjectsCore()
        {
            if (FocusedObject != null)
                return new object[] { FocusedObject };
            else
                return new object[0];
        }

        public override DevExpress.ExpressApp.SelectionType SelectionType
        {
            get { return DevExpress.ExpressApp.SelectionType.FocusedObject | DevExpress.ExpressApp.SelectionType.MultipleSelection; }
        }
    }

}
