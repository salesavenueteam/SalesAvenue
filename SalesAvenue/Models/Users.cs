using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace SalesAvenue.Models
{
    public class Users
    {
        [Display(Name="Store name")]
        [Required(ErrorMessage="Please Enter a Store Name")]
        [Remote("StoreNameExists", "Registeration", HttpMethod = "POST", ErrorMessage = "Store name already exists. Please enter a different store name.")]
        public string StoreName { get; set; }

        [Remote("EmailExists", "Registeration", HttpMethod = "POST", ErrorMessage = "Email already exists. Please enter a different email.")]
        [Display(Name = "Email")]
        [Required(ErrorMessage="Email field cannot be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }

    public class UserCompleteDetails
    {
        [ReadOnly(true)]
        [Display(Name = "Store name")]
        [Required(ErrorMessage = "Please Enter a Store Name")]
        public string StoreName { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email field cannot be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }



}