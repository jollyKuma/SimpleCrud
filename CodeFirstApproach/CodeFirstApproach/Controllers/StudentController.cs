using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Models;

namespace CodeFirstApproach.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        StudentContext objContext;
        public StudentController()
        {
            objContext = new StudentContext();
        }

        public ActionResult Index()
        {
            var Students = objContext.students.ToList();
            return View(Students);
        }
        public ViewResult Details(int id)
        {
            Student student = objContext.students.Where(x => x.ID == id).SingleOrDefault();
            return View(student);
        }
        #region Create Student
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            objContext.students.Add(student);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        #region Edit Student
        public ActionResult Edit(int id)
        {
            Student student = objContext.students.Where(x => x.ID == id).SingleOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            Student student = objContext.students.Where(x => x.ID == model.ID).SingleOrDefault();
            if(student != null)
            {
                objContext.Entry(student).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
        #region Delete Student
        public ActionResult Delete(int id)
        {
            Student student = objContext.students.Find(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(int id, Student model)
        {
            Student student = objContext.students.Where(x => x.ID == id).SingleOrDefault();
            if (student != null)
            {
                objContext.students.Remove(student);
                objContext.SaveChanges();
               
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
