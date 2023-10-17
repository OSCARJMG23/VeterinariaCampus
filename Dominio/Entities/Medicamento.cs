using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Medicamento : BaseEntity
    {
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public int IdLaboratorioFk { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public ICollection<TratamientoMedico> TratamientosMedicos { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
        public ICollection<MedicamentoProveedor> MedicamentosProveedores { get; set; }
        public ICollection<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    }
}