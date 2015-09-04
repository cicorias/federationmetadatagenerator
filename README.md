# Federation Metadata Generation Tool
Tool to generate Federation Metadata - yes, remember the old SAML WS-Federation stuff

**Disclaimer: Use at your own risk – no warranties are granted or implied**

**Original Blog post:** [Federation Metadata Generation Tool](http://blogs.msdn.com/b/scicoria/archive/2010/08/18/federation-metadata-generation-tool.aspx)

If you’ve worked with Windows Identity Foundation (WIF) without the help of ADFS 2.0, 
you’ll run into situations where you’ll need to potentially generate or regenerate 
the metadata used for federation.

Additionally, while WIF supports SAML tokens, it doesn’t have support for SAML 
Passive Requestor protocol (urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST)  - 
you get that with ADFS 2.0.

I needed the ability to quickly generate meta-data and regenerate as needed.  
I created a very simple tool – hacked in a few hours - that uses the meta data serialization 
support in WIF (MetadataSerializer) to generate the meta data.

This tool will generate the following metadata

### SAML IdP and SP
*  IDPSSODescriptor "urn:oasis:names:tc:SAML:2.0:protocol"
*  SPSSODescriptor "urn:oasis:names:tc:SAML:2.0:protocol"

### And WS-Federation
*  http://docs.oasis-open.org/wsfed/federation/200706

The tool makes use of the [PropertyGrid](https://msdn.microsoft.com/en-us/library/system.windows.forms.propertygrid\(v=vs.110\).aspx) for binding to some types used to generate, 
and in order to read the certificate private key it needs permissions – if you run elevated, you should have access.


![Screen 1](https://raw.githubusercontent.com/cicorias/federationmetadatagenerator/master/assets/fig1.png)

![Screen 2](https://raw.githubusercontent.com/cicorias/federationmetadatagenerator/master/assets/fig2.png)


tags: Identity, WIF, Federation, Security