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
    public class ConverterServiceWebUrlToDeepLinkUnitTest
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
        public void ProductPage_With_BoutiqueId_MerchantId_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + "Product&ContentId=1925865&CampaignId=439892&MerchantId=105064";

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductPage_Only_With_Product_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + "Product&ContentId=1925865";

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/casio/erkek-kol-saati-p-1925865")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductPage_With_BoutiqueId_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + "Product&ContentId=1925865&CampaignId=439892";

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/casio/erkek-kol-saati-p-1925865?boutiqueId=439892")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductPage_With_MerchantId_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + "Product&ContentId=1925865&MerchantId=105064";

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/casio/erkek-kol-saati-p-1925865?merchantId=105064")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchPage_With_Search_Product_1_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + "Search&Query=elbise";

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/sr?q=elbise")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchPage_With_Search_Product_2_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + "Search&Query=%C3%BCt%C3%BC";

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/sr?q=%C3%BCt%C3%BC")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherPage_1_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + ConverterConstants.Deep.Home;

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "/Hesabim/Favoriler")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OtherPage_2_AreEqual()
        {
            var expected = ConverterConstants.Deep.Base + ConverterConstants.Deep.Home;

            var actual = converterService.ConvertToDeepLink(CreateConvertedLinkDto(ConverterConstants.Web.Url + "Hesabim/#/Siparisleri")).Result.Link;

            Assert.AreEqual(expected, actual);
        }

        private ConvertedLinkDto CreateConvertedLinkDto(String link)
        {
            return new ConvertedLinkDto() { Link = link };
        }
    }
}
