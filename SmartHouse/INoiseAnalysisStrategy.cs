﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
   public interface INoiseAnalysisStrategy
    {
        void Analyze(string sensorName, int value, SmartHouseSystem system);
    }
}
