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
        protected string id;
        public string Id
        {
            set { id = value; }
            get { return id; }
        }
        [JsonProperty("name")]
        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        [JsonProperty("lastname")]
        private string lastname;
        public string Lastname
        {
            set { lastname = value; }
            get { return lastname; }
        }
        [JsonProperty("email")]
        private string email;
        public string Email
        {
            set { email = value; }
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