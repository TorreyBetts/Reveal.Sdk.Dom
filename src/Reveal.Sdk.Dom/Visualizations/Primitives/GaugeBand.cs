﻿using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    //todo: should be we have a NumberBand/PercentageBand?
    public class GaugeBand : Band
    {
        public GaugeBand()
        {
            SchemaTypeName = SchemaTypeNames.GaugeBandType;
        }
    }
}