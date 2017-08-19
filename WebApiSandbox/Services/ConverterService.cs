using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSandbox.Models;

namespace WebApiSandbox.Services
{
    public static class ConverterService
    {
        #region ConvertToViewModel
        public static ViewModel.Person ConvertToViewModel(this Models.Person person) => new ViewModel.Person
        {
            Id = person.Id,
            FirstName = person.FirstName,
            MiddleName = person.MiddleName,
            LastName = person.LastName,
            HomePhone = person.HomePhone,
            WorkPhone = person.HomePhone,
            Address = person.Address?.ConvertToViewModel()
        };

        public static ViewModel.Address ConvertToViewModel(this Models.Address addr) => new ViewModel.Address
        {
            Id = addr.Id,
            AddressType = addr.AddressType,
            Street1 = addr.Street1,
            Street2 = addr.Street2,
            City = addr.City,
            State = addr.State,
            Zip = addr.Zip
        };

        public static IList<ViewModel.Address> ConvertToViewModel(this IList<Models.Address> addrs) => 
            addrs?.Select(a => a.ConvertToViewModel()).ToList();
        #endregion
        #region ConvertToModel
        public static Models.Person ConvertToModel(this ViewModel.Person person) => new Models.Person
        {
            Id = person.Id,
            FirstName = person.FirstName,
            MiddleName = person.MiddleName,
            LastName = person.LastName,
            HomePhone = person.HomePhone,
            WorkPhone = person.HomePhone,
            Address = person.Address?.ConvertToModel()
        };

        public static Models.Address ConvertToModel(this ViewModel.Address addr) => new Models.Address
        {
            Id = addr.Id,
            AddressType = addr.AddressType,
            Street1 = addr.Street1,
            Street2 = addr.Street2,
            City = addr.City,
            State = addr.State,
            Zip = addr.Zip
        };

        public static IList<Models.Address> ConvertToModel(this IList<ViewModel.Address> addrs) =>
            addrs?.Select(a => a.ConvertToModel()).ToList();
#endregion
    }
}