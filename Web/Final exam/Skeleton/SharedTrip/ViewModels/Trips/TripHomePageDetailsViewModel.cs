﻿using System;

namespace SharedTrip.ViewModels.Trips
{
    public class TripHomePageDetailsViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }
    }
}
