﻿using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class SummarizationDimensionField : SummarizationField
    {
        public List<string> DrillDownElements { get; set; } = new List<string>();
        public List<string> ExpandedItems { get; set; } = new List<string>();
        public string SortByField { get; set; }

        internal SummarizationDimensionField() : this(string.Empty) { }

        public SummarizationDimensionField(string fieldName) : base(fieldName) { }
    }
}