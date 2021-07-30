﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWebApp.Components
{
    interface IErrorComponent
    {
        void ShowError(string title, string message);
    }
}
