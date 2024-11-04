using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment2
{
    public class ContactModel
    {
        public string FirstName {get;set;} = "";
        public string LastName {get;set;} = "";
        public string Address {get;set;} = "";
        public string State {get;set;} = "";
        public string City {get;set;} = "";

        public int Zip {get;set;} = 0;
    }

}