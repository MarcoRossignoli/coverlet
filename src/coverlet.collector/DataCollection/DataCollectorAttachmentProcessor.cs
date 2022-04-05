// Copyright (c) Toni Solarin-Sodara
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Coverlet.Collector.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Palmmedia.ReportGenerator.Core;

namespace Coverlet.Collector.DataCollection
{
    internal class DataCollectorAttachmentProcessor : IDataCollectorAttachmentProcessor
    {
        public bool SupportsIncrementalProcessing => true;

        public IEnumerable<Uri> GetExtensionUris()
        {
            yield return new Uri(CoverletConstants.DefaultUri);
        }

        public Task<ICollection<AttachmentSet>> ProcessAttachmentSetsAsync(XmlElement configurationElement, ICollection<AttachmentSet> attachments, IProgress<int> progressReporter, IMessageLogger logger, CancellationToken cancellationToken)
        {
            if (attachments.Count <= 1)
            {
                return Task.FromResult(attachments);
            }

            if (int.TryParse(Environment.GetEnvironmentVariable("COVERLET_DATACOLLECTOR_ATTACHMENTPROCESSOR_DEBUG"), out int result) && result == 1)
            {
                Debugger.Launch();
            }

            var reports = new List<string>();
            foreach (AttachmentSet attachmentSet in attachments)
            {
                foreach (UriDataAttachment attachment in attachmentSet.Attachments)
                {
                    reports.Add(attachment.Uri.LocalPath);
                }
            }

            string finalDir = System.IO.Path.GetDirectoryName(reports.First());
            new Generator().GenerateReport(new ReportConfiguration(
            reports.ToArray(),
            finalDir,
            Array.Empty<string>(),
            null,
            Array.Empty<string>(),
            Array.Empty<string>(),
            Array.Empty<string>(),
            Array.Empty<string>(),
            Array.Empty<string>(),
            null,
            null));

            string htmlReport = System.IO.Path.GetFullPath(System.IO.Path.Combine(finalDir, "index.htm"));
            var htmlAttachmentSet = new List<AttachmentSet>
            {
                new AttachmentSet(new Uri(CoverletConstants.DefaultUri), "Coverlet report")
            };
            htmlAttachmentSet[0].Attachments.Add(UriDataAttachment.CreateFrom(htmlReport, "Report generator html report"));

            return Task.FromResult((ICollection<AttachmentSet>)htmlAttachmentSet);
        }
    }
}
