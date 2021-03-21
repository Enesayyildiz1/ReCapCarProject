using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapCarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapCarDbContext db =new ReCapCarDbContext())
            {
                if (filter == null)
                {
                    var result = from p in db.Cars
                                 join b in db.Brands
                                 on p.BrandId equals b.Id
                                 join c in db.Colors
                                 on p.ColorId equals c.Id

                                 select new CarDetailDto
                                 { Id = p.Id, Name = p.Name, ColorId = p.ColorId, BrandId = p.BrandId, BrandName = b.Name, ColorName = c.Name, ModelYear = p.ModelYear, DailyPrice = p.DailyPrice, Description = p.Descriptions };
                    return result.ToList();
                }
                else
                {
                    {
                        var result = from p in db.Cars
                                     join b in db.Brands
                                     on p.BrandId equals b.Id
                                     join c in db.Colors
                                     on p.ColorId equals c.Id

                                     select new CarDetailDto
                                     { Id = p.Id, Name = p.Name, ColorId = p.ColorId, BrandId = p.BrandId, BrandName = b.Name, ColorName = c.Name, ModelYear = p.ModelYear, DailyPrice = p.DailyPrice, Description = p.Descriptions };
                        return result.Where(filter).ToList();
                    }

                }

                           

            }
        }
    }
}
