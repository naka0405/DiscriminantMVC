using DataAccess.Models;


namespace DataAccess
{
    public class DataRepozitory
    {
        public void CreateEquationWithRoots(Equation equation)
        {
            using (var ctx = new DContext())
            {
                ctx.Equations.Add(equation);
                ctx.SaveChanges();
            }                
        }

        //public Equation GetEquation(int id)
        //{
        //    using (var ctx = new DContext())
        //    {              
        //        var equation = ctx.Equations.FirstOrDefault(x => x.Id == id);
        //        ctx.SaveChanges();
        //        return equation;
        //    }
        //}

       
    }
}
