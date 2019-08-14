using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class User
    {
        public int id {get;set;}
        public string name {get;set;}
        public string quote {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
}