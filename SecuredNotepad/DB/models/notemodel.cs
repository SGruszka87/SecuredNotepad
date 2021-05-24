using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuredNotepad.DB.models
{
    public class notemodel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [JsonProperty("data")]
        public DateTime Date { get; set; }

        [MaxLength(50)]
        [JsonProperty("Title")]
        public string Title { get; set; }

        [MaxLength(1024)]
        [JsonProperty("Note")]
        public string Note { get; set; }


        [MaxLength(1024)]
        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
