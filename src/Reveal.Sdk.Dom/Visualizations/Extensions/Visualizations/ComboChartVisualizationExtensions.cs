﻿using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class ComboChartVisualizationExtensions
    {
        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart1 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The name of the field to use as a Chart1 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart1Value(this ComboChartVisualization visualization, string field)
        {
            return visualization.SetChart1Value(new SummarizationValueField(field));
        }

        /// <summary>
        /// Adds a collection of <see cref="SummarizationValueField"/> as Chart1 Values.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="fields">The collection of fields names to use as Chart1 values.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart1Values(this ComboChartVisualization visualization, params string[] fields)
        {
            visualization.Chart1.Clear();
            foreach (var field in fields)
            {
                visualization.Chart1.Add(new MeasureColumnSpec()
                {
                    SummarizationField = new SummarizationValueField(field)
                });
            }
            return visualization;
        }

        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart1 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The <see cref="SummarizationValueField"/> to use as a Chart1 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart1Value(this ComboChartVisualization visualization, SummarizationValueField field)
        {
            visualization.Chart1.Clear();
            visualization.Chart1.Add(new MeasureColumnSpec() { SummarizationField = field });
            return visualization;
        }

        /// <summary>
        /// Adds a collection of <see cref="SummarizationValueField"/> as Chart1 Values.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="fields">The collection of <see cref="SummarizationValueField"/> to use as Chart1 values.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart1Values(this ComboChartVisualization visualization, params SummarizationValueField[] fields)
        {
            visualization.Chart1.Clear();
            foreach (var field in fields)
            {
                visualization.Chart1.Add(new MeasureColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }

        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart2 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The name of the field to use as a Chart2 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart2Value(this ComboChartVisualization visualization, string field)
        {
            return visualization.SetChart2Value(new SummarizationValueField(field));
        }

        /// <summary>
        /// Adds a collection of <see cref="SummarizationValueField"/> as Chart2 Values.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="fields">The collection of fields names to use as Chart2 values.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart2Values(this ComboChartVisualization visualization, params string[] fields)
        {
            visualization.Chart2.Clear();
            foreach (var field in fields)
            {
                visualization.Chart2.Add(new MeasureColumnSpec()
                {
                    SummarizationField = new SummarizationValueField(field)
                });
            }
            return visualization;
        }

        /// <summary>
        /// Adds a <see cref="SummarizationValueField"/> as a Chart2 Value.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="field">The <see cref="SummarizationValueField"/> to use as a Chart2 value.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart2Value(this ComboChartVisualization visualization, SummarizationValueField field)
        {
            visualization.Chart2.Clear();
            visualization.Chart2.Add(new MeasureColumnSpec() { SummarizationField = field });
            return visualization;
        }

        /// <summary>
        /// Adds a collection of <see cref="SummarizationValueField"/> as Chart2 Values.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="fields">The collection of <see cref="SummarizationValueField"/> to use as Chart2 values.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization SetChart2Values(this ComboChartVisualization visualization, params SummarizationValueField[] fields)
        {
            visualization.Chart2.Clear();
            foreach (var field in fields)
            {
                visualization.Chart2.Add(new MeasureColumnSpec()
                {
                    SummarizationField = field
                });
            }
            return visualization;
        }

        /// <summary>
        /// Configures the available settings for the <see cref="ComboChartVisualization"/>.
        /// </summary>
        /// <param name="visualization">The <see cref="ComboChartVisualization"/>.</param>
        /// <param name="settings">The <see cref="ComboChartVisualizationSettings"/> that will be applied to the <see cref="ComboChartVisualization"/>.</param>
        /// <returns>The <see cref="ComboChartVisualization"/>.</returns>
        public static ComboChartVisualization ConfigureSettings(this ComboChartVisualization visualization, Action<ComboChartVisualizationSettings> settings)
        {
            return visualization.ConfigureSettings<ComboChartVisualization, ComboChartVisualizationSettings>(settings);
        }
    }
}