﻿using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Core.Serialization.Converters
{
    internal class VisualizationConverter : CustomJsonConverter<Visualization>
    {
        public override Visualization ReadJson(JsonReader reader, Type objectType, Visualization existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var visualizationSettings = jObject["VisualizationSettings"];
            var visualizationType = visualizationSettings["_type"].Value<string>();
            Type vizType = visualizationType switch
            {
                SchemaTypeNames.ChartVisualizationSettingsType => GetChartVsualizationType(visualizationSettings),
                SchemaTypeNames.GridVisualizationSettingsType => typeof(GridVisualization),
                SchemaTypeNames.IndicatorVisualizationSettingsType => typeof(KpiTimeVisualization),
                SchemaTypeNames.IndicatorTargetVisualizationSettingsType => typeof(KpiTargetVisualization),
                SchemaTypeNames.PivotVisualizationSettingsType => typeof(PivotVisualization),
                SchemaTypeNames.SparklineVisualizationSettingsType => typeof(SparklineVisualization),
                SchemaTypeNames.GaugeVisualizationSettingsType => GetGaugeVisualizationType(jObject),
                SchemaTypeNames.TextBoxVisualizationSettingsType => typeof(TextBoxVisualization),
                SchemaTypeNames.SingleRowVisualizationSettingsType => typeof(TextViewVisualization),                
                _ => throw new JsonException($"Visualization not supported: {visualizationType}")
            };

            var item = Activator.CreateInstance(vizType, true);
            serializer.Populate(jObject.CreateReader(), item);
            return item as Visualization;
        }

        private static Type GetGaugeVisualizationType(JToken jToken)
        {
            var vds = jToken.SelectToken("VisualizationDataSpec._type").Value<string>();
            Type type = vds switch
            {
                "SingleGaugeVisualizationDataSpecType" => typeof(CircularGaugeVisualization),
                "LinearGaugeVisualizationDataSpecType" => typeof(LinearGaugeVisualization),
                _ => throw new JsonException($"Chart type not supported: {vds}")
            };

            return type;
        }

        Type GetChartVsualizationType(JToken jToken)
        {
            var chartType = jToken["ChartType"].Value<string>();
            Type type = chartType switch
            {
                "Bar" => typeof(BarChartVisualization),
                "Pie" => typeof(PieChartVisualization),
                "Line" => typeof(LineChartVisualization),
                "Column" => typeof(ColumnChartVisualization),
                "Funnel" => typeof(FunnelChartVisualization),
                "SplineArea" => typeof(SplineAreaChartVisualization),
                "StackedColumn" => typeof(StackedColumnChartVisualization),
                "Doughnut" => typeof(DoughnutChartVisualization),
                _ => throw new JsonException($"Chart type not supported: {chartType}")
            };

            return type;
        }
    }
}
