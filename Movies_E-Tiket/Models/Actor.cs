﻿using System.ComponentModel.DataAnnotations;

namespace Movies_E_Tiket.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }


    }
}
