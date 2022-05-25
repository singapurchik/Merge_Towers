using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MT.Core
{
    public class PlaceFinder
    {
        private readonly List<OnBoardPlace> _places;
        private readonly List<Transform> _emptyPlaces = new List<Transform>();

        public PlaceFinder(List<OnBoardPlace> places)
        {
            _places = places;
        }

        public bool HasEmptyPlace()
        {
            _emptyPlaces.Clear();
            
            foreach (var place in _places.Where(place => place.IsEmpty))
                _emptyPlaces.Add(place.transform);
            
            return _emptyPlaces.Count > 0;
        }

        public Transform GetEmptyPlace()
        {
            var randomPlace = _emptyPlaces[Random.Range(0, _emptyPlaces.Count)];
            return randomPlace;
        }
    }
}
