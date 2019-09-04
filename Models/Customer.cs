using MessagePack;
using System;

namespace Models
{

    // add package MessagePack
    [MessagePackObject]
    public class Customer
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string FirstName { get; set; }
        [Key(2)]
        public string LastName { get; set; }
        [Key(3)]
        public Gender Gender { get; set; }
        [Key(4)]
        public DateTime? Birthday { get; set; }
        [Key(5)]
        public string Email { get; set; }
        [Key(6)]
        public bool IsRemoved { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }

}
