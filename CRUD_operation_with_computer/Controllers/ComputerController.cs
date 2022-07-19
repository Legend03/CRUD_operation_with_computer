using CRUD_operation_with_computer.Models;
using CRUD_operation_with_computer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_operation_with_computer.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _computerService;

    public ComputerController(IComputerService computerService)
    {
        _computerService = computerService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _computerService.GetAllComputer());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Computer());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Computer computer)
    {
        bool flag = false;
        if (computer.Name == null)
        {
            flag = true;
            ModelState.AddModelError("Name", "Неверное название компьютера!");
        }
        if (computer.VideoCard == null)
        {
            flag = true;
            ModelState.AddModelError("VideoCard", "Неверное название видеокарты!");
        }
        if (computer.Processor == null)
        {
            flag = true;
            ModelState.AddModelError("Processor", "Неверное название процессора!");
        }
        if (computer.RAM <= 0)
        {
            flag = true;
            ModelState.AddModelError("RAM", "Неверное количество оперативной памяти!");
        }
        if (computer.ROM <= 0)
        {
            flag = true;
            ModelState.AddModelError("ROM", "Неверное количество постоянной памяти!");
        }
        if (flag)
        {
            return View(computer);
        }
        await _computerService.Create(computer);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int computerId)
    {
        await _computerService.Delete(computerId);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int computerId)
    {
        return View(await _computerService.GetComputerById(computerId));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Computer computer)
    {
        bool flag = false;
        if (String.IsNullOrEmpty(computer.Name))
        {
            flag = true;
            ModelState.AddModelError("Name", "Неверное название компьютера!");
        }
        if (String.IsNullOrEmpty(computer.VideoCard))
        {
            flag = true;
            ModelState.AddModelError("VideoCard", "Неверное название видеокарты!");
        }
        if (String.IsNullOrEmpty(computer.Processor))
        {
            flag = true;
            ModelState.AddModelError("Processor", "Неверное название процессора!");
        }
        if (computer.RAM <= 0)
        {
            flag = true;
            ModelState.AddModelError("RAM", "Неверное количество оперативной памяти!");
        }
        if (computer.ROM <= 0)
        {
            flag = true;
            ModelState.AddModelError("ROM", "Неверное количество постоянной памяти!");
        }
        if (flag)
        {
            return View(computer);
        }
        await _computerService.Update(computer);
        return RedirectToAction("Index");
    }
}