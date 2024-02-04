using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Shop.Models;

namespace Shop.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Product> _products = new List<Product>();

        private static List<Post> posts= new List<Post>();

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Show()
        {

            return View(_products);
        }
        #region create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            int id;
            if (_products.Count() == 0)
            {
                 id = 1;
            }
            else
            {
                id = _products.Max(x => x.Id) + 1;
            }
            p.Id = id;
            _products.Add(p);
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult Delete(int id)
        {
            Product toDelete = _products.FirstOrDefault( x=> x.Id == id );
            _products.Remove(toDelete);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id )
        {
            Product pp = _products.FirstOrDefault(x => x.Id == Id);

            return View(pp);
        }

        [HttpPost]
        public IActionResult Edit(Product pr)
        {
            Product pp = _products.FirstOrDefault(x => x.Id == pr.Id);
            pp.Name = pr.Name;
            pp.Id = pr.Id;
            pp.Description = pr.Description;
            pp.Price = pr.Price;
            pp.EnableSize = pr.EnableSize;
            pp.Quantity = pr.Quantity;
            return View(pp);
        }

        #region 
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddPost(Post post)
		{
            int id ;
            if(posts.Count == 0)
            {
                id = 1;
            }else
            {
                id = posts.Max(x => x.Id)+1;
            }
            post.Id= id;
            posts.Add(post);
			return RedirectToAction("Index");
		}
        #endregion
        #region display
        public IActionResult display()
        {
            return View(posts);
        }

        #endregion

        #region Remove Post
        public IActionResult Remove(int id)
        {
            Post post = posts.FirstOrDefault(x => x.Id == id);
            posts.Remove(post);
            return RedirectToAction("Display");
        }
        #endregion

        #region Update Post
        public IActionResult Update(int id)
        {
            Post post = posts.FirstOrDefault(x=>x.Id==id);
            ViewData["D"] = post.Date.ToString("yyyy-MM-dd");
            return View(post);
        }
        [HttpPost]
        public IActionResult Update(Post post)
        {
            Post temp = posts.FirstOrDefault(x =>x.Id == post.Id);

            temp.Id=post.Id;
            temp.Title = post.Title;
            temp.Author = post.Author;
            temp.Date = post.Date;
            temp.Descrition = post.Descrition;
            temp.Completed= post.Completed;
            temp.category.Id = post.category.Id;

            return RedirectToAction("Index"); 
            //return View(temp);
        }
        #endregion


    }
}
