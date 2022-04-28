using CoreServer.Models;
using System;
using System.Collections.Generic;

namespace CoreServer.DataStorage
{
    public static class DataManager
    {
        public static List<ChartModel> GetData()
        {
            var r = new Random();
            return new List<ChartModel> {
                new ChartModel{Data = new List<int>{ r.Next(1, 100)}, Label = "Clients Registered"},
                new ChartModel{Data = new List<int>{ r.Next(1, 100)}, Label = "Completed Policies"},
                new ChartModel{Data = new List<int>{ r.Next(1, 100)}, Label = "Callbacks"},
            };
        }
    }
}
