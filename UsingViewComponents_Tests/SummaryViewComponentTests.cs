using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System.Collections.Generic;
using UsingViewComponents.Components;
using UsingViewComponents.Models;
using Xunit;

namespace UsingViewComponents_Tests
{
    public class SummaryViewComponentTests
    {
        [Fact(DisplayName = "CitySummary => Invoke returns a CityViewModel")]
        public void TestCitySummary()
        {
            // Arrange
            var _mockCityRepository = new Mock<ICityRepository>();
            _mockCityRepository.SetupGet(cr => cr.Cities).Returns(new List<City>
            {
                new City {Population = 100},
                new City {Population = 20000},
                new City {Population = 1000000},
                new City {Population = 500000}
            });

            var citySummary = new CitySummary(_mockCityRepository.Object);

            // Act
            var viewViewComponentResult = citySummary.Invoke(false) as ViewViewComponentResult;

            // Assert
            Assert.IsType<CityViewModel>(viewViewComponentResult.ViewData.Model);
            Assert.Equal(4, ((CityViewModel)viewViewComponentResult.ViewData.Model).Cities);
            Assert.Equal(1520100, ((CityViewModel)viewViewComponentResult.ViewData.Model).Population);
        }
    }
}
