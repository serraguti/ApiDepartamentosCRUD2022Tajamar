using ApiDepartamentosCRUD2022.Models;
using ApiDepartamentosCRUD2022.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDepartamentosCRUD2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Departamento>> GetDepartamentos()
        {
            return this.repo.GetDepartamentos();
        }

        [HttpGet("{id}")]
        public ActionResult<Departamento> GetDepartamento(int id)
        {
            return this.repo.FindDepartamento(id);
        }

        //EN LAS CONSULTAS DE ACCION POST Y PUT SE RECIBEN LOS 
        //OBJETOS POR DEFECTO
        //PODRIAMOS HACER QUE NO DEVOLVIERAN NADA Y LA RESPUESTA 
        //ES 200 SI TODO VA BIEN
        //PODRIAMOS PERSONALIZAR LA RESPUESTA
        //public ActionResult Insert()
        //{
        //    return Ok();
        //    return BadRequest();
        //    return Unauthorized();
        //    return new HttpStatusCode(405);
        //}
        [HttpPost]
        public ActionResult InsertDepartamento(Departamento departamento)
        {
            this.repo.InsertDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateDepartamento(Departamento departamento)
        {
            this.repo.UpdateDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        //EL METODO DELETE POR DEFECTO RECIBE {id}
        [HttpDelete("{id}")]
        public void DeleteDepartamento(int id)
        {
            this.repo.DeleteDepartamento(id);
        }
    }
}
