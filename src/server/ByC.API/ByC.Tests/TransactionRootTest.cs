using ByC.Domain.Transactions.Entities;
using ByC.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByC.Tests
{
    [TestClass]
    public class TransactionRootTest
    {
        static Random random = new Random();

        [TestMethod]
        public void NewTransaction_CNAB_Length_IsValid()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB();

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();
            // Assert
            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void NewTransaction_CNAB_Length_IsInvalid()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB();
            cnab = cnab.Substring(0, cnab.Length - random.Next(0, 30));

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();
            // Assert
            Assert.IsTrue(validation.IsValid == false);
        }
    }
}
