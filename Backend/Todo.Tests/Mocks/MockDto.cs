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

        public static CategoryDto CategoryTwo = new CategoryDto
        {
            Id = Constants.CATEGORY_ID_TWO,
            Name = Constants.CATEGORY_NAME_TWO
        };

        public static IEnumerable<CategoryDto> ListCategoryOne { get; } = [CategoryOne, CategoryTwo];
    }
}
