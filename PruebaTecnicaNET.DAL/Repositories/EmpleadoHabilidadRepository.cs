using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNET.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNET.DAL.Repositories
{
    public class EmpleadoHabilidadRepository : IEmpleadoHabilidadRepository
    {
        private readonly ExamenContext _examenContext;

        public EmpleadoHabilidadRepository(ExamenContext examenContext)
        {
            _examenContext = examenContext;
        }

        public async Task AddHabilidadByEmpleado(EmpleadoHabilidad empleadoHabilidad)
        {
            _examenContext.EmpleadoHabilidad.Add(empleadoHabilidad);
            await _examenContext.SaveChangesAsync();
        }

        public async Task DeleteHabilidadEmpleado(EmpleadoHabilidad empleadoHabilidad)
        {

                _examenContext.EmpleadoHabilidad.Remove(empleadoHabilidad);
                await _examenContext.SaveChangesAsync();
        }

        public async Task<EmpleadoHabilidad> GetHabilidad(int IdHabilidad)
        {
            return await _examenContext.EmpleadoHabilidad.FirstOrDefaultAsync(x => x.IdHabilidad == IdHabilidad);
        }

        public async Task<IEnumerable<EmpleadoHabilidad>> GetHabilidadesByEmpleadoId(int IdEmpleado)
        {
            return await  _examenContext.EmpleadoHabilidad.Where(x => x.IdEmpleado == IdEmpleado).ToListAsync();
        }

        public async Task<IEnumerable<Jerarquia>> GetJerarquia()
        {
            List<Jerarquia> jerarquia = new List<Jerarquia>();
            try
            {
                using (SqlConnection cnx = new SqlConnection(_examenContext.Database.GetDbConnection().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"WITH empleados_CTE AS (
    SELECT
        IdEmpleado, NombreCompleto, Correo,
        IdArea, 0[IdJefe],
        1 as Nivel
    FROM
        Empleado
    WHERE
        IdJefe IS NULL


    UNION ALL
    SELECT
        e.IdEmpleado, e.NombreCompleto, e.Correo,
        e.IdArea, e.IdJefe,
        Nivel + 1 as Nivel
    FROM
        Empleado e
        INNER JOIN empleados_CTE ecte
            ON ecte.IdEmpleado = e.IdJefe
)


SELECT C.*, ISNULL(E.NombreCompleto,'')[NombreJefe]
FROM empleados_CTE C
LEFT JOIN Empleado E ON C.IdJefe = E.IdEmpleado", cnx))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cnx.Open();
                        var reader = await cmd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Jerarquia j = new Jerarquia()
                                {
                                    IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                                    NombreCompleto = Convert.ToString(reader["NombreCompleto"]),
                                    Nivel = Convert.ToInt32(reader["Nivel"]),
                                    IdJefe = Convert.ToInt32(reader["IdJefe"]),
                                    NombreJefe = Convert.ToString(reader["NombreJefe"] ?? "")
                                };

                                jerarquia.Add(j);
                            }
                        }
                    }
                }

                return jerarquia;
            }
            catch (System.Exception)
            {
                return new List<Jerarquia>();
                throw;
            }
        }
    }
}
