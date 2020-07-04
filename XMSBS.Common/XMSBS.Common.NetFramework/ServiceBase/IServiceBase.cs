using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace XMSBS.Common.ServiceBase
{
    public interface IServiceBase<IChannel>
    {
        void ConfigurationService(BasicHttpSecurityMode basicHttpSecurityMode, HttpClientCredentialType httpClientCredentialType, string Uri);
        void CreateFactoryChannel();
        void CloseFactory();
        void CloseCommunitation();
    }
}
