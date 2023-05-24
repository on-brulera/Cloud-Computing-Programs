using Historia.Modelos;
using Historia.UAPI;

var uapi = new Crud<Mitologia>();
var url = "https://localhost:7149/api/";

//INSERTAR MITOLOGIA

//var mitologia = new Historia.Modelos.Mitologia
//{
//    Id = 0,
//    Nombre = "EGIPCIA",
//    PaisOrigen = "EGIPTO",
//    FechaOrigen = new DateTime()
//};

//var crearMitologia = uapi.Insert(url + "Mitologias", mitologia);

//VERIFICAR MITOLOGIA

var dataMitologia = uapi.Select(url + "Mitologias");

foreach (var mito in dataMitologia)
{
    Console.WriteLine($"Nombre Mitología:  {mito.Nombre} - Pais: {mito.PaisOrigen} - Fecha Origen: {mito.FechaOrigen}");
}

//CAPA BL

//var numeroDioses = uapi.Select("https://localhost:7149/BL/NumeroDioses");

//Console.WriteLine("Número total de Dioses " + numeroDioses);

Console.ReadKey();