﻿using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Data;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class DataDefinitionBase : SchemaType, IDataDefinition
    {
        [JsonProperty]
        public DataSourceItem DataSourceItem { get; internal set; }

        /// <inheritdoc/>
        [JsonProperty("Expiration")]
        public int CacheExpiration { get; set; } = 1440;

        /// <summary>
        /// This is exposed via the Visualization.FilterBindings property
        /// </summary>
        [JsonProperty]
        internal DataSpecBindings Bindings { get; set; } = new DataSpecBindings();
    }
}
