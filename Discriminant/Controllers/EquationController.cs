using BisnessLogic.Models;
using BisnessLogic;
using System.Web.Mvc;
using AutoMapper;
using Discriminant.Models;

namespace Discriminant.Controllers
{
    public class EquationController : Controller
    {
        private readonly EquationManager _equationManager;
        private readonly Mapper _mapper;
        public EquationController()
        {
            _equationManager = new EquationManager();
            var config = new MapperConfiguration(x =>
              {
                  x.CreateMap<InputDataBL, InputData>();
                  x.CreateMap<InputData, InputDataBL>();
                  x.CreateMap<EquationBL, EquationPostModel>();
              });
            _mapper = new Mapper(config);
        }

        // GET: D
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(InputData datas)
        {
            var datasBL = _mapper.Map<InputDataBL>(datas);

            //var discr = _equationManager.CalculateDiscriminant(datasBL);
            var equationBl = new EquationBL() { A = datasBL.A, B = datasBL.B, C = datasBL.C };            
            //var roots = _equationManager.CalculateRoots(equationBl);
            var dscrmnntAndRoots = _equationManager.GetEquationSolution(datasBL);
            equationBl.Dscrmnnt = dscrmnntAndRoots.Dscrmnnt;
            equationBl.X1 = dscrmnntAndRoots.X1;
            equationBl.X2 = dscrmnntAndRoots.X2;
            //equationBl.X1 = roots.X1;
            //equationBl.X2 = roots.X2;

            var equationPL = _mapper.Map<EquationPostModel>(equationBl); 
            return View("GetDscrmnntRoots", equationPL);
        } 
    }
}