using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ILibroService
    {
        IEnumerable<Libro> GetAll();
        bool Add(Libro model);
        bool Update(Libro model);
        bool Delete(int id);
        Libro Get(int id);
        
    }   
    public class LibroService : ILibroService
    {
        private readonly libroDbContext _libroDbContext;
        public LibroService(libroDbContext libroDbContext)
        {

            _libroDbContext = libroDbContext;
        }

            
        public IEnumerable<Libro> GetAll()
        {
            var result = new List<Libro>();
            try
            {
                result = _libroDbContext.Libro.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public Libro Get(int id)
        {
            var result = new Libro();   
            try
            { 
                result = _libroDbContext.Libro.Single(x => x.libroID == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Libro model)
        {
            try
            {
                _libroDbContext.Add(model);
                _libroDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
                
            }
            return true;
        }


        public bool Update(Libro model)
        {
            try
            {
                var originalModel = _libroDbContext.Libro.Single(x => x.libroID == model.libroID);
                originalModel.nombre = model.nombre;
                originalModel.autor = model.autor;
                originalModel.descripcion = model.autor;
                originalModel.precio = model.precio;


                _libroDbContext.Update(originalModel);
                _libroDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;

            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _libroDbContext.Entry(new Libro { libroID = id}).State = EntityState.Deleted; ;
                _libroDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;

            }
            return true;
        }

     
    }
}
