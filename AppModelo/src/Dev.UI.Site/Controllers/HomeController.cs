using Dev.UI.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.UI.Site.Controllers
{
    public class HomeController : Controller
    {

        //Injeção de dependencia padrão
        //***
        private readonly IPedidoRepository _pedidoRepository;

        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        //***


        //Injeção de dependencia para aplicações legado, quando não se pode alterar o contrutor
        //**
        public IActionResult Index([FromServices] IPedidoRepository _pedidoRepository)
        {
            var pedido = _pedidoRepository.ObterPedido();

            return View();
        }
        //**

    }
}
