namespace RoleWebApi.Application.Context.PolicyModule.Specifications
{
    using Newtonsoft.Json.Linq;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class PolicySpecification : IPolicySpecification
    {
        public Client GetClientByPolicyId(string policyId)
        {
            Policy policy = ListPoliciesClient().FirstOrDefault(q => q.Id == policyId);
            return policy != null ? policy.Client : null;
        }

        public IEnumerable<Policy> ListPoliciesClient()
        {
            string policyUrl = "http://www.mocky.io/v2/580891a4100000e8242b75c5";
            string clientUrl = "http://www.mocky.io/v2/5808862710000087232b75ac";

            List<Client> clients = new List<Client>();

            using (WebClient wc = new WebClient())
            {
                var clientData = wc.DownloadString(clientUrl);
                JObject jObject = JObject.Parse(clientData);
                Array jClients = jObject["clients"].ToArray();

                for (int i = 0; i < jClients.Length; i++)
                {
                    JObject jClient = JObject.Parse(jClients.GetValue(i).ToString());

                    Client client = new Client();
                    client.Id = (string)jClient["id"];
                    client.Name = (string)jClient["name"];
                    client.Email = (string)jClient["email"];
                    client.Role = (string)jClient["role"];

                    clients.Add(client);
                }
            }

            List<Policy> policies = new List<Policy>();

            using (WebClient wc = new WebClient())
            {
                var policyData = wc.DownloadString(policyUrl);
                JObject jObject = JObject.Parse(policyData);
                Array jPolicies = jObject["policies"].ToArray();

                for (int i = 0; i < jPolicies.Length; i++)
                {
                    JObject jPolicy = JObject.Parse(jPolicies.GetValue(i).ToString());

                    Policy policy = new Policy();
                    policy.Id = (string)jPolicy["id"];
                    policy.AmountInsured = (decimal)jPolicy["amountInsured"];
                    policy.Email = (string)jPolicy["email"];
                    policy.InceptionDate = (DateTime)jPolicy["inceptionDate"];
                    policy.InstallmentPayment = (bool)jPolicy["installmentPayment"];
                    policy.ClientId = (string)jPolicy["clientId"];
                    policy.Client = clients.FirstOrDefault(q => q.Id == policy.ClientId);

                    policies.Add(policy);
                }
            }

            return policies;
        }

        public IEnumerable<Policy> ListPolicies()
        {
            string policyUrl = "http://www.mocky.io/v2/580891a4100000e8242b75c5";
         
            List<Policy> policies = new List<Policy>();

            using (WebClient wc = new WebClient())
            {
                var policyData = wc.DownloadString(policyUrl);
                JObject jObject = JObject.Parse(policyData);
                Array jPolicies = jObject["policies"].ToArray();

                for (int i = 0; i < jPolicies.Length; i++)
                {
                    JObject jPolicy = JObject.Parse(jPolicies.GetValue(i).ToString());

                    Policy policy = new Policy();
                    policy.Id = (string)jPolicy["id"];
                    policy.AmountInsured = (decimal)jPolicy["amountInsured"];
                    policy.Email = (string)jPolicy["email"];
                    policy.InceptionDate = (DateTime)jPolicy["inceptionDate"];
                    policy.InstallmentPayment = (bool)jPolicy["installmentPayment"];
                    policy.ClientId = (string)jPolicy["clientId"];

                    policies.Add(policy);
                }
            }

            return policies;
        }

        public IEnumerable<Policy> ListPoliciesByClientId(string clientId)
        {
            return ListPolicies().Where(q => q.ClientId == clientId);
        }

        public IEnumerable<Policy> ListPoliciesByName(string name)
        {
            return ListPoliciesClient().Where(q => q.Client.Name == name);
        }
    }
}
