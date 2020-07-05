using DataAccess;
using AutoMapper;
using BisnessLogic.Models;
using DataAccess.Models;
using System;

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

        public double CalculateDiscriminant(InputDataBL datas)
        {            
            var discriminant = Math.Pow(datas.B, 2) - 4 * datas.A * datas.C;            
            return discriminant;
        }
        public GetDscrmnntRoots GetEquationSolution(InputDataBL datas)
        {
            
            var dscrmnntAndRoots = new GetDscrmnntRoots();
            double x1 = default;
            double x2 = default;
            var discriminant = Math.Pow(datas.B, 2) - 4 * datas.A * datas.C;
            dscrmnntAndRoots.Dscrmnnt = discriminant;
            if (discriminant>0)
            {               
                    x1 = (-datas.B + Math.Sqrt(discriminant)) / (2 * datas.A);
                    x2 = (-datas.B - Math.Sqrt(discriminant)) / (2 * datas.A);
            }
                else if (discriminant == 0)
                {
                    x1 = (-datas.B) / (2 * datas.A);
                    x2 = x1;
                }
                dscrmnntAndRoots.X1 = x1;
                dscrmnntAndRoots.X2 = x2;
            
            var equationBL = new EquationBL() { A = datas.A, B = datas.B, C = datas.C, Dscrmnnt = dscrmnntAndRoots.Dscrmnnt, X1 = dscrmnntAndRoots.X1, X2 = dscrmnntAndRoots.X2 };
            var equationDal = _mapper.Map<Equation>(equationBL);
            _dataRepozitory.CreateEquationWithRoots(equationDal);
            return dscrmnntAndRoots;
        }
       
        public GetRoots CalculateRoots(EquationBL equation)
        {
            //-b+sqD/2a  
            var roots = new GetRoots();
            double x1 = default;
            double x2 = default;

            if (equation.Dscrmnnt.HasValue)
            {
                double discriminant = (double)equation.Dscrmnnt;
                if (discriminant > 0)
                {
                    x1 = (-equation.B + Math.Sqrt(discriminant)) / (2 * equation.A);
                    x2 = (-equation.B - Math.Sqrt(discriminant)) / (2 * equation.A);
                }
                else if (discriminant == 0)
                {
                    x1 = (-equation.B) / (2 * equation.A);
                    x2 = x1;
                }
                roots.X1 = x1;
                roots.X2 = x2;
            }
            return roots;
        }
    }
}
