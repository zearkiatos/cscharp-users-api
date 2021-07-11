using System;
using Newtonsoft.Json;
using Csharp.UsersApi.Shared.Utils;
namespace Csharp.UsersApi.Users.Domain
{
    public class User
    {
        public User(string name, string lastname, string email)
        {
            this.id = new GuidService().NewGuid().ToString();
            this.name = name;
            this.lastname = lastname;
            this.email = email;

        }
        [JsonProperty("id")]
        private string id;
        public string Id
        {
            get { return id; }
        }
        [JsonProperty("name")]
        private string name;
        public string Name
        {
            get { return name; }
        }
        [JsonProperty("lastname")]
        private string lastname;
        public string Lastname
        {
            get { return lastname; }
        }
        [JsonProperty("email")]
        private string email;
        public string Email
        {
            get { return email; }
        }

        public string Serialization()
        {
            string serialized = "";

            serialized += string.IsNullOrEmpty(this.id) ? "" : $"{this.id}~";

            serialized += string.IsNullOrEmpty(this.name) ? "" : $"{this.name}~";

            serialized += string.IsNullOrEmpty(this.lastname) ? "" : $"{this.lastname}~";

            serialized += string.IsNullOrEmpty(this.email) ? "" : $"{this.email}";

            return serialized;
        }


    }
}