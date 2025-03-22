using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataBasMedRegistrering
{
    internal class StudentManager
    {
        private Menu menu;
        StudentDbContext dbCtx = new();
        public StudentManager()
        {
            menu = new(this);
        }
        internal void ListStudents()
        {
            foreach (var student in dbCtx.Students)
            {
                Console.WriteLine($"Id: {student.StudentId} Name: {student.FirstName} {student.LastName} City: {student.City}");
            }
        }
        internal void RegisterStudent(Student student)
        {
            dbCtx.Add(student);
            dbCtx.SaveChanges();

        }
        internal Student GetStudentInfo(int id)
        {
            var studentToChange = dbCtx.Students.First(student => student.StudentId == id);
            return studentToChange;
        }
        internal void UpdateStudent(Student student)
        {
            dbCtx.Update(student);
            dbCtx.SaveChanges();
        }

        internal int GetStudentCount()
        {
            return dbCtx.Students.OrderBy(s => s.StudentId).Last().StudentId;
        }

    }
}
