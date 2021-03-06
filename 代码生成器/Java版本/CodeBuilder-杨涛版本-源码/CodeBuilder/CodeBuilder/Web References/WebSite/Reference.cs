﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.296 版自动生成。
// 
#pragma warning disable 1591

namespace Esint.CodeBuilder.WebSite {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WS_CategorySoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RootModel))]
    public partial class WS_Category : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCategoryListOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WS_Category() {
            this.Url = global::Esint.CodeBuilder.Properties.Settings.Default.Esint_CodeBuilder_WebSite_WS_Category;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetCategoryListCompletedEventHandler GetCategoryListCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCategoryList", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Info_CategoryInfo[] GetCategoryList(string categoryType, System.Guid userID) {
            object[] results = this.Invoke("GetCategoryList", new object[] {
                        categoryType,
                        userID});
            return ((Info_CategoryInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCategoryListAsync(string categoryType, System.Guid userID) {
            this.GetCategoryListAsync(categoryType, userID, null);
        }
        
        /// <remarks/>
        public void GetCategoryListAsync(string categoryType, System.Guid userID, object userState) {
            if ((this.GetCategoryListOperationCompleted == null)) {
                this.GetCategoryListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCategoryListOperationCompleted);
            }
            this.InvokeAsync("GetCategoryList", new object[] {
                        categoryType,
                        userID}, this.GetCategoryListOperationCompleted, userState);
        }
        
        private void OnGetCategoryListOperationCompleted(object arg) {
            if ((this.GetCategoryListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCategoryListCompleted(this, new GetCategoryListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Info_CategoryInfo : BaseModel {
        
        private System.Guid categoryIDField;
        
        private string categoryNameField;
        
        private string categoryTypeField;
        
        private System.Guid parentCategoryField;
        
        private System.Guid userIDField;
        
        private System.Nullable<int> orderNumField;
        
        /// <remarks/>
        public System.Guid CategoryID {
            get {
                return this.categoryIDField;
            }
            set {
                this.categoryIDField = value;
            }
        }
        
        /// <remarks/>
        public string CategoryName {
            get {
                return this.categoryNameField;
            }
            set {
                this.categoryNameField = value;
            }
        }
        
        /// <remarks/>
        public string CategoryType {
            get {
                return this.categoryTypeField;
            }
            set {
                this.categoryTypeField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid ParentCategory {
            get {
                return this.parentCategoryField;
            }
            set {
                this.parentCategoryField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid UserID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> OrderNum {
            get {
                return this.orderNumField;
            }
            set {
                this.orderNumField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Info_CategoryInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BaseModel : RootModel {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseModel))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Info_CategoryInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RootModel {
        
        private string updateNullFieldsField;
        
        /// <remarks/>
        public string UpdateNullFields {
            get {
                return this.updateNullFieldsField;
            }
            set {
                this.updateNullFieldsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetCategoryListCompletedEventHandler(object sender, GetCategoryListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCategoryListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCategoryListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Info_CategoryInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Info_CategoryInfo[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591