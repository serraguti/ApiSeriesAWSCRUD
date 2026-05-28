using ApiSeriesAWSCRUD.Data;
using ApiSeriesAWSCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ApiSeriesAWSCRUD.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int idSerie)
        {
            return await this.context.Series
                .FirstOrDefaultAsync(x => x.IdSerie == idSerie);
        }

        private async Task<int> GetMaxIdSerieAsync()
        {
            return await this.context.Series
                .MaxAsync(x => x.IdSerie) + 1;
        }

        public async Task CreateSerieAsync
            (string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = await this.GetMaxIdSerieAsync();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            await this.context.Series.AddAsync(serie);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateSerieAsync
            (int id, string nombre, string imagen, int anyo)
        {
            Serie serie = await this.FindSerieAsync(id);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteSerieAsync(int id)
        {
            Serie serie = await this.FindSerieAsync(id);
            this.context.Series.Remove(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
