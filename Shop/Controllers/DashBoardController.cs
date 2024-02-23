using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Shop.Data;
using Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Company> _company = new List<Company>();
        private static List<Product> _products = new List<Product>();

        private static List<Category> _category = new List<Category>();
        private static List<Post> _posts= new List<Post>();

        private readonly ApplicationDbContext _db;

        public DashBoardController(ApplicationDbContext db)
        {

            _db = db;
            _company.Add(new Company());
            _category.Add(new Category());
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Show()
        {
            var products = _db.products.Include(p => p.company).ToList();
            
            return View(products);
        }
        
        #region create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {

            if (!ModelState.IsValid)
            {
                return View(p);
            }
            _db.products.Add(p);
            _db.SaveChanges();
            _products.Add(p);
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult Delete(int id)
        {
            Product? toDelete = _db.products.SingleOrDefault( x=> x.Id == id );
            _db.products.Remove(toDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id )
        {
            Product? pp = _db.products.SingleOrDefault(x => x.Id == Id);

            return View(pp);
        }

        [HttpPost]
        public IActionResult Edit(Product pr)
        {
            Product pp = _db.products.FirstOrDefault(x => x.Id == pr.Id);
            pp.Name = pr.Name;
            pp.Id = pr.Id;
            pp.Description = pr.Description;
            pp.Price = pr.Price;
            pp.EnableSize = pr.EnableSize;
            pp.CompanyId = pr.CompanyId;
            pp.Quantity = pr.Quantity;
            _db.products.Update(pp);
            _db.SaveChanges();
            return RedirectToAction("Show");
        }

        #region 
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddPost(Post post)
		{
            //         int id ;
            //         if(posts.Count == 0)
            //         {
            //             id = 1;
            //         }else
            //         {
            //             id = posts.Max(x => x.Id)+1;
            //         }
            //         post.Id= id;
            //         posts.Add(post);
            //return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                return View(post);
            }
            _db.posts.Add(post);
            _db.SaveChanges();
            _posts.Add(post);
            return RedirectToAction("Index");

            
        }
        #endregion

        #region display
        public IActionResult display()
        {
            var ppp = _db.posts.Include(p => p.category).ToList();

            return View(ppp);
        }

        #endregion
        #region Remove Post
        public IActionResult Remove(int id)
        {
            //Post post = posts.FirstOrDefault(x => x.Id == id);
            //posts.Remove(post);
            //return RedirectToAction("Display");


            Post? toRemove = _db.posts.SingleOrDefault(x => x.Id == id);
            _db.posts.Remove(toRemove);
            _db.SaveChanges();
            return RedirectToAction("Index");

           
        }
        #endregion

        #region Update Post
        public IActionResult Update(int Id)
        {
            //Post post = posts.FirstOrDefault(x=>x.Id==id);
            //ViewData["D"] = post.Date.ToString("yyyy-MM-dd");
            //return View(post);

            Post? pp = _db.posts.SingleOrDefault(x => x.Id == Id);
            return View(pp);
        }

        [HttpPost]
        public IActionResult Update(Post post)
        {
            Post temp = _db.posts.FirstOrDefault(x =>x.Id == post.Id);

            temp.Id=post.Id;
            temp.Title = post.Title;
            temp.Author = post.Author;
            temp.Date = post.Date;
            temp.Descrition = post.Descrition;
            temp.Completed= post.Completed;
            temp.CategoryId = post.CategoryId;
            _db.posts.Update(temp);
            _db.SaveChanges();

            return RedirectToAction("Display"); 
            //return View(temp);
        }
        #endregion


    }

    public class CheckMaxCompanyPriceAttribute : ValidationAttribute
    {
        private readonly int _maxCompanyPrice;
        public CheckMaxCompanyPriceAttribute(int price) {
            _maxCompanyPrice =price;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product product = (Product)validationContext.ObjectInstance;
            int price;
            if(!int.TryParse(value.ToString() , out price) ){
                return new ValidationResult("Invalid Price Value");
            }

            if(product.CompanyId == 1 && price > _maxCompanyPrice)
            {
                return new ValidationResult("Price Must be less Than 30000 for ADDIDAS.");
            }
            return ValidationResult.Success;
        }

    }
}
