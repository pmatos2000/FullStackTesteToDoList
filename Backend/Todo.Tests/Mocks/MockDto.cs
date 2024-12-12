using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Services.Dto;

namespace Todo.Tests.Mocks
{
    public static class MockDto
    {
        public static CategoryDto CategoryOne = new CategoryDto
        {
            Id = Constants.CATEGORY_ID_UM,
            Name = Constants.CATEGORY_NAME_ONE
        };
    }
}
