﻿using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class MeasureColumn : ColumnBase
    {
        public MeasureColumn()
        {
            SchemaTypeName = SchemaTypeNames.MeasureColumnSpecType;
        }
        
        public MeasureColumn(NumberDataField dataField) : this()
        {            
            DataField = dataField;
        }

        /// <summary>
        /// Gets or sets the <see cref="DataField"/>.
        /// </summary>
        [JsonProperty("SummarizationField")]
        public NumberDataField DataField { get; set; }

        //todo: implement
        [JsonProperty]
        internal XmlaMeasure XmlaMeasure { get; set; }
    }
}