﻿namespace SistemaAPI.Models.Domain
{
    public class Persona
    {
        public Guid Id { get; set; }
        public int identificacion { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}