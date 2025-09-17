using lib_dominio.Entidades;
namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {

        public static TelefonosAcompañantes? TelefonosAcompañantes()
        {
            var entidad = new TelefonosAcompañantes();
            entidad.Telefono = "Prueba";

            return entidad;
        }
        public static Acompañantes? Acompañantes(TelefonosAcompañantes telefonosacompañantes)
        {
            var entidad = new Acompañantes();
            entidad.Nombre = "Prueba";
            entidad.Email = "Prueba";
            entidad.FechaNacimiento = DateTime.Now;
            entidad.Documento = 2332;
            entidad.IdTelefonoAcompañante = telefonosacompañantes.Id;

            return entidad;
        }

        public static Clientes? Clientes(TelefonosClientes telefonosclientes)
        {
            var entidad = new Clientes();
            entidad.Nombre = "Prueba";
            entidad.Email = "Prueba";
            entidad.FechaNacimiento = DateTime.Now;
            entidad.Documento = 2332;
            entidad.IdTelefonoCliente = telefonosclientes.Id;

            return entidad;
        }

        public static TelefonosClientes? TelefonosClientes()
        {
            var entidad = new TelefonosClientes();
            entidad.Telefono = "Prueba";

            return entidad;
        }

        public static Hoteles? Hoteles(TelefonosHoteles telefonoshoteles)
        {
            var entidad = new Hoteles();
            entidad.Nombre = "Prueba";
            entidad.Direccion = "Prueba";
            entidad.Calificacion = 2332;
            entidad.IdTelefonoHotel = telefonoshoteles.Id;

            return entidad;
        }

        public static TelefonosHoteles? TelefonosHoteles()
        {
            var entidad = new TelefonosHoteles();
            entidad.Telefono = "Prueba";

            return entidad;
        }

        public static Reservas? Reservas(Clientes clientes)
        {
            var entidad = new Reservas();
            entidad.CheckIn = DateTime.Now;
            entidad.CheckOut = DateTime.Now;
            entidad.IdCliente = clientes.Id;

            return entidad;
        }

        public static ReservasHabitaciones? ReservasHabitaciones(Habitaciones habitaciones, Reservas reservas, Fases fases, Acompañantes acompañantes, Mascotas mascotas)
        {
            var entidad = new ReservasHabitaciones();
            entidad.Fecha = DateTime.Now;
            entidad.Codigo = 6465;
            entidad.IdHabitacion = habitaciones.Id;
            entidad.IdReserva = reservas.Id;
            entidad.IdMascota = mascotas.Id;
            entidad.IdAcompañante = acompañantes.Id;
            entidad.IdFase = fases.Id;

            return entidad;
        }

        public static Facturas? Facturas(EstadosFacturas estadosfacturas, ReservasHabitaciones reservashabitaciones)
        {
            var entidad = new Facturas();
            entidad.FechaPago = DateTime.Now;
            entidad.Codigo = 6465;
            entidad.Total = 50;
            entidad.SubTotal = 30;
            entidad.IdEstadoFactura = estadosfacturas.Id;
            entidad.IdReservaHabitacion = reservashabitaciones.Id;

            return entidad;
        }

        public static Mascotas? Mascotas(TiposMascotas tiposmascotas)
        {
            var entidad = new Mascotas();

            entidad.IdTipoMascota = tiposmascotas.Id;
            entidad.Nombre = "prueba";
            entidad.FechaNacimiento = DateTime.Now;
            return entidad;
        }

        public static TiposMascotas? TiposMascotas()
        {
            var entidad = new TiposMascotas();

            entidad.Nombre = "prueba";
            entidad.Raza = "Prueba";
            return entidad;
        }

        public static Habitaciones? Habitaciones(EstadosHabitaciones estadoshabitaciones, Hoteles hoteles, TiposHabitaciones tiposhabitaciones)
        {
            var entidad = new Habitaciones();

            entidad.IdEstadoHabitacion = estadoshabitaciones.Id;
            entidad.IdHotel = hoteles.Id;
            entidad.IdTipoHabitacion = tiposhabitaciones.Id;
            entidad.Numero = 100;
            entidad.Piso = 1;
            entidad.PrecioDia = 50;
            return entidad;
        }

        public static EstadosFacturas? EstadosFacturas()
        {
            var entidad = new EstadosFacturas();
            entidad.Descripcion = "Prueba";

            return entidad;
        }

        public static Fases? Fases()
        {
            var entidad = new Fases();
            entidad.Descripcion = "Prueba";

            return entidad;
        }

        public static EstadosHabitaciones? EstadosHabitaciones()
        {
            var entidad = new EstadosHabitaciones();

            entidad.Descripcion = "prueba";

            return entidad;
        }

        public static TiposHabitaciones? TiposHabitaciones()
        {
            var entidad = new TiposHabitaciones();

            entidad.Descripcion = "prueba";

            return entidad;
        }
    }
}
