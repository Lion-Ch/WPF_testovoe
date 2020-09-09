using BLL.DTO;
using BLL.Services;
using DAL.EF;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            EFUnitOfWork uow = new EFUnitOfWork("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebStoreDb;Integrated Security=True");
            CategoryService categoryService = new CategoryService(uow);
            List<CategoryDTO> list = (List<CategoryDTO>)categoryService.GetAll();

            foreach(CategoryDTO c in list)
            {
                Console.WriteLine($"{c.Id} {c.Name}");
            }
        }
    }
}
