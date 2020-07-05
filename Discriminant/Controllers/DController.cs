using BisnessLogic.Models;
using BisnessLogic;
using System.Web.Mvc;
using AutoMapper;
using Discriminant.Models;

namespace Discriminant.Controllers
{
    public class DController : Controller
    {
        private readonly EquationManager _equationManager;
        private readonly Mapper _mapper;
        public DController()
        {
            _equationManager = new EquationManager();
            var config = new MapperConfiguration(x =>
              {
                  x.CreateMap<EquationBL, EquationViewModel>();
                  x.CreateMap<EquationViewModel, EquationBL>();
              });
            _mapper = new Mapper(config);
        }

        // GET: D
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(EquationViewModel eq)
        {
           var d= _equationManager.CalculateDiscriminant(_mapper.Map<EquationBL>(eq));
           eq.Dscrmnnt = d;
            _equationManager.CalculateRoots(_mapper.Map<EquationBL>(eq),out double x1, out double x2);
            eq.X1 = x1;
            eq.X2 = x2;
            return View("GetDscrmnntRoots", eq);
        }

      

       
    }
}