using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests
    {

        [TestMethod]
        public void Encode_ABC_to_BCD_with_key_1()
        {
            const string str = "ABC";
            const string final_str = "BCD";
            const int key = 1;

            var actual_result = MailSender.lib.Service.TextEncoder.Encode(str, key);
            Assert.AreEqual(final_str, actual_result);
        }

        [TestMethod]
        public void Decode_BCD_to_ABC_with_key_1()
        {
            const string str = "BCD";
            const string final_str = "ABC";
            const int key = 1;

            var actual_result = MailSender.lib.Service.TextEncoder.Decode(str, key);
            Assert.AreEqual(final_str, actual_result);
        }
    }
}
