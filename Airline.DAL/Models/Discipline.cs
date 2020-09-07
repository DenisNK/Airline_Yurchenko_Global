﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class Discipline : BaseId , IEntity
    {
        [Required(ErrorMessage = "Please, input discipline name")]
        //   [Remote("ValidateJsonResultTitle", "Disciplines")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should not be longer than 20 characters.")]
        public string Title { set; get; }

        [Required(ErrorMessage = "Please, input annotation name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} should not be longer than 20 characters.")]
        public string Annotation { set; get; }

        public List<StudDisc> StudDiscs { set; get; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}