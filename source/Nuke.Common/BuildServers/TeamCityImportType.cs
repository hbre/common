// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.BuildServers
{
    [PublicAPI]
    public enum TeamCityImportType
    {
        /// <summary>JUnit Ant task XML reports</summary>
        junit,

        /// <summary>Maven Surefire XML reports</summary>
        surefire,

        /// <summary>NUnit-Console XML reports</summary>
        nunit,

        /// <summary>MSTest XML reports</summary>
        mstest,

        /// <summary>VSTest XML reports</summary>
        vstest,

        /// <summary>Google Test XML reports</summary>
        gtest,

        /// <summary>Checkstyle inspections XML reports</summary>
        checkstyle,

        /// <summary>FindBugs inspections XML reports</summary>
        findBugs,

        /// <summary>JSLint XML reports</summary>
        jslint,

        /// <summary>ReSharper inspectCode.exe XML reports</summary>
        ReSharperInspectCode,

        /// <summary>FxCop inspection XML reports</summary>
        FxCop,

        /// <summary>PMD inspections XML reports</summary>
        pmd,

        /// <summary>PMD Copy/Paste Detector (CPD) XML reports</summary>
        pmdCpd,

        /// <summary>ReSharper dupfinder.exe XML reports</summary>
        DotNetDupFinder,

        /// <summary>XML reports generated by dotcover, partcover, ncover or ncover3)</summary>
        dotNetCoverage
    }
}
