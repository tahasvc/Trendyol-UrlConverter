using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrendyolCase.Core.ApiModels;
using TrendyolCase.Core.Entities;
using TrendyolCase.Core.Interfaces.Repositories;
using TrendyolCase.Infrastructure.Constants;
using TrendyolCase.Infrastructure.Services;

namespace TrendyolCase.UnitTest.Services
{
    [TestClass]
    public class ConverterServiceDeepLinkToWebUrlUnitTest
    {
        private static ConverterService converterService;

        /// <summary>
        /// Mock the repository because we don't want it to access the database.
        /// </summary>
        private static Mock<IConverterRepository> converterRepositoryMock;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            converterRepositoryMock = new Mock<IConverterRepository>();
            converterService = new ConverterService(converterRepositoryMock.Object);

            converterRepositoryMock.Setup(_ => _.AddAsync(It.IsAny<ConvertedLink>()));
        }

        [TestMethod]
        public void ProductPage_With_CampaignId_And_MerchantId_AreEqual()
        {
            var expected = ConverterConstants.Web.Url + "/brand/name-p-1925865?boutiqueId=439892&merchantId=105064";

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "Product&ContentId=1925865&CampaignId=439892&MerchantId=105064")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductPage_Only_Product_AreEqual()
        {
            var expected = ConverterConstants.Web.Url + "/brand/name-p-1925865";

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "Product&ContentId=1925865")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductPage_With_ContentId_and_CampaignId_AreEqual()
        {
            var expected = ConverterConstants.Web.Url + "/brand/name-p-1925865?boutiqueId=439892";

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "Product&ContentId=1925865&CampaignId=439892")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductPage_With_ContentId_and_MerchantId_AreEqual()
        {
            var expected = ConverterConstants.Web.Url + "/brand/name-p-1925865?merchantId=105064";

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "Product&ContentId=1925865&MerchantId=105064")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchPage_Query_1_AreEqual()
        {
            var expected = ConverterConstants.Web.Url + "/sr?q=elbise";

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "Search&Query=elbise")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchPage_Query_2_AreEqual()
        {
            var expected = ConverterConstants.Web.Url + "/sr?q=%C3%BCt%C3%BC";

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "Search&Query=%C3%BCt%C3%BC")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherPage_1_AreEqual()
        {
            var expected = ConverterConstants.Web.Url;

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "/Favorites")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherPage_2_AreEqual()
        {
            var expected = ConverterConstants.Web.Url;

            var actual = converterService.ConvertToWebLink(CreateConvertedLinkDto(ConverterConstants.Deep.Base + "/Orders")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        private ConvertedLinkDto CreateConvertedLinkDto(String link)
        {
            return new ConvertedLinkDto() { Link = link };
        }
    }
}
