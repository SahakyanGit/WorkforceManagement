﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkforceManagement.BLL.DataProvider;
using WorkforceManagement.Domain.Entities;
using System.Linq;
using AutoMapper;
using WorkforceManagement.DAL.DataProvider;
using WorkforceManagement.DTO.Models;
using WorkforceManagement.BLL.Logic;

namespace WorkforceManagement.BLL.Authentication
{
    public class AuthenticationConfig :  IAuthenticationConfig
    {
        private IMapLogic<Employee,EmployeeDto> _mapperEmployee;
        private IMapLogic<AuthData, AuthDataDto> _mapperAuthData;
        private IRepository<Employee> _employee;
        private IRepository<AuthData> _authData;

        public AuthenticationConfig(IMapLogic<Employee,EmployeeDto> mapperEmployee,IMapLogic<AuthData,AuthDataDto> mapperAuthData,
            IRepository<Employee> employee,IRepository<AuthData> authData)
        {
            _mapperEmployee = mapperEmployee;
            _mapperAuthData = mapperAuthData;
            _employee = employee;
            _authData = authData;
        }

        public static bool IsAuthenticated { get; set; }

        public void Register(EmployeeDto employee,AuthDataDto authData)
        {
            var newEmployee = _mapperEmployee.MapEntitySingle(employee);

            _employee.Insert(newEmployee);

            int id = _employee.GetAll().Select(x => x.EmployeeId).Last();
            authData.Roles = "User";
            authData.EmployeeId = id;


            var newAuthData = _mapperAuthData.MapEntitySingle(authData);

            _authData.Insert(newAuthData);
        }

        public string SignIn(AuthData authData)
        {
            var adminEmail = _authData.GetAll().Select(x => x.Email).First();
            var adminPass = _authData.GetAll().Select(x => x.Password).First();
            string role = "";

            if (authData.Email == adminEmail && authData.Password == adminPass)
            {
                role = "admin";
            }
            else
            {
                foreach (var item in _authData.GetAll())
                {
                    if (item.Email == authData.Email && item.Password == authData.Password)
                    {
                        AuthenticationConfig.IsAuthenticated = true;
                        role = "user";
                        break;
                    }
                }
            }
            return role;
        }
    }
}
