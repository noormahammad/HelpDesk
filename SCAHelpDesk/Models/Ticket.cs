using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCAHelpDesk.Models
{
    public class Ticket
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        public string IssueDescription { get; set; }

    }
}