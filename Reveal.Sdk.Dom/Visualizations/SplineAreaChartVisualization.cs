﻿using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SplineAreaChartVisualization : CategoryVisualizationBase<SplineAreaChartVisualizationSettings>
    {
        internal SplineAreaChartVisualization() : this(null) { }

        public SplineAreaChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
    }
}
