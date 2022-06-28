﻿using Newtonsoft.Json;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class ComboChartVisualization : Visualization<ComboChartVisualizationSettings>
    {
        internal ComboChartVisualization() : this(null) { }
        public ComboChartVisualization(DataSourceItem dataSourceItem) : base(dataSourceItem) { }
        public ComboChartVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem) { }


        //todo: implement

        [JsonProperty(Order = 7)]
        CompositeChartVisualizationDataSpec VisualizationDataSpec { get; set; } = new CompositeChartVisualizationDataSpec();
    }
}