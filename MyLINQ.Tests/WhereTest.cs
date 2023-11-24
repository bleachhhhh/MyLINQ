using System;
using Xunit;
using MyLinq;
using System.Collections.Generic;

namespace MyLINQ.Tests
{
    public class WhereTest
    {
        [Fact]
        public void NotEmptyCollection_GetElementsMorehanFive_Success()
        {
            //Arrange.
            var array = new int[] { 1, 2, 3, 4, 5, 10, 20 };
            var expected = new[] { 10, 20 };
            //Act.
            var result = array.Where(o => o > 5);
            //Assert.
            Assert.Equal(expected, result);
        }
        [Fact]
        public void NullSource_Throws()
        {
            //Arrange.
            int[] array = null;
            var expected = new[] { 10, 20 };
            //Act+Assert.
            Assert.Throws<InvalidOperationException>(() => array.Where(o => o > 0));
        }
        [Fact]
        public void NotEmptyColletcion_TryToGetNotFitCollection_EmptyResult()
        {
            //Arrange.
            var array = new int[] { 1, 2, 3, 4, 5, 10, 20 };
            //Act.
            var result = array.Where(o => o < 0);
            //Assert.
            Assert.Empty(result);
        }
        [Fact]
        public void ColectionWithTupels_GetSpecificOne_Success()
        {
            var array = new List<(int Grade, double Salary)>
            {
                (Grade:5,Salary:1200 ),
                (Grade:10, Salary:2400)
            };
            var result = array.Where(o => o.Grade == 10);

            Assert.Single(result);
        }
        [Fact]
        public void NotEmptyCollection_GetFirstElement_Success()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 10, 20 };
            Assert.NotNull(array.First());
        }
        [Fact]
        public void EmptyCollection_GetFirst_Throws()
        {
            var array = Array.Empty<int>();
            Assert.Throws<InvalidOperationException>(()=>array.First());
        }
        [Fact]
        public void EmptyCollection_GetFirstOrDefault_ReturnDefault()
        {
            var array = Array.Empty<int>();
            var result = array.FirstOrDefault();
            Assert.Equal(0, result);
        }
        [Fact]
        public void NotEmptyCollection_GetFirstOrDefault_ReturnFirst()
        {
            var array = new int[] { 1, 2, 3};
            var result = array.FirstOrDefault();
            Assert.Equal(1, result);
        }
        [Fact]
        public void NotEmptyCollection_GetFirstOrDefaultWithCriterion_Succes()
        {
            var array = new int[] { 1, 2, 3 };

            var result = array.FirstOrDefault(array=>array==3);

            Assert.Equal(3, result);
        }
        [Fact]
        public void EmptyCollection_GetFirstWithCriterion_Throws()
        {
            var array = Array.Empty<int>();

            

            Assert.Throws<InvalidOperationException>(() => array.First(array => array == 3));
        }
        [Fact]
        public void NotEmptyCollection_GetFirstOrDefaultWithCriterionNotElement_ReturnDefault()
        {
            var array = new int[] { 1, 2, 3 };

            var result = array.FirstOrDefault(array => array == 33);

            Assert.Equal(0, result);
        }
        [Fact]
        public void AnyTest()
        {
            var arr = new int[] {  };
            Assert.False(arr.Any());
        }
        [Fact]
        public void AnyWithCriterionTest()
        {
            var arr = new int[] {1 };
            Assert.False(arr.Any(x=>x>2));
        }
        //метод Any, без критерия или с ним , добавить в таблицу ссылку на акк в гите
    }
}
