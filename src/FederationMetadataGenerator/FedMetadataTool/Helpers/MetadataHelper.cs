using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using System.ServiceModel;
using Microsoft.IdentityModel.SecurityTokenService;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml2;
using System.Windows.Forms;

namespace CedarLogic.Identity
{ 
    public class MetadataHelper
    {

        public static void CreateMetaData(MetadataDescriptor data, string fileName, Encoding encoding)
        {
            if (string.IsNullOrEmpty(fileName))
                fileName = "FederationMetadata.xml";

            if (data.EntityId == null)
                throw new ApplicationException("Entity ID is null");
            //Uri entityId = new Uri(data.EntityId);


            //move to subtypes - validator
            //if (data.BindingLocation == null)
            //    throw new ApplicationException("no binding location");

            //if (data.BindingType == null)
            //    throw new ApplicationException("no binding type provided");

            //if (data.MainContact == null)
            //    throw new ApplicationException("no contact supplied");

            //branch here
            if (data is SamlIdpData)
                CreateIdentityProviderMetadata(data as SamlIdpData, fileName, encoding);

            if (data is SamlSpData)
                CreateIdentityProviderMetadata(data as SamlSpData, fileName, encoding);

            if (data is StsData)
                CreatePassiveStsMetadata(data as StsData, fileName, encoding);
                

        }

        private static void CreateIdentityProviderMetadata(SamlSpData samlSpData, string fileName, Encoding encoding)
        {
            Constants.NameIdType nidFmt = samlSpData.NameIdType;

            MetadataSerializer serializer = new MetadataSerializer();
            ServiceProviderSingleSignOnDescriptor item = new ServiceProviderSingleSignOnDescriptor();

            EntityDescriptor metadata = new EntityDescriptor();
            metadata.EntityId = new EntityId(samlSpData.EntityId);

            //using 2.0
            if (Constants.NameIdType.Saml20 == nidFmt)
                item.NameIdentifierFormats.Add(Saml2Constants.NameIdentifierFormats.Transient);

            //using 1.1
            if (Constants.NameIdType.Saml11 == nidFmt)
                item.NameIdentifierFormats.Add(Saml2Constants.NameIdentifierFormats.Unspecified);

            item.ProtocolsSupported.Add(new Uri(Constants.Saml20Protocol));
            IndexedProtocolEndpoint ipEndpoint = new IndexedProtocolEndpoint()
                {
                    IsDefault=true,
                    Binding=new Uri(samlSpData.BindingType),
                    Location=new Uri(samlSpData.BindingLocation)
                };

            item.AssertionConsumerService.Add(0, ipEndpoint);

            metadata.RoleDescriptors.Add(item);

            metadata.Contacts.Add(new ContactPerson(ContactType.Technical)
            {
                Company = samlSpData.MainContact.Company,
                GivenName = samlSpData.MainContact.GivenName,
                Surname = samlSpData.MainContact.SurName,
                EmailAddresses = { samlSpData.MainContact.Email },
                TelephoneNumbers = { samlSpData.MainContact.Phone }
            });

            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);
            serializer.WriteMetadata(writer, metadata);
            writer.Close();

        }

