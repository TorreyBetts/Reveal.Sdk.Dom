using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class RadialVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new RadialVisualizationSettings();

        // Assert
        Assert.Equal(RdashChartType.RadialLines, settings.ChartType);
        Assert.Equal(TrendlineType.None, settings.Trendline);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChartVisualizationSettingsType",
              "TrendlineType" : "LinearFit",
              "ShowLegends" : true,
              "BrushOffsetIndex" : null,
              "ChartType" : "RadialLines",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new RadialVisualizationSettings
        {
            Trendline = TrendlineType.LinearFit
        };

        // Act
        var actualJson = JsonConvert.SerializeObject(settings, Formatting.Indented);
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }
}