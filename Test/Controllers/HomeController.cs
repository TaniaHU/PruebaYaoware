using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Drawing.Imaging;
using Test.BLL;
using Test.BOL.Modelos;
using Test.BOL.ModelosSistema;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unit;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _unit = new UnitOfWork();
            _logger = logger;
        }
        #region Ventas
        public IActionResult Index()
        {
            return View(_unit.ventas.GetListVentasPagadoVM());
        }
        public IActionResult Registros()
        {
            var num = _unit.ventas.GetListVentas().Count;
            return Json(num);
        }
        public IActionResult VentasList()
        {
            return View(_unit.ventas.GetListVentasVM());
        }
        public IActionResult AgregaVenta(int? id)
        {
            ViewData["Usuario"] = new SelectList(_unit.usuario.GetListUsuario(), "IdUsuario", "Nombre");
            ViewData["Producto"] = new SelectList(_unit.producto.GetListProducto(), "IdProducto", "Nombre");
            ViewData["Estatus"] = new SelectList(_unit.estatus.GetListEstatus(), "IdEstatusVenta", "Descripcion");
            Ventas ventas = _unit.ventas.GetVentasId(id.Value);
            return PartialView(ventas);
        }
        [HttpPost]
        public async Task<JsonResult> AgregaVenta(Ventas modeloVentas)
        {
            if (modeloVentas.IdVenta == 0)
            {
                Ventas ventas = new Ventas
                {
                    Cantidad = modeloVentas.Cantidad,
                    IdEstatusVenta = modeloVentas.IdEstatusVenta,
                    IdProducto = modeloVentas.IdProducto,
                    IdUsuario = modeloVentas.IdUsuario,
                    IdVenta = modeloVentas.IdVenta,
                    Total = modeloVentas.Total
                };
                _unit.ventas.Agrega(ventas);

                var SalidaOk = new
                {
                    isSuccess = true,
                    ventas,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
            else
            {
                Ventas ventas = new Ventas
                {
                    Cantidad = modeloVentas.Cantidad,
                    IdEstatusVenta = modeloVentas.IdEstatusVenta,
                    IdProducto = modeloVentas.IdProducto,
                    IdUsuario = modeloVentas.IdUsuario,
                    IdVenta = modeloVentas.IdVenta,
                    Total = modeloVentas.Total
                };
                _unit.ventas.Actualiza(ventas);
                var SalidaOk = new
                {
                    isSuccess = true,
                    ventas,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
        }

        [HttpPost]
        public async Task<JsonResult> BorrarVenta(int Id)
        {
            _unit.ventas.Borrar(Id);
            return Json(true);
        }
        #endregion
        #region Usuarios
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Verificar(string correo, string pass)
        {
            var us = _unit.usuario.InicioSesion(correo, pass);
            if (us != null)
            {
                var SalidaOk = new
                {
                    isSuccess = true,
                    us,
                    mensaje = ModelState
                };
                return Json(true);
                
            }
            else
            {
                var SalidaOk = new
                {
                    isSuccess = false,
                    us,
                    mensaje = ModelState
                };
                return Json(false);

            }
        }
        public IActionResult Usuario()
        {
            return View(_unit.usuario.GetListUsuario());
        }
        public IActionResult AgregaUsuario(int? id)
        {
            Usuario usuario = _unit.usuario.GetUsuarioId(id.Value);
            return PartialView(usuario);
        }
        [HttpPost]
        public async Task<JsonResult> AgregaUsuarioP(Usuario modeloUsuario)
        {
            if (modeloUsuario.IdUsuario == 0)
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = modeloUsuario.IdUsuario,
                    Correo = modeloUsuario.Correo,
                    Nombre = modeloUsuario.Nombre,
                    Password = modeloUsuario.Password
                };
                _unit.usuario.Agrega(usuario);

                var SalidaOk = new
                {
                    isSuccess = true,
                    usuario,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
            else
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = modeloUsuario.IdUsuario,
                    Correo = modeloUsuario.Correo,
                    Nombre = modeloUsuario.Nombre,
                    Password = modeloUsuario.Password
                };
                _unit.usuario.Actualiza(usuario);
                var SalidaOk = new
                {
                    isSuccess = true,
                    usuario,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
        }
        [HttpPost]
        public async Task<JsonResult> BorrarUsuario(int Id)
        {
            _unit.usuario.Borrar(Id);
            return Json(true);
        }
        #endregion
        #region Estatus
        public IActionResult Estatus()
        {
            return View(_unit.estatus.GetListEstatus());
        }
        public IActionResult AgregaEstatus(int? id)
        {
            Estatus estatus = _unit.estatus.GetPEstatusId(id.Value);
            return PartialView(estatus);
        }
        [HttpPost]
        public async Task<JsonResult> AgregaEstatus(Estatus modeloEstatus)
        {
            if (modeloEstatus.IdEstatusVenta == 0)
            {
                Estatus estatus = new Estatus
                {
                    IdEstatusVenta = modeloEstatus.IdEstatusVenta,
                 Descripcion = modeloEstatus.Descripcion
                };
                _unit.estatus.Agrega(estatus);

                var SalidaOk = new
                {
                    isSuccess = true,
                    estatus,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
            else
            {
                Estatus estatus = new Estatus
                {
                    IdEstatusVenta = modeloEstatus.IdEstatusVenta,
                    Descripcion = modeloEstatus.Descripcion
                };
                _unit.estatus.Actualiza(estatus);
                var SalidaOk = new
                {
                    isSuccess = true,
                    estatus,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
        }
        [HttpPost]
        public async Task<JsonResult> BorrarEstatus(int Id)
        {
            _unit.estatus.Borrar(Id);
            return Json(true);
        }
        #endregion
        #region Producto
        public IActionResult Producto()
        {
            return View(_unit.producto.GetListProducto());
        }
        public IActionResult AgregaProducto(int? id)
        {
            Producto producto = _unit.producto.GetProductoId(id.Value);
            return PartialView(producto);
        }
        [HttpPost]
        public async Task<JsonResult> AgregaProductop(Producto modeloProducto)
        {
            if (modeloProducto.IdProducto == 0)
            {
                Producto producto = new Producto
                {
                    IdProducto = modeloProducto.IdProducto,
                    Nombre = modeloProducto.Nombre,
                    Precio = modeloProducto.Precio,
                };
                _unit.producto.Agrega(producto);

                var SalidaOk = new
                {
                    isSuccess = true,
                    producto,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
            else
            {
                Producto producto = new Producto
                {
                    IdProducto = modeloProducto.IdProducto,
                    Nombre = modeloProducto.Nombre,
                    Precio = modeloProducto.Precio,
                };
                _unit.producto.Actualiza(producto);
                var SalidaOk = new
                {
                    isSuccess = true,
                    producto,
                    mensaje = ModelState
                };
                return Json(SalidaOk);
            }
        }
        [HttpPost]
        public async Task<JsonResult> BorrarProducto(int Id)
        {
            _unit.producto.Borrar(Id);
            return Json(true);
        }
        #endregion
    }
}