﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Orquestra3_SIAD.Authentication {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AuthenticationSoap", Namespace="http://www.cryo.com.br/")]
    public partial class Authentication : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Login01OperationCompleted;
        
        private System.Threading.SendOrPostCallback Login02OperationCompleted;
        
        private System.Threading.SendOrPostCallback Login03OperationCompleted;
        
        private System.Threading.SendOrPostCallback LoginBiometric01OperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveFingerprintOperationCompleted;
        
        private System.Threading.SendOrPostCallback Assume01OperationCompleted;
        
        private System.Threading.SendOrPostCallback IsAuthenticated01OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Authentication() {
            this.Url = global::Orquestra3_SIAD.Properties.Settings.Default.Orquestra3_SIAD_Authentication_Authentication;
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
        public event Login01CompletedEventHandler Login01Completed;
        
        /// <remarks/>
        public event Login02CompletedEventHandler Login02Completed;
        
        /// <remarks/>
        public event Login03CompletedEventHandler Login03Completed;
        
        /// <remarks/>
        public event LoginBiometric01CompletedEventHandler LoginBiometric01Completed;
        
        /// <remarks/>
        public event SaveFingerprintCompletedEventHandler SaveFingerprintCompleted;
        
        /// <remarks/>
        public event Assume01CompletedEventHandler Assume01Completed;
        
        /// <remarks/>
        public event IsAuthenticated01CompletedEventHandler IsAuthenticated01Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/Login01", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode Login01(string DsUsername, string DsPassword) {
            object[] results = this.Invoke("Login01", new object[] {
                        DsUsername,
                        DsPassword});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void Login01Async(string DsUsername, string DsPassword) {
            this.Login01Async(DsUsername, DsPassword, null);
        }
        
        /// <remarks/>
        public void Login01Async(string DsUsername, string DsPassword, object userState) {
            if ((this.Login01OperationCompleted == null)) {
                this.Login01OperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogin01OperationCompleted);
            }
            this.InvokeAsync("Login01", new object[] {
                        DsUsername,
                        DsPassword}, this.Login01OperationCompleted, userState);
        }
        
        private void OnLogin01OperationCompleted(object arg) {
            if ((this.Login01Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Login01Completed(this, new Login01CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/Login02", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode Login02() {
            object[] results = this.Invoke("Login02", new object[0]);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void Login02Async() {
            this.Login02Async(null);
        }
        
        /// <remarks/>
        public void Login02Async(object userState) {
            if ((this.Login02OperationCompleted == null)) {
                this.Login02OperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogin02OperationCompleted);
            }
            this.InvokeAsync("Login02", new object[0], this.Login02OperationCompleted, userState);
        }
        
        private void OnLogin02OperationCompleted(object arg) {
            if ((this.Login02Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Login02Completed(this, new Login02CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/Login03", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode Login03(string DsUsername, string DsPassword) {
            object[] results = this.Invoke("Login03", new object[] {
                        DsUsername,
                        DsPassword});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void Login03Async(string DsUsername, string DsPassword) {
            this.Login03Async(DsUsername, DsPassword, null);
        }
        
        /// <remarks/>
        public void Login03Async(string DsUsername, string DsPassword, object userState) {
            if ((this.Login03OperationCompleted == null)) {
                this.Login03OperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogin03OperationCompleted);
            }
            this.InvokeAsync("Login03", new object[] {
                        DsUsername,
                        DsPassword}, this.Login03OperationCompleted, userState);
        }
        
        private void OnLogin03OperationCompleted(object arg) {
            if ((this.Login03Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Login03Completed(this, new Login03CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/LoginBiometric01", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode LoginBiometric01(string DsUsername, string Base64StringFingerprint) {
            object[] results = this.Invoke("LoginBiometric01", new object[] {
                        DsUsername,
                        Base64StringFingerprint});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void LoginBiometric01Async(string DsUsername, string Base64StringFingerprint) {
            this.LoginBiometric01Async(DsUsername, Base64StringFingerprint, null);
        }
        
        /// <remarks/>
        public void LoginBiometric01Async(string DsUsername, string Base64StringFingerprint, object userState) {
            if ((this.LoginBiometric01OperationCompleted == null)) {
                this.LoginBiometric01OperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoginBiometric01OperationCompleted);
            }
            this.InvokeAsync("LoginBiometric01", new object[] {
                        DsUsername,
                        Base64StringFingerprint}, this.LoginBiometric01OperationCompleted, userState);
        }
        
        private void OnLoginBiometric01OperationCompleted(object arg) {
            if ((this.LoginBiometric01Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoginBiometric01Completed(this, new LoginBiometric01CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/SaveFingerprint", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode SaveFingerprint(string DsUsername, string DsPassword, string Base64StringFingerprint) {
            object[] results = this.Invoke("SaveFingerprint", new object[] {
                        DsUsername,
                        DsPassword,
                        Base64StringFingerprint});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void SaveFingerprintAsync(string DsUsername, string DsPassword, string Base64StringFingerprint) {
            this.SaveFingerprintAsync(DsUsername, DsPassword, Base64StringFingerprint, null);
        }
        
        /// <remarks/>
        public void SaveFingerprintAsync(string DsUsername, string DsPassword, string Base64StringFingerprint, object userState) {
            if ((this.SaveFingerprintOperationCompleted == null)) {
                this.SaveFingerprintOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveFingerprintOperationCompleted);
            }
            this.InvokeAsync("SaveFingerprint", new object[] {
                        DsUsername,
                        DsPassword,
                        Base64StringFingerprint}, this.SaveFingerprintOperationCompleted, userState);
        }
        
        private void OnSaveFingerprintOperationCompleted(object arg) {
            if ((this.SaveFingerprintCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveFingerprintCompleted(this, new SaveFingerprintCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/Assume01", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode Assume01(string Token, string DsUsername) {
            object[] results = this.Invoke("Assume01", new object[] {
                        Token,
                        DsUsername});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void Assume01Async(string Token, string DsUsername) {
            this.Assume01Async(Token, DsUsername, null);
        }
        
        /// <remarks/>
        public void Assume01Async(string Token, string DsUsername, object userState) {
            if ((this.Assume01OperationCompleted == null)) {
                this.Assume01OperationCompleted = new System.Threading.SendOrPostCallback(this.OnAssume01OperationCompleted);
            }
            this.InvokeAsync("Assume01", new object[] {
                        Token,
                        DsUsername}, this.Assume01OperationCompleted, userState);
        }
        
        private void OnAssume01OperationCompleted(object arg) {
            if ((this.Assume01Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Assume01Completed(this, new Assume01CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.cryo.com.br/IsAuthenticated01", RequestNamespace="http://www.cryo.com.br/", ResponseNamespace="http://www.cryo.com.br/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode IsAuthenticated01(string Token) {
            object[] results = this.Invoke("IsAuthenticated01", new object[] {
                        Token});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void IsAuthenticated01Async(string Token) {
            this.IsAuthenticated01Async(Token, null);
        }
        
        /// <remarks/>
        public void IsAuthenticated01Async(string Token, object userState) {
            if ((this.IsAuthenticated01OperationCompleted == null)) {
                this.IsAuthenticated01OperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsAuthenticated01OperationCompleted);
            }
            this.InvokeAsync("IsAuthenticated01", new object[] {
                        Token}, this.IsAuthenticated01OperationCompleted, userState);
        }
        
        private void OnIsAuthenticated01OperationCompleted(object arg) {
            if ((this.IsAuthenticated01Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsAuthenticated01Completed(this, new IsAuthenticated01CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void Login01CompletedEventHandler(object sender, Login01CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Login01CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Login01CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void Login02CompletedEventHandler(object sender, Login02CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Login02CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Login02CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void Login03CompletedEventHandler(object sender, Login03CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Login03CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Login03CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void LoginBiometric01CompletedEventHandler(object sender, LoginBiometric01CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LoginBiometric01CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoginBiometric01CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void SaveFingerprintCompletedEventHandler(object sender, SaveFingerprintCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveFingerprintCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveFingerprintCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void Assume01CompletedEventHandler(object sender, Assume01CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Assume01CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Assume01CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void IsAuthenticated01CompletedEventHandler(object sender, IsAuthenticated01CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsAuthenticated01CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsAuthenticated01CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591