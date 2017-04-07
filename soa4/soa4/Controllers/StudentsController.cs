using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using soa4.Models;
namespace soa4.Controllers
{
    public class StudentsController : ApiController
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
       /* Product[] p = new Product[]
        {
            new Product {id=1,name="hey" }
        };*/
        [HttpGet]
        public IEnumerable<Student> getStudent()
        {
            //return p;
            return db.Students.AsEnumerable();
        }
        [HttpGet]
        public Student getStudentById(int id)
        {
            var q = db.Students.FirstOrDefault(i => i.Id == id);
            return q;
        }
        [HttpDelete]
        public void deleteStudentById(int id)
        {
            var q = db.Students.FirstOrDefault(i => i.Id == id);
            db.Students.DeleteOnSubmit(q);
            db.SubmitChanges();
        }

        [HttpPut]
        public void updateStudentById(int id, string name, int age, string email)
        {
            foreach (Student s in db.Students)
            {
                if (s.Id == id)
                {
                    s.Name = name;
                    s.age = age;
                    s.email = email;
                    db.SubmitChanges();
                }
            }
        }
        [HttpPost]
        public void addStudent(string name, int age, string email)
        {
            Student s = new Student();
            s.Name = name;
            s.age = age;
            s.email = email;
            db.Students.InsertOnSubmit(s);
            db.SubmitChanges();
        }
    }
}
