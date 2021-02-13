﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;

using System.Text;

namespace BusinessLogic.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
