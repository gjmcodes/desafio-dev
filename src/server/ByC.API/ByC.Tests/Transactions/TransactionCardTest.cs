using ByC.Domain.Transactions.Entities;
using ByC.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByC.Tests.Transactions
{
    [TestClass]
    public class TransactionCardTest
    {
        [TestMethod]
        public void NewTransaction_Card_IsValid()
        {
            // Arrange

            var cnab = CNABHelpers.validCNAB;

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid);
        }

        [TestMethod]
        public void NewTransaction_Card_IsPlainText()
        {
            // Arrange

            var cnab = CNABHelpers.GetCNAB(card: "475312343153");

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid == false);
            Assert.IsTrue(validation.Errors.Any(x => x.PropertyName.ToLower() == "card"));
        }

        [TestMethod]
        public void NewTransaction_Card_IsLessThan_12_Text()
        {
            // Arrange
            var cnab = CNABHelpers.GetCNAB(card: "4753****315 ");

            // Act
            var transaction = new TransactionRoot(cnab);
            var validation = transaction.IsValid();

            // Assert
            Assert.IsTrue(validation.IsValid == false);
            Assert.IsTrue(validation.Errors.Any(x => x.PropertyName.ToLower() == "card"));
        }
    }
}
