using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSystem
{
    public class datos_Impresora
    {
        int id, id_em;
        string nombre, nombre_em, modelo, marca, serial;

        public int Id { get => id; set => id = value; }
        public int Id_em { get => id_em; set => id_em = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nombre_em { get => nombre_em; set => nombre_em = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Serial { get => serial; set => serial = value; }
    }
}
