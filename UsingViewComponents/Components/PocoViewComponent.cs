﻿using System.Linq;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class PocoViewComponent
    {
        private readonly ICityRepository _cityRepository;

        public PocoViewComponent(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public string Invoke() => $"{_cityRepository.Cities.Count()} cities, {_cityRepository.Cities.Sum(c => c.Population)} people.";
    }
}
