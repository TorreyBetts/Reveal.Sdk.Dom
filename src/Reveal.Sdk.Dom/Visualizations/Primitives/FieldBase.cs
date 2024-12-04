﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class FieldBase<TFilter> : IField, IFieldDataType
        where TFilter : IFilter
    {
        private string _fieldLabel;

        protected FieldBase(string fieldName)
        {
            FieldName = fieldName;
            FieldLabel = fieldName;
        }        

        /// <inheritdoc />
        public string FieldName { get; set; }

        /// <inheritdoc />
        public string FieldLabel 
        { 
            get => _fieldLabel;
            set
            {
                _fieldLabel = value;
                UserCaption = value;
            }
        }

        /// <summary>
        /// The UserCaption is used to display a custom label in the UI. 
        /// However, the FieldLabel is also used to display a custom label in the UI and is generated from the data provides if it exists.
        /// To simplify the API, we are using the FieldLabel as the primary label and hiding UserCaption from the public API
        /// </summary>
        [JsonProperty]
        internal string UserCaption { get; set; }

        [JsonProperty("FieldType")]
        [JsonConverter(typeof(StringEnumConverter))]
        DataType IFieldDataType.DataType { get; set; } = DataType.String;

        /// <inheritdoc />
        public bool IsCalculated { get; set; }

        /// <inheritdoc />
        public string Expression { get; set; }

        /// <summary>
        /// Gets or sets the data filter to apply to the field.
        /// </summary>
        [JsonProperty("Filter")]
        public TFilter DataFilter { get; set; }

        //certain connectors like SalesForce use this - this is generated by Reveal and not currently meant for external use
        [JsonProperty]
        internal Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        [JsonConverter(typeof(StringEnumConverter))]
        public SortingType Sorting { get; set; } = SortingType.None;

        /// <inheritdoc />
        public string TableAlias { get; set; } //used when joining data from multiple sources
    }
}
