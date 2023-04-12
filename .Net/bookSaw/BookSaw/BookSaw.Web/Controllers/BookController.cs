using AutoMapper;
using BookSaw.Core.Models;
using BookSaw.Core.Services;
using BookSaw.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookSaw.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;
        private readonly ICategoryService _categoryService;

        public BookController(IMapper mapper, IBookService service, ICategoryService categoryService)
        {
            _mapper = mapper;
            _service = service;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var books = await _service.GetAllAsync();

            var bookModels = _mapper.Map<List<BookModel>>(books.ToList());

            return View(bookModels);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var book = await _service.GetByIdAsync(id);

            var bookModel = _mapper.Map<BookModel>(book);

            return View(bookModel);
        }


        public async Task<ActionResult> Save()
        {

            var categories = await _categoryService.GetAllAsync();

            var categoryModels = _mapper.Map<List<CategoryModel>>(categories.ToList());

            ViewBag.categories = new SelectList(categoryModels, "Id", "Name");
            

            return View();

        }


        [HttpPost]
        public async Task<ActionResult> Save(BookModel bookModel)
        {

            if (ModelState.IsValid)
            {

                var book = _mapper.Map<Book>(bookModel);

                await _service.AddAsync(book);

                return RedirectToAction(nameof(Index));

            }

            var categories = await _categoryService.GetAllAsync();

            var categoryModels = _mapper.Map<List<CategoryModel>>(categories.ToList());

            ViewBag.categories = new SelectList(categoryModels, "Id", "Name",bookModel.CategoryId);


            return View();

        }


        public async Task<ActionResult> Update(int id)
        {
            var book = await _service.GetByIdAsync(id);


            var categories = await _categoryService.GetAllAsync();

            var categoryModels = _mapper.Map<List<CategoryModel>>(categories.ToList());

            ViewBag.categories = new SelectList(categoryModels, "Id", "Name");


            return View(_mapper.Map<BookUpdateModel>(book));

        }

        [HttpPost]
        public async Task<ActionResult> Update(BookUpdateModel bookUpdateModel)
        {


            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(bookUpdateModel);

                await _service.UpdateAsync(book);

                return RedirectToAction(nameof(Index));
            }


            var categories = await _categoryService.GetAllAsync();

            var categoryModels = _mapper.Map<List<CategoryModel>>(categories.ToList());

            ViewBag.categories = new SelectList(categoryModels, "Id", "Name", bookUpdateModel.CategoryId);

            return View();

        }

        public async Task<ActionResult> GetBooksWithCategory()
        {
             

            return View(await _service.GetBooksWithCategory());

        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _service.GetByIdAsync(id);

            await _service.DeleteAsync(book);


            return RedirectToAction(nameof(Index));
        }



    }
}
