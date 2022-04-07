using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebContactRegister.Data;
using WebContactRegister.Models;
namespace WebContactRegister.Controllers
{
    public class ContactRegController : Controller
    {
        private readonly ContactRegDBContext _context;
        public ContactRegController(ContactRegDBContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            List<Company> companies;
            companies = _context.Companies.ToList();
            return View(companies);
        }
        [HttpGet]

        public IActionResult Index(string name)
        {
            List<Company> companies;
            companies = _context.Companies
                .Where(a => a.CompanyName == name || name == null).ToList();


            return View(companies);

        }
        [HttpGet]
        public IActionResult Create()
        {
            Company company = new Company();
            company.Persons.Add(new Person() { PID = 1 });
            //company.Persons.Add(new Person() { PID = 2 });
            //company.Persons.Add(new Person() { PID = 3 });

            return View(company);
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            company.Persons.RemoveAll(n => n.Name == "");
            company.Persons.RemoveAll(n => n.PhoneNumber == "");

            _context.Add(company);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        // [HttpGet]
        public IActionResult Details(int Id)
        {
            Company company = _context.Companies
                .Include(e => e.Persons)
                .Where(a => a.CompanyID == Id).FirstOrDefault();

            return View(company);
        }
        [HttpGet]

        public IActionResult Delete(int Id)
        {
            Company company = _context.Companies
                .Include(e => e.Persons)
                .Where(a => a.CompanyID == Id).FirstOrDefault();

            return View(company);
        }
        [HttpPost]
        public IActionResult Delete(Company company)
        {
            _context.Attach(company);
            _context.Entry(company).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Company company = _context.Companies
                .Include(e => e.Persons)
                .Where(a => a.CompanyID == Id).FirstOrDefault();

            return View(company);
        }
        [HttpPost]
        public IActionResult Edit(Company company)
        {
            List<Person> personDetails = _context.People.Where(d => d.CID == company.CompanyID).ToList();
            _context.People.RemoveRange(personDetails);
            _context.SaveChanges();
            company.Persons.RemoveAll(n => n.Name == "");
            company.Persons.RemoveAll(n => n.PhoneNumber == "");
            company.Persons.RemoveAll(n => n.IsDeleted == true);

            _context.Attach(company);
            _context.Entry(company).State = EntityState.Modified;
            _context.People.AddRange(company.Persons);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
