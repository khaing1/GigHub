using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }  //didn't understand the full meaning

        public IEnumerable<Genre> Genres { get; set; }  //didn't understand the full meaning

        public DateTime getDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));

        }
    }
}