        private static void CreateIdentityProviderMetadata(SamlIdpData idpData, string fileName, Encoding encoding)
        {

            if ( string.IsNullOrEmpty(idpData.SigninCertificateCn))
                throw new ApplicationException("no CN for a Certificate supplied");

            string signingCertificateSubjectName = idpData.SigninCertificateCn;

            Constants.NameIdType nidFmt = idpData.NameIdType;

            MetadataSerializer serializer = new MetadataSerializer();
            IdentityProviderSingleSignOnDescriptor item = new IdentityProviderSingleSignOnDescriptor();

            EntityDescriptor metadata = new EntityDescriptor();
            metadata.EntityId = new EntityId(idpData.EntityId);

            X509Certificate2 certificate = CertificateHelper.RetrieveCertificate(signingCertificateSubjectName);
            KeyDescriptor descriptor = new KeyDescriptor(
                new SecurityKeyIdentifier(
                    new SecurityKeyIdentifierClause[] 
                    { 
                        new X509SecurityToken(certificate).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>()
                    }));

            descriptor.Use = KeyType.Signing;
            item.Keys.Add(descriptor);

            //using 2.0
            if (Constants.NameIdType.Saml20 == nidFmt)
                item.NameIdentifierFormats.Add(Saml2Constants.NameIdentifierFormats.Transient);

            //using 1.1
            if (Constants.NameIdType.Saml11 == nidFmt)
                item.NameIdentifierFormats.Add(Saml2Constants.NameIdentifierFormats.Unspecified);

            foreach (var attributeName in idpData.AttributeNames)
            {
                Saml2Attribute at1 = new Saml2Attribute(attributeName.Name)
                {
                    NameFormat = new Uri(Constants.Saml20AttributeNameFormat)
                };
                item.SupportedAttributes.Add(at1);
            }

            item.ProtocolsSupported.Add(new Uri(Constants.Saml20Protocol));
            item.SingleSignOnServices.Add(new ProtocolEndpoint(new Uri(idpData.BindingType), new Uri(idpData.BindingLocation)));

            metadata.RoleDescriptors.Add(item);

            metadata.Contacts.Add(new ContactPerson(ContactType.Technical)
            {
                Company = idpData.MainContact.Company,
                GivenName = idpData.MainContact.GivenName,
                Surname = idpData.MainContact.SurName,
                EmailAddresses = { idpData.MainContact.Email },
                TelephoneNumbers = { idpData.MainContact.Phone }
            });

            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);
            serializer.WriteMetadata(writer, metadata);
            writer.Close();

        }

        static void CreatePassiveStsMetadata(StsData data, string fileName, Encoding encoding)
        {
            MetadataSerializer serializer = new MetadataSerializer();
            SecurityTokenServiceDescriptor item = new SecurityTokenServiceDescriptor();
            EntityDescriptor metadata = new EntityDescriptor();
            metadata.EntityId = new EntityId(data.EntityId);

            X509Certificate2 certificate = CertificateHelper.RetrieveCertificate(data.SigninCertificateCn);

            metadata.SigningCredentials = new X509SigningCredentials(certificate);
            KeyDescriptor descriptor3 = new KeyDescriptor(new SecurityKeyIdentifier(new SecurityKeyIdentifierClause[] { new X509SecurityToken(certificate).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>() }));
            descriptor3.Use = KeyType.Signing;
            item.Keys.Add(descriptor3);

            if (data.Claims != null)
            {
                foreach (var claim in data.Claims)
                {
                    DisplayClaim dc = new DisplayClaim(claim.ClaimType, claim.DisplayTag, claim.Description)
                    {
                        Optional = claim.Optional
                    };

                    item.ClaimTypesOffered.Add(dc);
                }
            }

            item.PassiveRequestorEndpoints.Add(new EndpointAddress( new Uri(data.PassiveRequestorEndpoint).AbsoluteUri));

            if (data.Protocols != null)
            {
                foreach (Protocol protocol in data.Protocols)
                {
                    item.ProtocolsSupported.Add(new Uri(protocol.ProtocolNamespace));
                }
            }


            item.SecurityTokenServiceEndpoints.Add(new EndpointAddress( new Uri(data.ActiveStsEndpoint).AbsoluteUri));
            item.Contacts.Add(new ContactPerson(ContactType.Technical)
            {
                Company = data.MainContact.Company,
                GivenName = data.MainContact.GivenName,
                Surname = data.MainContact.SurName,
                EmailAddresses = { data.MainContact.Email },
                TelephoneNumbers = { data.MainContact.Phone }
            });

            metadata.RoleDescriptors.Add(item);

            

            XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8);
            serializer.WriteMetadata(writer, metadata);
            writer.Close();


        }

        private static DisplayClaim CreateDisplayClaim(string claimType, bool optional, string displayTag, string description)
        {
            var claim = new DisplayClaim(claimType);
            claim.Optional = optional;
            claim.DisplayTag = displayTag;
            claim.Description = (string.IsNullOrEmpty(description)) ? displayTag : description;

            return claim;
        }


    }
}