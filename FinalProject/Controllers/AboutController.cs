using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;
using FinalProject.Models;

namespace FinalProject.Controllers;

public class AboutController : Controller
{
    private readonly ITodoItemService _todoItemService;
    public AboutController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }
    public IActionResult Index()
    {
        return View();
    }
}