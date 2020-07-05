using DataAccess;
using AutoMapper;
using BisnessLogic.Models;
using DataAccess.Models;

namespace BisnessLogic
{
    public class EquationManager
    {
        private readonly DataRepozitory _dataRepozitory;
        private readonly Mapper _mapper;
        public EquationManager()
        {
            _dataRepozitory = new DataRepozitory();

            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Equation, EquationBL>();
                x.CreateMap<EquationBL, Equation>();
            });
            _mapper = new Mapper(config);
        }


        public double CalculateDiscriminant(EquationBL equation)
        {
            var discriminant = _dataRepozitory.CalculateDiscriminant(_mapper.Map<Equation>(equation));
            equation.Dscrmnnt = discriminant;
            return discriminant;
        }

        public void CalculateRoots(EquationBL equation, out double x1, out double x2)
        {
            _dataRepozitory.CalculateRoots(_mapper.Map<Equation>(equation),out x1, out x2);
            equation.X1 = x1;
            equation.X2 = x2;
        }
    }

}
