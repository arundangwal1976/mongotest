﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoWebAppTest.Models;

namespace MongoWebAppTest.Helper
{
    public class EmployeeContext: IDataContext<Employee, EmployeeViewModel>
    {
        MongoConfiguration mongoConfiguration;
        IMongoDatabase db;

        public EmployeeContext(IOptionsMonitor<MongoConfiguration> option)
        {
            mongoConfiguration = option.CurrentValue;

            var dbClient = new MongoClient(mongoConfiguration.Connection);
            db = dbClient.GetDatabase("hrm");


        }

        public IMongoCollection<Employee> Employees
        {
            get
            {
                return db.GetCollection<Employee>("employees");
            }
        }

        public void Add(EmployeeViewModel vm)
        {
            Employees.InsertOne(new Employee(vm));
        }

        public IEnumerable<EmployeeViewModel> Get(string id = null)
        {
            var filter = Builders<Employee>.Filter.Empty;

            if (!string.IsNullOrEmpty(id))
            {
                filter = Builders<Employee>.Filter.Eq("_id", ObjectId.Parse(id));
            }

            return Employees.Find<Employee>(filter)
                .ToList()
                ?.Select(e => new EmployeeViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    JoiningDate = e.JoiningDate,
                    IsMale = e.IsMale
                });
        }

        public void Update(EmployeeViewModel vm)
        {
            var filter = Builders<Employee>.Filter.Eq("_id", ObjectId.Parse(vm.Id));

            Employees.ReplaceOne(filter, new Employee(vm));
        }
    }
}
