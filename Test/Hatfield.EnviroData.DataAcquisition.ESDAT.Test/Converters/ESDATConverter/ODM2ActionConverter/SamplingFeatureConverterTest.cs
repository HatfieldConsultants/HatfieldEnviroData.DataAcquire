﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ODMActionConverter
{
    [TestFixture]
    class SamplingFeatureConverterTest : ODM2ActionConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var samplingFeature = samplingFeatureConverter.Convert(new FeatureAction(), new ESDATModel());

            Assert.AreEqual(0, samplingFeature.SamplingFeatureID);
            Assert.AreEqual("Site", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
        }

        [Test]
        public void ChemistryTest()
        {
            var samplingFeature = samplingFeatureConverter.Convert(new FeatureAction(), new ChemistryFileData());

            Assert.AreEqual(0, samplingFeature.SamplingFeatureID);
            Assert.AreEqual("Specimen", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
        }
    }
}
