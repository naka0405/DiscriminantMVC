using DataAccess.Models;
using System;
using System.Linq;


namespace DataAccess
{
    public class DataRepozitory
    {
        public double CalculateDiscriminant(Equation equation)
        {
            //using (var ctx = new DContext())
            //{
                var discriminant = Math.Pow(equation.B, 2) - 4 * equation.A * equation.C;
                equation.Dscrmnnt = discriminant;
               // ctx.Equations.Add(equation);
                //ctx.SaveChanges();
                return discriminant;
            //}
                
        }

        public Equation GetEquation(int id)
        {
            using (var ctx = new DContext())
            {              
                var equation = ctx.Equations.FirstOrDefault(x => x.Id == id);
                ctx.SaveChanges();
                return equation;
            }
        }

        public void CalculateRoots(Equation equation, out double x1, out double x2 )
        {
            //-b+sqD/2a     
            using(var ctx=new DContext())
            {
                x1 = default;
                x2 = default;

                if (equation.Dscrmnnt.HasValue)
                {
                    double discriminant = (double)equation.Dscrmnnt;
                    if (discriminant > 0)
                    {
                        x1 = (-equation.B + Math.Sqrt(discriminant)) /( 2 * equation.A);
                        x2 = (-equation.B - Math.Sqrt(discriminant)) / (2 * equation.A);
                        equation.X1 = x1;
                        equation.X2 = x2;
                        //ctx.Entry(equation).State = System.Data.Entity.EntityState.Modified;
                        ctx.Equations.Add(equation);
                        ctx.SaveChanges();
                        //ctx.Equations.AddOrUpdate(equation);
                    }
                    else if (discriminant == 0)
                    {
                        x1 = (-equation.B) /( 2 * equation.A);
                        x2 = x1;
                        equation.X1 = x1;
                        equation.X2 = x2;
                        //ctx.Entry(equation).State = System.Data.Entity.EntityState.Modified;
                        ctx.Equations.Add(equation);
                        ctx.SaveChanges();
                        //ctx.Equations.AddOrUpdate(equation);
                    }
                }
                ctx.SaveChanges();
            }           
        }
    }
}
