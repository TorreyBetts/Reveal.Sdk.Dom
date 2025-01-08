using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class PieChartVisualizationSettingsBaseFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new TestPieChartVisualizationSettingsBase();

        // Assert
        Assert.True(settings.ShowLegend);
        Assert.Equal(default(LabelDisplayMode), settings.SliceLabelDisplay);
        Assert.Null(settings.StartColorIndex);
        Assert.Equal(3.0, settings.OthersSliceThreshold);
        Assert.Equal("CHART", settings.VisualizationType);
        Assert.Equal("ChartVisualizationSettingsType", settings.SchemaTypeName);
        Assert.Equal(default(RdashChartType), settings.ChartType);
    }

    [Theory]
    [InlineData(-1.0, 0.0)]
    [InlineData(0.0, 0.0)]
    [InlineData(1.5, 2.0)]
    [InlineData(3.3, 3.0)]
    [InlineData(4.5, 4.0)]
    [InlineData(5.0, 4.0)]
    public void OthersSliceThreshold_CoercesValueToValidRange_WhenSet(double inputValue, double expectedValue)
    {
        // Arrange
        var settings = new TestPieChartVisualizationSettingsBase();

        // Act
        settings.OthersSliceThreshold = inputValue;

        // Assert
        Assert.Equal(expectedValue, settings.OthersSliceThreshold);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChartVisualizationSettingsType",
              "ShowLegends" : true,
              "LabelDisplayMode" : "ValueAndPercentage",
              "BrushOffsetIndex" : 2,
              "OthersSliceThreshold" : 3.0,
              "ChartType" : "Column",
              "VisualizationType" : "CHART"
            }
            """;

        var settings = new TestPieChartVisualizationSettingsBase
        {
            ShowLegend = true,
            SliceLabelDisplay = LabelDisplayMode.ValueAndPercentage,
            StartColorIndex = 2,
            OthersSliceThreshold = 3.0
        };

        // Act
        var actualJson = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings
        {
            Converters = { new StringEnumConverter() }
        });

        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }

    private class TestPieChartVisualizationSettingsBase : PieChartVisualizationSettingsBase
    {
    }
}