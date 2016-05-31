using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        List<Student> users = new List<Student>()
        {
            new Student{Id="A", Marks=7},
            new Student{Id="B", Marks=9},
            new Student{Id="C", Marks=8},
            new Student{Id="D", Marks=5},
            new Student{Id="E", Marks=10}
        };

        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            return users;
        }

        // GET api/<controller>/5
        public Student Get(String id)
        {
            var user = users.Single(u => u.Id == id);
            return user;
        }

        // POST api/<controller>
        public IEnumerable<Student> Post(Student user)
        {
            users.Add(user);
            return users;
        }

        // PUT api/<controller>/5
        public IEnumerable<Student> Put(String id, Student newUser)
        {
            var user = users.Single(u => u.Id == id);
            user.Id = newUser.Id;
            user.Marks = newUser.Marks;
            return users;
        }

        // DELETE api/<controller>/5
        public IEnumerable<Student> Delete(String id)
        {
            var user = users.Single(u => u.Id == id);
            users.Remove(user);
            return users;
        }
    }
}