using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Banco1
{
   public class Cliente
    {
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Codigo;
        public decimal? Balance;//Sera un dato Null

        
    }

    //Creamos los pedidos y las respuestas de los servicios dentro de un enum
    public enum PedirServicios
    {
        Depositar, Retirar, Consultar, Tranferencia, Actualizar
    }
    public enum RespuestaServicios
    {
        Confirmacion, DatosPersonales
    }
    public enum CanalRealizado
    {
        Caja, IBanking
    }

    //Crearemos unas clases genericas para poder heredarlo con otras clases
    public class Request
    {
        public PedirServicios pedir { get; set; }
        public decimal Monto;
        public DateTime Fecha;
        public string Banco;
        public CanalRealizado Canal { get; set; }
    }

    public class Response
    {
        public RespuestaServicios pedir { get; set; }
    }

    #region Pedidos
    //Request Consultar Cuenta
    public class Consultar : Request
    {
        public Consultar()
        {
            pedir = (PedirServicios)2;
        }
        public Cliente Cuenta;
    }

   //Hacemos el request de transferencia
    public class Transferencia : Request
    {
        public Transferencia()
        {
            pedir = (PedirServicios)3;
        }
        public Cliente CuentaOrigen;
        public Cliente CuentaDestino;
        
    }
    
    //Request Retiro
    public class Retiro : Request
    {
        public Retiro()
        {
            pedir = (PedirServicios)1;
        }
        public Cliente Cuenta;
    }

    //Request Deposito
    public class Deposito : Request
    {
        public Deposito(Cliente Cuenta)
        {
            pedir = (PedirServicios)0;
            this.Cuenta = Cuenta;
        }
        public Deposito()
        {
            pedir = (PedirServicios)0;
            Cuenta = new Cliente();
        }
        public Cliente Cuenta;
    }

    //Request Cambiar Estado Cuenta
    public class CambiarEstadoCuenta : Request
    {
        public CambiarEstadoCuenta()
        {
            pedir = (PedirServicios)4;
        }
        public Cliente StatusCuenta;
        public Cliente Cuenta;

    }

    //Request Datos Personales de un Cliente
    public class DatosPersonalesCliente : Request
    {
        public DatosPersonalesCliente()
        {
            pedir = (PedirServicios)2;
        }
        public Cliente Datos;
    }
    
    //Request Movimiento de Cliente
    public class MovimientosClientes : Request
    {
        public MovimientosClientes()
        {
            pedir = (PedirServicios)2;
        }
        public Cliente Cedula;
    }

    //Request Cambiar Estado de Cliente
    public class CambiarEstadoCliente : Request
    {
        public CambiarEstadoCliente()
        {
            pedir = (PedirServicios)4;
        }
        public Cliente StatusCliente;
    }

    //Request Listar todas las cuentas de los Clientes
    public class ListasDeCuentas : Request
    {
        public ListasDeCuentas()
        {
            pedir = (PedirServicios)2;
        }
        public Cliente Cedula;
        public Cliente Cuenta;
    }

    #endregion Pedidos


    #region Respuesta
    //La respuesta de los servicios que se pidan, se le devolvera un string si se hizo el proceso con exito.
    //Este Response lo que hace que cada request que se haga se le devolvera un mensaje de confirmacion
    //en dado caso se guardara el error con el try/Catch que se hara.
    public class Confirmacion : Response
    {
        public Confirmacion()
        {
            pedir = (RespuestaServicios)0;
        }
        public Confirmacion(string mensaje, bool success)
        {
            pedir = (RespuestaServicios)0;
            mensajeConfirmacion = mensaje;
            this.success = success;
        } 
        public string mensajeConfirmacion { get; set; }
        public bool success { get; set; }
    }

    //Response para los datos personales
    public class DatosPersonales : Response
    {
        public DatosPersonales()
        {
            pedir = (RespuestaServicios)1;
        }
        public Cliente Datos;
    }

    #endregion Respuesta
}
