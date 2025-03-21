using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Settings;

public class ChoroplethVisualizationSettingsFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var settings = new ChoroplethVisualizationSettings();

        // Assert
        Assert.Equal(SchemaTypeNames.ChoroplethMapVisualizationSettingsType, settings.SchemaTypeName);
        Assert.Equal(VisualizationTypes.CHOROPLETH_MAP, settings.VisualizationType);
        Assert.Equal(MapColorStyle.RangeOfValues, settings.ColorStyle);
        Assert.Equal(MapLabelVisibility.HasValues, settings.LabelVisibility);
        Assert.Equal(MapLabelStyle.LocationAbbreviation, settings.LabelStyle);
        Assert.Equal(MapDataLocale.English, settings.DataLocale);
    }

    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson =
            """
            {
              "_type" : "ChoroplethMapVisualizationSettingsType",
              "ColorizationStyle" : "SINGLE",
              "LabelVisibility" : "HAS VALUES",
              "LabelStyle" : "VALUES",
              "DataLocale" : "ja",
              "ShowLegends" : true,
              "ColorIndex" : -1,
              "VisualizationType" : "CHOROPLETH_MAP"
            }
            """;

        var settings = new ChoroplethVisualizationSettings()
        {
            ColorStyle = MapColorStyle.SingleColor,
            LabelVisibility = MapLabelVisibility.HasValues,
            LabelStyle = MapLabelStyle.Values,
            DataLocale = MapDataLocale.Japanese
        };

        // Act
        var actualJson = settings.ToJsonString();
        var expectedJObject = JObject.Parse(expectedJson);
        var actualJObject = JObject.Parse(actualJson);

        // Assert
        Assert.Equal(expectedJObject, actualJObject);
    }

}