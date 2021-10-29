﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoogleClient.BoggleServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BoggleServices.IUserManagerContract", CallbackContract=typeof(BoogleClient.BoggleServices.IUserManagerContractCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IUserManagerContract {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUserManagerContract/LogIn")]
        void LogIn(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUserManagerContract/LogIn")]
        System.Threading.Tasks.Task LogInAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUserManagerContract/CreateAccount")]
        void CreateAccount(string username, string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUserManagerContract/CreateAccount")]
        System.Threading.Tasks.Task CreateAccountAsync(string username, string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserManagerContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagerContract/GrantAccess", ReplyAction="http://tempuri.org/IUserManagerContract/GrantAccessResponse")]
        void GrantAccess(bool access);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserManagerContractChannel : BoogleClient.BoggleServices.IUserManagerContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserManagerContractClient : System.ServiceModel.DuplexClientBase<BoogleClient.BoggleServices.IUserManagerContract>, BoogleClient.BoggleServices.IUserManagerContract {
        
        public UserManagerContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public UserManagerContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public UserManagerContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void LogIn(string username, string password) {
            base.Channel.LogIn(username, password);
        }
        
        public System.Threading.Tasks.Task LogInAsync(string username, string password) {
            return base.Channel.LogInAsync(username, password);
        }
        
        public void CreateAccount(string username, string email, string password) {
            base.Channel.CreateAccount(username, email, password);
        }
        
        public System.Threading.Tasks.Task CreateAccountAsync(string username, string email, string password) {
            return base.Channel.CreateAccountAsync(username, email, password);
        }
    }
}
