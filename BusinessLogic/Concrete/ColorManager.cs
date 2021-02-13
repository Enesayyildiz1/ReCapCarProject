using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult("Renkler başarıyla listelendi.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Renk veritabanında başarıyla silindi.");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), "Renkler başarıyla listelendi");
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color> (_colorDal.Get(x => x.Id == id),"Id ile belirtilen ürün başarıyla listelendi");
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult("Değişiklikler başarıyla kaydedildi");
        }
    }
}
