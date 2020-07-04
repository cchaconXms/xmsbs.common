using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace XMSBS.Common.ServiceBase
{
    public abstract class ServiceBase<IChannel> : IServiceBase<IChannel>
    {
        private BasicHttpBinding BasicHttpBinding = null;
        private EndpointAddress EndpointAddress = null;
        private ChannelFactory<IChannel> Factory = null;
        protected OperationContextScope Scope = null;
        protected IChannel Service;

        public void ConfigurationService(BasicHttpSecurityMode basicHttpSecurityMode, HttpClientCredentialType httpClientCredentialType, string Uri)
        {
            BasicHttpBinding = new BasicHttpBinding(basicHttpSecurityMode);
            BasicHttpBinding.Security.Transport.ClientCredentialType = httpClientCredentialType;            
            EndpointAddress = new EndpointAddress(new Uri(Uri));
        }

        public void ConfigurationService(BasicHttpSecurityMode basicHttpSecurityMode, HttpClientCredentialType httpClientCredentialType, string Uri,TimeSpan tiempoCierre,TimeSpan tiempoRespuesta)
        {
            BasicHttpBinding = new BasicHttpBinding(basicHttpSecurityMode);
            BasicHttpBinding.Security.Transport.ClientCredentialType = httpClientCredentialType;
            BasicHttpBinding.CloseTimeout = tiempoCierre;
            BasicHttpBinding.ReceiveTimeout = tiempoRespuesta;
            EndpointAddress = new EndpointAddress(new Uri(Uri));

        }

        public void CreateFactoryChannel()
        {
            Factory = new ChannelFactory<IChannel>(BasicHttpBinding, EndpointAddress);
            Service = Factory.CreateChannel();
            Scope = new OperationContextScope((IContextChannel)Service);
        }

        public void CloseFactory()
            => Factory.Close();

        public void CloseCommunitation()
            => ((ICommunicationObject)Service).Close();
    }
}
