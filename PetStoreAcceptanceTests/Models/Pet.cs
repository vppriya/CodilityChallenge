using System;
using System.Collections.Generic;

namespace PetStoreAcceptanceTests.Models
{
    internal class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }
        public PetStatus Status { get; set; }
    }

    internal class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    internal class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public enum PetStatus
    {
        Available,
        Pending,
        Sold
    }
}

