using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoWebAppTest.Models;

namespace MongoWebAppTest.Helper
{
    public class Employee
    {
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Local)]
        public DateTime JoiningDate { get; set; }

        [BsonDateTimeOptions(DateOnly = true, Kind = DateTimeKind.Local)]
        public DateTime? ResignationDate { get; set; }

        public bool IsMale { get; set; }

        public Address Address { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public List<Department> Departments { get; set; }

        public Employee()
        {

        }

        public Employee(EmployeeViewModel vm)
        {
            Id = vm.Id ?? ObjectId.GenerateNewId().ToString();
            Name = vm.Name;
            JoiningDate = vm.JoiningDate;
            ResignationDate = vm.ResignationDate;
            IsMale = vm.IsMale;
            Address = new Address
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Street = (vm.Address?.Street ?? string.Empty).Split('/'),
                City = vm.Address?.City,
                State = vm.Address?.State,
                ZipCode = vm.Address?.ZipCode
            };
            Salary = vm.Salary;
            Age = vm.Age;
            Departments = vm.Departments?.Select(d => new Department
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = d.Name
            })?.ToList();
        }
    }
}
