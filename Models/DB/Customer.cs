﻿using System.ComponentModel.DataAnnotations;

namespace TrainingProjectAPI.Models.DB
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
