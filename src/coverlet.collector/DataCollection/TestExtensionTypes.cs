// Copyright (c) Toni Solarin-Sodara
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Coverlet.Collector.DataCollection;
using Coverlet.Collector.Utilities;
using Microsoft.VisualStudio.TestPlatform;

using System;

[assembly: TestExtensionTypes(typeof(CoverletCoverageCollector))]
[assembly: TestExtensionTypesV2(Constansts.ExtensionTypeName, CoverletConstants.DefaultUri, typeof(CoverletCoverageCollector), 1)]
[assembly: TestExtensionTypesV2(Constansts.ExtensionTypeName, CoverletConstants.DefaultUri, typeof(CoverletCoverageCollectorWithAttachmentProcessor), 2)]

namespace Microsoft.VisualStudio.TestPlatform;
internal class Constansts
{
    public const string ExtensionTypeName = "DataCollector";
}

[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
internal sealed class TestExtensionTypesAttribute : Attribute
{
    public TestExtensionTypesAttribute(params Type[] types)
    {
        Types = types;
    }

    public Type[] Types { get; }
}

[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
internal sealed class TestExtensionTypesV2Attribute : Attribute
{
    public string ExtensionType { get; }
    public string ExtensionIdentifier { get; }
    public Type ExtensionImplementation { get; }
    public int Version { get; }

    public TestExtensionTypesV2Attribute(string extensionType, string extensionIdentifier, Type extensionImplementation, int version)
    {
        ExtensionType = extensionType;
        ExtensionIdentifier = extensionIdentifier;
        ExtensionImplementation = extensionImplementation;
        Version = version;
    }
}
