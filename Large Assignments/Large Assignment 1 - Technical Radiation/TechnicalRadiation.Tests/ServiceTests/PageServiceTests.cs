using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FizzWare.NBuilder;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Repositories.Implementation;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.Tests
{
    /// <summary>
    /// Tests functionality of the page service
    /// </summary>
    [TestClass]
    public class PageServiceTests
    {
        private class ListVal { public int Val { get; set; } }
        private List<ListVal> _mockList;
        private int _pageSize = 2;
        private int _pageNumber = 2;

        /// <summary>
        /// Setup mock data for every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _mockList = new List<ListVal>();
            _mockList.Add(new ListVal{ Val = 1});
            _mockList.Add(new ListVal{ Val = 2});
            _mockList.Add(new ListVal{ Val = 3});
            _mockList.Add(new ListVal{ Val = 4});
            // _mockList is { 1, 2, 3, 4 } of list values
        }

        /// <summary>
        /// Tests if page service pages data correctly in terms of page size
        /// </summary>
        [TestMethod]
        public void PageData_ShouldYieldCorrectPageSize()
        {
            var list = PageService<ListVal>.PageData(_mockList, _pageNumber, _pageSize);
            Assert.AreEqual(list.Count(), _pageSize);
        } 

        /// <summary>
        /// Tests if page service pages data correctly in terms of page number
        /// </summary>
        [TestMethod]
        public void PageData_ShouldYieldCorrectPage()
        {
            var list = PageService<ListVal>.PageData(_mockList, _pageNumber, _pageSize);
            Assert.AreEqual(list.OrderByDescending(item => item.Val).First().Val, _mockList.Count());
        } 

        /// <summary>
        /// Tests if page service returns correct maximum number of pages
        /// </summary>
        [TestMethod]
        public void GetMaxPages_ShouldYieldCorrectMaximumNumberOfPages()
        {
            Assert.AreEqual(PageService<ListVal>.GetMaxPages(_mockList.Count(), _pageSize), 2);
        } 
    }
}