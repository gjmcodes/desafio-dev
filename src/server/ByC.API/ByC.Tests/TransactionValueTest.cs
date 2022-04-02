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
    public class TransactionValueTest
    {

        [TestMethod]
        public void NewTransaction_Value_IsValid()
        {
            // Arrange

            var cnab = CNABHelpers.validCNAB;

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(transaction.Value.HasValue);
            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void NewTransaction_Value_HasFloatingValue_IsValid()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB(value: "0000014299");

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(transaction.Value.HasValue && transaction.Value.Value == 142.99m);
            Assert.IsTrue(validation.IsValid);
        }
    }
}
