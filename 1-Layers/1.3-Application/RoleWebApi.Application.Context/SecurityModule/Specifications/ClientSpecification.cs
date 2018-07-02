namespace RoleWebApi.Application.Context.SecurityModule.Specifications
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RoleWebApi.Infrastructure.CrossCutting.DTO;
    using RoleWebApi.Infrastructure.Data.Context;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class ClientSpecification : IClientSpecification
    {
        private readonly IUnitOfWork<PolicyContext> _unitOfWork;

        public ClientSpecification(IUnitOfWork<PolicyContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Client GetClientById(string id)
        {
            return ListClients().FirstOrDefault(q => q.Id == id);
        }

        public Client GetClientByName(string name)
        {
            return ListClients().FirstOrDefault(q => q.Name == name);
        }

        public Client GetClientByEmail(string email)
        {
            return ListClients().FirstOrDefault(q => q.Email == email);
        }

        public ICollection<Client> ListClients()
        {
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

            return clients;
        }
    }
}
