using System;
using System.Linq;
using ASPNet_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet_core.Controllers
{
    public class EscuelaController:Controller
    {
        
        public IActionResult Index()
        {


            ViewBag.a="cali";
            ViewData["hola"]=5;
            
            return View(_context.Escuelas.FirstOrDefault());
        }
        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context=context;
        }

         
    }
}