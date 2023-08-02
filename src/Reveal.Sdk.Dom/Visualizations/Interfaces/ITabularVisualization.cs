﻿using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ITabularVisualization
    {
        List<VisualizationFilter> Filters { get; }
    }
}