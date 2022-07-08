﻿using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;

namespace Sandbox.Helpers
{
    internal class DataSourceFactory
    {
        internal static DataSourceItem GetMarketingDataSourceItem()
        {
            var excelDataSourceItem = new RestBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .SetTitle("Excel Data Source")
                .SetSubtitle("Marketing Sheet")
                .UseExcel("Marketing")
                .SetFields(GetMarketingDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetHealthcareDataSourceItem()
        {
            var excelDataSourceItem = new RestBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .SetTitle("Excel Data Source")
                .SetSubtitle("Healthcare Sheet")
                .UseExcel("Healthcare")
                .SetFields(GetHealthcareDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetManufacturingDataSourceItem()
        {
            var excelDataSourceItem = new RestBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .SetTitle("Excel Data Source")
                .SetSubtitle("Manufacturing Sheet")
                .UseExcel("Manufacturing")
                .SetFields(GetManufacturingDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static DataSourceItem GetSalesDataSourceItem()
        {
            var excelDataSourceItem = new RestBuilder("http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx")
                .SetTitle("Excel Data Source")
                .SetSubtitle("Sales Sheet")
                .UseExcel("Sales")
                .SetFields(GetSalesDataSourceFields())
                .Build();

            return excelDataSourceItem;
        }

        internal static List<Field> GetHealthcareDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new DateField("Date"),
                new NumberField("Number of Inpatients"),
                new NumberField("Number of Outpatients"),
                new NumberField("Treatment Costs "),
                new NumberField("ER Wait Time"),
                new TextField("Divison"),
                new TextField("Satisfaction"),
                new NumberField("Length of Stay "),
                new NumberField("Charges per MD"),
                new NumberField("Current Paitents")
            };
            return fields;
        }

        internal static List<Field> GetManufacturingDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new DateField("Date"),
                new NumberField("Units Lost"),
                new NumberField("Overall Plant Productivity "),
                new NumberField("Operators Available "),
                new TextField("Operators by Function"),
                new NumberField("Units Produced"),
                new TextField("Product"),
                new NumberField("Efficiency"),
                new TextField("Line"),
                new NumberField("Orders In"),
                new NumberField("Orders Shipped "),
                new NumberField("Cost of Labor "),
                new NumberField("Revenue")
            };

            return fields;
        }

        internal static List<Field> GetMarketingDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new DateField("Date"),
                new NumberField("Spend"),
                new NumberField("Budget"),
                new NumberField("CTR"),
                new NumberField("Avg. CPC"),
                new NumberField("Traffic"),
                new NumberField("Paid Traffic"),
                new NumberField("Other Traffic"),
                new NumberField("Conversions"),
                new TextField("Territory"),
                new TextField("CampaignID"),
                new NumberField("New Seats"),
                new NumberField("Paid %"),
                new NumberField("Organic %")
            };
            return fields;
        }

        internal static List<Field> GetSalesDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new TextField("Territory"),
                new DateField("Date"),
                new NumberField("Quota"),
                new NumberField("Leads"),
                new NumberField("Hot Leads"),
                new NumberField("New Seats"),
                new NumberField("New Sales"),
                new NumberField("Renewal Seats"),
                new NumberField("Renewal Sales "),
                new TextField("Employee"),
                new NumberField("Pipepline"),
                new NumberField("Forecasted"),
                new NumberField("Revenue"),
                new NumberField("Total Opportunites"),
                new TextField("Product")
            };
            return fields;
        }

        internal static List<Field> GetSalesByCategoryFields()
        {
            List<Field> fields = new List<Field>
            {
                new NumberField("CategoryID"),
                new TextField("CategoryName"),
                new TextField("ProductName"),
                new NumberField("ProductSales"),
            };
            return fields;
        }

        internal static List<Field> GetCsvDataSourceFields()
        {
            List<Field> fields = new List<Field>
            {
                new TextField("the_geom"),
                new NumberField("School_ID"),
                new TextField("School_Nm"),
                new TextField("Sch_Addr"),
                new TextField("Grade_Cat"),
                new TextField("Grades"),
                new TextField("Sch_Type"),
                new NumberField("X"),
                new NumberField("Y"),
            };
            return fields;
        }
    }
}