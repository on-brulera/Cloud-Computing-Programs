namespace Historia.Modelos
{
    public class Mitologia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public DateTime FechaOrigen { get; set; }

        //Relacion
        public List<Dios>? Dioses { get; set; }
    }
}