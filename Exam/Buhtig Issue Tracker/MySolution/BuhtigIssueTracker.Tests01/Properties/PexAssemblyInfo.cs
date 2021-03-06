using System;
using System.Text;
using System.Globalization;
using BuhtigIssueTracker.Data;
using Microsoft.Pex.Framework.Using;
// <copyright file="PexAssemblyInfo.cs">Copyright ©  2015</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("BuhtigIssueTracker")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("PowerCollections")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "PowerCollections")]
[assembly: PexUseType(typeof(BuhtigIssueTrackerData))]
[assembly: PexInstrumentType(typeof(TextInfo))]
[assembly: PexInstrumentType("mscorlib", "Microsoft.Win32.Win32Native")]
[assembly: PexInstrumentType(typeof(EncodingProvider))]
[assembly: PexInstrumentType("mscorlib", "System.Text.BaseCodePageEncoding")]
[assembly: PexInstrumentType("mscorlib", "System.Text.InternalEncoderBestFitFallback")]
[assembly: PexInstrumentType("mscorlib", "System.Text.InternalDecoderBestFitFallback")]
[assembly: PexInstrumentType("mscorlib", "System.Text.EncodingNLS")]
[assembly: PexUseType(typeof(GC), "System.CultureAwareComparer")]
[assembly: PexUseType(typeof(GC), "System.CultureAwareRandomizedComparer")]
[assembly: PexUseType(typeof(GC), "System.OrdinalComparer")]
[assembly: PexUseType(typeof(GC), "System.OrdinalRandomizedComparer")]
[assembly: PexUseType(typeof(GC), "System.Resources.FastResourceComparer")]
[assembly: PexUseType(typeof(GC), "System.Collections.Generic.RandomizedStringEqualityComparer")]

