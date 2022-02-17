using MenuApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MenuApp.Controllers
{
    public class ServicesController : Controller
    {

        private readonly ICountriesSearch _countriesSearch;
        private readonly ILettersCounter _lettersCounter;
        private readonly INamePrinter _namePrinter;
        private readonly ISmartCalculator _smartCalculator;

        public ServicesController(ICountriesSearch countriesSearch, ILettersCounter lettersCounter, INamePrinter namePrinter, ISmartCalculator smartCalculator)
        {
            _countriesSearch = countriesSearch;
            _lettersCounter = lettersCounter;
            _namePrinter = namePrinter;
            _smartCalculator = smartCalculator;
        }

        [HttpGet]
        public IActionResult NamePrinter()
        {

            return View(_namePrinter);
        }
        [HttpPost]
        public IActionResult NamePrinter(NamePrinter namePrinter)
        {
            if (ModelState.IsValid)
            {
                namePrinter.Serve();
            }
            return View(namePrinter);
        }

        [HttpGet]
        public IActionResult CountriesSearch()
        {
            return View(_countriesSearch);
        }

        [HttpPost]
        public IActionResult CountriesSearch(CountriesSearch countriesSearch)
        {
            countriesSearch.Serve();
            return View(countriesSearch);
        }

        [HttpGet]
        public IActionResult LettersCounter()
        {
            return View(_lettersCounter);
        }

        [HttpPost]
        public IActionResult LettersCounter(LettersCounter lettersCounter)
        {
            if (ModelState.IsValid)
            {
                lettersCounter.Serve();
            }
            return View(lettersCounter);
        }
        [HttpGet]
        public IActionResult SmartCalculator()
        {

            return View(_smartCalculator);
        }

        [HttpPost]
        public IActionResult SmartCalculator(SmartCalculator smartCalculator)
        {
            if (ModelState.IsValid)
            {
                smartCalculator.Serve();
            }
            return View(smartCalculator);
        }

        [HttpGet]
        public IActionResult WeekDescription()
        {
            return View(_countriesSearch);
        }

        [HttpPost]
        public IActionResult WeekDescription(CountriesSearch countriesSearch)
        {
            countriesSearch.Start();
            return View(countriesSearch);
        }
    }
}
