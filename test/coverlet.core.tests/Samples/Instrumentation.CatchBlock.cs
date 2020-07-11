// Remember to use full name because adding new using directives change line numbers

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Coverlet.Core.Samples.Tests
{
    public class CatchBlock
    {
        public int Parse(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> ParseAsync(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                await Task.Delay(0);

                throw;
            }
        }

        public void Test()
        {
            Parse(nameof(Test).Length.ToString());
        }

        public void Test_Catch()
        {
            try
            {
                Parse(nameof(Test));
            }
            catch { }
        }

        public async Task TestAsync()
        {
            await ParseAsync(nameof(Test).Length.ToString());
        }

        public async Task TestAsync_Catch()
        {
            try
            {
                await ParseAsync(nameof(Test));
            }
            catch { }
        }

        public int Parse(string str, bool condition)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                if (condition)
                {
                    throw;
                }
                else
                {
                    throw new System.Exception();
                }
            }
        }

        public async Task<int> ParseAsync(string str, bool condition)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                await Task.Delay(0);

                if (condition)
                {
                    throw;
                }
                else
                {
                    throw new System.Exception();
                }
            }
        }

        public void Test(bool condition)
        {
            Parse(nameof(Test).Length.ToString(), condition);
        }

        public void Test_Catch(bool condition)
        {
            try
            {
                Parse(nameof(Test), condition);
            }
            catch { }
        }

        public async Task TestAsync(bool condition)
        {
            await ParseAsync(nameof(Test).Length.ToString(), condition);
        }

        public async Task TestAsync_Catch(bool condition)
        {
            try
            {
                await ParseAsync(nameof(Test), condition);
            }
            catch { }
        }

        public int Parse_WithTypedCatch(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch (System.DivideByZeroException)
            {
                throw;
            }
            catch (System.FormatException)
            {
                throw;
            }
        }

        public async Task<int> ParseAsync_WithTypedCatch(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch (System.DivideByZeroException)
            {
                await Task.Delay(0);
                throw;
            }
            catch (System.FormatException)
            {
                await Task.Delay(0);
                throw;
            }
        }

        public void Test_WithTypedCatch()
        {
            Parse_WithTypedCatch(nameof(Test).Length.ToString());
        }

        public void Test_Catch_WithTypedCatch()
        {
            try
            {
                Parse_WithTypedCatch(nameof(Test));
            }
            catch { }
        }

        public async Task TestAsync_WithTypedCatch()
        {
            await ParseAsync_WithTypedCatch(nameof(Test).Length.ToString());
        }

        public async Task TestAsync_Catch_WithTypedCatch()
        {
            try
            {
                await ParseAsync_WithTypedCatch(nameof(Test));
            }
            catch { }
        }

        public int Parse_WithTypedCatch(string str, bool condition)
        {
            try
            {
                return int.Parse(str);
            }
            catch (System.DivideByZeroException)
            {
                throw;
            }
            catch (System.FormatException)
            {
                if (condition)
                {
                    throw;
                }
                else
                {
                    throw new System.Exception();
                }
            }
        }

        public async Task<int> ParseAsync_WithTypedCatch(string str, bool condition)
        {
            try
            {
                return int.Parse(str);
            }
            catch (System.DivideByZeroException)
            {
                await Task.Delay(0);
                throw;
            }
            catch (System.FormatException)
            {
                await Task.Delay(0);

                if (condition)
                {
                    throw;
                }
                else
                {
                    throw new System.Exception();
                }
            }
        }

        public void Test_WithTypedCatch(bool condition)
        {
            Parse_WithTypedCatch(nameof(Test).Length.ToString(), condition);
        }

        public void Test_Catch_WithTypedCatch(bool condition)
        {
            try
            {
                Parse_WithTypedCatch(nameof(Test), condition);
            }
            catch { }
        }

        public async Task TestAsync_WithTypedCatch(bool condition)
        {
            await ParseAsync_WithTypedCatch(nameof(Test).Length.ToString(), condition);
        }

        public async Task TestAsync_Catch_WithTypedCatch(bool condition)
        {
            try
            {
                await ParseAsync_WithTypedCatch(nameof(Test), condition);
            }
            catch { }
        }

        public int Parse_WithNestedCatch(string str, bool condition)
        {
            try
            {
                try
                {
                    return int.Parse(str);
                }
                catch
                {
                    if (condition)
                        throw new System.Exception();
                    else
                        throw;
                }
            }
            catch (System.FormatException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> ParseAsync_WithNestedCatch(string str, bool condition)
        {
            try
            {
                try
                {
                    return int.Parse(str);
                }
                catch
                {
                    await Task.Delay(0);
                    if (condition)
                        throw new System.Exception();
                    else
                        throw;
                }
            }
            catch (System.FormatException)
            {
                await Task.Delay(0);
                throw;
            }
            catch
            {
                await Task.Delay(0);
                throw;
            }
        }

        public void Test_WithNestedCatch(bool condition)
        {
            Parse_WithNestedCatch(nameof(Test).Length.ToString(), condition);
        }

        public void Test_Catch_WithNestedCatch(bool condition)
        {
            try
            {
                Parse_WithNestedCatch(nameof(Test), condition);
            }
            catch { }
        }

        public async Task TestAsync_WithNestedCatch(bool condition)
        {
            await ParseAsync_WithNestedCatch(nameof(Test).Length.ToString(), condition);
        }

        public async Task TestAsync_Catch_WithNestedCatch(bool condition)
        {
            try
            {
                await ParseAsync_WithNestedCatch(nameof(Test), condition);
            }
            catch { }
        }

        private Task<int> SaveChangesAsync(int val)
        {
            if (val == 10)
            {
                throw new Microsoft.EntityFrameworkCore.DbUpdateException("10", new System.Exception());
            }
            else if (val == 11)
            {
                throw new Microsoft.EntityFrameworkCore.DbUpdateException("11", new System.Exception());
            }
            else
                return Task.FromResult(100);
        }

        private System.Exception GetException(DbUpdateException originalException)
        {
            return originalException.Message == "10" ? originalException : null;
        }

        public async Task<int> Issue_823(int val)
        {
            try
            {
                return await SaveChangesAsync(val);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException originalException)
            {
                var exception = GetException(originalException);

                if (exception != null)
                {
                    throw exception;
                }

                throw;
            }
        }
    }
}
