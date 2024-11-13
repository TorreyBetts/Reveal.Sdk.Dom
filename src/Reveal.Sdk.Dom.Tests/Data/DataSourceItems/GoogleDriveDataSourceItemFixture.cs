﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSourceItems
{
    public class GoogleDriveDataSourceItemFixture
    {
        [Fact]
        public void GoogleDriveDataSourceItem_IsDataSourceItem_WhenConstructed()
        {
            // Arrange
            var dataSource = new GoogleDriveDataSource();

            // Act
            var dataSourceItem = new GoogleDriveDataSourceItem("Test title", dataSource);

            // Assert
            Assert.True(dataSourceItem is DataSourceItem);
        }

        [Fact]
        public void Constructor_SetsTitleAndDatasource_AsProvided()
        {
            // Arrange
            var dataSource = new GoogleDriveDataSource();
            var title = "Test title";

            // Act
            var dataSourceItem = new GoogleDriveDataSourceItem(title, dataSource);

            // Assert
            Assert.Equal(title, dataSourceItem.Title);
            Assert.Equal(dataSource, dataSourceItem.DataSource);
        }

        [Fact]
        public void Identitifer_SaveValueAndProperties_WhenSet()
        {
            // Arrange
            var dataSource = new GoogleDriveDataSource();
            var dataSourceItem = new GoogleDriveDataSourceItem("Test", dataSource);
            var identifier = "IdentitiferTest";

            // Act
            dataSourceItem.Identitifer = identifier;

            // Assert
            Assert.Equal(identifier, dataSourceItem.Identitifer);
            Assert.Equal(identifier, dataSourceItem.Properties.GetValue<string>("Identitifer"));
        }
    }
}
