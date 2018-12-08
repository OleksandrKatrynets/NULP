using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NULP.DAL;
using NULP.Model.Models;
using static System.Console;

namespace NULP.Terminal
{
    public static class Program
    {
        private static async Task Main()
        {
            using (var uw = new UnitOfWork())
            {
                PrintAllData(uw);
                await uw.HospitalRepository.Create(GenerateData());
                PrintAllData(uw);
                var hospital = uw.HospitalRepository.GetAll()
                    .Include(h => h.Departments)
                    .FirstOrDefault(h => h.Name == "Hospital 1");
                if (hospital != null)
                {
                    await uw.HospitalRepository.Delete(hospital.Id);                    
                }
                PrintAllData(uw);
            }

            Read();
        }

        private static Hospital GenerateData()
        {
            var data = new Hospital
            {
                Name = "Hospital 1",

                Departments = new List<Department>
                {
                    new Department
                    {
                        Name = "Department 1",

                        Persons = new List<Person>
                        {
                            new Person
                            {
                                FirstName = "FirstName1",
                                LastName = "LastName1"
                            },
                            new Person
                            {
                                FirstName = "FirstName2",
                                LastName = "LastName2"
                            }
                        }
                    },
                    new Department
                    {
                        Name = "Department 2",

                        Persons = new List<Person>
                        {
                            new Person
                            {
                                FirstName = "FirstName3",
                                LastName = "LastName3"
                            },
                            new Person
                            {
                                FirstName = "FirstName4",
                                LastName = "LastName4"
                            }
                        }
                    }
                }
            };
            return data;
        }

        private static void PrintAllData(UnitOfWork uw)
        {
            WriteLine("Hospitals:");
            uw.HospitalRepository.GetAll().ToList().ForEach(hospital => WriteLine(hospital.Name));
            WriteLine("Departments:");
            uw.DepartmentRepository.GetAll().ToList().ForEach(department => WriteLine(department.Name));
            WriteLine("Personal:");
            uw.PersonRepository.GetAll().ToList().ForEach(person => WriteLine(person.GetFullName()));
        }
    }
}