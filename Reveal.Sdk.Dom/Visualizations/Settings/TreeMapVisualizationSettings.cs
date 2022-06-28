﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
	//todo: clean up and move classes out
    public class TreeMapVisualizationSettings : VisualizationSettings
    {
		[JsonConverter(typeof(StringEnumConverter))]
		public DashboardTreeMapLayoutEnumType Layout { get; set; } = DashboardTreeMapLayoutEnumType.Squarified;
		public int? BrushOffsetIndex { get; set; } = -1;
		public bool ShowValues { get; set; } = true;
		public bool ShowLegend { get; set; } = true;

		[JsonConverter(typeof(StringEnumConverter))]
		public DashboardTreeMapColorType ColorAs { get; set; } = DashboardTreeMapColorType.SingleColor;

		[JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
		public TreeMapBound MinBound { get; set; } = new TreeMapBound() { Color = DashboardTreeMapBoundColorType.Red };

		[JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
		public TreeMapBound MaxBound { get; set; } = new TreeMapBound() { Color = DashboardTreeMapBoundColorType.Green };

		public string LabelColumnName { get; set; }
		public string ValueColumnName { get; set; }

        public TreeMapVisualizationSettings()
        {
			SchemaTypeName = SchemaTypeNames.TreeMapVisualizationSettingsType;
		}
	}

	public enum DashboardTreeMapLayoutEnumType
	{
		Squarified,
		SliceAndDice,
		Strip
	}

	public enum DashboardTreeMapColorType
	{
		SingleColor,
		Gradient
	}

	public class TreeMapBound
    {
		public DashboardTreeMapBoundColorType Color { get; set; } = DashboardTreeMapBoundColorType.Green;
		public double? Value { get; set; }
	}

	public enum DashboardTreeMapBoundColorType
	{
		Green,
		Red
	}
}