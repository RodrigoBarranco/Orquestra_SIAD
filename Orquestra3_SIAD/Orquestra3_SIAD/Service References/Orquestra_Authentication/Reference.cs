﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Orquestra3_SIAD.Orquestra_Authentication {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.cryo.com.br/", ConfigurationName="Orquestra_Authentication.AuthenticationSoap")]
    public interface AuthenticationSoap {
        
        // CODEGEN: Generating message contract since element name DsUsername from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/Login01", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.Login01Response Login01(Orquestra3_SIAD.Orquestra_Authentication.Login01Request request);
        
        // CODEGEN: Generating message contract since element name Login02Result from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/Login02", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.Login02Response Login02(Orquestra3_SIAD.Orquestra_Authentication.Login02Request request);
        
        // CODEGEN: Generating message contract since element name DsUsername from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/Login03", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.Login03Response Login03(Orquestra3_SIAD.Orquestra_Authentication.Login03Request request);
        
        // CODEGEN: Generating message contract since element name DsUsername from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/LoginBiometric01", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Response LoginBiometric01(Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Request request);
        
        // CODEGEN: Generating message contract since element name DsUsername from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/SaveFingerprint", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintResponse SaveFingerprint(Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequest request);
        
        // CODEGEN: Generating message contract since element name Token from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/Assume01", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.Assume01Response Assume01(Orquestra3_SIAD.Orquestra_Authentication.Assume01Request request);
        
        // CODEGEN: Generating message contract since element name Token from namespace http://www.cryo.com.br/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cryo.com.br/IsAuthenticated01", ReplyAction="*")]
        Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Response IsAuthenticated01(Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Request request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Login01Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login01", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Login01RequestBody Body;
        
        public Login01Request() {
        }
        
        public Login01Request(Orquestra3_SIAD.Orquestra_Authentication.Login01RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Login01RequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string DsUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string DsPassword;
        
        public Login01RequestBody() {
        }
        
        public Login01RequestBody(string DsUsername, string DsPassword) {
            this.DsUsername = DsUsername;
            this.DsPassword = DsPassword;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Login01Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login01Response", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Login01ResponseBody Body;
        
        public Login01Response() {
        }
        
        public Login01Response(Orquestra3_SIAD.Orquestra_Authentication.Login01ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Login01ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement Login01Result;
        
        public Login01ResponseBody() {
        }
        
        public Login01ResponseBody(System.Xml.Linq.XElement Login01Result) {
            this.Login01Result = Login01Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Login02Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login02", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Login02RequestBody Body;
        
        public Login02Request() {
        }
        
        public Login02Request(Orquestra3_SIAD.Orquestra_Authentication.Login02RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class Login02RequestBody {
        
        public Login02RequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Login02Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login02Response", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Login02ResponseBody Body;
        
        public Login02Response() {
        }
        
        public Login02Response(Orquestra3_SIAD.Orquestra_Authentication.Login02ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Login02ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement Login02Result;
        
        public Login02ResponseBody() {
        }
        
        public Login02ResponseBody(System.Xml.Linq.XElement Login02Result) {
            this.Login02Result = Login02Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Login03Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login03", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Login03RequestBody Body;
        
        public Login03Request() {
        }
        
        public Login03Request(Orquestra3_SIAD.Orquestra_Authentication.Login03RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Login03RequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string DsUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string DsPassword;
        
        public Login03RequestBody() {
        }
        
        public Login03RequestBody(string DsUsername, string DsPassword) {
            this.DsUsername = DsUsername;
            this.DsPassword = DsPassword;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Login03Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login03Response", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Login03ResponseBody Body;
        
        public Login03Response() {
        }
        
        public Login03Response(Orquestra3_SIAD.Orquestra_Authentication.Login03ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Login03ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement Login03Result;
        
        public Login03ResponseBody() {
        }
        
        public Login03ResponseBody(System.Xml.Linq.XElement Login03Result) {
            this.Login03Result = Login03Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginBiometric01Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoginBiometric01", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01RequestBody Body;
        
        public LoginBiometric01Request() {
        }
        
        public LoginBiometric01Request(Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class LoginBiometric01RequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string DsUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Base64StringFingerprint;
        
        public LoginBiometric01RequestBody() {
        }
        
        public LoginBiometric01RequestBody(string DsUsername, string Base64StringFingerprint) {
            this.DsUsername = DsUsername;
            this.Base64StringFingerprint = Base64StringFingerprint;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginBiometric01Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoginBiometric01Response", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01ResponseBody Body;
        
        public LoginBiometric01Response() {
        }
        
        public LoginBiometric01Response(Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class LoginBiometric01ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement LoginBiometric01Result;
        
        public LoginBiometric01ResponseBody() {
        }
        
        public LoginBiometric01ResponseBody(System.Xml.Linq.XElement LoginBiometric01Result) {
            this.LoginBiometric01Result = LoginBiometric01Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveFingerprintRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveFingerprint", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequestBody Body;
        
        public SaveFingerprintRequest() {
        }
        
        public SaveFingerprintRequest(Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class SaveFingerprintRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string DsUsername;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string DsPassword;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Base64StringFingerprint;
        
        public SaveFingerprintRequestBody() {
        }
        
        public SaveFingerprintRequestBody(string DsUsername, string DsPassword, string Base64StringFingerprint) {
            this.DsUsername = DsUsername;
            this.DsPassword = DsPassword;
            this.Base64StringFingerprint = Base64StringFingerprint;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveFingerprintResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SaveFingerprintResponse", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintResponseBody Body;
        
        public SaveFingerprintResponse() {
        }
        
        public SaveFingerprintResponse(Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class SaveFingerprintResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement SaveFingerprintResult;
        
        public SaveFingerprintResponseBody() {
        }
        
        public SaveFingerprintResponseBody(System.Xml.Linq.XElement SaveFingerprintResult) {
            this.SaveFingerprintResult = SaveFingerprintResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Assume01Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Assume01", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Assume01RequestBody Body;
        
        public Assume01Request() {
        }
        
        public Assume01Request(Orquestra3_SIAD.Orquestra_Authentication.Assume01RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Assume01RequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string Token;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string DsUsername;
        
        public Assume01RequestBody() {
        }
        
        public Assume01RequestBody(string Token, string DsUsername) {
            this.Token = Token;
            this.DsUsername = DsUsername;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class Assume01Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Assume01Response", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.Assume01ResponseBody Body;
        
        public Assume01Response() {
        }
        
        public Assume01Response(Orquestra3_SIAD.Orquestra_Authentication.Assume01ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class Assume01ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement Assume01Result;
        
        public Assume01ResponseBody() {
        }
        
        public Assume01ResponseBody(System.Xml.Linq.XElement Assume01Result) {
            this.Assume01Result = Assume01Result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsAuthenticated01Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsAuthenticated01", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01RequestBody Body;
        
        public IsAuthenticated01Request() {
        }
        
        public IsAuthenticated01Request(Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class IsAuthenticated01RequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string Token;
        
        public IsAuthenticated01RequestBody() {
        }
        
        public IsAuthenticated01RequestBody(string Token) {
            this.Token = Token;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class IsAuthenticated01Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="IsAuthenticated01Response", Namespace="http://www.cryo.com.br/", Order=0)]
        public Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01ResponseBody Body;
        
        public IsAuthenticated01Response() {
        }
        
        public IsAuthenticated01Response(Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.cryo.com.br/")]
    public partial class IsAuthenticated01ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.Linq.XElement IsAuthenticated01Result;
        
        public IsAuthenticated01ResponseBody() {
        }
        
        public IsAuthenticated01ResponseBody(System.Xml.Linq.XElement IsAuthenticated01Result) {
            this.IsAuthenticated01Result = IsAuthenticated01Result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AuthenticationSoapChannel : Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationSoapClient : System.ServiceModel.ClientBase<Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap>, Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap {
        
        public AuthenticationSoapClient() {
        }
        
        public AuthenticationSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.Login01Response Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.Login01(Orquestra3_SIAD.Orquestra_Authentication.Login01Request request) {
            return base.Channel.Login01(request);
        }
        
        public System.Xml.Linq.XElement Login01(string DsUsername, string DsPassword) {
            Orquestra3_SIAD.Orquestra_Authentication.Login01Request inValue = new Orquestra3_SIAD.Orquestra_Authentication.Login01Request();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.Login01RequestBody();
            inValue.Body.DsUsername = DsUsername;
            inValue.Body.DsPassword = DsPassword;
            Orquestra3_SIAD.Orquestra_Authentication.Login01Response retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).Login01(inValue);
            return retVal.Body.Login01Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.Login02Response Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.Login02(Orquestra3_SIAD.Orquestra_Authentication.Login02Request request) {
            return base.Channel.Login02(request);
        }
        
        public System.Xml.Linq.XElement Login02() {
            Orquestra3_SIAD.Orquestra_Authentication.Login02Request inValue = new Orquestra3_SIAD.Orquestra_Authentication.Login02Request();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.Login02RequestBody();
            Orquestra3_SIAD.Orquestra_Authentication.Login02Response retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).Login02(inValue);
            return retVal.Body.Login02Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.Login03Response Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.Login03(Orquestra3_SIAD.Orquestra_Authentication.Login03Request request) {
            return base.Channel.Login03(request);
        }
        
        public System.Xml.Linq.XElement Login03(string DsUsername, string DsPassword) {
            Orquestra3_SIAD.Orquestra_Authentication.Login03Request inValue = new Orquestra3_SIAD.Orquestra_Authentication.Login03Request();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.Login03RequestBody();
            inValue.Body.DsUsername = DsUsername;
            inValue.Body.DsPassword = DsPassword;
            Orquestra3_SIAD.Orquestra_Authentication.Login03Response retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).Login03(inValue);
            return retVal.Body.Login03Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Response Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.LoginBiometric01(Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Request request) {
            return base.Channel.LoginBiometric01(request);
        }
        
        public System.Xml.Linq.XElement LoginBiometric01(string DsUsername, string Base64StringFingerprint) {
            Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Request inValue = new Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Request();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01RequestBody();
            inValue.Body.DsUsername = DsUsername;
            inValue.Body.Base64StringFingerprint = Base64StringFingerprint;
            Orquestra3_SIAD.Orquestra_Authentication.LoginBiometric01Response retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).LoginBiometric01(inValue);
            return retVal.Body.LoginBiometric01Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintResponse Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.SaveFingerprint(Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequest request) {
            return base.Channel.SaveFingerprint(request);
        }
        
        public System.Xml.Linq.XElement SaveFingerprint(string DsUsername, string DsPassword, string Base64StringFingerprint) {
            Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequest inValue = new Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequest();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintRequestBody();
            inValue.Body.DsUsername = DsUsername;
            inValue.Body.DsPassword = DsPassword;
            inValue.Body.Base64StringFingerprint = Base64StringFingerprint;
            Orquestra3_SIAD.Orquestra_Authentication.SaveFingerprintResponse retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).SaveFingerprint(inValue);
            return retVal.Body.SaveFingerprintResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.Assume01Response Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.Assume01(Orquestra3_SIAD.Orquestra_Authentication.Assume01Request request) {
            return base.Channel.Assume01(request);
        }
        
        public System.Xml.Linq.XElement Assume01(string Token, string DsUsername) {
            Orquestra3_SIAD.Orquestra_Authentication.Assume01Request inValue = new Orquestra3_SIAD.Orquestra_Authentication.Assume01Request();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.Assume01RequestBody();
            inValue.Body.Token = Token;
            inValue.Body.DsUsername = DsUsername;
            Orquestra3_SIAD.Orquestra_Authentication.Assume01Response retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).Assume01(inValue);
            return retVal.Body.Assume01Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Response Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap.IsAuthenticated01(Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Request request) {
            return base.Channel.IsAuthenticated01(request);
        }
        
        public System.Xml.Linq.XElement IsAuthenticated01(string Token) {
            Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Request inValue = new Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Request();
            inValue.Body = new Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01RequestBody();
            inValue.Body.Token = Token;
            Orquestra3_SIAD.Orquestra_Authentication.IsAuthenticated01Response retVal = ((Orquestra3_SIAD.Orquestra_Authentication.AuthenticationSoap)(this)).IsAuthenticated01(inValue);
            return retVal.Body.IsAuthenticated01Result;
        }
    }
}