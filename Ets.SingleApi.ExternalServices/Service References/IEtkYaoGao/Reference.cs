﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ets.SingleApi.ExternalServices.IEtkYaoGao {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webservice.accor.huateng.com", ConfigurationName="IEtkYaoGao.ETSHServicePortType")]
    public interface ETSHServicePortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        string ETSH_Card_Change_Pin(string CardNo, string Old_Pin, string New_Pin, string CVV2, string AuthCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<string> ETSH_Card_Change_PinAsync(string CardNo, string Old_Pin, string New_Pin, string CVV2, string AuthCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        string ETSH_Card_Balance_Inquery(string CardNo, string AuthCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<string> ETSH_Card_Balance_InqueryAsync(string CardNo, string AuthCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ETSHServicePortTypeChannel : Ets.SingleApi.ExternalServices.IEtkYaoGao.ETSHServicePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ETSHServicePortTypeClient : System.ServiceModel.ClientBase<Ets.SingleApi.ExternalServices.IEtkYaoGao.ETSHServicePortType>, Ets.SingleApi.ExternalServices.IEtkYaoGao.ETSHServicePortType {
        
        public ETSHServicePortTypeClient() {
        }
        
        public ETSHServicePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ETSHServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ETSHServicePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ETSHServicePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ETSH_Card_Change_Pin(string CardNo, string Old_Pin, string New_Pin, string CVV2, string AuthCode) {
            return base.Channel.ETSH_Card_Change_Pin(CardNo, Old_Pin, New_Pin, CVV2, AuthCode);
        }
        
        public System.Threading.Tasks.Task<string> ETSH_Card_Change_PinAsync(string CardNo, string Old_Pin, string New_Pin, string CVV2, string AuthCode) {
            return base.Channel.ETSH_Card_Change_PinAsync(CardNo, Old_Pin, New_Pin, CVV2, AuthCode);
        }
        
        public string ETSH_Card_Balance_Inquery(string CardNo, string AuthCode) {
            return base.Channel.ETSH_Card_Balance_Inquery(CardNo, AuthCode);
        }
        
        public System.Threading.Tasks.Task<string> ETSH_Card_Balance_InqueryAsync(string CardNo, string AuthCode) {
            return base.Channel.ETSH_Card_Balance_InqueryAsync(CardNo, AuthCode);
        }
    }
}
