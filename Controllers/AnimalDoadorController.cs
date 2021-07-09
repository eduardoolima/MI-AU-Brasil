using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIEAUBRASIL.Models;


namespace MIEAUBRASIL.Controllers
{
    public class AnimalDoadorController : Controller
    {
        private readonly MIEAUBRASILContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AnimalDoadorController(MIEAUBRASILContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AnimalDoador
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalDoador.ToListAsync());
        }

        public async Task<IActionResult> Adopt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalDoador = await _context.AnimalDoador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalDoador == null)
            {
                return NotFound();
            }
            animalDoador.UrlWhatsapp = "https://api.whatsapp.com/send?phone=55"+animalDoador.WhatsApp.ToString()+"&text=Ol%C3%A1!%20Gostaria%20de%20saber%20mais%20sobre%20o%20animal%20que%20você%20postou%20na%20MIAU-BRASIL";
            return View(animalDoador);
        }

        // GET: AnimalDoador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalDoador = await _context.AnimalDoador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalDoador == null)
            {
                return NotFound();
            }
            return View(animalDoador);
        }

        // GET: AnimalDoador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalDoador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAnimal,Especie,Genero,Deficiencia,Vacinado,Castrado,Observacao,DataResgate,Idade,Porte,PathFoto,Codigo,NomeDoador,Telefone,WhatsApp,Email,Cidade,Estado")] AnimalDoador animalDoador, IFormFile foto)
        {
            if (ModelState.IsValid)
            {
                //desativado
                #region Gerador de código
                //    List<AnimalDoador> codigos = _context.AnimalDoador.ToList();
                //    List<string> cods = new List<string>();
                
                //    foreach(AnimalDoador item in codigos)
                //    {
                //        cods.Add(item.Codigo.ToString());
                //    }
                //    Random cod = new Random();
                //    string codigo = cod.Next(99999).ToString();
                //    while (cods.Contains(codigo))
                //    {
                //        codigo=cod.Next().ToString();
                //    }
                //    animalDoador.Codigo = codigo;
                #endregion

                #region Foto
                    if (foto != null)
                    {
                        string pathFile = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                        string fileName = animalDoador.NomeAnimal + animalDoador.Codigo + ".png";
                        using (FileStream fileStream = new FileStream(Path.Combine(pathFile, fileName), FileMode.Create))
                        {
                            await foto.CopyToAsync(fileStream);
                            animalDoador.PathFoto = "~/img/" + fileName;
                        }
                    }
                    else
                    {
                        animalDoador.PathFoto = "~/img/default.jpg";
                    }
                #endregion
                

                _context.Add(animalDoador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalDoador);
        }

        // GET: AnimalDoador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalDoador = await _context.AnimalDoador.FindAsync(id);
            if (animalDoador == null)
            {
                return NotFound();
            }
            return View(animalDoador);
        }

        // POST: AnimalDoador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAnimal,Especie,Genero,Deficiencia,Vacinado,Castrado,Observacao,DataResgate,Idade,Porte,PathFoto,Codigo,ConfirmaCod,NomeDoador,Telefone,WhatsApp,Email,Cidade,Estado")] AnimalDoador animalDoador, IFormFile foto)
        {
            if (id != animalDoador.Id)
            {
                return NotFound();
            }
            AnimalDoador animal = new AnimalDoador();
            animal.Idade = animalDoador.Idade;


            AnimalDoador animal2 = animal;

            animal2.Idade = 44;


            if (ModelState.IsValid)
            {
                try
                {
                    if (animalDoador.ConfirmaCod != animalDoador.Codigo)
                    {
                        return View(animalDoador);
                    }
                    if (animalDoador.PathFoto != null)
                    {
                        #region Foto
                        if (foto != null)
                        {
                            string pathFile = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                            string fileName = animalDoador.NomeAnimal + animalDoador.Codigo + ".png";
                            using (FileStream fileStream = new FileStream(Path.Combine(pathFile, fileName), FileMode.Create))
                            {
                                await foto.CopyToAsync(fileStream);
                                animalDoador.PathFoto = "~/img/" + fileName;
                            }
                        }
                        #endregion
                    }
                    _context.Update(animalDoador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalDoadorExists(animalDoador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animalDoador);
        }
        

        // GET: AnimalDoador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalDoador = await _context.AnimalDoador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalDoador == null)
            {
                return NotFound();
            }

            return View(animalDoador);
        }

        // POST: AnimalDoador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, AnimalDoador cod)
        {

            var animalDoador = await _context.AnimalDoador.FindAsync(id);
            if (cod.ConfirmaCod != animalDoador.Codigo)
            {
                return View(animalDoador);
            }
            _context.AnimalDoador.Remove(animalDoador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalDoadorExists(int id)
        {
            return _context.AnimalDoador.Any(e => e.Id == id);
        }
    }
}
