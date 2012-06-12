namespace WebSplitLayout.Win
{
    partial class WebSplitLayoutWindowsFormsApplication
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
            this.module3 = new WebSplitLayout.Module.WebSplitLayoutModule();
            this.module4 = new WebSplitLayout.Module.Win.WebSplitLayoutWindowsFormsModule();
            this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.module7 = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();

            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.securitySimple = new DevExpress.ExpressApp.Security.SecurityStrategySimple();
            this.authenticationActiveDirectory1 = new DevExpress.ExpressApp.Security.AuthenticationActiveDirectory();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // securitySimple1
            // 
            this.securitySimple.Authentication = this.authenticationActiveDirectory1;
            this.securitySimple.UserType = typeof(DevExpress.ExpressApp.Security.SecuritySimpleUser);
            // 
            // authenticationActiveDirectory1
            // 
            this.authenticationActiveDirectory1.CreateUserAutomatically = true;
            this.authenticationActiveDirectory1.UserType = typeof(DevExpress.ExpressApp.Security.SecuritySimpleUser);
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=WebSplitLayout;Integrated Security=SSPI;Pooling=false";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // WebSplitLayoutWindowsFormsApplication
            // 
            this.ApplicationName = "WebSplitLayout";
            this.Connection = this.sqlConnection1;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.module4);
            this.Modules.Add(this.module5);
            this.Modules.Add(this.module6);
            this.Modules.Add(this.module7);
            this.Modules.Add(this.securityModule1);
            this.Security = this.securitySimple;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.WebSplitLayoutWindowsFormsApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
        private WebSplitLayout.Module.WebSplitLayoutModule module3;
        private WebSplitLayout.Module.Win.WebSplitLayoutWindowsFormsModule module4;
        private DevExpress.ExpressApp.Validation.ValidationModule module5;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
        private DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule module7;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Security.SecurityStrategySimple securitySimple;
        private DevExpress.ExpressApp.Security.AuthenticationActiveDirectory authenticationActiveDirectory1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
    }
}
