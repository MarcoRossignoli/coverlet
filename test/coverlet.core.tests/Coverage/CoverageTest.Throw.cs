using System.Data.Common;
using System.IO;
using System.Threading.Tasks;

using Coverlet.Core.Samples.Tests;
using Tmds.Utils;
using Xunit;

namespace Coverlet.Core.Tests
{
    public partial class CoverageTests : ExternalProcessExecutionTest
    {
        [Fact]
        public void Throw_Issue890()
        {
            string path = Path.GetTempFileName();
            try
            {
                FunctionExecutor.RunInProcess(async (string[] pathSerialize) =>
                {
                    CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<Issue_890>(instance =>
                    {
                        instance.AddSkillRequired("value1");
                        try
                        {
                            instance.AddSkillRequired("value");
                        }
                        catch { }
                        return Task.CompletedTask;
                    }, persistPrepareResultToFile: pathSerialize[0]);

                    return 0;
                }, new string[] { path });

                CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);
                result.GenerateReport(show: true);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
