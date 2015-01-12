﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ICalculatorService")]
public interface ICalculatorService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/Add", ReplyAction="http://tempuri.org/ICalculatorService/AddResponse")]
    Entities.Complex Add(Entities.Complex a, Entities.Complex b);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/Substract", ReplyAction="http://tempuri.org/ICalculatorService/SubstractResponse")]
    Entities.Complex Substract(Entities.Complex first, Entities.Complex second);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/Multiply", ReplyAction="http://tempuri.org/ICalculatorService/MultiplyResponse")]
    Entities.Complex Multiply(Entities.Complex first, Entities.Complex second);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculatorService/ThrowError", ReplyAction="http://tempuri.org/ICalculatorService/ThrowErrorResponse")]
    void ThrowError();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ICalculatorServiceChannel : ICalculatorService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class CalculatorServiceClient : System.ServiceModel.ClientBase<ICalculatorService>, ICalculatorService
{
    
    public CalculatorServiceClient()
    {
    }
    
    public CalculatorServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CalculatorServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculatorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculatorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public Entities.Complex Add(Entities.Complex a, Entities.Complex b)
    {
        return base.Channel.Add(a, b);
    }
    
    public Entities.Complex Substract(Entities.Complex first, Entities.Complex second)
    {
        return base.Channel.Substract(first, second);
    }
    
    public Entities.Complex Multiply(Entities.Complex first, Entities.Complex second)
    {
        return base.Channel.Multiply(first, second);
    }
    
    public void ThrowError()
    {
        base.Channel.ThrowError();
    }
}
